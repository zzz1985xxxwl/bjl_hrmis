using System.Collections.Generic;
using SEP.HRMIS.Bll.LeaveRequests.MailAndPhone;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.LeaveRequests
{
    /// <summary>
    /// ���������ٵ�
    /// </summary>
    public class ApproveWholeLeaveRequest : Transaction
    {
        private readonly int _LeaveRequestID;
        private readonly int _AccountID;
        private readonly string _Reason;
        private RequestStatus _RequestStatus;
        private LeaveRequest _LeaveRequest;

        private readonly IVacation _DalVacation = DalFactory.DataAccess.CreateVacation();
        private readonly IAdjustRest _IAdjustRestDal = DalFactory.DataAccess.CreateAdjustRest();
        private readonly IPlanDutyDal _DalPlanDutyDal = DalFactory.DataAccess.CreatePlanDutyDal();
        private readonly ILeaveRequestDal _DalLeaveRequest = DalFactory.DataAccess.CreateLeaveRequest();
        private readonly ILeaveRequestType _DalLeaveRequestType = DalFactory.DataAccess.CreateLeaveRequestType();
        private readonly ILeaveRequestFlowDal _DalLeaveRequestFlow = DalFactory.DataAccess.CreateLeaveRequestFlow();
        private readonly IEmployeeDiyProcessDal _DalEmployeeDiyProcess = DalFactory.DataAccess.CreateEmployeeDiyProcessDal();

        /// <summary>
        /// ���������ٵ�
        /// </summary>
        public ApproveWholeLeaveRequest(int leaveRequestID, int accountID, RequestStatus requestStatus, string reason)
        {
            _AccountID = accountID;
            _LeaveRequestID = leaveRequestID;
            _RequestStatus = requestStatus;
            _Reason = reason;
        }

        /// <summary>
        /// ���������ٵ�
        /// </summary>
        public ApproveWholeLeaveRequest(int leaveRequestID, int accountID, RequestStatus requestStatus, string reason,
            ILeaveRequestDal mockILeaveRequestDal, ILeaveRequestFlowDal mockILeaveRequestFlowDal,
            IEmployeeDiyProcessDal mockIEmployeeDiyProcessDal, IVacation mockIVacation,
            IAdjustRest mockIAdjustRest, IPlanDutyDal mockIPlanDutyDal, ILeaveRequestType mockILeaveRequestType)
        {
            _AccountID = accountID;
            _LeaveRequestID = leaveRequestID;
            _RequestStatus = requestStatus;
            _Reason = reason;

            _DalLeaveRequest = mockILeaveRequestDal;
            _DalLeaveRequestFlow = mockILeaveRequestFlowDal;
            _DalEmployeeDiyProcess = mockIEmployeeDiyProcessDal;
            _DalVacation = mockIVacation;
            _IAdjustRestDal = mockIAdjustRest;
            _DalPlanDutyDal = mockIPlanDutyDal;
            _DalLeaveRequestType = mockILeaveRequestType;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Validation()
        {
            _LeaveRequest = _DalLeaveRequest.GetLeaveRequestByPKID(_LeaveRequestID);
            //�ж������Ϣ�Ƿ�Ϊ��
            if (_LeaveRequest == null)
            {
                ResultMessage = HrmisUtility._LeaveRequest_Not_Exist;
                HrmisUtility.ThrowException(HrmisUtility._LeaveRequest_Not_Exist);
            }
        }

        private string _ResultMessage;
        /// <summary>
        /// �������
        /// </summary>
        public string ResultMessage
        {
            get
            {
                return _ResultMessage;
            }
            set
            {
                _ResultMessage = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ExcuteSelf()
        {
            int failCount = 0;
            int successCount = 0;
            List<List<Account>> account = new List<List<Account>>();
            List<DiyStep> csteps = new List<DiyStep>();
            List<DiyStep> nsteps = new List<DiyStep>();
            foreach (LeaveRequestItem item in _LeaveRequest.LeaveRequestItems)
            {
                try
                {
                    ChangeRequestStatus(item);
                    ApproveLeaveRequestItem approveLeaveRequestItem =
                        new ApproveLeaveRequestItem(_LeaveRequestID, item.LeaveRequestItemID, _AccountID, _RequestStatus,
                                                    _Reason, _DalLeaveRequest, _DalLeaveRequestFlow,
                                                    _DalEmployeeDiyProcess, _DalVacation,
                                                    _IAdjustRestDal, _DalPlanDutyDal, _DalLeaveRequestType);
                    List<Account> mailaccountlist;
                    DiyStep cstep;
                    DiyStep nstep;
                    approveLeaveRequestItem.ConfirmItem(out mailaccountlist, out cstep, out nstep);
                    if (!DiyStep.Contains(nsteps, nstep))
                    {
                        account.Add(mailaccountlist);
                        csteps.Add(cstep);
                        nsteps.Add(nstep);
                    }
                    successCount++;
                }
                catch
                {
                    failCount++;
                }

                ResultMessage = successCount + "���������˳ɹ���" + failCount + "����������ʧ��"; ;
            }
            for (int i = 0; i < nsteps.Count; i++)
            {
                new LeaveRequestMailAndPhoneDelegate().ConfirmOperationMail(_LeaveRequest, account[i], _AccountID,
                                                                            csteps[i], nsteps[i]);
            }
        }

        private void ChangeRequestStatus(LeaveRequestItem item)
        {
            //-1 ȫ��;0 ����;1 �ύ;2 ��˲�ͨ��;3 ���ͨ��;4 ȡ�����;
            //5 �ܾ�ȡ������;6 ��׼ȡ������;7 �����;8 ȡ�������
            switch (item.Status.Id)
            {
                case 1:
                case 7:
                    if (_RequestStatus.Id == RequestStatus.ApproveCancelPass.Id)
                    {
                        _RequestStatus = RequestStatus.ApprovePass;
                    }
                    break;
                case 4:
                case 8:
                    if (_RequestStatus.Id == RequestStatus.ApprovePass.Id)
                    {
                        _RequestStatus = RequestStatus.ApproveCancelPass;
                    }
                    break;
            }
            
        }
    }
}