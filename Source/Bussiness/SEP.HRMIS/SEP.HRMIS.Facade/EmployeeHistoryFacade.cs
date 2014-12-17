using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// IEmployeeHistoryFacade µœ÷¿‡
    /// </summary>
    public class EmployeeHistoryFacade : IEmployeeHistoryFacade
    {
        public void AddEmployeeHistoryByDepartment(Department department, Account operatorAccount)
        {
            new AddEmployeeHistoryByDepartment(department, operatorAccount).Excute();
        }

        public List<EmployeeHistory> GetEmployeeHistoryBasicInfoByAccountID(int accountID)
        {
            return new GetEmployeeHistory().GetEmployeeHistoryBasicInfoByAccountID(accountID);
        }

        public List<EmployeeHistory> GetEmployeeHistoryByAccountID(int accountID)
        {
            return new GetEmployeeHistory().GetEmployeeHistoryByAccountID(accountID);
        }

        public EmployeeHistory GetEmployeeHistoryByEmployeeHistoryID(int employeeHistoryID)
        {
            return new GetEmployeeHistory().GetEmployeeHistoryByEmployeeHistoryID(employeeHistoryID);
        }

        public List<Employee> GetOnDutyEmployeeBasicInfoByDateTime(DateTime dt)
        {
            return new GetEmployeeHistory().GetOnDutyEmployeeBasicInfoByDateTime(dt);
        }

        public List<Employee> GetEmployeeOnDutyByDepartmentAndDateTime(int departmentID, DateTime dt, bool onlyBasicInfo,
                                                                       Account loginUser, int powersID,
                                                                       List<Employee> allEmployeeSource)
        {
            return new GetEmployeeHistory().GetEmployeeOnDutyByDepartmentAndDateTime(departmentID, dt, onlyBasicInfo,
                                                                                     loginUser, powersID,
                                                                                     allEmployeeSource);
        }
    }
}
