using System.Collections.Generic;
using System.Data;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    /// <summary>
    /// 插入一条记录到AccountAuth表的数据访问类
    /// </summary>
    public class AccountAuthDA
    {
        public static List<AccountAuthEntity> GetAccountAuthByAccountId(int accountId)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText = @"
SELECT 
	[PKID],
	[AccountId],
	[AuthId],
	[DepartmentID]
FROM [dbo].[TAccountAuth] WITH(NOLOCK)
where AccountId=@AccountId
";
                dataOperator.SetParameter("@AccountId", accountId, SqlDbType.Int);
                return dataOperator.ExecuteEntityList<AccountAuthEntity>();
            }

        }

        public static List<int> GetAccountAuthDepartment(int accountId, int authId)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText = @"
SELECT 
	[DepartmentID]
FROM [dbo].[TAccountAuth] WITH(NOLOCK)
where AccountId=@AccountId and AuthId=@AuthId and DepartmentID>0
";
                dataOperator.SetParameter("@AccountId", accountId, SqlDbType.Int);
                dataOperator.SetParameter("@AuthId", authId, SqlDbType.Int);
                return dataOperator.ExecuteList<int>();
            }
        }
    }
}


