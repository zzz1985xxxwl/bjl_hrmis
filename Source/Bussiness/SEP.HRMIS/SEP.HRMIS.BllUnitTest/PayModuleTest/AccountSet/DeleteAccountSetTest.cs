//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteAccountSetTest.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 删除帐套
// ----------------------------------------------------------------
using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.PayModule.AccountSet;
using SEP.HRMIS.IDal.PayModule;

namespace SEP.HRMIS.BllUnitTest.PayModuleTest.AccountSet
{
    [TestFixture]
    public class DeleteAccountSetTest
    {
        [Test, Description("删除帐套")]
        public void DeleteAccountSetTestSuccess1()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "帐套1");
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(
                iAccountSet.GetWholeAccountSetByPKID(accountSet.AccountSetID)).Return(accountSet);
            Expect.Call(
                iEmployeeAccountSet.CountEmployeeAccountSetByAccountSetID(accountSet.AccountSetID)).Return(0);
            Expect.Call(iAccountSet.DeleteWholeAccountSetByPKID(accountSet.AccountSetID)).Return(1);
            mocks.ReplayAll();

            DeleteAccountSet target =
                new DeleteAccountSet(accountSet.AccountSetID, iAccountSet, iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("删除帐套失败,帐套不存在")]
        public void DeleteAccountSetTestFailure1()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "帐套1");
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(
                iAccountSet.GetWholeAccountSetByPKID(accountSet.AccountSetID)).Return(null);
            mocks.ReplayAll();

            DeleteAccountSet target =
                new DeleteAccountSet(accountSet.AccountSetID, iAccountSet, iEmployeeAccountSet);
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
        [Test, Description("删除帐套失败,帐套不存在")]
        public void DeleteAccountSetTestFailure2()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "帐套1");
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
            Expect.Call(
                iAccountSet.GetWholeAccountSetByPKID(accountSet.AccountSetID)).Return(accountSet);
            Expect.Call(
                iEmployeeAccountSet.CountEmployeeAccountSetByAccountSetID(accountSet.AccountSetID)).Return(2);
            mocks.ReplayAll();

            DeleteAccountSet target =
                new DeleteAccountSet(accountSet.AccountSetID, iAccountSet, iEmployeeAccountSet);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "操作失败，该帐套已被使用");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }

    }
}
