using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.LeaveRequests.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class MailAndPhoneUtility
    {
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequest"></param>
        /// <param name="nextStep"></param>
        /// <returns></returns>
        public Account GetMailToAccount(LeaveRequest leaveRequest, DiyStep nextStep)
        {
            int accountID =
                new GetLeaveRequest().ChangeOperatorToEmployee(leaveRequest, nextStep);
            Account account = _AccountBll.GetAccountById(accountID);
            return account;
        }
    }
}
