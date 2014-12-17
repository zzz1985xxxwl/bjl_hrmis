//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateAccountSetParaTest.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 修改帐套参数测试
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.PayModule.AccountSet;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.BllUnitTest.PayModuleTest.AccountSet
{
    [TestFixture]
    public class UpdateAccountSetParaTest
    {
        [Test, Description("修改帐套参数,参数为未被用到")]
        public void UpdateAccountSetParaTestSuccess1()
        {
            AccountSetPara accountSetParaOld = new AccountSetPara(1, "帐套参数1");
            accountSetParaOld.BindItem = BindItemEnum.NoBindItem;
            accountSetParaOld.Description = "描述帐套参数";
            accountSetParaOld.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaOld.MantissaRound = MantissaRoundEnum.OmitFenJiao;

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetParaOld.AccountSetParaID)).Return(accountSetParaOld);
            Expect.Call(
                iAccountSet.CountAccountSetParaByNameDiffPKID(accountSetParaOld.AccountSetParaID,
                                                              "新帐套参数1")).Return(0);
            Expect.Call(
                iAccountSet.CountAccountSetItemByAccountSetParaID(accountSetParaOld.AccountSetParaID)).Return(0);
            Expect.Call(iAccountSet.UpdateAccountSetPara(null)).IgnoreArguments().Return(1);
            mocks.ReplayAll();

            UpdateAccountSetPara target =
                new UpdateAccountSetPara(accountSetParaOld.AccountSetParaID, "新帐套参数1",
                                         FieldAttributeEnum.FloatField,
                                         BindItemEnum.LeaveEarly, MantissaRoundEnum.NoDealWith,
                                         "新描述帐套参数", "wang.shali", false, false, iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            AccountSetPara accountSetParaExpected = new AccountSetPara(1, "新帐套参数1");
            accountSetParaExpected.BindItem = BindItemEnum.LeaveEarly;
            accountSetParaExpected.Description = "新描述帐套参数";
            accountSetParaExpected.FieldAttribute = FieldAttributeEnum.FloatField;
            accountSetParaExpected.MantissaRound = MantissaRoundEnum.NoDealWith;
            TestUtility.AssertAccountSetPara(target.AccountSetParaForTest, accountSetParaExpected);
            Assert.IsNull(target.EmployeeSalaryListTest);
        }
        [Test, Description("修改帐套参数,参数已被帐套用到（但帐套无对应员工），修改所有信息")]
        public void UpdateAccountSetParaTestSuccess2()
        {
            AccountSetPara accountSetParaOld = new AccountSetPara(1, "帐套参数1");
            accountSetParaOld.BindItem = BindItemEnum.NoBindItem;
            accountSetParaOld.Description = "描述帐套参数";
            accountSetParaOld.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaOld.MantissaRound = MantissaRoundEnum.OmitFenJiao;

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetParaOld.AccountSetParaID)).Return(accountSetParaOld);
            Expect.Call(
                iAccountSet.CountAccountSetParaByNameDiffPKID(accountSetParaOld.AccountSetParaID,
                                                              "新帐套参数1")).Return(0);
            Expect.Call(
                iAccountSet.CountAccountSetItemByAccountSetParaID(accountSetParaOld.AccountSetParaID)).Return(8);
            Expect.Call(iAccountSet.UpdateAccountSetPara(null)).IgnoreArguments().Return(1);
            Expect.Call(
                iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetParaID(accountSetParaOld.AccountSetParaID)).Return(
                new List<EmployeeSalary>());
            mocks.ReplayAll();

            UpdateAccountSetPara target =
                new UpdateAccountSetPara(accountSetParaOld.AccountSetParaID, "新帐套参数1",
                                         FieldAttributeEnum.FloatField,
                                         BindItemEnum.LeaveEarly, MantissaRoundEnum.NoDealWith,
                                         "新描述帐套参数", "wang.shali", false, false, iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            AccountSetPara accountSetParaExpected = new AccountSetPara(1, "新帐套参数1");
            accountSetParaExpected.BindItem = BindItemEnum.LeaveEarly;
            accountSetParaExpected.Description = "新描述帐套参数";
            accountSetParaExpected.FieldAttribute = FieldAttributeEnum.FloatField;
            accountSetParaExpected.MantissaRound = MantissaRoundEnum.NoDealWith;
            TestUtility.AssertAccountSetPara(target.AccountSetParaForTest, accountSetParaExpected);
            TestUtility.AssertEmployeeAccountSet(target.EmployeeSalaryListTest, new List<EmployeeSalary>());
        }
        [Test, Description("修改帐套参数,参数已被帐套用到（但帐套无对应员工），修改所有信息")]
        public void UpdateAccountSetParaTestSuccess3()
        {
            AccountSetPara accountSetParaOld = new AccountSetPara(1, "帐套参数1");
            accountSetParaOld.BindItem = BindItemEnum.NoBindItem;
            accountSetParaOld.Description = "描述帐套参数";
            accountSetParaOld.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaOld.MantissaRound = MantissaRoundEnum.OmitFenJiao;

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetParaOld.AccountSetParaID)).Return(accountSetParaOld);
            Expect.Call(
                iAccountSet.CountAccountSetParaByNameDiffPKID(accountSetParaOld.AccountSetParaID,
                                                              "新帐套参数1")).Return(0);
            Expect.Call(
                iAccountSet.CountAccountSetItemByAccountSetParaID(accountSetParaOld.AccountSetParaID)).Return(8);
            Expect.Call(iAccountSet.UpdateAccountSetPara(null)).IgnoreArguments().Return(1);
            Expect.Call(
                iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetParaID(accountSetParaOld.AccountSetParaID)).Return(
                new List<EmployeeSalary>());
            mocks.ReplayAll();

            UpdateAccountSetPara target =
                new UpdateAccountSetPara(accountSetParaOld.AccountSetParaID, "新帐套参数1",
                                         FieldAttributeEnum.FloatField,
                                         BindItemEnum.LeaveEarly, MantissaRoundEnum.NoDealWith,
                                         "新描述帐套参数", "wang.shali", false, false, iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            AccountSetPara accountSetParaExpected = new AccountSetPara(1, "新帐套参数1");
            accountSetParaExpected.BindItem = BindItemEnum.LeaveEarly;
            accountSetParaExpected.Description = "新描述帐套参数";
            accountSetParaExpected.FieldAttribute = FieldAttributeEnum.FloatField;
            accountSetParaExpected.MantissaRound = MantissaRoundEnum.NoDealWith;
            TestUtility.AssertAccountSetPara(target.AccountSetParaForTest, accountSetParaExpected);
            TestUtility.AssertEmployeeAccountSet(target.EmployeeSalaryListTest, new List<EmployeeSalary>());
        }
        [Test, Description("修改帐套参数,参数已被帐套用到（且帐套有对应员工），修改所有信息，如果修改了名字，则员工的帐套被修改，且有记录历史")]
        public void UpdateAccountSetParaTestSuccess4()
        {
            Model.PayModule.AccountSet accountSetOld = new Model.PayModule.AccountSet(1, "帐套1");
            accountSetOld.Description = "描述";
            accountSetOld.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaOld1 = new AccountSetPara(1, "参数1");
            accountSetParaOld1.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaOld1.BindItem = BindItemEnum.BingJia;
            accountSetParaOld1.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetOld.Items.Add(new AccountSetItem(0, accountSetParaOld1, "1+1"));

            List<EmployeeSalary> employeesalaryOlds = new List<EmployeeSalary>();
            EmployeeSalary employeesalaryOld1 = new EmployeeSalary(1);
            employeesalaryOld1.AccountSet = accountSetOld;
            employeesalaryOlds.Add(employeesalaryOld1);

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetParaOld1.AccountSetParaID)).Return(accountSetParaOld1);
            Expect.Call(
                iAccountSet.CountAccountSetParaByNameDiffPKID(accountSetParaOld1.AccountSetParaID,
                                                              "新帐套参数1")).Return(0);
            Expect.Call(
                iAccountSet.CountAccountSetItemByAccountSetParaID(accountSetParaOld1.AccountSetParaID)).Return(8);
            Expect.Call(iAccountSet.UpdateAccountSetPara(null)).IgnoreArguments().Return(1);
            Expect.Call(
                iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetParaID(accountSetParaOld1.AccountSetParaID)).Return
                (employeesalaryOlds);
            //UpdateEmployeeAccountSet片断
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(employeesalaryOld1.AccountSet.AccountSetID)).Return(accountSetOld);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByEmployeeID(employeesalaryOlds[0].Employee.Account.Id)).Return(employeesalaryOlds[0]);
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(employeesalaryOld1.AccountSet.AccountSetID)).Return(accountSetOld);
            Expect.Call(iEmployeeAccountSet.UpdateEmployeeAccountSet(employeesalaryOlds[0].Employee.Account.Id, null)).IgnoreArguments().Return(1);
            Expect.Call(delegate
                            {
                                iEmployeeAccountSet.InsertAdjustSalaryHistory(employeesalaryOlds[0].Employee.Account.Id,
                                                                              new AdjustSalaryHistory());
                            }).
                IgnoreArguments();
            mocks.ReplayAll();

            UpdateAccountSetPara target =
                new UpdateAccountSetPara(accountSetParaOld1.AccountSetParaID, "新帐套参数1",
                                         FieldAttributeEnum.FloatField,
                                         BindItemEnum.LeaveEarly, MantissaRoundEnum.NoDealWith,
                                         "新描述帐套参数", "wang.shali", false, false, iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "帐套1");
            accountSetExpected.Description = "描述（" + DateTime.Now.ToShortDateString() +
                                                        "wang.shali修改帐套参数操作，系统自动生成历史）";
            accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected = new AccountSetPara(1, "新帐套参数1");
            accountSetParaExpected.BindItem = BindItemEnum.LeaveEarly;
            accountSetParaExpected.Description = "新描述帐套参数";
            accountSetParaExpected.FieldAttribute = FieldAttributeEnum.FloatField;
            accountSetParaExpected.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected, "1+1"));

            List<EmployeeSalary> employeesalaryExpected = new List<EmployeeSalary>();
            EmployeeSalary employeesalaryExpected1 = new EmployeeSalary(1);
            employeesalaryExpected1.AccountSet = accountSetOld;
            employeesalaryExpected1.AccountSet.AccountSetName = accountSetExpected.AccountSetName;
            employeesalaryExpected1.AccountSet.Description = accountSetExpected.Description;
            employeesalaryExpected1.AccountSet = accountSetOld;
            employeesalaryExpected.Add(employeesalaryExpected1);

            TestUtility.AssertAccountSetPara(target.AccountSetParaForTest, accountSetParaExpected);
            TestUtility.AssertEmployeeAccountSet(target.EmployeeSalaryListTest, employeesalaryExpected);
        }
        [Test, Description("修改帐套参数,参数已被帐套用到（且帐套有对应员工），如果没有修改名字，只修改描述，则员工的帐套不需要被修改")]
        public void UpdateAccountSetParaTestSuccess5()
        {
            Model.PayModule.AccountSet accountSetOld = new Model.PayModule.AccountSet(1, "帐套1");
            accountSetOld.Description = "描述";
            accountSetOld.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaOld1 = new AccountSetPara(1, "参数1");
            accountSetParaOld1.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaOld1.BindItem = BindItemEnum.BingJia;
            accountSetParaOld1.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetOld.Items.Add(new AccountSetItem(0, accountSetParaOld1, "1+1"));

            List<EmployeeSalary> employeesalaryOlds = new List<EmployeeSalary>();
            EmployeeSalary employeesalaryOld1 = new EmployeeSalary(1);
            employeesalaryOld1.AccountSet = accountSetOld;
            employeesalaryOlds.Add(employeesalaryOld1);

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetParaOld1.AccountSetParaID)).Return(accountSetParaOld1);
            Expect.Call(
                iAccountSet.CountAccountSetParaByNameDiffPKID(accountSetParaOld1.AccountSetParaID,
                                                              "参数1")).Return(0);
            Expect.Call(
                iAccountSet.CountAccountSetItemByAccountSetParaID(accountSetParaOld1.AccountSetParaID)).Return(8);
            Expect.Call(iAccountSet.UpdateAccountSetPara(null)).IgnoreArguments().Return(1);
            mocks.ReplayAll();

            UpdateAccountSetPara target =
                new UpdateAccountSetPara(accountSetParaOld1.AccountSetParaID, "参数1",
                                         FieldAttributeEnum.FloatField,
                                         BindItemEnum.LeaveEarly, MantissaRoundEnum.NoDealWith,
                                         "新描述帐套参数", "wang.shali", false, false, iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            //Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "帐套1");
            //accountSetExpected.Description = "描述";
            //accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected = new AccountSetPara(1, "参数1");
            accountSetParaExpected.BindItem = BindItemEnum.LeaveEarly;
            accountSetParaExpected.Description = "新描述帐套参数";
            accountSetParaExpected.FieldAttribute = FieldAttributeEnum.FloatField;
            accountSetParaExpected.MantissaRound = MantissaRoundEnum.NoDealWith;
            //accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected, "1+1"));

            //List<EmployeeSalary> employeesalaryExpected = new List<EmployeeSalary>();
            //EmployeeSalary employeesalaryExpected1 = new EmployeeSalary(1);
            //employeesalaryExpected1.AccountSet = accountSetExpected;
            //employeesalaryExpected.Add(employeesalaryExpected1);

            TestUtility.AssertAccountSetPara(target.AccountSetParaForTest, accountSetParaExpected);
            Assert.IsNull(target.EmployeeSalaryListTest);
        }
        [Test, Description("修改帐套参数，帐套参数不存在")]
        public void UpdateAccountSetParaTestFailure1()
        {
            AccountSetPara accountSetParaOld = new AccountSetPara(1, "帐套参数1");
            accountSetParaOld.BindItem = BindItemEnum.NoBindItem;
            accountSetParaOld.Description = "描述帐套参数";
            accountSetParaOld.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaOld.MantissaRound = MantissaRoundEnum.OmitFenJiao;

            MockRepository mocks = new MockRepository();
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetParaOld.AccountSetParaID)).Return(null);
            mocks.ReplayAll();

            UpdateAccountSetPara target =
                new UpdateAccountSetPara(accountSetParaOld.AccountSetParaID, "新帐套参数1",
                                         FieldAttributeEnum.FloatField,
                                         BindItemEnum.LeaveEarly, MantissaRoundEnum.NoDealWith,
                                         "新描述帐套参数", "wang.shali", false, false, iAccountSet, iEmployeeAccountSet);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "帐套参数不存在");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("修改帐套参数,存在重复的帐套参数名称")]
        public void UpdateAccountSetParaTestFailure2()
        {
            AccountSetPara accountSetParaOld = new AccountSetPara(1, "帐套参数1");
            accountSetParaOld.BindItem = BindItemEnum.NoBindItem;
            accountSetParaOld.Description = "描述帐套参数";
            accountSetParaOld.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaOld.MantissaRound = MantissaRoundEnum.OmitFenJiao;

            MockRepository mocks = new MockRepository();
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetParaOld.AccountSetParaID)).Return(accountSetParaOld);
            Expect.Call(
                iAccountSet.CountAccountSetParaByNameDiffPKID(accountSetParaOld.AccountSetParaID,
                                                              "新帐套参数1")).Return(1);
            mocks.ReplayAll();

            UpdateAccountSetPara target =
                new UpdateAccountSetPara(accountSetParaOld.AccountSetParaID, "新帐套参数1",
                                         FieldAttributeEnum.FloatField,
                                         BindItemEnum.LeaveEarly, MantissaRoundEnum.NoDealWith,
                                         "新描述帐套参数", "wang.shlai", false, false, iAccountSet, iEmployeeAccountSet);

            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "存在重复的帐套参数名称");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }

    }
}
