using System.Collections.Generic;
using SEP.HRMIS.Bll.LeaveRequests.MailAndPhone;
using SEP.HRMIS.Bll.Requests;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.LeaveRequests
{
    /// <summary>
    /// ������ٵ�
    /// </summary>
    public class AddLeaveRequest : Transaction
    {
        private readonly IVacation _IVacationDal = new VacationDal();
        private readonly IAdjustRest _IAdjustRestDal = new AdjustRestDal();
        private readonly ILeaveRequestDal _DalLeaveRequest = new LeaveRequestDal();
        private readonly ILeaveRequestFlowDal _DalLeaveRequestFlow = new LeaveRequestFlowDal();
        private readonly ILeaveRequestType _DalLeaveRequestType = new LeaveRequestTypeDal();
        private readonly IEmployeeDiyProcessDal _DalEmployeeDiyProcess = new EmployeeDiyProcessDal();
        private readonly IOverWork  _OverWorkDal = new OverWorkDal();
        private readonly IOutApplication _DalOutApplication = new OutApplicationDal();
        private readonly IPlanDutyDal _DalPlanDutyDal = new PlanDutyDal();
        private static IEmployee _DalEmployee = new EmployeeDal();

        private LeaveRequest _LeaveRequest;
        private readonly bool _IfSubmit;

        /// <summary>
        /// ������ٵ�
        /// </summary>
        public AddLeaveRequest(LeaveRequest leaveRequest, bool ifSubmit)
        {
            _LeaveRequest = leaveRequest;
            _IfSubmit = ifSubmit;
        }

        /// <summary>
        /// ������ٵ�
        /// </summary>
        public AddLeaveRequest(LeaveRequest leaveRequest, bool ifSubmit, IVacation mockIVacation,
                               IAdjustRest mockIAdjustRest, ILeaveRequestDal mockILeaveRequestDal,
                               ILeaveRequestFlowDal mockILeaveRequestFlowDal,
                               IEmployeeDiyProcessDal mockIEmployeeDiyProcessDal,
                               IOverWork mockIOverWork, IOutApplication mockIOutApplication,
                               IPlanDutyDal mockIPlanDutyDal,
                               ILeaveRequestType mockILeaveRequestType, IEmployee mockIEmployee)
        {
            _LeaveRequest = leaveRequest;
            _IfSubmit = ifSubmit;
            _IVacationDal = mockIVacation;
            _IAdjustRestDal = mockIAdjustRest;
            _DalLeaveRequest = mockILeaveRequestDal;
            _DalLeaveRequestFlow = mockILeaveRequestFlowDal;
            _DalEmployeeDiyProcess = mockIEmployeeDiyProcessDal;
            _OverWorkDal = mockIOverWork;
            _DalOutApplication = mockIOutApplication;
            _DalPlanDutyDal = mockIPlanDutyDal;
            _DalLeaveRequestType = mockILeaveRequestType;
            _DalEmployee = mockIEmployee;
        }

        /// <summary>
        /// ��Ч���ж�
        /// </summary>
        protected override void Validation()
        {
            //�ж�ʱ���Ƿ��ص�
            new ValidateRequestItemRepeat(_OverWorkDal, _DalLeaveRequest, _DalOutApplication, _LeaveRequest, true).
                Excute();

            //�жϸ��˺��Ƿ����������
            _LeaveRequest.DiyProcess =
                _DalEmployeeDiyProcess.GetDiyProcessByProcessTypeAndAccountID(ProcessType.LeaveRequest,
                                                                              _LeaveRequest.Account.Id);
            if (_LeaveRequest.DiyProcess == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._No_LeaveRequest_DiyProcess);
            }

            //�ж�����������٣����ʱ���Ƿ񳬹�����ʣ���������
            if (_LeaveRequest.LeaveRequestType.LeaveRequestTypeID == (int) LeaveRequestTypeEnum.AnnualLeave)
            {
                if (!new GetLeaveRequest(_IVacationDal, _DalLeaveRequestType, _DalPlanDutyDal).
                         AdjudgeVacationDaysAvailable(_LeaveRequest))
                {
                    HrmisUtility.ThrowException(HrmisUtility._Over_Vacation);
                }
            }

            //�ж��������ǵ��ݣ����ʱ���Ƿ񳬹�����ʣ�����
            if (_LeaveRequest.LeaveRequestType.LeaveRequestTypeID == (int) LeaveRequestTypeEnum.AdjustRest)
            {
                if (!new GetAdjustRest(_IAdjustRestDal, _DalLeaveRequest, _DalLeaveRequestFlow).AdjudgeAdjustAvailable(_LeaveRequest))
                {
                    HrmisUtility.ThrowException(HrmisUtility._Over_AdjustRest);
                }
            }

            foreach (LeaveRequestItem item in _LeaveRequest.LeaveRequestItems)
            {
                if (item.CostTime == 0)
                {
                    HrmisUtility.ThrowException(HrmisUtility._LeaveRequestItem_CanNot_Zero);
                }
            }
            // �ж��Ƿ��������ڣ��������޷��������
            new JudgeProbation(_LeaveRequest.LeaveRequestItems, _LeaveRequest.Account.Id, _LeaveRequest.LeaveRequestType,
                               _DalEmployee).Excute();
        }

        /// <summary>
        /// ������ٵ�
        /// </summary>
        protected override void ExcuteSelf()
        {
            if (_IfSubmit)
            {
                foreach (LeaveRequestItem item in _LeaveRequest.LeaveRequestItems)
                {
                    item.Status = RequestStatus.Submit;
                }
                DiyStep currentStep = _LeaveRequest.DiyProcess.FindFirstStep();
                DiyStep nextStep = _LeaveRequest.DiyProcess.FindSecondStep();
                _LeaveRequest.PKID = _DalLeaveRequest.InsertLeaveRequest(_LeaveRequest, nextStep.DiyStepID);
                _LeaveRequest = _DalLeaveRequest.GetLeaveRequestByPKID(_LeaveRequest.PKID);
                foreach (LeaveRequestItem item in _LeaveRequest.LeaveRequestItems)
                {
                    _DalLeaveRequestFlow.InsertLeaveRequestFlow(PrepareLeaveRequestFlow(item));
                }
                new LeaveRequestMailAndPhoneDelegate().SubmitOperation(_LeaveRequest.PKID, _LeaveRequest.MailCC??new List<Account>(),
                                                                       currentStep.MailAccount, nextStep);
            }
            else
            {
                foreach (LeaveRequestItem item in _LeaveRequest.LeaveRequestItems)
                {
                    item.Status = RequestStatus.New;
                }
                DiyStep nextStep = _LeaveRequest.DiyProcess.FindFirstStep();
                _LeaveRequest.PKID = _DalLeaveRequest.InsertLeaveRequest(_LeaveRequest, nextStep.DiyStepID);
            }
        }

        /// <summary>
        /// ׼����������Ĳ�������
        /// </summary>
        /// <returns></returns>
        private LeaveRequestFlow PrepareLeaveRequestFlow(LeaveRequestItem item)
        {
            LeaveRequestFlow leaveRequestFlow = new LeaveRequestFlow();
            leaveRequestFlow.LeaveRequestStatus = item.Status;
            leaveRequestFlow.Account = _LeaveRequest.Account;
            leaveRequestFlow.LeaveRequestItem = item;
            leaveRequestFlow.OperationTime = _LeaveRequest.SubmitDate;
            leaveRequestFlow.Remark = _LeaveRequest.Reason;
            return leaveRequestFlow;
        }
    }
}