using System.Collections.Generic;
using Framework.Common;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.Logic
{
    public class AuthLogic
    {
        public static List<AuthEntity> GetAllAuth()
        {
            var allAuth = MemoryCacheUtils.Get("GetAllAuth") as List<AuthEntity>;
            if (allAuth == null)
            {
                allAuth = AuthDA.GetAllAuth();
                MemoryCacheUtils.Set("GetAllAuth", allAuth);
            }
            return allAuth;
        }
    }
}