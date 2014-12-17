//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CloseSalaryTest.cs
// 创建者: 刘丹
// 创建日期: 2008-12-25
// 概述: 员工工资封账单元测试
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.PayModule.EmployeeAccountSet;
using SEP.HRMIS.IDal;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;

namespace SEP.HRMIS.BllUnitTest.PayModuleTest.EmployeeAccountSet
{
    [TestFixture]
    public class CloseSalaryTest
    {
        //private CloseEmployeeSalary _Target;
        //private MockRepository _Mocks;
        //private IAccountBll _IAccountBll;
        //private IEmployee _IEmployee;
        //private GetEmployee _GetEmployee;

        //private IEmployeeSkill _IEmployeeSkill;
        //private IDepartmentBll _IDepartmentBll;
        //private IEmployeeSalary _IEmployeeSalary;
        //[SetUp]
        //public void SetUp()
        //{
        //    _Mocks = new MockRepository();
        //    _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
        //    _IAccountBll = _Mocks.CreateMock<IAccountBll>();
        //    _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));
        //    _IEmployeeSkill = (IEmployeeSkill)_Mocks.CreateMock(typeof(IEmployeeSkill));
        //    _IEmployeeSalary = (IEmployeeSalary)_Mocks.CreateMock(typeof(IEmployeeSalary));

        //    _GetEmployee =
        //        new GetEmployee(_IEmployee, _IAccountBll, _IEmployeeSkill, _IDepartmentBll);
        //    _Target = new CloseEmployeeSalary(Convert.ToDateTime("2008-10-10"), "", "", 1, _IEmployeeSalary);
        //    _Target.MockGetEmployee = _GetEmployee;
        //}

        //[Test, Description("当月工资不存在")]
        //public void TSaveSalaryNoAccountSet()
        //{
        //    Expect.Call(_IEmployeeSalary.GetEmployeeSalaryByCondition(Convert.ToDateTime("2008-10-10"), -1)).Return(null);
        //    _Mocks.ReplayAll();
        //    string exception = "";
        //    try
        //    {
        //        _Target.Excute();
        //    }
        //    catch (Exception ex)
        //    {
        //        exception = ex.Message;
        //    }
        //    _Mocks.VerifyAll();
        //    Assert.AreEqual("该薪水记录不存在", exception);
        //}

        //[Test, Description("该薪水记录不存在")]
        //public void SalaryAlreadyCloseTest()
        //{
        //    List<EmployeeSalary> salaries = new List<EmployeeSalary>();
        //    EmployeeSalary salary = new EmployeeSalary(1);
        //    salaries.Add(salary);
        //    Expect.Call(_IEmployeeSalary.GetEmployeeSalaryByCondition(Convert.ToDateTime("2008-10-10"), -1)).Return(salaries);
        //    _Mocks.ReplayAll();
        //    string exception = "";
        //    try
        //    {
        //        _Target.Excute();
        //    }
        //    catch (Exception ex)
        //    {
        //        exception = ex.Message;
        //    }
        //    _Mocks.VerifyAll();
        //    Assert.AreEqual("该薪水记录不存在", exception);
        //}

        //[Test, Description("该薪水记录已封帐")]
        //public void SalaryAlreadyCloseTest2()
        //{
        //    List<EmployeeSalary> salaries = new List<EmployeeSalary>();
        //    EmployeeSalary salary = new EmployeeSalary(1);
        //    salary.EmployeeSalaryHistoryList = new List<EmployeeSalaryHistory>();
        //    EmployeeSalaryHistory salaryHistory = new EmployeeSalaryHistory();
        //    salaryHistory.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.AccountClosed;
        //    salary.EmployeeSalaryHistoryList.Add(salaryHistory);
        //    salaries.Add(salary);
        //    Expect.Call(_IEmployeeSalary.GetEmployeeSalaryByCondition(Convert.ToDateTime("2008-10-10"), -1)).Return(
        //        salaries);
        //    _Mocks.ReplayAll();
        //    string exception = "";
        //    try
        //    {
        //        _Target.Excute();
        //    }
        //    catch (Exception ex)
        //    {
        //        exception = ex.Message;
        //    }
        //    _Mocks.VerifyAll();
        //    Assert.AreEqual("该薪水记录已封帐", exception);
        //}

        //[Test, Description("更新薪资，操作成功")]
        //public void UpdateSalarySuccess()
        //{
        //    List<EmployeeSalary> salaries = new List<EmployeeSalary>();
        //    EmployeeSalary salary = new EmployeeSalary(1);
        //    salary.EmployeeSalaryHistoryList = new List<EmployeeSalaryHistory>();
        //    EmployeeSalaryHistory salaryHistory = new EmployeeSalaryHistory();
        //    salaryHistory.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.TemporarySave;
        //    salary.EmployeeSalaryHistoryList.Add(salaryHistory);
        //    salaries.Add(salary);
        //    Expect.Call(_IEmployeeSalary.GetEmployeeSalaryByCondition(Convert.ToDateTime("2008-10-10"), -1)).Return(
        //        salaries);
        //    _Mocks.ReplayAll();

        //    _Target.Excute();
        //    _Mocks.ReplayAll();
        //}
    }
}
