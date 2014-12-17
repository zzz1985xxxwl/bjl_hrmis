using System.Collections.Generic;
using SEP.HRMIS.Bll.AccountAuth;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// IAccountAuthFacadeµÄÊµÏÖ
    /// </summary>
    public class AccountAuthFacade : IAccountAuthFacade
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public List<Auth> GetAccountAllAuthList(int accountId, Account loginUser)
        {
            return new GetAuth().GetAccountAllAuthList(accountId, loginUser);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public List<Auth> GetAccountAllAuth(int accountId, Account loginUser)
        {
            return new GetAuth().GetAccountAllAuth(accountId, loginUser);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newAuths"></param>
        /// <param name="user"></param>
        /// <param name="loginUser"></param>
        public void SetAccountAuths(List<Auth> newAuths, Account user, Account loginUser)
        {
            new GetAuth().SetAccountAuths(newAuths, user, loginUser);
        }
    }
}
