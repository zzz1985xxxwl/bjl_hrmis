
using SEP.Model.Departments;

namespace SEP.HRMIS.Model.PayModule
{
    public class EmployeeSalaryAverageStatistics
    {
        private Department _Department;
        private EmployeeSalaryStatisticsItem _EmployeeCountItem;
        private EmployeeSalaryStatisticsItem _AverageItem;
        private EmployeeSalaryStatisticsItem _SumItem;

        public Department Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        public EmployeeSalaryStatisticsItem EmployeeCountItem
        {
            get { return _EmployeeCountItem; }
            set { _EmployeeCountItem = value; }
        }

        public EmployeeSalaryStatisticsItem AverageItem
        {
            get { return _AverageItem; }
            set { _AverageItem = value; }
        }

        public EmployeeSalaryStatisticsItem SumItem
        {
            get { return _SumItem; }
            set { _SumItem = value; }
        }
    }
}
