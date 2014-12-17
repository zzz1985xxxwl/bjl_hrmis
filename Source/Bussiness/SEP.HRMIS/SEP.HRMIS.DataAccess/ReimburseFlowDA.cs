using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Framework.Common.DataAccess;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.DataAccess
{
    public class ReimburseFlowDA
    {
        public static void Insert(ReimburseFlow entity,int reimburseID)
        {
            using (var dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText = @"
 INSERT INTO TReimburseFlow(
ReimburseID,
OperatorID,
ReimburseStatus,
OperationTime
)
    VALUES (
@ReimburseID,
@OperatorID,
@ReimburseStatus,
@OperationTime
)

";
                dataOperator.SetParameter("@ReimburseID",reimburseID, SqlDbType.Int);
                dataOperator.SetParameter("@OperatorID", entity.Operator.Account.Id, SqlDbType.Int);
                dataOperator.SetParameter("@ReimburseStatus",entity.ReimburseStatusEnum ,SqlDbType.Int);
                dataOperator.SetParameter("@OperationTime", entity.OperationTime, SqlDbType.DateTime);
                dataOperator.ExecuteNonQuery();
            }
        }
    }
}
