//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteAccountSetParaTest.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 删除帐套参数测试
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
        [Test, Description("删除帐套参数")]
        public void DeleteAccountSetParaTestSuccess1()
        {
            AccountSetPara accountSetPara = new AccountSetPara(1, "帐套参数1");
            accountSetPara.BindItem = BindItemEnum.NoBindItem;
            accountSetPara.Description = "描述帐套参数";
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
        [Test, Description("删除帐套参数,帐套参数不存在")]
        public void DeleteAccountSetParaTestFailure1()
        {
            AccountSetPara accountSetPara = new AccountSetPara(1, "帐套参数1");
            accountSetPara.BindItem = BindItemEnum.NoBindItem;
            accountSetPara.Description = "描述帐套参数";
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
                Assert.AreEqual(ex.Message, "帐套参数不存在");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("删除帐套参数,帐套参数不存在")]
        public void DeleteAccountSetParaTestFailure2()
        {
            AccountSetPara accountSetPara = new AccountSetPara(1, "帐套参数1");
            accountSetPara.BindItem = BindItemEnum.NoBindItem;
            accountSetPara.Description = "描述帐套参数";
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
                Assert.AreEqual(ex.Message, "操作失败，帐套参数已被某个帐套项使用");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }
}