using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// IVacationFacade µœ÷¿‡
    /// </summary>
    public class VacationFacade : IVacationFacade
    {
        public void AddVacation(Vacation vacation)
        {
            AddVacation AddVacation = new AddVacation(vacation);
            AddVacation.Excute();
        }

        public void UpdateVacation(Vacation vacation)
        {
            UpdateVacation UpdateVacation = new UpdateVacation(vacation);
            UpdateVacation.Excute();
        }

        public void DeleteVacation(int vacationID)
        {
            DeleteVacation DeleteVacation = new DeleteVacation(vacationID);
            DeleteVacation.Excute();
        }

        public Vacation GetVacationByVacationID(int vacationID)
        {
            GetVacation GetVacation = new GetVacation();
            return GetVacation.GetVacationByVacationID(vacationID);
        }

        public void EditVacation(List<Vacation> vacationList, Employee employee)
        {
            EditVacation EditVacation = new EditVacation(vacationList, employee);
            EditVacation.Excute();
        }

        public List<Vacation> GetVacationByAccountID(int accountID)
        {
            GetVacation GetVacation = new GetVacation();
            return GetVacation.GetVacationByAccountID(accountID);
        }

        public Vacation GetLastVacationByAccountID(int accountID)
        {
            GetVacation GetVacation = new GetVacation();
            return GetVacation.GetLastVacationByAccountID(accountID);
        }

        public List<Vacation> GetVacationByCondition(string employeeName, decimal vacationDayNumStart, decimal vacationDayNumEnd,
                                                     DateTime vacationEndDateStart, DateTime vacationEndDateEnd,
                                                    decimal SurplusDayNumStart, decimal surplusDayNumEnd, Account Operator, int employeeStatus)
        {
            GetVacation GetVacation = new GetVacation();
            return GetVacation.GetVacationByCondition(employeeName, vacationDayNumStart, vacationDayNumEnd,
                                               vacationEndDateStart, vacationEndDateEnd,
                                               SurplusDayNumStart, surplusDayNumEnd, Operator, employeeStatus);
        }

    }
}
