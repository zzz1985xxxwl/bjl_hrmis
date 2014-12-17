using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.SystemError;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.HRMIS.Bll.SystemErrors
{
    /// <summary>
    /// 员工合同异常数据
    /// </summary>
    public class GetEmployeeContractError : Transaction
    {
        private readonly string _EmployeeName;
        private readonly int _DepartmentID;
        private DateTime _CurrentDate;
        private readonly Account _Account;
        private readonly int _Powers;
        private List<SystemError> _SystemErrorList = new List<SystemError>();
        /// <summary>
        /// 构造函数
        /// </summary>
        public GetEmployeeContractError(string employeeName, int departmentID,
                                  DateTime currentDate, Account account, int powers)
        {
            _EmployeeName = employeeName;
            _DepartmentID = departmentID;
            _CurrentDate = currentDate;
            _Account = account;
            _Powers = powers;
        }
        /// <summary>
        /// 返回的结果
        /// </summary>
        public List<SystemError> SystemErrorList
        {
            get { return _SystemErrorList; }
            set { _SystemErrorList = value; }
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            IContract iContract = DalFactory.DataAccess.CreateContract();
            GetEmployee getEmployee = new GetEmployee();
            List<Employee> employeeList = new List<Employee>();
            employeeList.AddRange(
                getEmployee.GetEmployeeBasicInfoByBasicCondition(_EmployeeName, EmployeeTypeEnum.NormalEmployee, -1,
                                                                 _DepartmentID,
                                                                 true,-1));
            employeeList.AddRange(
                getEmployee.GetEmployeeBasicInfoByBasicCondition(_EmployeeName, EmployeeTypeEnum.ProbationEmployee, -1,
                                                                 _DepartmentID,
                                                                 true,-1));
            employeeList.AddRange(
                getEmployee.GetEmployeeBasicInfoByBasicCondition(_EmployeeName, EmployeeTypeEnum.BorrowedEmployee, -1,
                                                                 _DepartmentID,
                                                                 true,-1));
            employeeList.AddRange(
                getEmployee.GetEmployeeBasicInfoByBasicCondition(_EmployeeName, EmployeeTypeEnum.PartTimeEmployee, -1,
                                                                 _DepartmentID,
                                                                 true,-1));
            employeeList.AddRange(
                getEmployee.GetEmployeeBasicInfoByBasicCondition(_EmployeeName, EmployeeTypeEnum.PracticeEmployee, -1,
                                                                 _DepartmentID,
                                                                 true,-1));
            employeeList.AddRange(
                getEmployee.GetEmployeeBasicInfoByBasicCondition(_EmployeeName, EmployeeTypeEnum.Retirement, -1,
                                                                 _DepartmentID,
                                                                 true,-1));
            employeeList.AddRange(
                getEmployee.GetEmployeeBasicInfoByBasicCondition(_EmployeeName, EmployeeTypeEnum.RetirementHire, -1,
                                                                 _DepartmentID,
                                                                 true,-1));
            employeeList.AddRange(
                getEmployee.GetEmployeeBasicInfoByBasicCondition(_EmployeeName, EmployeeTypeEnum.WorkEmployee, -1,
                                                                 _DepartmentID,
                                                                 true,-1));
            employeeList = HrmisUtility.RemoteUnAuthEmployee(employeeList, AuthType.HRMIS, _Account, _Powers);
            foreach (Employee employee in employeeList)
            {

                string description = string.Empty;
                Contract contract = iContract.GetLastContractInAllTypeByAccountID(employee.Account.Id, _CurrentDate);
                if (contract == null)
                {
                    description = string.Format("{0}目前没有合同信息", employee.Account.Name);
                }
                if (string.IsNullOrEmpty(description))
                {
                    continue;
                }
                SystemError error = new SystemError(description, ErrorType.EmployeeContractError, employee.Account.Id);
                error.ErrorEmployee = employee;
                error.EditUrl =
                    string.Format("{0}employeeID={1}",
                                  ErrorType.EmployeeContractError.EditPageUrl,
                                  SecurityUtil.DECEncrypt(employee.Account.Id.ToString()));
                _SystemErrorList.Add(error);
            }
        }
    }
}
