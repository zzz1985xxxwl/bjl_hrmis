using System.Collections.Generic;
using System.Data;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class PositionDA
    {
        public static List<PositionEntity> GetPositionByCompanyID(int companyID)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.SEPConnectionString))
            {
                dataOperator.CommandText =
                    @"
select PKID,PositionName
from TPosition with(nolock) 
where PKID in (
select PositionId from TAccount where
PKID in (select AccountID from " +
                    SqlHelper.HrmisDBName + @".dbo.TEmployee where CompanyID=@CompanyID)
)
";
                dataOperator.SetParameter("@CompanyID", companyID, SqlDbType.Int);
                return dataOperator.ExecuteEntityList<PositionEntity>();
            }
        }
    }
}