//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateAccountSetParaTest.cs
// ������: wang.shali
// ��������: 2008-12
// ����: �޸����ײ�������
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
        [Test, Description("�޸����ײ���,����Ϊδ���õ�")]
        public void UpdateAccountSetParaTestSuccess1()
        {
            AccountSetPara accountSetParaOld = new AccountSetPara(1, "���ײ���1");
            accountSetParaOld.BindItem = BindItemEnum.NoBindItem;
            accountSetParaOld.Description = "�������ײ���";
            accountSetParaOld.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaOld.MantissaRound = MantissaRoundEnum.OmitFenJiao;

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetParaOld.AccountSetParaID)).Return(accountSetParaOld);
            Expect.Call(
                iAccountSet.CountAccountSetParaByNameDiffPKID(accountSetParaOld.AccountSetParaID,
                                                              "�����ײ���1")).Return(0);
            Expect.Call(
                iAccountSet.CountAccountSetItemByAccountSetParaID(accountSetParaOld.AccountSetParaID)).Return(0);
            Expect.Call(iAccountSet.UpdateAccountSetPara(null)).IgnoreArguments().Return(1);
            mocks.ReplayAll();

            UpdateAccountSetPara target =
                new UpdateAccountSetPara(accountSetParaOld.AccountSetParaID, "�����ײ���1",
                                         FieldAttributeEnum.FloatField,
                                         BindItemEnum.LeaveEarly, MantissaRoundEnum.NoDealWith,
                                         "���������ײ���", "wang.shali", false, false, iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            AccountSetPara accountSetParaExpected = new AccountSetPara(1, "�����ײ���1");
            accountSetParaExpected.BindItem = BindItemEnum.LeaveEarly;
            accountSetParaExpected.Description = "���������ײ���";
            accountSetParaExpected.FieldAttribute = FieldAttributeEnum.FloatField;
            accountSetParaExpected.MantissaRound = MantissaRoundEnum.NoDealWith;
            TestUtility.AssertAccountSetPara(target.AccountSetParaForTest, accountSetParaExpected);
            Assert.IsNull(target.EmployeeSalaryListTest);
        }
        [Test, Description("�޸����ײ���,�����ѱ������õ����������޶�ӦԱ�������޸�������Ϣ")]
        public void UpdateAccountSetParaTestSuccess2()
        {
            AccountSetPara accountSetParaOld = new AccountSetPara(1, "���ײ���1");
            accountSetParaOld.BindItem = BindItemEnum.NoBindItem;
            accountSetParaOld.Description = "�������ײ���";
            accountSetParaOld.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaOld.MantissaRound = MantissaRoundEnum.OmitFenJiao;

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetParaOld.AccountSetParaID)).Return(accountSetParaOld);
            Expect.Call(
                iAccountSet.CountAccountSetParaByNameDiffPKID(accountSetParaOld.AccountSetParaID,
                                                              "�����ײ���1")).Return(0);
            Expect.Call(
                iAccountSet.CountAccountSetItemByAccountSetParaID(accountSetParaOld.AccountSetParaID)).Return(8);
            Expect.Call(iAccountSet.UpdateAccountSetPara(null)).IgnoreArguments().Return(1);
            Expect.Call(
                iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetParaID(accountSetParaOld.AccountSetParaID)).Return(
                new List<EmployeeSalary>());
            mocks.ReplayAll();

            UpdateAccountSetPara target =
                new UpdateAccountSetPara(accountSetParaOld.AccountSetParaID, "�����ײ���1",
                                         FieldAttributeEnum.FloatField,
                                         BindItemEnum.LeaveEarly, MantissaRoundEnum.NoDealWith,
                                         "���������ײ���", "wang.shali", false, false, iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            AccountSetPara accountSetParaExpected = new AccountSetPara(1, "�����ײ���1");
            accountSetParaExpected.BindItem = BindItemEnum.LeaveEarly;
            accountSetParaExpected.Description = "���������ײ���";
            accountSetParaExpected.FieldAttribute = FieldAttributeEnum.FloatField;
            accountSetParaExpected.MantissaRound = MantissaRoundEnum.NoDealWith;
            TestUtility.AssertAccountSetPara(target.AccountSetParaForTest, accountSetParaExpected);
            TestUtility.AssertEmployeeAccountSet(target.EmployeeSalaryListTest, new List<EmployeeSalary>());
        }
        [Test, Description("�޸����ײ���,�����ѱ������õ����������޶�ӦԱ�������޸�������Ϣ")]
        public void UpdateAccountSetParaTestSuccess3()
        {
            AccountSetPara accountSetParaOld = new AccountSetPara(1, "���ײ���1");
            accountSetParaOld.BindItem = BindItemEnum.NoBindItem;
            accountSetParaOld.Description = "�������ײ���";
            accountSetParaOld.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaOld.MantissaRound = MantissaRoundEnum.OmitFenJiao;

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetParaOld.AccountSetParaID)).Return(accountSetParaOld);
            Expect.Call(
                iAccountSet.CountAccountSetParaByNameDiffPKID(accountSetParaOld.AccountSetParaID,
                                                              "�����ײ���1")).Return(0);
            Expect.Call(
                iAccountSet.CountAccountSetItemByAccountSetParaID(accountSetParaOld.AccountSetParaID)).Return(8);
            Expect.Call(iAccountSet.UpdateAccountSetPara(null)).IgnoreArguments().Return(1);
            Expect.Call(
                iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetParaID(accountSetParaOld.AccountSetParaID)).Return(
                new List<EmployeeSalary>());
            mocks.ReplayAll();

            UpdateAccountSetPara target =
                new UpdateAccountSetPara(accountSetParaOld.AccountSetParaID, "�����ײ���1",
                                         FieldAttributeEnum.FloatField,
                                         BindItemEnum.LeaveEarly, MantissaRoundEnum.NoDealWith,
                                         "���������ײ���", "wang.shali", false, false, iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            AccountSetPara accountSetParaExpected = new AccountSetPara(1, "�����ײ���1");
            accountSetParaExpected.BindItem = BindItemEnum.LeaveEarly;
            accountSetParaExpected.Description = "���������ײ���";
            accountSetParaExpected.FieldAttribute = FieldAttributeEnum.FloatField;
            accountSetParaExpected.MantissaRound = MantissaRoundEnum.NoDealWith;
            TestUtility.AssertAccountSetPara(target.AccountSetParaForTest, accountSetParaExpected);
            TestUtility.AssertEmployeeAccountSet(target.EmployeeSalaryListTest, new List<EmployeeSalary>());
        }
        [Test, Description("�޸����ײ���,�����ѱ������õ����������ж�ӦԱ�������޸�������Ϣ������޸������֣���Ա�������ױ��޸ģ����м�¼��ʷ")]
        public void UpdateAccountSetParaTestSuccess4()
        {
            Model.PayModule.AccountSet accountSetOld = new Model.PayModule.AccountSet(1, "����1");
            accountSetOld.Description = "����";
            accountSetOld.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaOld1 = new AccountSetPara(1, "����1");
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
                                                              "�����ײ���1")).Return(0);
            Expect.Call(
                iAccountSet.CountAccountSetItemByAccountSetParaID(accountSetParaOld1.AccountSetParaID)).Return(8);
            Expect.Call(iAccountSet.UpdateAccountSetPara(null)).IgnoreArguments().Return(1);
            Expect.Call(
                iEmployeeAccountSet.GetEmployeeAccountSetByAccountSetParaID(accountSetParaOld1.AccountSetParaID)).Return
                (employeesalaryOlds);
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

            UpdateAccountSetPara target =
                new UpdateAccountSetPara(accountSetParaOld1.AccountSetParaID, "�����ײ���1",
                                         FieldAttributeEnum.FloatField,
                                         BindItemEnum.LeaveEarly, MantissaRoundEnum.NoDealWith,
                                         "���������ײ���", "wang.shali", false, false, iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "����1");
            accountSetExpected.Description = "������" + DateTime.Now.ToShortDateString() +
                                                        "wang.shali�޸����ײ���������ϵͳ�Զ�������ʷ��";
            accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected = new AccountSetPara(1, "�����ײ���1");
            accountSetParaExpected.BindItem = BindItemEnum.LeaveEarly;
            accountSetParaExpected.Description = "���������ײ���";
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
        [Test, Description("�޸����ײ���,�����ѱ������õ����������ж�ӦԱ���������û���޸����֣�ֻ�޸���������Ա�������ײ���Ҫ���޸�")]
        public void UpdateAccountSetParaTestSuccess5()
        {
            Model.PayModule.AccountSet accountSetOld = new Model.PayModule.AccountSet(1, "����1");
            accountSetOld.Description = "����";
            accountSetOld.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaOld1 = new AccountSetPara(1, "����1");
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
                                                              "����1")).Return(0);
            Expect.Call(
                iAccountSet.CountAccountSetItemByAccountSetParaID(accountSetParaOld1.AccountSetParaID)).Return(8);
            Expect.Call(iAccountSet.UpdateAccountSetPara(null)).IgnoreArguments().Return(1);
            mocks.ReplayAll();

            UpdateAccountSetPara target =
                new UpdateAccountSetPara(accountSetParaOld1.AccountSetParaID, "����1",
                                         FieldAttributeEnum.FloatField,
                                         BindItemEnum.LeaveEarly, MantissaRoundEnum.NoDealWith,
                                         "���������ײ���", "wang.shali", false, false, iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
            //Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(1, "����1");
            //accountSetExpected.Description = "����";
            //accountSetExpected.Items = new List<AccountSetItem>();
            AccountSetPara accountSetParaExpected = new AccountSetPara(1, "����1");
            accountSetParaExpected.BindItem = BindItemEnum.LeaveEarly;
            accountSetParaExpected.Description = "���������ײ���";
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
        [Test, Description("�޸����ײ��������ײ���������")]
        public void UpdateAccountSetParaTestFailure1()
        {
            AccountSetPara accountSetParaOld = new AccountSetPara(1, "���ײ���1");
            accountSetParaOld.BindItem = BindItemEnum.NoBindItem;
            accountSetParaOld.Description = "�������ײ���";
            accountSetParaOld.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaOld.MantissaRound = MantissaRoundEnum.OmitFenJiao;

            MockRepository mocks = new MockRepository();
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetParaOld.AccountSetParaID)).Return(null);
            mocks.ReplayAll();

            UpdateAccountSetPara target =
                new UpdateAccountSetPara(accountSetParaOld.AccountSetParaID, "�����ײ���1",
                                         FieldAttributeEnum.FloatField,
                                         BindItemEnum.LeaveEarly, MantissaRoundEnum.NoDealWith,
                                         "���������ײ���", "wang.shali", false, false, iAccountSet, iEmployeeAccountSet);
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
        [Test, Description("�޸����ײ���,�����ظ������ײ�������")]
        public void UpdateAccountSetParaTestFailure2()
        {
            AccountSetPara accountSetParaOld = new AccountSetPara(1, "���ײ���1");
            accountSetParaOld.BindItem = BindItemEnum.NoBindItem;
            accountSetParaOld.Description = "�������ײ���";
            accountSetParaOld.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaOld.MantissaRound = MantissaRoundEnum.OmitFenJiao;

            MockRepository mocks = new MockRepository();
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetParaOld.AccountSetParaID)).Return(accountSetParaOld);
            Expect.Call(
                iAccountSet.CountAccountSetParaByNameDiffPKID(accountSetParaOld.AccountSetParaID,
                                                              "�����ײ���1")).Return(1);
            mocks.ReplayAll();

            UpdateAccountSetPara target =
                new UpdateAccountSetPara(accountSetParaOld.AccountSetParaID, "�����ײ���1",
                                         FieldAttributeEnum.FloatField,
                                         BindItemEnum.LeaveEarly, MantissaRoundEnum.NoDealWith,
                                         "���������ײ���", "wang.shlai", false, false, iAccountSet, iEmployeeAccountSet);

            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "�����ظ������ײ�������");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }

    }
}
