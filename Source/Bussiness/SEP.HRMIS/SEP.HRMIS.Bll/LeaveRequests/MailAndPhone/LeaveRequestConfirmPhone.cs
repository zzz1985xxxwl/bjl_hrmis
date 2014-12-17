using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
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
    public class LeaveRequestConfirmPhone
    {
        private readonly ILeaveRequestDal _DalLeaveRequest = DalFactory.DataAccess.CreateLeaveRequest();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly LeaveRequest _LeaveRequest;

        /// <summary>
        /// 
        /// </summary>
        public LeaveRequestConfirmPhone(int leaveRequestID)
        {
            _LeaveRequest = _DalLeaveRequest.GetLeaveRequestByPKID(leaveRequestID);
            _LeaveRequest.Account = _AccountBll.GetAccountById(_LeaveRequest.Account.Id);
        }

        /// <summary>
        /// 给下一步操作人发邮件
        /// </summary>
        public void SendPhoneToNextOperator(int nextOperator, LeaveRequestItem item, int nowAccount)
        {
            ConfirmMessage confirmmessage = new ConfirmMessage();
            confirmmessage.FinishPhoneMessageOperationByAssessorID(
                new PhoneMessageType(PhoneMessageEnumType.LeaveRequest,
                                     item.LeaveRequestItemID), nowAccount);
            Account phoneToAccount = _AccountBll.GetAccountById(nextOperator);
            confirmmessage.SendConfirmMessage(phoneToAccount,
                                              new PhoneMessageType(PhoneMessageEnumType.LeaveRequest,
                                                                   item.LeaveRequestItemID));
        }
    }
}
