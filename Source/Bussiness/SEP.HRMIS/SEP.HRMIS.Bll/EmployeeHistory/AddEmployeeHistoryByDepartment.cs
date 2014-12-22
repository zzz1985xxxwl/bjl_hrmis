using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// �������µ���Ա�����ʷ
    /// </summary>
    public class AddEmployeeHistoryByDepartment : Transaction
    {
        private readonly IEmployeeHistory _DalEmployeeHistory = new EmployeeHistoryDal();
        private GetEmployee _GetEmployee = new GetEmployee();
        private readonly Account _OperatorAccount;
        private readonly Department _Department;
        private readonly DateTime _DtNow = DateTime.Now;
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="department"></param>
        /// <param name="operatorAccount"></param>
        public AddEmployeeHistoryByDepartment(Department department, Account operatorAccount)
        {
            _Department = department;
            _OperatorAccount = operatorAccount;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="operatorAccount"></param>
        /// <param name="mockEmployeeHistory"></param>
        public AddEmployeeHistoryByDepartment(Department department, Account operatorAccount, IEmployeeHistory mockEmployeeHistory)
        {
            _Department = department;
            _DalEmployeeHistory = mockEmployeeHistory;
            _OperatorAccount = operatorAccount;
        }
        /// <summary>
        /// ���� Ա��
        /// </summary>
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
        }
        protected override void Validation()
        {
            //throw new System.NotImplementedException();
        }

        protected override void ExcuteSelf()
        {
            List<Employee> employeelist =
                _GetEmployee.GetEmployeeByBasicCondition("", EmployeeTypeEnum.All, -1, _Department.Id, false);

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                foreach (Employee employee in employeelist)
                {
                    EmployeeHistory employeeHistory =
                        new EmployeeHistory(employee, _DtNow, _OperatorAccount, "�����޸�����Ա����ʷ");
                    employee.Account.Dept.Name = _Department.Name;
                    _DalEmployeeHistory.CreateEmployeeHistory(employeeHistory);
                }
                ts.Complete();
            }
        }
    }
}
