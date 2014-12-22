//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ReopenEmployeeSalary.cs
// 创建者: 刘丹
// 创建日期: 2008-12-27
// 概述: 解封
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Transactions;

using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.EmployeeAccountSet
{
    /// <summary>
    /// </summary>
    public class ReopenEmployeeSalary : Transaction
    {
        private readonly string _BackAccountsName;
        private readonly int _CompanyId;
        private readonly IEmployeeSalary _DalEmployeeSalary = new EmployeeSalaryDal();
        private readonly GetEmployee _GetEmployee = new GetEmployee();
        private readonly DateTime _SalaryTime;
        private List<Employee> _EmployeeList;
        private List<EmployeeSalary> _EmployeeSalaryList;
        private int _DepartmentId;

        /// <summary>
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="backAcountsName"></param>
        /// <param name="description"></param>
        /// <param name="companyId"></param>
        public ReopenEmployeeSalary(DateTime dt, string backAcountsName, string description, int companyId, int departmentId)
        {
            //_SalaryTime = Convert.ToDateTime(dt.Year + "-" + dt.Month);
            _SalaryTime = dt;
            _BackAccountsName = backAcountsName;
            _CompanyId = companyId;
            _DepartmentId = departmentId;
        }

        /// <summary>
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="backAcountsName"></param>
        /// <param name="description"></param>
        /// <param name="mockSalary"></param>
        public ReopenEmployeeSalary(DateTime dt, string backAcountsName, string description, IEmployeeSalary mockSalary)
        {
            _SalaryTime = dt;
            _BackAccountsName = backAcountsName;
            _DalEmployeeSalary = mockSalary;
        }

        protected override void Validation()
        {
            _EmployeeSalaryList = new List<EmployeeSalary>();
            //获取所有员工
            _EmployeeList = _GetEmployee.GetEmployeeWithCurrentMonthDimissionEmployee(_SalaryTime, _CompanyId, _DepartmentId);
            foreach (Employee employee in _EmployeeList)
            {
                EmployeeSalaryHistory salaryHistory =
                    _DalEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(employee.Account.Id, _SalaryTime);
                //判断当月工资是否存在
                if (salaryHistory == null)
                {
                    BllUtility.ThrowException(BllExceptionConst._Employee_Salary_NotExist);
                }
                //判断当月工资状态是否没有封帐
                else if (salaryHistory.EmployeeSalaryStatus != EmployeeSalaryStatusEnum.AccountClosed)
                {
                    BllUtility.ThrowException(BllExceptionConst._Employee_Salary_Not_Closed);
                }
                var employeeSalary = new EmployeeSalary(employee.Account.Id);
                employeeSalary.Employee = employee;
                employeeSalary.EmployeeSalaryHistoryList = new List<EmployeeSalaryHistory>();
                employeeSalary.EmployeeSalaryHistoryList.Add(salaryHistory);
                _EmployeeSalaryList.Add(employeeSalary);
            }
        }

        protected override void ExcuteSelf()
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                foreach (EmployeeSalary employeeSalary in _EmployeeSalaryList)
                {
                    //employeeSalary.EmployeeSalaryHistoryList[0].Description = _Description;
                    employeeSalary.EmployeeSalaryHistoryList[0].SalaryDateTime = _SalaryTime;
                    employeeSalary.EmployeeSalaryHistoryList[0].EmployeeSalaryStatus =
                        EmployeeSalaryStatusEnum.AccountReopened;
                    employeeSalary.EmployeeSalaryHistoryList[0].AccountsBackName = _BackAccountsName;
                    _DalEmployeeSalary.UpdateEmployeeSalaryHistory(employeeSalary.Employee.Account.Id,
                        employeeSalary.EmployeeSalaryHistoryList[0]);
                }
                ts.Complete();
            }
        }
    }
}