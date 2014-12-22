using System.Collections.Generic;
using SEP.HRMIS.Bll.LeaveRequests.MailAndPhone;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.LeaveRequests
{
    /// <summary>
    /// 快速通过
    /// </summary>
    public class FastApproveWholeLeaveRequest : Transaction
    { 
        private readonly int _LeaveRequestID;
        private readonly int _AccountID;
        private readonly string _Reason;
        private RequestStatus _RequestStatus;
        private LeaveRequest _LeaveRequest;

        private readonly IVacation _DalVacation = new VacationDal();
        private readonly IAdjustRest _IAdjustRestDal = new AdjustRestDal();
        private readonly IPlanDutyDal _DalPlanDutyDal = new PlanDutyDal();
        private readonly ILeaveRequestDal _DalLeaveRequest = new LeaveRequestDal();
        private readonly ILeaveRequestType _DalLeaveRequestType = new LeaveRequestTypeDal();
        private readonly ILeaveRequestFlowDal _DalLeaveRequestFlow = new LeaveRequestFlowDal();
        private readonly IEmployeeDiyProcessDal _DalEmployeeDiyProcess = new EmployeeDiyProcessDal();

        /// <summary>
        /// 取消整张请假单
        /// </summary>
        public FastApproveWholeLeaveRequest(int leaveRequestID, int accountID, string reason)
        {
            _AccountID = accountID;
            _LeaveRequestID = leaveRequestID;
            _Reason = reason;
        }

        /// <summary>
        /// 取消整张请假单
        /// </summary>
        public FastApproveWholeLeaveRequest(int leaveRequestID, int accountID, string reason,
            ILeaveRequestDal mockILeaveRequestDal, ILeaveRequestFlowDal mockILeaveRequestFlowDal,
            IEmployeeDiyProcessDal mockIEmployeeDiyProcessDal, IVacation mockIVacation,
            IAdjustRest mockIAdjustRest, IPlanDutyDal mockIPlanDutyDal, ILeaveRequestType mockILeaveRequestType)
        {
            _AccountID = accountID;
            _LeaveRequestID = leaveRequestID;
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
            //判断请假信息是否为空
            if (_LeaveRequest == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._LeaveRequest_Not_Exist);
            }
        }

        private string _ResultMessage;
        /// <summary>
        /// 操作结果
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
                //-1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;
                //6 批准取消假期;7 审核中;8 审核取消中
                switch (item.Status.Id)
                {
                    case 1:
                    case 7:
                        _RequestStatus = RequestStatus.ApprovePass;
                        break;
                    case 4:
                    case 8:
                        _RequestStatus = RequestStatus.ApproveCancelPass;
                        break;
                }

                try
                {
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

                ResultMessage = successCount + "个请假项审核成功，" + failCount + "个请假项审核失败"; ;
            }
            for (int i = 0; i < nsteps.Count; i++)
            {
                new LeaveRequestMailAndPhoneDelegate().ConfirmOperationMail(_LeaveRequest, account[i], _AccountID,
                                                                            csteps[i], nsteps[i]);
            }
        }
    }
}