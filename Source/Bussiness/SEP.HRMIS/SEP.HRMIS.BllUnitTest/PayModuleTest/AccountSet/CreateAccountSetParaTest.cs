//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CreateAccountSetParaTest.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 新增帐套参数测试
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
        [Test, Description("新增帐套参数")]
        public void CreateAccountSetParaTestSuccess1()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetParaByNameDiffPKID(0, "帐套参数1")).Return(0);
            Expect.Call(iAccountSet.InsertAccountSetPara(null)).IgnoreArguments().Return(1);
            mocks.ReplayAll();

            CreateAccountSetPara target =
                new CreateAccountSetPara("帐套参数1", FieldAttributeEnum.FixedField,
                                         BindItemEnum.NoBindItem, MantissaRoundEnum.OmitFenJiao,
                                         "描述帐套参数", false, false, iAccountSet);
            target.Excute();
            mocks.VerifyAll();
            AccountSetPara accountSetParaExpected = new AccountSetPara(0, "帐套参数1");
            accountSetParaExpected.BindItem = BindItemEnum.NoBindItem;
            accountSetParaExpected.Description = "描述帐套参数";
            accountSetParaExpected.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaExpected.MantissaRound = MantissaRoundEnum.OmitFenJiao;
            Assert.AreEqual(1, target.AccountSetParaID);
            TestUtility.AssertAccountSetPara(target.AccountSetParaForTest, accountSetParaExpected);
        }

        [Test, Description("新增帐套参数，名字重名")]
        public void CreateAccountSetParaTestFailure1()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetParaByNameDiffPKID(0, "帐套参数1")).Return(1);
            mocks.ReplayAll();

            CreateAccountSetPara target =
                new CreateAccountSetPara("帐套参数1", FieldAttributeEnum.FixedField,
                                         BindItemEnum.NoBindItem, MantissaRoundEnum.OmitFenJiao,
                                         "描述帐套参数", false, false, iAccountSet);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, "存在重复的帐套参数名称");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }

    }
}
