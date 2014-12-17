using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 员工统计
    /// </summary>
    public class EmployeeStatisticsFacade : IEmployeeStatisticsFacade
    {
        public List<EmployeeComeAndLeave> ComeAndLeaveStatistics(DateTime dt, int departmentID, Account accountoperator)
        {
            GetEmployeeComeAndLeave GetEmployeeComeAndLeave = new GetEmployeeComeAndLeave();
            return GetEmployeeComeAndLeave.ComeAndLeaveStatistics(dt, departmentID, accountoperator);
        }

        public EmployeeStatistics BindEmployeeStatistics(DateTime dt, int departmentID, Account accountoperator, List<Employee> employeeSource)
        {
            GetEmployeeStatistics GetEmployeeStatistics = new GetEmployeeStatistics(dt, departmentID, accountoperator, employeeSource);
            return GetEmployeeStatistics.BindEmployeeStatistics();
        }
        public EmployeeComeAndLeave ComeAndLeaveStatisticsOnlyOneMonth(DateTime dt, int departmentID, Account accountoperator)
        {
            List<Employee> outEndDtEmployeeList;
            GetEmployeeComeAndLeave GetEmployeeComeAndLeave = new GetEmployeeComeAndLeave();
            return
                GetEmployeeComeAndLeave.ComeAndLeaveStatisticsOnlyOneMonth(dt, departmentID, accountoperator,
                                                                           null, out outEndDtEmployeeList, null);
        }

        public EmployeeOtherStatistics ResidenceStatistics(DateTime dt, int departmentID, Account accountoperator, List<Employee> employeeSource)
        {
            GetEmployeeStatistics GetEmployeeStatistics = new GetEmployeeStatistics(dt, departmentID, accountoperator, employeeSource);
            return GetEmployeeStatistics.ResidenceStatistics();
        }

        public EmployeeOtherStatistics VocationStatistics(DateTime dt, int departmentID, Account accountoperator, List<Employee> employeeSource)
        {
            GetEmployeeStatistics GetEmployeeStatistics = new GetEmployeeStatistics(dt, departmentID, accountoperator, employeeSource);
            return GetEmployeeStatistics.VocationStatistics();
        }

        public List<PositionGradeStatistics> PositionGradeStatistics(DateTime dt, int departmentID, Account accountoperator, List<Employee> employeeSource)
        {
            GetEmployeeStatistics GetEmployeeStatistics = new GetEmployeeStatistics(dt, departmentID, accountoperator, employeeSource);
            return GetEmployeeStatistics.PositionGradeStatistics();
        }
    }
}
