//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ReopenSalaryTest.cs
// ������: ����
// ��������: 2008-12-25
// ����: Ա�����ʽ�ⵥԪ����
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
        //[Test, Description("���¹��ʲ�����")]
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
        //    Assert.AreEqual("��нˮ��¼������", exception);
        //}

        //[Test, Description("���¹��ʲ�����")]
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
        //    Assert.AreEqual("��нˮ��¼������", exception);
        //}

        //[Test, Description("��нˮ��¼δ����")]
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
        //    Assert.AreEqual("��нˮ��¼��û�з���", exception);
        //}

        //[Test, Description("����н�ʣ������ɹ�")]
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
