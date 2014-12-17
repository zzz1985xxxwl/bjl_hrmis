//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: CreateAccountSetParaTest.cs
// ������: wang.shali
// ��������: 2008-12
// ����: �������ײ�������
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
    public class CreateAccountSetParaTest
    {
        [Test, Description("�������ײ���")]
        public void CreateAccountSetParaTestSuccess1()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetParaByNameDiffPKID(0, "���ײ���1")).Return(0);
            Expect.Call(iAccountSet.InsertAccountSetPara(null)).IgnoreArguments().Return(1);
            mocks.ReplayAll();

            CreateAccountSetPara target =
                new CreateAccountSetPara("���ײ���1", FieldAttributeEnum.FixedField,
                                         BindItemEnum.NoBindItem, MantissaRoundEnum.OmitFenJiao,
                                         "�������ײ���", false, false, iAccountSet);
            target.Excute();
            mocks.VerifyAll();
            AccountSetPara accountSetParaExpected = new AccountSetPara(0, "���ײ���1");
            accountSetParaExpected.BindItem = BindItemEnum.NoBindItem;
            accountSetParaExpected.Description = "�������ײ���";
            accountSetParaExpected.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaExpected.MantissaRound = MantissaRoundEnum.OmitFenJiao;
            Assert.AreEqual(1, target.AccountSetParaID);
            TestUtility.AssertAccountSetPara(target.AccountSetParaForTest, accountSetParaExpected);
        }

        [Test, Description("�������ײ�������������")]
        public void CreateAccountSetParaTestFailure1()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetParaByNameDiffPKID(0, "���ײ���1")).Return(1);
            mocks.ReplayAll();

            CreateAccountSetPara target =
                new CreateAccountSetPara("���ײ���1", FieldAttributeEnum.FixedField,
                                         BindItemEnum.NoBindItem, MantissaRoundEnum.OmitFenJiao,
                                         "�������ײ���", false, false, iAccountSet);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, "�����ظ������ײ�������");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }

    }
}
