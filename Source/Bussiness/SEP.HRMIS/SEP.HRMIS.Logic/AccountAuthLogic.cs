using System.Collections.Generic;
using Framework.Common;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.Logic
{
    public class AccountAuthLogic
    {
        public static List<AccountAuthEntity> GetAccountAuthByAccountId(int accountId)
        {
            var key = "GetAccountAuthByAccountId_" + accountId;
            var allAccountAuth = MemoryCacheUtils.Get(key) as List<AccountAuthEntity>;
            if (allAccountAuth == null)
            {
                allAccountAuth = AccountAuthDA.GetAccountAuthByAccountId(accountId);
                MemoryCacheUtils.Set(key, allAccountAuth);
            }
            return allAccountAuth;
        }
    }
}