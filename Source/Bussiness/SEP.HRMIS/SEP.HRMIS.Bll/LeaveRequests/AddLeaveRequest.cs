using System.Collections.Generic;
using SEP.HRMIS.Bll.LeaveRequests.MailAndPhone;
using SEP.HRMIS.Bll.Requests;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.LeaveRequests
{
    /// <summary>
    /// 新增请假单
    /// </summary>
    public class AddLeaveRequest : Transaction
    {
        private readonly IVacation _IVacationDal = DalFactory.DataAccess.CreateVacation();
        private readonly IAdjustRest _IAdjustRestDal = DalFactory.DataAccess.CreateAdjustRest();
        private readonly ILeaveRequestDal _DalLeaveRequest = DalFactory.DataAccess.CreateLeaveRequest();
        private readonly ILeaveRequestFlowDal _DalLeaveRequestFlow = DalFactory.DataAccess.CreateLeaveRequestFlow();
        private readonly ILeaveRequestType _DalLeaveRequestType = DalFactory.DataAccess.CreateLeaveRequestType();
        private readonly IEmployeeDiyProcessDal _DalEmployeeDiyProcess = DalFactory.DataAccess.CreateEmployeeDiyProcessDal();
        private readonly IOverWork _DalOverWork = DalFactory.DataAccess.CreateOverWork();
        private readonly IOutApplication _DalOutApplication = DalFactory.DataAccess.CreateOutApplication();
        private readonly IPlanDutyDal _DalPlanDutyDal = DalFactory.DataAccess.CreatePlanDutyDal();
        private static IEmployee _DalEmployee = DalFactory.DataAccess.CreateEmployee();

        private LeaveRequest _LeaveRequest;
        private readonly bool _IfSubmit;

        /// <summary>
        /// 新增请假单
        /// </summary>
        public AddLeaveRequest(LeaveRequest leaveRequest, bool ifSubmit)
        {
            _LeaveRequest = leaveRequest;
            _IfSubmit = ifSubmit;
        }

        /// <summary>
        /// 新增请假单
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
            _DalOverWork = mockIOverWork;
            _DalOutApplication = mockIOutApplication;
            _DalPlanDutyDal = mockIPlanDutyDal;
            _DalLeaveRequestType = mockILeaveRequestType;
            _DalEmployee = mockIEmployee;
        }

        /// <summary>
        /// 有效性判断
        /// </summary>
        protected override void Validation()
        {
            //判断时间是否重叠
            new ValidateRequestItemRepeat(_DalOverWork, _DalLeaveRequest, _DalOutApplication, _LeaveRequest, true).
                Excute();

            //判断该账号是否有请假流程
            _LeaveRequest.DiyProcess =
                _DalEmployeeDiyProcess.GetDiyProcessByProcessTypeAndAccountID(ProcessType.LeaveRequest,
                                                                              _LeaveRequest.Account.Id);
            if (_LeaveRequest.DiyProcess == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._No_LeaveRequest_DiyProcess);
            }

            //判断如果请的是年假，请假时间是否超过他的剩余年假天数
            if (_LeaveRequest.LeaveRequestType.LeaveRequestTypeID == (int) LeaveRequestTypeEnum.AnnualLeave)
            {
                if (!new GetLeaveRequest(_IVacationDal, _DalLeaveRequestType, _DalPlanDutyDal).
                         AdjudgeVacationDaysAvailable(_LeaveRequest))
                {
                    HrmisUtility.ThrowException(HrmisUtility._Over_Vacation);
                }
            }

            //判断如果请的是调休，请假时间是否超过他的剩余调休
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

            new JudgeProbation(_LeaveRequest.LeaveRequestItems, _LeaveRequest.Account.Id, _LeaveRequest.LeaveRequestType,
                               _DalEmployee).Excute();
        }

        /// <summary>
        /// 新增请假单
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
        /// 准备流程所需的插入数据
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