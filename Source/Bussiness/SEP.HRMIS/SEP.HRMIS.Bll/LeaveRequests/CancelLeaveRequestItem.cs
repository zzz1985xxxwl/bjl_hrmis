using System;
using System.Transactions;
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
    /// 取消单个请假项
    /// </summary>
    public class CancelLeaveRequestItem : Transaction
    {
        private readonly int _LeaveRequestID;
        private readonly int _LeaveRequestItemID;
        private readonly int _OperatorID;
        private readonly RequestStatus _RequestStatus;
        private readonly string _Reason;
        private LeaveRequest _LeaveRequest;
        private LeaveRequestItem _LeaveRequestItem;

        private readonly ILeaveRequestDal _DalLeaveRequest = DalFactory.DataAccess.CreateLeaveRequest();
        private readonly ILeaveRequestFlowDal _DalLeaveRequestFlow = DalFactory.DataAccess.CreateLeaveRequestFlow();
        private readonly IEmployeeDiyProcessDal _DalEmployeeDiyProcess = DalFactory.DataAccess.CreateEmployeeDiyProcessDal();
        
        /// <summary>
        /// 取消请假单
        /// </summary>
        public CancelLeaveRequestItem(int leaveRequestID, int leaveRequestItemID, int operatorID, 
            RequestStatus requestStatus, string reason)
        {
            _LeaveRequestID = leaveRequestID;
            _LeaveRequestItemID = leaveRequestItemID;
            _RequestStatus = requestStatus;
            _Reason = reason;
            _OperatorID = operatorID;
        }

        /// <summary>
        /// 取消请假单
        /// </summary>
        public CancelLeaveRequestItem(int leaveRequestID, int leaveRequestItemID, int operatorID,
            RequestStatus requestStatus, string reason, ILeaveRequestDal mockILeaveRequestDal,
            ILeaveRequestFlowDal mockILeaveRequestFlowDal, IEmployeeDiyProcessDal mockIEmployeeDiyProcessDal)
        {
            _LeaveRequestID = leaveRequestID;
            _LeaveRequestItemID = leaveRequestItemID;
            _RequestStatus = requestStatus;
            _Reason = reason;
            _OperatorID = operatorID;

            _DalLeaveRequest = mockILeaveRequestDal;
            _DalLeaveRequestFlow = mockILeaveRequestFlowDal;
            _DalEmployeeDiyProcess = mockIEmployeeDiyProcessDal;
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

            //判断该账号是否有请假流程
            _LeaveRequest.DiyProcess =
                _DalEmployeeDiyProcess.GetDiyProcessByProcessTypeAndAccountID(ProcessType.LeaveRequest, _LeaveRequest.Account.Id);
            if (_LeaveRequest.DiyProcess == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._No_LeaveRequest_DiyProcess);
            }

            _LeaveRequestItem = _DalLeaveRequest.GetLeaveRequestItemByPKID(_LeaveRequestItemID);
            if (_LeaveRequestItem == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._LeaveRequest_Not_Exist);
            }
            //如果请假信息状态不是取消或提交状态，不能取消
            if (!RequestStatus.CanCancelStatus(_LeaveRequestItem.Status))
            {
                HrmisUtility.ThrowException(HrmisUtility._LeaveRequest_Partial_CanNot_BeCancled);
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
            try
            {
                DiyStep currentStep = _LeaveRequest.DiyProcess.FindCancelStep();
                DiyStep nextStep = _LeaveRequest.DiyProcess.FindCancelNextStep();
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DalLeaveRequest.UpdateLeaveRequestItemStatusByLeaveRequestItemID(_LeaveRequestItemID,
                                                                                      _RequestStatus, nextStep.DiyStepID);
                    _DalLeaveRequestFlow.InsertLeaveRequestFlow(PrepareLeaveRequestFlow(_LeaveRequestItemID));
                    ts.Complete();
                }
                new LeaveRequestMailAndPhoneDelegate().CancelOperation(_LeaveRequest.PKID, _LeaveRequestItem,
                                                                       currentStep.MailAccount, nextStep);
                new LeaveRequestMailAndPhoneDelegate().CancelMail(_LeaveRequest.PKID, currentStep.MailAccount, nextStep);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        /// <summary>
        /// 准备流程所需的插入数据
        /// </summary>
        /// <param name="leaveRequestItemID"></param>
        /// <returns></returns>
        private LeaveRequestFlow PrepareLeaveRequestFlow(int leaveRequestItemID)
        {
            LeaveRequestFlow leaveRequestFlow = new LeaveRequestFlow();
            leaveRequestFlow.LeaveRequestItem = new LeaveRequestItem(leaveRequestItemID);
            leaveRequestFlow.LeaveRequestStatus = _RequestStatus;
            leaveRequestFlow.Account = new Account(_OperatorID, "", "");
            leaveRequestFlow.OperationTime = DateTime.Now;
            leaveRequestFlow.Remark = _Reason;
            return leaveRequestFlow;
        }
    }
}
