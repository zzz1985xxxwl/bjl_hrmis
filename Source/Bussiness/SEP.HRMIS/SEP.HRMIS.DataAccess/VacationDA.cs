using System;
using System.Collections.Generic;
using System.Data;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class VacationDA
    {
        public static List<VacationEntity> GetVacationByCondition(string employeeName, decimal vacationDayNumStart,
                                                                  decimal vacationDayNumEnd,
                                                                  DateTime vacationEndDateStart,
                                                                  DateTime vacationEndDateEnd,
                                                                  decimal surplusDayNumStart, decimal surplusDayNumEnd,
                                                                  int employeeStatus, List<int> canOperateDepartment)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    string.Format(
                        @"
select a.* from TVacation as a with(nolock)
inner join TEmployee as c with(nolock) on a.AccountID=c.AccountID
inner join {0}.dbo.TAccount as b with(nolock) on a.AccountID=b.PKID
where a.EmployeeName like @EmployeeName and VacationEndDate>=@VacationEndDateStart and VacationEndDate<=@VacationEndDateEnd
",
                        SqlHelper.SEPDBName);

                dataOperator.SetParameter("@VacationEndDateStart", vacationEndDateStart, SqlDbType.DateTime);
                dataOperator.SetParameter("@VacationEndDateEnd", vacationEndDateEnd, SqlDbType.DateTime);
                dataOperator.SetParameter("@EmployeeName", "%" + employeeName + "%", SqlDbType.NVarChar, 50);
                if (vacationDayNumStart >= 0)
                {
                    dataOperator.CommandText += " and VacationDayNum>=@VacationDayNumStart";
                    dataOperator.SetParameter("@VacationDayNumStart", vacationDayNumStart, SqlDbType.Decimal);
                }
                if (vacationDayNumEnd >= 0)
                {
                    dataOperator.CommandText += " and VacationDayNum<=@VacationDayNumEnd";
                    dataOperator.SetParameter("@VacationDayNumEnd", vacationDayNumEnd, SqlDbType.Decimal);
                }
                if (surplusDayNumStart >= 0)
                {
                    dataOperator.CommandText += " and SurplusDayNum>=@SurplusDayNumStart";
                    dataOperator.SetParameter("@SurplusDayNumStart", surplusDayNumStart, SqlDbType.Decimal);
                }
                if (surplusDayNumEnd >= 0)
                {
                    dataOperator.CommandText += " and SurplusDayNum<=@SurplusDayNumEnd";
                    dataOperator.SetParameter("@SurplusDayNumEnd", surplusDayNumEnd, SqlDbType.Decimal);
                }
                if (canOperateDepartment != null && canOperateDepartment.Count > 0)
                {
                    dataOperator.CommandText += " and DepartmentId in (" + string.Join(",", canOperateDepartment) + ")";
                }
                //在职
                if (employeeStatus == 0)
                {
                    dataOperator.CommandText +=
                        " and ComeDate<=getdate() and (LeaveDate is null or LeaveDate > getdate())";
                }
                    //离职
                else if (employeeStatus == 1)
                {
                    dataOperator.CommandText += " and LeaveDate<getdate()";
                }
                return dataOperator.ExecuteEntityList<VacationEntity>();
            }
        }
    }
}