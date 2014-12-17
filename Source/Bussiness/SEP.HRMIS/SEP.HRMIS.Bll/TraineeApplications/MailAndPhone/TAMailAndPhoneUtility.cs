using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.TraineeApplications.MailAndPhone
{
    ///<summary>
    ///</summary>
    public class TAMailAndPhoneUtility
    {
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="traineeApplication"></param>
        /// <returns></returns>
        /// <param name="diyStep"></param>
        public Account GetMailToAccount(TraineeApplication traineeApplication, DiyStep diyStep)
        {
            int accountID =
                new GetTraineeApplication().ChangeOperatorToEmployee(traineeApplication, diyStep);
            Account account = _AccountBll.GetAccountById(accountID);
            return account;
        }

    }
}
