using System.Collections.Generic;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class AccountSetParaDA
    {
        public static List<AccountSetParaEntity> GetAllAccountSetParamEntity()
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText = @"
select PKID,AccountSetParaName from TAccountSetPara
";
                return dataOperator.ExecuteEntityList<AccountSetParaEntity>();
            }
        }
    }
}