//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateAccountSetTest.cs
// ������: wang.shali
// ��������: 2008-12
// ����: �޸����ײ���
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
        [Test, Description("�޸�����,��������,����û�б�Ա��ʹ��")]
        public void UpdateAccountSetTestSuccess1()
        {
            Model.PayModule.AccountSet accountSetOld = new Model.PayModule.AccountSet(1, "����1");
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSetOld.AccountSetID)).Return(accountSetOld);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSetOld.AccountSetID, "������1")).Return(0);
            Expect.Call(iAccountSet.UpdateWholeAccountSet(null)).IgnoreArguments().Return(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(accountSetOld.AccountSetID)).Return(null);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSetOld.AccountSetID, "������1", "������", null,"wang.shali",
                                     iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "������1");
            accountSetExpected.Description = "������";
            accountSetExpected.Items = new List<AccountSetItem>();
            TestUtility.AssertAccountSet(target.AccountSetForTest, accountSetExpected);
        }
        [Test, Description("�޸�����,��������2��������û�б�Ա��ʹ��")]
        public void UpdateAccountSetTestSuccess2()
        {
            Model.PayModule.AccountSet accountSetActual = new Model.PayModule.AccountSet(1, "����1");
            accountSetActual.Description = "����";
            accountSetActual.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "����1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "����2");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetActual.Items.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetActual.Items.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSetActual.AccountSetID)).Return(accountSetActual);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSetActual.AccountSetID, "������")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual2.AccountSetParaID)).Return(accountSetParaActual2);
            Expect.Call(iAccountSet.UpdateWholeAccountSet(null)).IgnoreArguments().Return(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(accountSetActual.AccountSetID)).Return(null);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSetActual.AccountSetID, "������", "������", accountSetActual.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "������");
            accountSetExpected.Description = "������";
            accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected1 = new AccountSetPara(1, "����1");
            accountSetParaExpected1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaExpected1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaExpected1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaExpected2 = new AccountSetPara(2, "����2");
            accountSetParaExpected2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaExpected2.BindItem = BindItemEnum.BingJia;
            accountSetParaExpected2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected1, ""));
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected2, "1+1"));
            TestUtility.AssertAccountSet(target.AccountSetForTest, accountSetExpected);
        }
        [Test, Description("�޸�����,�����Ա�Ա��ʹ��,���������κθı�����")]
        public void UpdateAccountSetTestSuccess3()
        {
            Model.PayModule.AccountSet accountSetActual = new Model.PayModule.AccountSet(1, "����1");
            accountSetActual.Description = "����";
            accountSetActual.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "����1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "����2");
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
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSetActual.AccountSetID, "������")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual2.AccountSetParaID)).Return(accountSetParaActual2);
            Expect.Call(iAccountSet.UpdateWholeAccountSet(null)).IgnoreArguments().Return(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(accountSetActual.AccountSetID)).Return(employeesalaryOlds);
            //UpdateEmployeeAccountSetƬ��
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
                new UpdateAccountSet(accountSetActual.AccountSetID, "������", "������", accountSetActual.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "������");
            accountSetExpected.Description = "������";
            accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected1 = new AccountSetPara(1, "����1");
            accountSetParaExpected1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaExpected1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaExpected1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaExpected2 = new AccountSetPara(2, "����2");
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

            employeesalaryExpected1.AccountSet.Description = "��������" + DateTime.Now.ToShortDateString() +
                                                             "wang.shali�޸����ײ�����ϵͳ�Զ�������ʷ��";
            TestUtility.AssertEmployeeAccountSet(target.EmployeeSalaryListTest, employeesalaryExpected);
        }
        [Test, Description("�޸�����,�����Ա�Ա��ʹ��,�����������")]
        public void UpdateAccountSetTestSuccess4()
        {
            Model.PayModule.AccountSet accountSetOld = new Model.PayModule.AccountSet(1, "����1");
            accountSetOld.Description = "����";
            accountSetOld.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaOld1 = new AccountSetPara(2, "����2");
            accountSetParaOld1.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaOld1.BindItem = BindItemEnum.BingJia;
            accountSetParaOld1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaOld2 = new AccountSetPara(1, "����1");
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
            AccountSetPara newAccountSetItem2 = new AccountSetPara(1, "����1");
            newAccountSetItem2.FieldAttribute = FieldAttributeEnum.FixedField;
            newAccountSetItem2.BindItem = BindItemEnum.NoBindItem;
            newAccountSetItem2.MantissaRound = MantissaRoundEnum.NoDealWith;
            newAccountSetItem.Add(new AccountSetItem(0, newAccountSetItem2, ""));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSetOld.AccountSetID)).Return(accountSetOld);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSetOld.AccountSetID, "������")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(newAccountSetItem2.AccountSetParaID)).Return(newAccountSetItem2);
            Expect.Call(iAccountSet.UpdateWholeAccountSet(null)).IgnoreArguments().Return(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(accountSetOld.AccountSetID)).Return(employeesalaryOlds);
            //UpdateEmployeeAccountSetƬ��
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
                new UpdateAccountSet(accountSetOld.AccountSetID, "������", "������", newAccountSetItem,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();

            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "������");
            accountSetExpected.Description = "������";
            accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected2 = new AccountSetPara(1, "����1");
            accountSetParaExpected2.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaExpected2.BindItem = BindItemEnum.NoBindItem;
            accountSetParaExpected2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetExpected.Items.Add(new AccountSetItem(0, accountSetParaExpected2, ""));
            TestUtility.AssertAccountSet(target.AccountSetForTest, accountSetExpected);

            List<EmployeeSalary> employeesalaryExpected = new List<EmployeeSalary>();
            EmployeeSalary employeesalaryExpected1 = new EmployeeSalary(1);
            employeesalaryExpected1.AccountSet = accountSetExpected;
            employeesalaryExpected.Add(employeesalaryExpected1);
            employeesalaryExpected1.AccountSet.Description = "��������" + DateTime.Now.ToShortDateString() +
                                                             "wang.shali�޸����ײ�����ϵͳ�Զ�������ʷ��";

            TestUtility.AssertEmployeeAccountSet(target.EmployeeSalaryListTest, employeesalaryExpected);
            Assert.AreEqual(target.EmployeeSalaryListTest[0].AccountSet.Items[0].CalculateResult, 8000);
        }
        [Test, Description("�޸�����,�����Ա�Ա��ʹ��,������������")]
        public void UpdateAccountSetTestSuccess5()
        {
            Model.PayModule.AccountSet accountSetOld = new Model.PayModule.AccountSet(1, "����1");
            accountSetOld.Description = "����";
            accountSetOld.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaOld1 = new AccountSetPara(2, "����2");
            accountSetParaOld1.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaOld1.BindItem = BindItemEnum.BingJia;
            accountSetParaOld1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaOld2 = new AccountSetPara(1, "����1");
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
            AccountSetPara newAccountSetItem1 = new AccountSetPara(2, "����2");
            newAccountSetItem1.FieldAttribute = FieldAttributeEnum.CalculateField;
            newAccountSetItem1.BindItem = BindItemEnum.BingJia;
            newAccountSetItem1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara newAccountSetItem2 = new AccountSetPara(1, "����1");
            newAccountSetItem2.FieldAttribute = FieldAttributeEnum.FixedField;
            newAccountSetItem2.BindItem = BindItemEnum.NoBindItem;
            newAccountSetItem2.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara newAccountSetItem3 = new AccountSetPara(3, "����3");
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
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSetOld.AccountSetID, "������")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(newAccountSetItem1.AccountSetParaID)).Return(newAccountSetItem1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(newAccountSetItem2.AccountSetParaID)).Return(newAccountSetItem2);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(newAccountSetItem3.AccountSetParaID)).Return(newAccountSetItem3);
            Expect.Call(iAccountSet.UpdateWholeAccountSet(null)).IgnoreArguments().Return(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(accountSetOld.AccountSetID)).Return(employeesalaryOlds);
            //UpdateEmployeeAccountSetƬ��
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
                new UpdateAccountSet(accountSetOld.AccountSetID, "������", "������", newAccountSetItem,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();

            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "������");
            accountSetExpected.Description = "������";
            accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected1 = new AccountSetPara(2, "����2");
            accountSetParaExpected1.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaExpected1.BindItem = BindItemEnum.BingJia;
            accountSetParaExpected1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaExpected2 = new AccountSetPara(1, "����1");
            accountSetParaExpected2.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaExpected2.BindItem = BindItemEnum.NoBindItem;
            accountSetParaExpected2.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaExpected3 = new AccountSetPara(3, "����3");
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

            employeesalaryExpected1.AccountSet.Description = "��������" + DateTime.Now.ToShortDateString() +
                                                             "wang.shali�޸����ײ�����ϵͳ�Զ�������ʷ��";
            TestUtility.AssertEmployeeAccountSet(target.EmployeeSalaryListTest, employeesalaryExpected);
            Assert.AreEqual(target.EmployeeSalaryListTest[0].AccountSet.Items[1].CalculateResult, 8000);
            Assert.AreEqual(target.EmployeeSalaryListTest[0].AccountSet.Items[2].CalculateResult, 0);            
        }
        [Test, Description("�޸�����,�����Ա�Ա��ʹ��,�����������Ӽ���")]
        public void UpdateAccountSetTestSuccess6()
        {
            Model.PayModule.AccountSet accountSetOld = new Model.PayModule.AccountSet(1, "����1");
            accountSetOld.Description = "����";
            accountSetOld.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaOld1 = new AccountSetPara(2, "����2");
            accountSetParaOld1.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaOld1.BindItem = BindItemEnum.BingJia;
            accountSetParaOld1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaOld2 = new AccountSetPara(1, "����1");
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
            AccountSetPara newAccountSetItem1 = new AccountSetPara(2, "����2");
            newAccountSetItem1.FieldAttribute = FieldAttributeEnum.CalculateField;
            newAccountSetItem1.BindItem = BindItemEnum.BingJia;
            newAccountSetItem1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara newAccountSetItem3 = new AccountSetPara(3, "����3");
            newAccountSetItem3.FieldAttribute = FieldAttributeEnum.FloatField;
            newAccountSetItem3.BindItem = BindItemEnum.NoBindItem;
            newAccountSetItem3.MantissaRound = MantissaRoundEnum.NoDealWith;
            newAccountSetItem.Add(new AccountSetItem(0, newAccountSetItem1, "1+1"));
            newAccountSetItem.Add(new AccountSetItem(0, newAccountSetItem3, ""));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(accountSetOld.AccountSetID)).Return(accountSetOld);
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSetOld.AccountSetID, "������")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(newAccountSetItem1.AccountSetParaID)).Return(newAccountSetItem1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(newAccountSetItem3.AccountSetParaID)).Return(newAccountSetItem3);
            Expect.Call(iAccountSet.UpdateWholeAccountSet(null)).IgnoreArguments().Return(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(accountSetOld.AccountSetID)).Return(employeesalaryOlds);
            //UpdateEmployeeAccountSetƬ��
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
                new UpdateAccountSet(accountSetOld.AccountSetID, "������", "������", newAccountSetItem,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();

            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "������");
            accountSetExpected.Description = "������";
            accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected1 = new AccountSetPara(2, "����2");
            accountSetParaExpected1.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaExpected1.BindItem = BindItemEnum.BingJia;
            accountSetParaExpected1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaExpected3 = new AccountSetPara(3, "����3");
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
            employeesalaryExpected1.AccountSet.Description = "��������" + DateTime.Now.ToShortDateString() +
                                                             "wang.shali�޸����ײ�����ϵͳ�Զ�������ʷ��";

            TestUtility.AssertEmployeeAccountSet(target.EmployeeSalaryListTest, employeesalaryExpected);
            Assert.AreEqual(target.EmployeeSalaryListTest[0].AccountSet.Items[1].CalculateResult, 0);

        }
        [Test, Description("�޸�����,�����Ա�Ա��ʹ��,ֻ�޸���������")]
        public void UpdateAccountSetTestSuccess7()
        {
            Model.PayModule.AccountSet accountSetActual = new Model.PayModule.AccountSet(1, "����1");
            accountSetActual.Description = "����";
            accountSetActual.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "����1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "����2");
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
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(accountSetActual.AccountSetID, "����1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual2.AccountSetParaID)).Return(accountSetParaActual2);
            Expect.Call(iAccountSet.UpdateWholeAccountSet(null)).IgnoreArguments().Return(1);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(accountSetActual.AccountSetID)).Return(employeesalaryOlds);
            mocks.ReplayAll();

            UpdateAccountSet target =
                new UpdateAccountSet(accountSetActual.AccountSetID, "����1", "������", accountSetActual.Items,
                                     "wang.shali",iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "����1");
            accountSetExpected.Description = "������";
            accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected1 = new AccountSetPara(1, "����1");
            accountSetParaExpected1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaExpected1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaExpected1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaExpected2 = new AccountSetPara(2, "����2");
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

        [Test, Description("�޸�����ʧ��,���ײ�����")]
        public void UpdateAccountSetParaTestFailure1()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "����1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "����1");
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
                Assert.AreEqual(ex.Message, "���ײ�����");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("�޸�����ʧ��,�����ظ�����������")]
        public void UpdateAccountSetParaTestFailure2()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "����1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "����1");
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
                Assert.AreEqual(ex.Message, "�����ظ�����������");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("�޸�����ʧ��,���ײ���������")]
        public void UpdateAccountSetParaTestFailure3()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "����1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "����1");
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
                Assert.AreEqual(ex.Message, "���ײ���������");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("�޸�����ʧ��,���ײ���������")]
        public void UpdateAccountSetParaTestFailure4()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "����1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "����1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "����2");
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
                Assert.AreEqual(ex.Message, "���ײ���������");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("�޸�����ʧ��,������ʹ�����ظ������ײ���")]
        public void UpdateAccountSetParaTestFailure5()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "����1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "����1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            AccountSetPara accountSetPara2 = new AccountSetPara(1, "����1");
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
                Assert.AreEqual(ex.Message, "������ʹ�����ظ������ײ���");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("�޸�����ʧ��,������ʹ�����ظ������ײ���")]
        public void UpdateAccountSetParaTestFailure6()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "����1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "����1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            AccountSetPara accountSetPara2 = new AccountSetPara(1, "����1");
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
                Assert.AreEqual(ex.Message, "������ʹ�����ظ������ײ���");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("�޸�����ʧ��,���ײ���û��ʵ����")]
        public void UpdateAccountSetParaTestFailure7()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "����1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "����1");
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
                Assert.AreEqual(ex.Message, "���ײ���û��ʵ����");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("�޸�����ʧ��,���㹫ʽ����Ϊ��")]
        public void UpdateAccountSetParaTestFailure8()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "����1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "����1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "����2");
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
                Assert.AreEqual(ex.Message, "���㹫ʽ����Ϊ��");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("�޸�����ʧ��,���ײ������ֶ�����û��ʵ����")]
        public void UpdateAccountSetParaTestFailure9()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "����1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "����1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "����2");
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
                Assert.AreEqual(ex.Message, "���ײ������ֶ�����û��ʵ����");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("�޸�����ʧ��,���㹫ʽ����Ϊ��")]
        public void UpdateAccountSetParaTestFailure10()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "����1");
            accountSet.Items = new List<AccountSetItem>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "����1");
            accountSetPara1.FieldAttribute = FieldAttributeEnum.FixedField;
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "����2");
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
                Assert.AreEqual(ex.Message, "�����Ϊ���ޡ�");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }
}
