//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteAccountSetParaTest.cs
// ������: wang.shali
// ��������: 2008-12
// ����: ɾ�����ײ�������
// ----------------------------------------------------------------
using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.PayModule.AccountSet;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.BllUnitTest.PayModuleTest.AccountSet
{
    [TestFixture]
    public class DeleteAccountSetParaTest
    {
        [Test, Description("ɾ�����ײ���")]
        public void DeleteAccountSetParaTestSuccess1()
        {
            AccountSetPara accountSetPara = new AccountSetPara(1, "���ײ���1");
            accountSetPara.BindItem = BindItemEnum.NoBindItem;
            accountSetPara.Description = "�������ײ���";
            accountSetPara.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetPara.MantissaRound = MantissaRoundEnum.OmitFenJiao;
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetPara.AccountSetParaID)).Return(accountSetPara);
            Expect.Call(
                iAccountSet.CountAccountSetItemByAccountSetParaID(accountSetPara.AccountSetParaID)).Return(0);
            Expect.Call(iAccountSet.DeleteAccountSetParaByPKID(accountSetPara.AccountSetParaID)).Return(1);
            mocks.ReplayAll();

            DeleteAccountSetPara target =
                new DeleteAccountSetPara(accountSetPara.AccountSetParaID, iAccountSet);
            target.Excute();
            mocks.VerifyAll();
        }
        [Test, Description("ɾ�����ײ���,���ײ���������")]
        public void DeleteAccountSetParaTestFailure1()
        {
            AccountSetPara accountSetPara = new AccountSetPara(1, "���ײ���1");
            accountSetPara.BindItem = BindItemEnum.NoBindItem;
            accountSetPara.Description = "�������ײ���";
            accountSetPara.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetPara.MantissaRound = MantissaRoundEnum.OmitFenJiao;
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetPara.AccountSetParaID)).Return(null);
            mocks.ReplayAll();

            DeleteAccountSetPara target =
                new DeleteAccountSetPara(accountSetPara.AccountSetParaID, iAccountSet);
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
        [Test, Description("ɾ�����ײ���,���ײ���������")]
        public void DeleteAccountSetParaTestFailure2()
        {
            AccountSetPara accountSetPara = new AccountSetPara(1, "���ײ���1");
            accountSetPara.BindItem = BindItemEnum.NoBindItem;
            accountSetPara.Description = "�������ײ���";
            accountSetPara.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetPara.MantissaRound = MantissaRoundEnum.OmitFenJiao;
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(
                iAccountSet.GetAccountSetParaByPKID(accountSetPara.AccountSetParaID)).Return(accountSetPara);
            Expect.Call(
                iAccountSet.CountAccountSetItemByAccountSetParaID(accountSetPara.AccountSetParaID)).Return(1);
            mocks.ReplayAll();

            DeleteAccountSetPara target =
                new DeleteAccountSetPara(accountSetPara.AccountSetParaID, iAccountSet);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "����ʧ�ܣ����ײ����ѱ�ĳ��������ʹ��");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }
}