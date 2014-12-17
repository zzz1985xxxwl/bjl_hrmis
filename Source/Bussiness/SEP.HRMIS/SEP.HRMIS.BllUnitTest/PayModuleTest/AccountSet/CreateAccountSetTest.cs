//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: CreateAccountSetTest.cs
// ������: wang.shali
// ��������: 2008-12
// ����: �������ײ���
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
    public class CreateAccountSetTest
    {
        [Test, Description("��������,��������")]
        public void CreateAccountSetParaTestSuccess1()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet) mocks.CreateMock(typeof (IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "����1")).Return(0);
            Expect.Call(iAccountSet.InsertWholeAccountSet(null)).IgnoreArguments().Return(1);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("����1", "����", null, iAccountSet);
            target.Excute();
            mocks.VerifyAll();
            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(0, "����1");
            accountSetExpected.Description = "����";
            accountSetExpected.Items = new List<AccountSetItem>();
            Assert.AreEqual(1, target.AccountSetID);
            TestUtility.AssertAccountSet(target.AccountSetForTest, accountSetExpected);
        }

        [Test, Description("��������,��������2��")]
        public void CreateAccountSetParaTestSuccess2()
        {
           List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
           AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "����1");
           accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
           accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
           accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
           AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "����2");
           accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
           accountSetParaActual2.BindItem = BindItemEnum.BingJia;
           accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
           accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
           accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));
            
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "����1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual2.AccountSetParaID)).Return(accountSetParaActual2);
            Expect.Call(iAccountSet.InsertWholeAccountSet(null)).IgnoreArguments().Return(1);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("����1", "����", accountSetItemActual, iAccountSet);
            target.Excute();
            mocks.VerifyAll();
            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(0, "����1");
            accountSetExpected.Description = "����";
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
            Assert.AreEqual(1, target.AccountSetID);
            TestUtility.AssertAccountSet(target.AccountSetForTest, accountSetExpected);
        }
        [Test, Description("��������ʧ��,�����ظ�����������")]
        public void CreateAccountSetParaTestFailure1()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "����1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "����2");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "����1")).Return(1);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("����1", "����", accountSetItemActual, iAccountSet);
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
        [Test, Description("��������ʧ��,���ײ���û��ʵ����")]
        public void CreateAccountSetParaTestFailure2()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "����1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = null;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "����1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("����1", "����", accountSetItemActual, iAccountSet);
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
        [Test, Description("��������ʧ��,���ײ������ֶ�����û��ʵ����")]
        public void CreateAccountSetParaTestFailure3()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "����1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "����2");
            accountSetParaActual2.FieldAttribute = null;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "����1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("����1", "����", accountSetItemActual, iAccountSet);
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
        [Test, Description("��������ʧ��,���ײ���������")]
        public void CreateAccountSetParaTestFailure4()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "����1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "����2");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "����1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual2.AccountSetParaID)).Return(null);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("����1", "����", accountSetItemActual, iAccountSet);
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
        [Test, Description("��������ʧ��,���㹫ʽ����Ϊ��")]
        public void CreateAccountSetParaTestFailure5()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "����1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FloatField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "����2");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, ""));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "����1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("����1", "����", accountSetItemActual, iAccountSet);
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
        [Test, Description("��������ʧ��,��������")]
        public void CreateAccountSetParaTestFailure6()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "����1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(1, "����1");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "����1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual2.AccountSetParaID)).Return(accountSetParaActual2);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("����1", "����", accountSetItemActual, iAccountSet);
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
        [Test, Description("��������ʧ��,��������")]
        public void CreateAccountSetParaTestFailure7()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "����1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(1, "����2");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "����1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual2.AccountSetParaID)).Return(accountSetParaActual2);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("����1", "����", accountSetItemActual, iAccountSet);
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

        [Test, Description("��������ʧ��,�жϰ�ֵ���͵��ֶ��Ƿ�����д��ֵ")]
        public void CreateAccountSetParaTestFailure8()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "����1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FloatField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "����2");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.BindField;
            accountSetParaActual2.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, ""));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "����1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("����1", "����", accountSetItemActual, iAccountSet);
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
