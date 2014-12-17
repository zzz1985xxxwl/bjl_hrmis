using System;
using System.Data;
using Framework.Common.DataAccess;
using System.Collections.Generic;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.DataAccess
{
    public class ReimburseDA
    {
        public static void UpdateReimburseStatus(int id,ReimburseStatusEnum status)
        {
            using (var dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText = "Update TReimburse set ReimburseStatus=@ReimburseStatus where PKID=@PKID";
                dataOperator.SetParameter("@ReimburseStatus", (int)status, SqlDbType.Int);
                dataOperator.SetParameter("@PKID", id, SqlDbType.Int);
                dataOperator.ExecuteNonQuery();
            }
        }

        public static List<ReimburseEntity> GetReimburseByCondition(List<int> departmentId, ReimburseStatusEnum statusEnum, ReimburseStatusEnum? exceptStatusEnum, bool? isFillCustomer, int reimburseCategoriesEnumID,
                                                        decimal? totalcostfrom,
                                                       decimal? totalcostto, DateTime? applydateFrom,
                                                       DateTime? applydateTo, DateTime? billtimeFrom, DateTime? billtimeTo,
                                                        int companyID, int finishStatus)
        {
            using (var dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText = @"SELECT a.*,b.Name as ExchangeRateName,b.Symbol as ExchangeSymbol,b.Rate as ExchangeRate 
from TReimburse as a with(nolock)  left join TExchangeRate as b with(nolock)  on a.ExchangeRateID=b.PKID  WHERE   1=1  ";
                if (departmentId != null && departmentId.Count > 0)
                {
                    dataOperator.CommandText += string.Format(" and DepartmentID in ({0})", string.Join(",", departmentId));
                }
                if ((int)statusEnum != -1)
                {
                    dataOperator.CommandText += " and ReimburseStatus=@ReimburseStatus";
                    dataOperator.SetParameter("@ReimburseStatus", (int)statusEnum, SqlDbType.Int);
                }
                if (exceptStatusEnum != null)
                {
                    dataOperator.CommandText += " and ReimburseStatus<>@ExceptReimburseStatus";
                    dataOperator.SetParameter("@ExceptReimburseStatus", (int)exceptStatusEnum, SqlDbType.Int);
                }
                if (isFillCustomer != null)
                {
                    dataOperator.CommandText += " and a.PKID in (select ReimburseID from TReimburseItem with(nolock) where CustomerID" + (isFillCustomer.Value ? "<>" : "=") + "0)";
                }
                if (reimburseCategoriesEnumID != -1)
                {
                    dataOperator.CommandText += " and ReimburseCategoriesEnum=@ReimburseCategoriesEnum";
                    dataOperator.SetParameter("@ReimburseCategoriesEnum", reimburseCategoriesEnumID, SqlDbType.Int);
                }
                if (companyID != -1)
                {
                    dataOperator.CommandText += " and EmployeeId in (select AccountID from TEmployee where CompanyID=@CompanyID) ";
                    dataOperator.SetParameter("@CompanyID", companyID, SqlDbType.Int);
                }
                if (finishStatus != -1)
                {
                    if (finishStatus == 0)
                    {
                        dataOperator.CommandText += " and Reimbursestatus<>2";
                    }
                    if (finishStatus == 1)
                    {
                        dataOperator.CommandText += " and Reimbursestatus=2";
                    }
                }
                if (totalcostfrom != null)
                {
                    dataOperator.CommandText += " and TotalCost>=@TotalCostFrom";
                    dataOperator.SetParameter("@TotalCostFrom", totalcostfrom, SqlDbType.Decimal);
                }
                if (totalcostto != null)
                {
                    dataOperator.CommandText += " and TotalCost<=@TotalCostTo";
                    dataOperator.SetParameter("@TotalCostTo", totalcostto, SqlDbType.Decimal);
                }
                if (applydateFrom != null)
                {
                    dataOperator.CommandText += " and ApplyDate>=@ApplyDateFrom";
                    dataOperator.SetParameter("@ApplyDateFrom", applydateFrom.GetValueOrDefault().Date, SqlDbType.DateTime);
                }
                if (applydateTo != null)
                {
                    dataOperator.CommandText += " and ApplyDate<@ApplyDateTo";
                    dataOperator.SetParameter("@ApplyDateTo", applydateTo.GetValueOrDefault().AddDays(1).Date, SqlDbType.DateTime, 2);
                }
                if (billtimeFrom != null)
                {
                    dataOperator.CommandText += " and BillingTime>=@BillingTimeFrom";
                    dataOperator.SetParameter("@BillingTimeFrom", billtimeFrom.GetValueOrDefault().Date, SqlDbType.DateTime);
                }
                if (billtimeTo != null)
                {
                    dataOperator.CommandText += " and BillingTime<@BillingTimeTo";
                    dataOperator.SetParameter("@BillingTimeTo", billtimeTo.GetValueOrDefault().AddDays(1).Date, SqlDbType.DateTime);
                }
                dataOperator.CommandText += " order By ApplyDate desc ";
                return dataOperator.ExecuteEntityList<ReimburseEntity>();
            }
        }
    }
}
