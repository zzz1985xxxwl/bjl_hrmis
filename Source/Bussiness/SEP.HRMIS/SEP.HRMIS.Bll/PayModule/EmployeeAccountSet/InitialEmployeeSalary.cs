//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InitialEmployeeSalary.cs
// 创建者: 刘丹
// 创建日期: 2008-12-27
// 概述: 初始化员工工资
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using System.Transactions;
using Transaction = SEP.HRMIS.Bll.Transaction;

namespace SEP.HRMIS.Bll.PayModule.EmployeeAccountSet
{
    public class InitialEmployeeSalary : Transaction
    {
        private readonly GetEmployee _GetEmployee = new GetEmployee();
        private readonly string _BackAccountsName;
        private readonly string _Description;
        private readonly DateTime _SalaryTime;
        private readonly int _CompanyId;
        private readonly int _DepartmentId;

        public InitialEmployeeSalary(DateTime dt, string backAcountsName, string description, int companyId,int departmentId)
        {
            //_SalaryTime = Convert.ToDateTime(dt.Year+"-"+dt.Month);
            _SalaryTime = dt;
            _Description = description;
            _BackAccountsName = backAcountsName;
            _CompanyId = companyId;
            _DepartmentId = departmentId;
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {

            //获取所有员工
            List<Employee> employeeList = _GetEmployee.GetEmployeeWithCurrentMonthDimissionEmployee(_SalaryTime, _CompanyId,_DepartmentId);

            foreach (Employee employee in employeeList)
            {
                //using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                //{
                    //新增
                    CreateEmployeeSalary create =
                        new CreateEmployeeSalary(employee.Account.Id, _SalaryTime, _BackAccountsName, _Description);
                    try
                    { create.Excute(); }
                    catch
                    { }
                //    ts.Complete();
                //}

            }
        }

    }
}

