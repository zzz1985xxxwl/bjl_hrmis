//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TemporarySaveSalaryTest.cs
// 创建者: 刘丹
// 创建日期: 2008-12-25
// 概述: 暂存员工工资单元测试
// ----------------------------------------------------------------
using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.PayModule.EmployeeAccountSet;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.BllUnitTest.PayModuleTest.EmployeeAccountSet
{
    [TestFixture]
    public class TemporarySaveSalaryTest
    {
        [Test, Description("为员工设置帐套，验证员工帐套是否必须是存在的")]
        public void TSaveSalaryAccountSetNotExist()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(1)).Return(null);
            mocks.ReplayAll();

            TemporarySaveEmployeeAccountSet target =
                new TemporarySaveEmployeeAccountSet(0, 1, Convert.ToDateTime("2008-10-10"), new Model.PayModule.AccountSet(1, ""), "", "", 1,
                                             iEmployeeSalary, iAccountSet);
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

        [Test, Description("更新薪资的id不存在")]
        public void CreateEmployeeAccountSetDBError()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "");
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(1)).Return(accountSet);
            Expect.Call(iEmployeeSalary.GetEmployeeSalaryHistoryByPKID(2)).Return(null);
            mocks.ReplayAll();

            TemporarySaveEmployeeAccountSet target =
                new TemporarySaveEmployeeAccountSet(2, 1, Convert.ToDateTime("2008-10-10"), new Model.PayModule.AccountSet(1, ""), "", "", 1,
                                             iEmployeeSalary, iAccountSet);
            string exception = "";
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            Assert.AreEqual("该薪水记录不存在", exception);
        }

        [Test, Description("更新薪资的id不存在")]
        public void CreateEmployeeAccountClosed()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "");
            EmployeeSalaryHistory history = new EmployeeSalaryHistory();
            history.HistoryId = 1;
            history.EmployeeAccountSet = accountSet;
            history.VersionNumber = 1;
            history.SalaryDateTime = Convert.ToDateTime("2008-10-10");
            history.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.AccountClosed;
            history.AccountsBackName = "";
            history.Description = "";
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(1)).Return(accountSet);
            Expect.Call(iEmployeeSalary.GetEmployeeSalaryHistoryByPKID(2)).Return(history);
            Expect.Call(iEmployeeSalary.UpdateEmployeeSalaryHistory(1, history)).Return(1);
            mocks.ReplayAll();

            TemporarySaveEmployeeAccountSet target =
                new TemporarySaveEmployeeAccountSet(2, 1, Convert.ToDateTime("2008-10-10"), new Model.PayModule.AccountSet(1, ""),
                                                    "", "", 1,
                                                    iEmployeeSalary, iAccountSet);
            string exception = "";
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            Assert.AreEqual("该薪水记录已封帐", exception);
        }

        [Test, Description("更新薪资，操作成功")]
        public void UpdateSalarySuccess()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "");
            EmployeeSalaryHistory history = new EmployeeSalaryHistory();
            history.HistoryId = 1;
            history.EmployeeAccountSet = accountSet;
            history.VersionNumber = 1;
            history.SalaryDateTime = Convert.ToDateTime("2008-10-10");
            history.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.TemporarySave;
            history.AccountsBackName = "";
            history.Description = "";
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(1)).Return(accountSet);
            Expect.Call(iEmployeeSalary.GetEmployeeSalaryHistoryByPKID(2)).Return(history);
            Expect.Call(iEmployeeSalary.UpdateEmployeeSalaryHistory(1, history)).Return(1);
            mocks.ReplayAll();

            TemporarySaveEmployeeAccountSet target =
                new TemporarySaveEmployeeAccountSet(2, 1, Convert.ToDateTime("2008-10-10"), new Model.PayModule.AccountSet(1, ""),
                                                    "", "", 1,
                                                    iEmployeeSalary, iAccountSet);

            target.Excute();
            mocks.ReplayAll();
        }
    }
}
