//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CloseEmployeeSalary.cs
// 创建者: 刘丹
// 创建日期: 2008-12-27
// 概述: 封帐
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.EmployeeAccountSet
{
    /// <summary>
    /// </summary>
    public class CloseEmployeeSalary : Transaction
    {
        private readonly string _BackAccountsName;
        private readonly int _CompanyId;
        private readonly IEmployeeSalary _DalEmployeeSalary = new EmployeeSalaryDal();
        private readonly int _DepartmentID;
        private readonly string _Description;
        private readonly bool _IsSendEmail;
        private readonly DateTime _SalaryTime;
        private List<Employee> _EmployeeList;
        private List<EmployeeSalary> _EmployeeSalaryList;
        private GetEmployee _GetEmployee = new GetEmployee();
        private string _NameMessge;

        /// <summary>
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="backAcountsName"></param>
        /// <param name="description"></param>
        /// <param name="companyId"></param>
        /// <param name="isSendEmail"></param>
        public CloseEmployeeSalary(DateTime dt, string backAcountsName, string description, int companyId,
            int departmentID, bool isSendEmail)
        {
            //_SalaryTime = Convert.ToDateTime(dt.Year + "-" + dt.Month);
            _SalaryTime = dt;
            _Description = description;
            _BackAccountsName = backAcountsName;
            _CompanyId = companyId;
            _IsSendEmail = isSendEmail;
            _DepartmentID = departmentID;
        }

        /// <summary>
        ///     测试
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="backAcountsName"></param>
        /// <param name="description"></param>
        /// <param name="companyId"></param>
        /// <param name="mockSalary"></param>
        public CloseEmployeeSalary(DateTime dt, string backAcountsName, string description, int companyId,
            IEmployeeSalary mockSalary)
        {
            _SalaryTime = dt;
            _Description = description;
            _BackAccountsName = backAcountsName;
            _DalEmployeeSalary = mockSalary;
            _CompanyId = companyId;
        }

        /// <summary>
        ///     测试
        /// </summary>
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
        }

        /// <summary>
        ///     错误消息
        /// </summary>
        public string NameMessge
        {
            get { return _NameMessge; }
            set { _NameMessge = value; }
        }

        protected override void Validation()
        {
            _EmployeeSalaryList = new List<EmployeeSalary>();
            //获取所有员工
            _EmployeeList = _GetEmployee.GetEmployeeWithCurrentMonthDimissionEmployee(_SalaryTime, _CompanyId,
                _DepartmentID);
            foreach (Employee employee in _EmployeeList)
            {
                //获取员工当月工资
                EmployeeSalaryHistory salaryHistory =
                    _DalEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(employee.Account.Id, _SalaryTime);
                //判断当月工资是否存在
                if (salaryHistory == null)
                {
                    throw new ApplicationException(employee.Account.Name +
                                                   BllUtility.GetResourceMessage(
                                                       BllExceptionConst._Employee_Salary_NotExist));
                }
                //当月工资是否已封帐
                if (Equals(salaryHistory.EmployeeSalaryStatus, EmployeeSalaryStatusEnum.AccountClosed))
                {
                    throw new ApplicationException(employee.Account.Name +
                                                   BllUtility.GetResourceMessage(
                                                       BllExceptionConst._Employee_Salary_Closed));
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
            //using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            //{
            foreach (EmployeeSalary employeeSalary in _EmployeeSalaryList)
            {
                //employeeSalary.EmployeeSalaryHistoryList[0].Description = _Description;
                employeeSalary.EmployeeSalaryHistoryList[0].SalaryDateTime = _SalaryTime;
                employeeSalary.EmployeeSalaryHistoryList[0].EmployeeSalaryStatus =
                    EmployeeSalaryStatusEnum.AccountClosed;
                employeeSalary.EmployeeSalaryHistoryList[0].AccountsBackName = _BackAccountsName;
                _DalEmployeeSalary.UpdateEmployeeSalaryHistory(employeeSalary.Employee.Account.Id,
                    employeeSalary.EmployeeSalaryHistoryList[0]);
                if (_IsSendEmail)
                {
                    //发送邮件
                    var mail =
                        new SendEmployeeSalaryToEmployee(employeeSalary.Employee.Account.Id,
                            employeeSalary.EmployeeSalaryHistoryList[0],
                            _DalEmployeeSalary);
                    mail.Excute();
                    string sendresultname = mail.MailFailName;
                    if (!string.IsNullOrEmpty(sendresultname))
                    {
                        if (!string.IsNullOrEmpty(_NameMessge))
                        {
                            _NameMessge += "，";
                        }
                        _NameMessge += sendresultname;
                    }
                }
            }
            //    ts.Complete();
            //}
        }
    }
}