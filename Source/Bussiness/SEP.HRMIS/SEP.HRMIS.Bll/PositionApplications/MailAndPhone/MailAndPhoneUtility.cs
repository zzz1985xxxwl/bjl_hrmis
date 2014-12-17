using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.PositionApp;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.PositionApplications.MailAndPhone
{
    public class MailAndPhoneUtility
    {
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionApplication"></param>
        /// <param name="nextStep"></param>
        /// <returns></returns>
        public Account GetMailToAccount(PositionApplication positionApplication, DiyStep nextStep)
        {
            int accountID =
                new GetPositionApplication().ChangeOperatorToEmployee(positionApplication, nextStep);
            Account account = _AccountBll.GetAccountById(accountID);
            return account;
        }
    }
}
