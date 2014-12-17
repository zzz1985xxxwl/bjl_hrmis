using System.Data;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class CustomerInfoDA
    {
        public static CustomerInfoEntity GetCustomerInfoByCode(string code)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
SELECT 
	[PKID],
	[CompanyName]
FROM [dbo].[TCustomerInfo] WITH(NOLOCK)
WHERE
	[CompanyName] like @Code
";

                dataOperator.SetParameter("@Code", code+" %", SqlDbType.NVarChar, 200);

                return dataOperator.ExecuteEntity<CustomerInfoEntity>();
            }
        }
    }
}