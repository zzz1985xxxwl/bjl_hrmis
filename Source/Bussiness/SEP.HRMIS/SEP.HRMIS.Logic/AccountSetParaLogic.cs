using System.Collections.Generic;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.Logic
{
    public class AccountSetParaLogic
    {
        public static List<AccountSetParaEntity> GetAllAccountSetParamEntity()
        {
            return AccountSetParaDA.GetAllAccountSetParamEntity();
        }
    }
}