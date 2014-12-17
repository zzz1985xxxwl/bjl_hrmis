//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ReopenSalaryTest.cs
// 创建者: 刘丹
// 创建日期: 2008-12-25
// 概述: 员工工资解封单元测试
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.PayModule.EmployeeAccountSet;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PayModule;


namespace SEP.HRMIS.BllUnitTest.PayModuleTest.EmployeeAccountSet
{
    [TestFixture]
    public class ReopenSalaryTest
    {
        //[Test, Description("当月工资不存在")]
        //public void TSaveSalaryNoAccountSet()
        //{
        //    MockRepository mocks = new MockRepository();
        //    IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
        //    Expect.Call(iEmployeeSalary.GetEmployeeSalaryByCondition(Convert.ToDateTime("2008-10-10"), -1)).Return(null);
        //    mocks.ReplayAll();
        //    ReopenEmployeeSalary target =
        //        new ReopenEmployeeSalary(Convert.ToDateTime("2008-10-10"), "", "",
        //                                     iEmployeeSalary);
        //    string exception = "";
        //    try
        //    {
        //        target.Excute();
        //    }
        //    catch (Exception ex)
        //    {
        //        exception = ex.Message;
        //    }
        //    mocks.VerifyAll();
        //    Assert.AreEqual("该薪水记录不存在", exception);
        //}

        //[Test, Description("当月工资不存在")]
        //public void SalaryAlreadyCloseTest()
        //{
        //    MockRepository mocks = new MockRepository();
        //    IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
        //    List<EmployeeSalary> salaries = new List<EmployeeSalary>();
        //    EmployeeSalary salary = new EmployeeSalary(1);
        //    salaries.Add(salary);
        //    Expect.Call(iEmployeeSalary.GetEmployeeSalaryByCondition(Convert.ToDateTime("2008-10-10"), -1)).Return(
        //        salaries);
        //    mocks.ReplayAll();
        //    ReopenEmployeeSalary target =
        //        new ReopenEmployeeSalary(Convert.ToDateTime("2008-10-10"), "", "",
        //                                     iEmployeeSalary);
        //    string exception = "";
        //    try
        //    {
        //        target.Excute();
        //    }
        //    catch (Exception ex)
        //    {
        //        exception = ex.Message;
        //    }
        //    mocks.VerifyAll();
        //    Assert.AreEqual("该薪水记录不存在", exception);
        //}

        //[Test, Description("该薪水记录未封帐")]
        //public void SalaryAlreadyCloseTest2()
        //{
        //    MockRepository mocks = new MockRepository();
        //    IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
        //    List<EmployeeSalary> salaries = new List<EmployeeSalary>();
        //    EmployeeSalary salary = new EmployeeSalary(1);
        //    salary.EmployeeSalaryHistoryList = new List<EmployeeSalaryHistory>();
        //    EmployeeSalaryHistory salaryHistory = new EmployeeSalaryHistory();
        //    salaryHistory.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.TemporarySave;
        //    salary.EmployeeSalaryHistoryList.Add(salaryHistory);
        //    salaries.Add(salary);
        //    Expect.Call(iEmployeeSalary.GetEmployeeSalaryByCondition(Convert.ToDateTime("2008-10-10"), -1)).Return(
        //        salaries);
        //    mocks.ReplayAll();
        //    ReopenEmployeeSalary target =
        //        new ReopenEmployeeSalary(Convert.ToDateTime("2008-10-10"), "", "",
        //                                     iEmployeeSalary);
        //    string exception = "";
        //    try
        //    {
        //        target.Excute();
        //    }
        //    catch (Exception ex)
        //    {
        //        exception = ex.Message;
        //    }
        //    mocks.VerifyAll();
        //    Assert.AreEqual("该薪水记录还没有封帐", exception);
        //}

        //[Test, Description("更新薪资，操作成功")]
        //public void UpdateSalarySuccess()
        //{
        //    MockRepository mocks = new MockRepository();
        //    IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
        //    List<EmployeeSalary> salaries = new List<EmployeeSalary>();
        //    EmployeeSalary salary = new EmployeeSalary(1);
        //    salary.EmployeeSalaryHistoryList = new List<EmployeeSalaryHistory>();
        //    EmployeeSalaryHistory salaryHistory = new EmployeeSalaryHistory();
        //    salaryHistory.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.AccountClosed;
        //    salary.EmployeeSalaryHistoryList.Add(salaryHistory);
        //    salaries.Add(salary);
        //    Expect.Call(iEmployeeSalary.GetEmployeeSalaryByCondition(Convert.ToDateTime("2008-10-10"), -1)).Return(
        //        salaries);
        //    mocks.ReplayAll();
        //    ReopenEmployeeSalary target =
        //        new ReopenEmployeeSalary(Convert.ToDateTime("2008-10-10"), "", "",
        //                                     iEmployeeSalary);

        //    target.Excute();
        //    mocks.ReplayAll();
        //}
    }
}
