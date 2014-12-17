using System;
using System.Collections.Generic;
using System.Data;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class EmployeeSalaryHistoryDA
    {
        public static List<EmployeeSalaryHistoryEntity> GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(int employeeID,
                                                                                                 DateTime? dtFrom,
                                                                                                 DateTime? dtTo)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText = @"select * from TEmployeeSalaryHistory with(nolock) where EmployeeID=@EmployeeID ";
                dataOperator.SetParameter("@EmployeeID", employeeID, SqlDbType.Int);
                if (dtFrom != null)
                {
                    dtFrom = dtFrom.Value.AddMonths(-1);
                    dataOperator.CommandText += " and SalaryDateTime>=@DateTimeFrom";
                    dataOperator.SetParameter("@DateTimeFrom", new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, 1), SqlDbType.DateTime);
                }
                if (dtTo != null)
                {
                    dataOperator.CommandText += " and SalaryDateTime<@DateTimeTo";
                    var dateTimeTo = dtTo.Value;
                    dataOperator.SetParameter("@DateTimeTo", new DateTime(dateTimeTo.Year, dateTimeTo.Month, 1), SqlDbType.DateTime);
                }
                dataOperator.CommandText += " order by SalaryDateTime desc";
                return dataOperator.ExecuteEntityList<EmployeeSalaryHistoryEntity>();
            }
        }
    }
}