using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.LeaveRequests.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class LeaveRequestCancelPhone
    {
        private readonly ILeaveRequestDal _DalLeaveRequest = DalFactory.DataAccess.CreateLeaveRequest();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly LeaveRequest _LeaveRequest;
        private readonly LeaveRequestItem _LeaveRequestItem;
        private readonly DiyStep _NextStep;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="item"></param>
        /// <param name="nextStep"></param>
        public LeaveRequestCancelPhone(int leaveRequestID, LeaveRequestItem item, DiyStep nextStep)
        {
            _LeaveRequest = _DalLeaveRequest.GetLeaveRequestByPKID(leaveRequestID);
            _LeaveRequest.Account = _AccountBll.GetAccountById(_LeaveRequest.Account.Id);
            _LeaveRequestItem = item;
            _NextStep = nextStep;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SendPhone()
        {
            Account phoneToAccount = new MailAndPhoneUtility().GetMailToAccount(_LeaveRequest, _NextStep);
            string contant = string.Format("请审批{0}取消的请假申请，请假类型为{1}，从{2}到{3}，共{4}小时，理由为{5}",
                                           _LeaveRequest.Account.Name, _LeaveRequest.LeaveRequestType.Name,
                                           _LeaveRequestItem.FromDate, _LeaveRequestItem.ToDate, _LeaveRequestItem.CostTime,
                                           _LeaveRequest.Reason);
            ConfirmMessage confirmmessage = new ConfirmMessage();
            confirmmessage.SendCancelMessage(phoneToAccount, contant,
                                             new PhoneMessageType(PhoneMessageEnumType.LeaveRequest,
                                                                  _LeaveRequestItem.LeaveRequestItemID));
        }
    }
}
