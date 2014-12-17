//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CreateSalaryTest.cs
// 创建者: 刘丹
// 创建日期: 2008-12-25
// 概述: 创建员工工资单元测试
// ----------------------------------------------------------------
using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.PayModule.EmployeeAccountSet;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.BllUnitTest.PayModuleTest.EmployeeAccountSet
{
    using System.Collections.Generic;

    [TestFixture]
    public class CreateSalaryTest
    {
        [Test, Description("判断有帐套的员工，帐套是否存在")]
        public void TSaveSalaryAccountSetNotExist()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            EmployeeSalary accountSet = new EmployeeSalary(1);
            accountSet.AccountSet = new Model.PayModule.AccountSet(1, "test");
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByEmployeeID(1)).Return(accountSet);
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(1)).Return(null);
            mocks.ReplayAll();

            CreateEmployeeSalary target =
                new CreateEmployeeSalary(1,Convert.ToDateTime("2008-10-10"),"", "",
                                             iEmployeeSalary, iAccountSet,iEmployeeAccountSet);
            string exception = "";
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            mocks.VerifyAll();
            Assert.AreEqual("该帐套不存在", exception);
        }

        [Test, Description("本月工资已存在")]
        public void CreateEmployeeAccountSetDBError()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            EmployeeSalaryHistory salary = new EmployeeSalaryHistory(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByEmployeeID(1)).Return(null);
            Expect.Call(iEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(1, Convert.ToDateTime("2008-10-10"))).Return(salary);
            mocks.ReplayAll();

            CreateEmployeeSalary target =
                new CreateEmployeeSalary(1, Convert.ToDateTime("2008-10-10"), "", "",
                                             iEmployeeSalary, iAccountSet, iEmployeeAccountSet);
            string exception = "";
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            mocks.VerifyAll();
            Assert.AreEqual("该员工此月工资记录已存在", exception);
        }

        [Test, Description("无帐套员工，工资插入成功")]
        public void CreateEmployeeAccountClosed()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            EmployeeSalaryHistory salary = new EmployeeSalaryHistory();
            Model.PayModule.AccountSet temp = new Model.PayModule.AccountSet(0, string.Empty);
            salary.EmployeeAccountSet = temp;

            salary.Description = string.Empty;
            salary.SalaryDateTime = Convert.ToDateTime("2008-10-10");
            salary.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.TemporarySave;
            salary.AccountsBackName = string.Empty;
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByEmployeeID(1)).Return(null);
            Expect.Call(iEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(1, Convert.ToDateTime("2008-10-10"))).Return(null);
            Expect.Call(iEmployeeSalary.InsertEmployeeSalaryHistory(1, salary)).Return(1);
            mocks.ReplayAll();

            CreateEmployeeSalary target =
                new CreateEmployeeSalary(1, Convert.ToDateTime("2008-10-10"), "", "",
                                             iEmployeeSalary, iAccountSet, iEmployeeAccountSet);

            target.Excute();
            mocks.ReplayAll();
        }


        public void MakeEmployeeLastYearSalaryTest1()
        {
            List<EmployeeSalaryHistory> returnList = new List<EmployeeSalaryHistory>();
            EmployeeSalaryHistory history=new EmployeeSalaryHistory();
            history.SalaryDateTime = Convert.ToDateTime("2009-01-01");
            returnList.Add(history);

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            EmployeeSalary accountSet = new EmployeeSalary(1);
            accountSet.AccountSet = new Model.PayModule.AccountSet(1, "test");
            Expect.Call(iEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeId(1)).Return(returnList);

            mocks.ReplayAll();

            CreateEmployeeSalary target =
                new CreateEmployeeSalary(1, Convert.ToDateTime("2009-10-10"), "", "",
                                             iEmployeeSalary, iAccountSet, iEmployeeAccountSet);
           List<EmployeeSalaryHistory> actual =target.MakeEmployeeLastYearSalary(1);
            mocks.VerifyAll();
            Assert.AreEqual(actual.Count, 0);
        }

        public void MakeEmployeeLastYearSalaryTest2()
        {
            List<EmployeeSalaryHistory> returnList = new List<EmployeeSalaryHistory>();
            EmployeeSalaryHistory history = new EmployeeSalaryHistory();
            history.SalaryDateTime = Convert.ToDateTime("2008-01-01");
            returnList.Add(history);

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            EmployeeSalary accountSet = new EmployeeSalary(1);
            accountSet.AccountSet = new Model.PayModule.AccountSet(1, "test");
            Expect.Call(iEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeId(1)).Return(returnList);

            mocks.ReplayAll();

            CreateEmployeeSalary target =
                new CreateEmployeeSalary(1, Convert.ToDateTime("2009-10-10"), "", "",
                                             iEmployeeSalary, iAccountSet, iEmployeeAccountSet);
            List<EmployeeSalaryHistory> actual = target.MakeEmployeeLastYearSalary(1);
            mocks.VerifyAll();
            Assert.AreEqual(actual.Count, 1);
        }

        public void MakeEmployeeLastYearSalaryTest3()
        {
            List<EmployeeSalaryHistory> returnList = new List<EmployeeSalaryHistory>();
            EmployeeSalaryHistory history = new EmployeeSalaryHistory();
            history.SalaryDateTime = Convert.ToDateTime("2008-01-01");
            returnList.Add(history);
            EmployeeSalaryHistory history2 = new EmployeeSalaryHistory();
            history2.SalaryDateTime = Convert.ToDateTime("2009-01-01");
            returnList.Add(history2);

            EmployeeSalaryHistory history3 = new EmployeeSalaryHistory();
            history3.SalaryDateTime = Convert.ToDateTime("2008-02-01");
            returnList.Add(history3);

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            EmployeeSalary accountSet = new EmployeeSalary(1);
            accountSet.AccountSet = new Model.PayModule.AccountSet(1, "test");
            Expect.Call(iEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeId(1)).Return(returnList);

            mocks.ReplayAll();

            CreateEmployeeSalary target =
                new CreateEmployeeSalary(1, Convert.ToDateTime("2009-10-10"), "", "",
                                             iEmployeeSalary, iAccountSet, iEmployeeAccountSet);
            List<EmployeeSalaryHistory> actual = target.MakeEmployeeLastYearSalary(1);
            mocks.VerifyAll();
            Assert.AreEqual(actual.Count, 2);
        }

        public void MakeEmployeeLastYearSalaryTest4()
        {
            List<EmployeeSalaryHistory> returnList = new List<EmployeeSalaryHistory>();
            EmployeeSalaryHistory history = new EmployeeSalaryHistory();
            history.SalaryDateTime = Convert.ToDateTime("2008-01-01");
            returnList.Add(history);
            EmployeeSalaryHistory history2 = new EmployeeSalaryHistory();
            history2.SalaryDateTime = Convert.ToDateTime("2009-01-01");
            returnList.Add(history2);

            EmployeeSalaryHistory history3 = new EmployeeSalaryHistory();
            history3.SalaryDateTime = Convert.ToDateTime("2007-02-01");
            returnList.Add(history3);

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            EmployeeSalary accountSet = new EmployeeSalary(1);
            accountSet.AccountSet = new Model.PayModule.AccountSet(1, "test");
            Expect.Call(iEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeId(1)).Return(returnList);

            mocks.ReplayAll();

            CreateEmployeeSalary target =
                new CreateEmployeeSalary(1, Convert.ToDateTime("2009-10-10"), "", "",
                                             iEmployeeSalary, iAccountSet, iEmployeeAccountSet);
            List<EmployeeSalaryHistory> actual = target.MakeEmployeeLastYearSalary(1);
            mocks.VerifyAll();
            Assert.AreEqual(actual.Count, 1);
        }
    }
}
