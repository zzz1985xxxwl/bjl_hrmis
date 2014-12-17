using System.Collections.Generic;

namespace SEP.HRMIS.Model.PayModule
{
    public class EmployeeSalary
    {
        private Employee _Employee;
        private AccountSet _AccountSet;
        private List<EmployeeSalaryHistory> _EmployeeSalaryHistoryList;
        private List<AdjustSalaryHistory> _AdjustSalaryHistoryList;

        public EmployeeSalary(int employeeID)
        {
            _Employee = new Employee(employeeID, new EmployeeTypeEnum());
        }

        public Employee Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }

        public AccountSet AccountSet
        {
            get { return _AccountSet; }
            set { _AccountSet = value; }
        }

        public List<EmployeeSalaryHistory> EmployeeSalaryHistoryList
        {
            get { return _EmployeeSalaryHistoryList; }
            set { _EmployeeSalaryHistoryList = value; }
        }

        public List<AdjustSalaryHistory> AdjustSalaryHistoryList
        {
            get { return _AdjustSalaryHistoryList; }
            set { _AdjustSalaryHistoryList = value; }
        }
    }
}
