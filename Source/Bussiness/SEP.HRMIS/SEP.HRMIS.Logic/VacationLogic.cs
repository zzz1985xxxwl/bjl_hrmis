using System;
using System.Collections.Generic;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Logic
{
    public class VacationLogic
    {
        public static List<VacationEntity> GetVacationByCondition(string employeeName, decimal vacationDayNumStart,
                                                                  decimal vacationDayNumEnd,
                                                                  DateTime vacationEndDateStart,
                                                                  DateTime vacationEndDateEnd,
                                                                  decimal surplusDayNumStart, decimal surplusDayNumEnd,
                                                                  Account Operator, int employeeStatus)
        {
            return VacationDA.GetVacationByCondition(employeeName, vacationDayNumStart,
                                                     vacationDayNumEnd,
                                                     vacationEndDateStart, vacationEndDateEnd,
                                                     surplusDayNumStart, surplusDayNumEnd
                                                     , employeeStatus,
                                                     AccountAuthDA.GetAccountAuthDepartment(Operator.Id,
                                                                                            HrmisPowers.A403));
        }
    }
}