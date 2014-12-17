using System.Collections.Generic;
using System.Data;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class ReimburseItemDA
    {
        public static List<ReimburseItemEntity> GetReimburseItemByReimburseID(List<int> reimburseID)
        {
            if (reimburseID == null || reimburseID.Count == 0)
            {
                return new List<ReimburseItemEntity>();
            }
            using (var dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                   @"select a.*,b.CompanyName as CustomerName,c.Name as ExchangeRateName,c.Rate as ExchangeRate from TReimburseItem as a with(nolock) 
left join TCustomerInfo as b with(nolock) on a.CustomerID=b.PKID
inner join TReimburse as r with(nolock) on a.ReimburseID=r.PKID
inner join TExchangeRate as c on r.ExchangeRateID=c.PKID WHERE ReimburseID in (";
                for (var i = 0; i < reimburseID.Count; i++)
                {
                    dataOperator.CommandText += "@ReimburseID" + i + ",";
                    dataOperator.SetParameter("@ReimburseID" + i, reimburseID[i], SqlDbType.Int);
                }
                dataOperator.CommandText = dataOperator.CommandText.TrimEnd(',') + ")";
                return dataOperator.ExecuteEntityList<ReimburseItemEntity>();
            }
        }
    }
}
