using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class AuthDA
    {
        public static List<AuthEntity> GetAllAuth()
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText = @"
SELECT 
	[PKID],
	[AuthName],
	[AuthParentId],
	[NavigateUrl],
	[IfHasDepartment]
FROM [dbo].[TAuth] WITH(NOLOCK)
";

                return dataOperator.ExecuteEntityList<AuthEntity>();

            }

        }
    }
}
