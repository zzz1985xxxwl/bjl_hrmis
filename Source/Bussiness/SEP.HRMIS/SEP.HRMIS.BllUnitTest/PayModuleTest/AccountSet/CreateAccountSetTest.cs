//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CreateAccountSetTest.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 新增帐套测试
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
        [Test, Description("新增帐套,无帐套项")]
        public void CreateAccountSetParaTestSuccess1()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet) mocks.CreateMock(typeof (IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "帐套1")).Return(0);
            Expect.Call(iAccountSet.InsertWholeAccountSet(null)).IgnoreArguments().Return(1);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("帐套1", "描述", null, iAccountSet);
            target.Excute();
            mocks.VerifyAll();
            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(0, "帐套1");
            accountSetExpected.Description = "描述";
            accountSetExpected.Items = new List<AccountSetItem>();
            Assert.AreEqual(1, target.AccountSetID);
            TestUtility.AssertAccountSet(target.AccountSetForTest, accountSetExpected);
        }

        [Test, Description("新增帐套,有帐套项2条")]
        public void CreateAccountSetParaTestSuccess2()
        {
           List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
           AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "参数1");
           accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
           accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
           accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
           AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "参数2");
           accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
           accountSetParaActual2.BindItem = BindItemEnum.BingJia;
           accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
           accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
           accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));
            
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "帐套1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual2.AccountSetParaID)).Return(accountSetParaActual2);
            Expect.Call(iAccountSet.InsertWholeAccountSet(null)).IgnoreArguments().Return(1);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("帐套1", "描述", accountSetItemActual, iAccountSet);
            target.Excute();
            mocks.VerifyAll();
            Model.PayModule.AccountSet accountSetExpected = new Model.PayModule.AccountSet(0, "帐套1");
            accountSetExpected.Description = "描述";
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
            Assert.AreEqual(1, target.AccountSetID);
            TestUtility.AssertAccountSet(target.AccountSetForTest, accountSetExpected);
        }
        [Test, Description("新增帐套失败,存在重复的帐套名称")]
        public void CreateAccountSetParaTestFailure1()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "参数1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "参数2");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "帐套1")).Return(1);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("帐套1", "描述", accountSetItemActual, iAccountSet);
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
        [Test, Description("新增帐套失败,帐套参数没有实例化")]
        public void CreateAccountSetParaTestFailure2()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "参数1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = null;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "帐套1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("帐套1", "描述", accountSetItemActual, iAccountSet);
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
        [Test, Description("新增帐套失败,帐套参数的字段属性没有实例化")]
        public void CreateAccountSetParaTestFailure3()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "参数1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "参数2");
            accountSetParaActual2.FieldAttribute = null;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "帐套1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("帐套1", "描述", accountSetItemActual, iAccountSet);
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
        [Test, Description("新增帐套失败,帐套参数不存在")]
        public void CreateAccountSetParaTestFailure4()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "参数1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "参数2");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "帐套1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual2.AccountSetParaID)).Return(null);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("帐套1", "描述", accountSetItemActual, iAccountSet);
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
        [Test, Description("新增帐套失败,计算公式不可为空")]
        public void CreateAccountSetParaTestFailure5()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "参数1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FloatField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "参数2");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, ""));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "帐套1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("帐套1", "描述", accountSetItemActual, iAccountSet);
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
        [Test, Description("新增帐套失败,有帐套项")]
        public void CreateAccountSetParaTestFailure6()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "参数1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(1, "参数1");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "帐套1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual2.AccountSetParaID)).Return(accountSetParaActual2);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("帐套1", "描述", accountSetItemActual, iAccountSet);
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
        [Test, Description("新增帐套失败,有帐套项")]
        public void CreateAccountSetParaTestFailure7()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "参数1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FixedField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(1, "参数2");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.CalculateField;
            accountSetParaActual2.BindItem = BindItemEnum.BingJia;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, "1+1"));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "帐套1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual2.AccountSetParaID)).Return(accountSetParaActual2);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("帐套1", "描述", accountSetItemActual, iAccountSet);
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

        [Test, Description("新增帐套失败,判断绑定值类型的字段是否已填写绑定值")]
        public void CreateAccountSetParaTestFailure8()
        {
            List<AccountSetItem> accountSetItemActual = new List<AccountSetItem>();
            AccountSetPara accountSetParaActual1 = new AccountSetPara(1, "参数1");
            accountSetParaActual1.FieldAttribute = FieldAttributeEnum.FloatField;
            accountSetParaActual1.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual1.MantissaRound = MantissaRoundEnum.NoDealWith;
            AccountSetPara accountSetParaActual2 = new AccountSetPara(2, "参数2");
            accountSetParaActual2.FieldAttribute = FieldAttributeEnum.BindField;
            accountSetParaActual2.BindItem = BindItemEnum.NoBindItem;
            accountSetParaActual2.MantissaRound = MantissaRoundEnum.NoDealWith;
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual1, ""));
            accountSetItemActual.Add(new AccountSetItem(0, accountSetParaActual2, ""));

            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            Expect.Call(iAccountSet.CountAccountSetByNameDiffPKID(0, "帐套1")).Return(0);
            Expect.Call(iAccountSet.GetAccountSetParaByPKID(accountSetParaActual1.AccountSetParaID)).Return(accountSetParaActual1);
            mocks.ReplayAll();

            CreateAccountSet target =
                new CreateAccountSet("帐套1", "描述", accountSetItemActual, iAccountSet);
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
