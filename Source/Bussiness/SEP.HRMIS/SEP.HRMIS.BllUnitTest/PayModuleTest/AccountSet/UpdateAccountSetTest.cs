//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateAccountSetTest.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 修改帐套测试
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
    public class UpdateAccountSetTest
    {
        [Test, Description("修改帐套,无帐套项,帐套没有被员工使用")]
        public void UpdateAccountSetTestSuccess1()
        {
            Model.PayModule.AccountSet accountSetOld = new Model.PayModule.AccountSet(1, "帐套1");
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSetOld.AccountSetID)).Return(accountSetOld);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSetOld.AccountSetID, "新帐套1")).Return(0);
            Expect.Call(iAccountSet.UpdateWholeAccountSet(null)).IgnoreArguments().Return(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(accountSetOld.AccountSetID)).Return(null);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSetOld.AccountSetID, "新帐套1", "新描述", null,"wang.shali",
                                     iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "新帐套1");
            accountSetExpected.Description = "新描述";
            accountSetExpected.Items = new List<AccountSetItem>();
            TestUtility.AssertAccountSet(target.AccountSetForTest, accountSetExpected);
        }
        [Test, Description("修改帐套,有帐套项2条，帐套没有被员工使用")]
        public void UpdateAccountSetTestSuccess2()
        {
            Model.PayModule.AccountSet accountSetActual = new Model.PayModule.AccountSet(1, "帐套1");
            accountSetActual.Description = "描述";
            accountSetActual.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "参数1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "参数2");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetActual.Items.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetActual.Items.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSetActual.AccountSetID)).Return(accountSetActual);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSetActual.AccountSetID, "新帐套")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual2.AccountSetParaID)).Return(accountSetParaActual2);
            Expect.Call(iAccountSet.UpdateWholeAccountSet(null)).IgnoreArguments().Return(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(accountSetActual.AccountSetID)).Return(null);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSetActual.AccountSetID, "新帐套", "新描述", accountSetActual.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "新帐套");
            accountSetExpected.Description = "新描述";
            accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected1 = new AccountSetPara(1, "参数1");
            accountSetParaExpected1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaExpected1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaExpected1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaExpected2 = new AccountSetPara(2, "参数2");
            accountSetParaExpected2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaExpected2.BindItem = BindItemEnum.BingJia;
            accountSetParaExpected2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected1, ""));
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected2, "1+1"));
            TestUtility.AssertAccountSet(target.AccountSetForTest, accountSetExpected);
        }
        [Test, Description("修改帐套,帐套以被员工使用,帐套项无任何改变的情况")]
        public void UpdateAccountSetTestSuccess3()
        {
            Model.PayModule.AccountSet accountSetActual = new Model.PayModule.AccountSet(1, "帐套1");
            accountSetActual.Description = "描述";
            accountSetActual.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "参数1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "参数2");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetActual.Items.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetActual.Items.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            List<EmployeeSalary> employeesalaryOlds = new List<EmployeeSalary>();
            EmployeeSalary employeesalaryOld1 = new EmployeeSalary(1);
            employeesalaryOld1.AccountSet = accountSetActual;
            employeesalaryOlds.Add(employeesalaryOld1);


            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSetActual.AccountSetID)).Return(accountSetActual);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSetActual.AccountSetID, "新帐套")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual2.AccountSetParaID)).Return(accountSetParaActual2);
            Expect.Call(iAccountSet.UpdateWholeAccountSet(null)).IgnoreArguments().Return(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(accountSetActual.AccountSetID)).Return(employeesalaryOlds);
            //UpdateEmployeeAccountSet片断
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(employeesalaryOld1.AccountSet.AccountSetID)).Return(accountSetActual);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByEmployeeID(employeesalaryOlds[0].Employee.Account.Id)).Return(employeesalaryOlds[0]);
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(employeesalaryOld1.AccountSet.AccountSetID)).Return(accountSetActual);
            Expect.Call(iEmployeeAccountSet.UpdateEmployeeAccountSet(employeesalaryOlds[0].Employee.Account.Id, null)).IgnoreArguments().Return(1);
            Expect.Call(delegate
                            {
                                iEmployeeAccountSet.InsertAdjustSalaryHistory(employeesalaryOlds[0].Employee.Account.Id,
                                                                              new AdjustSalaryHistory());
                            }).
                IgnoreArguments();
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSetActual.AccountSetID, "新帐套", "新描述", accountSetActual.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "新帐套");
            accountSetExpected.Description = "新描述";
            accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected1 = new AccountSetPara(1, "参数1");
            accountSetParaExpected1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaExpected1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaExpected1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaExpected2 = new AccountSetPara(2, "参数2");
            accountSetParaExpected2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaExpected2.BindItem = BindItemEnum.BingJia;
            accountSetParaExpected2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected1, ""));
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected2, "1+1"));
            TestUtility.AssertAccountSet(target.AccountSetForTest, accountSetExpected);

            List<EmployeeSalary> employeesalaryExpected = new List<EmployeeSalary>();
            EmployeeSalary employeesalaryExpected1 = new EmployeeSalary(1);
            employeesalaryExpected1.AccountSet = accountSetExpected;
            employeesalaryExpected.Add(employeesalaryExpected1);

            employeesalaryExpected1.AccountSet.Description = "新描述（" + DateTime.Now.ToShortDateString() +
                                                             "wang.shali修改帐套操作，系统自动生成历史）";
            TestUtility.AssertEmployeeAccountSet(target.EmployeeSalaryListTest, employeesalaryExpected);
        }
        [Test, Description("修改帐套,帐套以被员工使用,帐套项项减少")]
        public void UpdateAccountSetTestSuccess4()
        {
            Model.PayModule.AccountSet accountSetOld = new Model.PayModule.AccountSet(1, "帐套1");
            accountSetOld.Description = "描述";
            accountSetOld.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaOld1 = new AccountSetPara(2, "参数2");
            accountSetParaOld1.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaOld1.BindItem = BindItemEnum.BingJia;
            accountSetParaOld1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaOld2 = new AccountSetPara(1, "参数1");
            accountSetParaOld2.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaOld2.BindItem = BindItemEnum.NoBindItem;
            accountSetParaOld2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetOld.Items.Add(new AccountSetItem(0, accountSetParaOld1, "1+1"));
            accountSetOld.Items.Add(new AccountSetItem(0, accountSetParaOld2, ""));

            List<EmployeeSalary> employeesalaryOlds = new List<EmployeeSalary>();
            EmployeeSalary employeesalaryOld1 = new EmployeeSalary(1);
            employeesalaryOld1.AccountSet = accountSetOld;
            employeesalaryOld1.AccountSet.Items[1].CalculateResult = 8000;
            employeesalaryOlds.Add(employeesalaryOld1);

            List<AccountSetItem> newAccountSetItem =new List<AccountSetItem>();
            AccountSetPara newAccountSetItem2 = new AccountSetPara(1, "参数1");
            newAccountSetItem2.FieldAttribute = FieldAttributeEnum.FixedField;
            newAccountSetItem2.BindItem = BindItemEnum.NoBindItem;
            newAccountSetItem2.MantissaRound = MantissaRoundEnum.NoDealWith;
            newAccountSetItem.Add(new AccountSetItem(0, newAccountSetItem2, ""));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSetOld.AccountSetID)).Return(accountSetOld);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSetOld.AccountSetID, "新帐套")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(newAccountSetItem2.AccountSetParaID)).Return(newAccountSetItem2);
            Expect.Call(iAccountSet.UpdateWholeAccountSet(null)).IgnoreArguments().Return(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(accountSetOld.AccountSetID)).Return(employeesalaryOlds);
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

            UpdateAccountSet target =
                new UpdateAccountSet(accountSetOld.AccountSetID, "新帐套", "新描述", newAccountSetItem,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();

            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "新帐套");
            accountSetExpected.Description = "新描述";
            accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected2 = new AccountSetPara(1, "参数1");
            accountSetParaExpected2.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaExpected2.BindItem = BindItemEnum.NoBindItem;
            accountSetParaExpected2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected2, ""));
            TestUtility.AssertAccountSet(target.AccountSetForTest, accountSetExpected);

            List<EmployeeSalary> employeesalaryExpected = new List<EmployeeSalary>();
            EmployeeSalary employeesalaryExpected1 = new EmployeeSalary(1);
            employeesalaryExpected1.AccountSet = accountSetExpected;
            employeesalaryExpected.Add(employeesalaryExpected1);
            employeesalaryExpected1.AccountSet.Description = "新描述（" + DateTime.Now.ToShortDateString() +
                                                             "wang.shali修改帐套操作，系统自动生成历史）";

            TestUtility.AssertEmployeeAccountSet(target.EmployeeSalaryListTest, employeesalaryExpected);
            Assert.AreEqual(target.EmployeeSalaryListTest[0].AccountSet.Items[0].CalculateResult, 8000);
        }
        [Test, Description("修改帐套,帐套以被员工使用,帐套项项增加")]
        public void UpdateAccountSetTestSuccess5()
        {
            Model.PayModule.AccountSet accountSetOld = new Model.PayModule.AccountSet(1, "帐套1");
            accountSetOld.Description = "描述";
            accountSetOld.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaOld1 = new AccountSetPara(2, "参数2");
            accountSetParaOld1.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaOld1.BindItem = BindItemEnum.BingJia;
            accountSetParaOld1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaOld2 = new AccountSetPara(1, "参数1");
            accountSetParaOld2.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaOld2.BindItem = BindItemEnum.NoBindItem;
            accountSetParaOld2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetOld.Items.Add(new AccountSetItem(0, accountSetParaOld1, "1+1"));
            accountSetOld.Items.Add(new AccountSetItem(0, accountSetParaOld2, ""));

            List<EmployeeSalary> employeesalaryOlds = new List<EmployeeSalary>();
            EmployeeSalary employeesalaryOld1 = new EmployeeSalary(1);
            employeesalaryOld1.AccountSet = accountSetOld;
            employeesalaryOld1.AccountSet.Items[1].CalculateResult = 8000;
            employeesalaryOlds.Add(employeesalaryOld1);

            List<AccountSetItem> newAccountSetItem = new List<AccountSetItem>();
            AccountSetPara newAccountSetItem1 = new AccountSetPara(2, "参数2");
            newAccountSetItem1.FieldAttribute = FieldAttributeEnum.CalculateField;
            newAccountSetItem1.BindItem = BindItemEnum.BingJia;
            newAccountSetItem1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara newAccountSetItem2 = new AccountSetPara(1, "参数1");
            newAccountSetItem2.FieldAttribute = FieldAttributeEnum.FixedField;
            newAccountSetItem2.BindItem = BindItemEnum.NoBindItem;
            newAccountSetItem2.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara newAccountSetItem3 = new AccountSetPara(3, "参数3");
            newAccountSetItem3.FieldAttribute = FieldAttributeEnum.FloatField;
            newAccountSetItem3.BindItem = BindItemEnum.NoBindItem;
            newAccountSetItem3.MantissaRound = MantissaRoundEnum.NoDealWith;
            newAccountSetItem.Add(new AccountSetItem(0, newAccountSetItem1, "5+1"));
            newAccountSetItem.Add(new AccountSetItem(0, newAccountSetItem2, ""));
            newAccountSetItem.Add(new AccountSetItem(0, newAccountSetItem3, ""));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSetOld.AccountSetID)).Return(accountSetOld);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSetOld.AccountSetID, "新帐套")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(newAccountSetItem1.AccountSetParaID)).Return(newAccountSetItem1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(newAccountSetItem2.AccountSetParaID)).Return(newAccountSetItem2);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(newAccountSetItem3.AccountSetParaID)).Return(newAccountSetItem3);
            Expect.Call(iAccountSet.UpdateWholeAccountSet(null)).IgnoreArguments().Return(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(accountSetOld.AccountSetID)).Return(employeesalaryOlds);
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

            UpdateAccountSet target =
                new UpdateAccountSet(accountSetOld.AccountSetID, "新帐套", "新描述", newAccountSetItem,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();

            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "新帐套");
            accountSetExpected.Description = "新描述";
            accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected1 = new AccountSetPara(2, "参数2");
            accountSetParaExpected1.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaExpected1.BindItem = BindItemEnum.BingJia;
            accountSetParaExpected1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaExpected2 = new AccountSetPara(1, "参数1");
            accountSetParaExpected2.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaExpected2.BindItem = BindItemEnum.NoBindItem;
            accountSetParaExpected2.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaExpected3 = new AccountSetPara(3, "参数3");
            accountSetParaExpected3.FieldAttribute = FieldAttributeEnum.FloatField;
            accountSetParaExpected3.BindItem = BindItemEnum.NoBindItem;
            accountSetParaExpected3.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected1, "5+1"));
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected2, ""));
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected3, ""));
            TestUtility.AssertAccountSet(target.AccountSetForTest, accountSetExpected);

            List<EmployeeSalary> employeesalaryExpected = new List<EmployeeSalary>();
            EmployeeSalary employeesalaryExpected1 = new EmployeeSalary(1);
            employeesalaryExpected1.AccountSet = accountSetExpected;
            employeesalaryExpected.Add(employeesalaryExpected1);

            employeesalaryExpected1.AccountSet.Description = "新描述（" + DateTime.Now.ToShortDateString() +
                                                             "wang.shali修改帐套操作，系统自动生成历史）";
            TestUtility.AssertEmployeeAccountSet(target.EmployeeSalaryListTest, employeesalaryExpected);
            Assert.AreEqual(target.EmployeeSalaryListTest[0].AccountSet.Items[1].CalculateResult, 8000);
            Assert.AreEqual(target.EmployeeSalaryListTest[0].AccountSet.Items[2].CalculateResult, 0);            
        }
        [Test, Description("修改帐套,帐套以被员工使用,帐套项项增加减少")]
        public void UpdateAccountSetTestSuccess6()
        {
            Model.PayModule.AccountSet accountSetOld = new Model.PayModule.AccountSet(1, "帐套1");
            accountSetOld.Description = "描述";
            accountSetOld.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaOld1 = new AccountSetPara(2, "参数2");
            accountSetParaOld1.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaOld1.BindItem = BindItemEnum.BingJia;
            accountSetParaOld1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaOld2 = new AccountSetPara(1, "参数1");
            accountSetParaOld2.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaOld2.BindItem = BindItemEnum.NoBindItem;
            accountSetParaOld2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetOld.Items.Add(new AccountSetItem(0, accountSetParaOld1, "1+1"));
            accountSetOld.Items.Add(new AccountSetItem(0, accountSetParaOld2, ""));

            List<EmployeeSalary> employeesalaryOlds = new List<EmployeeSalary>();
            EmployeeSalary employeesalaryOld1 = new EmployeeSalary(1);
            employeesalaryOld1.AccountSet = accountSetOld;
            employeesalaryOld1.AccountSet.Items[1].CalculateResult = 8000;
            employeesalaryOlds.Add(employeesalaryOld1);

            List<AccountSetItem> newAccountSetItem = new List<AccountSetItem>();
            AccountSetPara newAccountSetItem1 = new AccountSetPara(2, "参数2");
            newAccountSetItem1.FieldAttribute = FieldAttributeEnum.CalculateField;
            newAccountSetItem1.BindItem = BindItemEnum.BingJia;
            newAccountSetItem1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara newAccountSetItem3 = new AccountSetPara(3, "参数3");
            newAccountSetItem3.FieldAttribute = FieldAttributeEnum.FloatField;
            newAccountSetItem3.BindItem = BindItemEnum.NoBindItem;
            newAccountSetItem3.MantissaRound = MantissaRoundEnum.NoDealWith;
            newAccountSetItem.Add(new AccountSetItem(0, newAccountSetItem1, "1+1"));
            newAccountSetItem.Add(new AccountSetItem(0, newAccountSetItem3, ""));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSetOld.AccountSetID)).Return(accountSetOld);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSetOld.AccountSetID, "新帐套")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(newAccountSetItem1.AccountSetParaID)).Return(newAccountSetItem1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(newAccountSetItem3.AccountSetParaID)).Return(newAccountSetItem3);
            Expect.Call(iAccountSet.UpdateWholeAccountSet(null)).IgnoreArguments().Return(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(accountSetOld.AccountSetID)).Return(employeesalaryOlds);
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

            UpdateAccountSet target =
                new UpdateAccountSet(accountSetOld.AccountSetID, "新帐套", "新描述", newAccountSetItem,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();

            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "新帐套");
            accountSetExpected.Description = "新描述";
            accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected1 = new AccountSetPara(2, "参数2");
            accountSetParaExpected1.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaExpected1.BindItem = BindItemEnum.BingJia;
            accountSetParaExpected1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaExpected3 = new AccountSetPara(3, "参数3");
            accountSetParaExpected3.FieldAttribute = FieldAttributeEnum.FloatField;
            accountSetParaExpected3.BindItem = BindItemEnum.NoBindItem;
            accountSetParaExpected3.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected1, "1+1"));
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected3, ""));
            
            TestUtility.AssertAccountSet(target.AccountSetForTest, accountSetExpected);

            List<EmployeeSalary> employeesalaryExpected = new List<EmployeeSalary>();
            EmployeeSalary employeesalaryExpected1 = new EmployeeSalary(1);
            employeesalaryExpected1.AccountSet = accountSetExpected;
            employeesalaryExpected.Add(employeesalaryExpected1);
            employeesalaryExpected1.AccountSet.Description = "新描述（" + DateTime.Now.ToShortDateString() +
                                                             "wang.shali修改帐套操作，系统自动生成历史）";

            TestUtility.AssertEmployeeAccountSet(target.EmployeeSalaryListTest, employeesalaryExpected);
            Assert.AreEqual(target.EmployeeSalaryListTest[0].AccountSet.Items[1].CalculateResult, 0);

        }
        [Test, Description("修改帐套,帐套以被员工使用,只修改帐套描述")]
        public void UpdateAccountSetTestSuccess7()
        {
            Model.PayModule.AccountSet accountSetActual = new Model.PayModule.AccountSet(1, "帐套1");
            accountSetActual.Description = "描述";
            accountSetActual.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "参数1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "参数2");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetActual.Items.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetActual.Items.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            List<EmployeeSalary> employeesalaryOlds = new List<EmployeeSalary>();
            EmployeeSalary employeesalaryOld1 = new EmployeeSalary(1);
            employeesalaryOld1.AccountSet = accountSetActual;
            employeesalaryOlds.Add(employeesalaryOld1);


            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSetActual.AccountSetID)).Return(accountSetActual);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSetActual.AccountSetID, "帐套1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual2.AccountSetParaID)).Return(accountSetParaActual2);
            Expect.Call(iAccountSet.UpdateWholeAccountSet(null)).IgnoreArguments().Return(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(accountSetActual.AccountSetID)).Return(employeesalaryOlds);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSetActual.AccountSetID, "帐套1", "新描述", accountSetActual.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "帐套1");
            accountSetExpected.Description = "新描述";
            accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected1 = new AccountSetPara(1, "参数1");
            accountSetParaExpected1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaExpected1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaExpected1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaExpected2 = new AccountSetPara(2, "参数2");
            accountSetParaExpected2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaExpected2.BindItem = BindItemEnum.BingJia;
            accountSetParaExpected2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected1, ""));
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected2, "1+1"));

            List<EmployeeSalary> employeesalaryExpected = new List<EmployeeSalary>();
            EmployeeSalary employeesalaryExpected1 = new EmployeeSalary(1);
            employeesalaryExpected1.AccountSet = accountSetExpected;
            employeesalaryExpected.Add(employeesalaryExpected1);

            TestUtility.AssertAccountSet(target.AccountSetForTest, accountSetExpected);
            TestUtility.AssertEmployeeAccountSet(target.EmployeeSalaryListTest, employeesalaryExpected);
        }

        [Test, Description("修改帐套失败,帐套不存在")]
        public void UpdateAccountSetParaTestFailure1()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "帐套1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "参数1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara1, ""));
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet =
                (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSet.AccountSetID)).Return(null);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSet.AccountSetID, accountSet.AccountSetName, accountSet.Description,
                                     accountSet.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "帐套不存在");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("修改帐套失败,存在重复的帐套名称")]
        public void UpdateAccountSetParaTestFailure2()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "帐套1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "参数1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara1, ""));
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet =
                (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSet.AccountSetID)).Return(accountSet);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSet.AccountSetID, accountSet.AccountSetName)).
                Return(1);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSet.AccountSetID, accountSet.AccountSetName, accountSet.Description,
                                     accountSet.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "存在重复的帐套名称");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("修改帐套失败,帐套参数不存在")]
        public void UpdateAccountSetParaTestFailure3()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "帐套1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "参数1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara1, ""));
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet =
                (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSet.AccountSetID)).Return(accountSet);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSet.AccountSetID, accountSet.AccountSetName)).
                Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetPara1.AccountSetParaID)).Return(null);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSet.AccountSetID, accountSet.AccountSetName, accountSet.Description,
                                     accountSet.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
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
        [Test, Description("修改帐套失败,帐套参数不存在")]
        public void UpdateAccountSetParaTestFailure4()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "帐套1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "参数1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "参数2");
            accountSetPara2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetPara2.BindItem = BindItemEnum.BingJia;
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara1, ""));
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara2, "1+1"));
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSet.AccountSetID)).Return(accountSet);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSet.AccountSetID, accountSet.AccountSetName)).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetPara1.AccountSetParaID)).Return(accountSetPara1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetPara2.AccountSetParaID)).Return(null);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSet.AccountSetID, accountSet.AccountSetName, accountSet.Description,
                                     accountSet.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
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
        [Test, Description("修改帐套失败,帐套中使用了重复的帐套参数")]
        public void UpdateAccountSetParaTestFailure5()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "帐套1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "参数1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            AccountSetPara accountSetPara2 = new AccountSetPara(1, "参数1");
            accountSetPara2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetPara2.BindItem = BindItemEnum.BingJia;
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara1, ""));
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara2, "1+1"));
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSet.AccountSetID)).Return(accountSet);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSet.AccountSetID, accountSet.AccountSetName)).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetPara1.AccountSetParaID)).Return(accountSetPara1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetPara2.AccountSetParaID)).Return(accountSetPara2);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSet.AccountSetID, accountSet.AccountSetName, accountSet.Description,
                                     accountSet.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "帐套中使用了重复的帐套参数");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("修改帐套失败,帐套中使用了重复的帐套参数")]
        public void UpdateAccountSetParaTestFailure6()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "帐套1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "参数1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            AccountSetPara accountSetPara2 = new AccountSetPara(1, "参数1");
            accountSetPara2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetPara2.BindItem = BindItemEnum.BingJia;
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara1, ""));
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara2, "1+1"));
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSet.AccountSetID)).Return(accountSet);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSet.AccountSetID, accountSet.AccountSetName)).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetPara1.AccountSetParaID)).Return(accountSetPara1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetPara2.AccountSetParaID)).Return(accountSetPara2);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSet.AccountSetID, accountSet.AccountSetName, accountSet.Description,
                                     accountSet.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "帐套中使用了重复的帐套参数");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("修改帐套失败,帐套参数没有实例化")]
        public void UpdateAccountSetParaTestFailure7()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "帐套1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "参数1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            AccountSetPara accountSetPara2 = null;
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara1, ""));
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara2, "1+1"));
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSet.AccountSetID)).Return(accountSet);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSet.AccountSetID, accountSet.AccountSetName)).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetPara1.AccountSetParaID)).Return(accountSetPara1);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSet.AccountSetID, accountSet.AccountSetName, accountSet.Description,
                                     accountSet.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "帐套参数没有实例化");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("修改帐套失败,计算公式不可为空")]
        public void UpdateAccountSetParaTestFailure8()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "帐套1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "参数1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "参数2");
            accountSetPara2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetPara2.BindItem = BindItemEnum.BingJia;
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara1, ""));
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara2, ""));
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSet.AccountSetID)).Return(accountSet);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSet.AccountSetID, accountSet.AccountSetName)).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetPara1.AccountSetParaID)).Return(accountSetPara1);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSet.AccountSetID, accountSet.AccountSetName, accountSet.Description,
                                     accountSet.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "计算公式不可为空");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("修改帐套失败,帐套参数的字段属性没有实例化")]
        public void UpdateAccountSetParaTestFailure9()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "帐套1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "参数1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "参数2");
            accountSetPara2.FieldAttribute = null;
            accountSetPara2.BindItem = BindItemEnum.BingJia;
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara1, ""));
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara2, "1+1"));
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSet.AccountSetID)).Return(accountSet);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSet.AccountSetID, accountSet.AccountSetName)).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetPara1.AccountSetParaID)).Return(accountSetPara1);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSet.AccountSetID, accountSet.AccountSetName, accountSet.Description,
                                     accountSet.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "帐套参数的字段属性没有实例化");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("修改帐套失败,计算公式不可为空")]
        public void UpdateAccountSetParaTestFailure10()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "帐套1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "参数1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "参数2");
            accountSetPara2.FieldAttribute = FieldAttributeEnum.BindField;
            accountSetPara2.BindItem = BindItemEnum.NoBindItem;
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara1, ""));
            accountSet.Items.Add(new AccountSetItem(0, accountSetPara2, ""));
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSet.AccountSetID)).Return(accountSet);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSet.AccountSetID, accountSet.AccountSetName)).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetPara1.AccountSetParaID)).Return(accountSetPara1);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSet.AccountSetID, accountSet.AccountSetName, accountSet.Description,
                                     accountSet.Items,
                                     "wang.shali", iAccountSet, iEmployeeAccountSet);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "绑定项不可为“无”");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }
}
