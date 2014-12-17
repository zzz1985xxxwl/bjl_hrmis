//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SaveEmployeeWelfareTest.cs
// Creater:  Xue.wenlong
// Date:  2008-12-27
// Resume:
// ----------------------------------------------------------------

using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.EmployeeWelfareTest
{
    [TestFixture]
    public class SaveEmployeeWelfareTest
    {
        [Test, Description("测试没有记录时，新增记录，并加历史")]
        public void SaveEmployeeWelfareTest1()
        {
            MockRepository mocks = new MockRepository();
            IEmployeeWelfare iEmployeeWelfare = (IEmployeeWelfare) mocks.CreateMock(typeof (IEmployeeWelfare));
            IEmployeeWelfareHistory iEmployeeWelfareHistory =
                (IEmployeeWelfareHistory) mocks.CreateMock(typeof (IEmployeeWelfareHistory));
            Expect.Call(iEmployeeWelfare.GetEmployeeWelfareByAccountID(1)).Return(null);
            Expect.Call(iEmployeeWelfare.InsertEmployeeWelfareByAccountID(new EmployeeWelfare(null, null), 1)).
                IgnoreArguments().Return(3);
            Expect.Call(iEmployeeWelfareHistory.CreateEmployeeWelfareHistoryByAccountID(null, 1)).IgnoreArguments().Return(2);
            mocks.ReplayAll();
            SaveEmployeeWelfare saveEmployeeWelfare =
                new SaveEmployeeWelfare(1, SocialSecurityTypeEnum.TownInsurance, 0.1m, Convert.ToDateTime("2008-1-1"),
                                        "123", Convert.ToDateTime("2008-1-1"), 0.1m, "admin", "123", 0.1m, 0.2m, 0.3m,
                                        0.4m);
            saveEmployeeWelfare.MockIEmployeeWelfare = iEmployeeWelfare;
            saveEmployeeWelfare.MockIEmployeeWelfareHistroy = iEmployeeWelfareHistory;
            saveEmployeeWelfare.Excute();
            Assert.AreEqual(3,saveEmployeeWelfare.EmployeeWelfareID);
            mocks.VerifyAll();
        }

        [Test, Description("测试没有记录时，不新增记录，不添加历史")]
        public void SaveEmployeeWelfareTest2()
        {
            MockRepository mocks = new MockRepository();
            IEmployeeWelfare iEmployeeWelfare = (IEmployeeWelfare)mocks.CreateMock(typeof(IEmployeeWelfare));
            Expect.Call(iEmployeeWelfare.GetEmployeeWelfareByAccountID(1)).Return(null);
            mocks.ReplayAll();
            SaveEmployeeWelfare saveEmployeeWelfare =
                new SaveEmployeeWelfare(1, SocialSecurityTypeEnum.Null, null, null,
                                        "", null, null, "admin", null, null, null, null, null);
            saveEmployeeWelfare.MockIEmployeeWelfare = iEmployeeWelfare;
            saveEmployeeWelfare.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("测试有记录时，更新记录，添加历史")]
        public void SaveEmployeeWelfareTest3()
        {
            MockRepository mocks = new MockRepository();
            IEmployeeWelfare iEmployeeWelfare = (IEmployeeWelfare) mocks.CreateMock(typeof (IEmployeeWelfare));
            IEmployeeWelfareHistory iEmployeeWelfareHistory =
                (IEmployeeWelfareHistory) mocks.CreateMock(typeof (IEmployeeWelfareHistory));
            Expect.Call(iEmployeeWelfare.GetEmployeeWelfareByAccountID(1)).Return(
                new EmployeeWelfare(
                    new EmployeeSocialSecurity(SocialSecurityTypeEnum.Null, 0.1m,
                                               Convert.ToDateTime("2008-1-1"), 0.2m, 0.3m, 0.4m),
                    new EmployeeAccumulationFund("123", 0.1m, Convert.ToDateTime("2008-1-1"), "123", 2)));

            Expect.Call(iEmployeeWelfare.UpdateEmployeeWelfareByAccountID(new EmployeeWelfare(null, null), 1)).
                IgnoreArguments().Return(3);
            Expect.Call(iEmployeeWelfareHistory.CreateEmployeeWelfareHistoryByAccountID(null, 1)).IgnoreArguments().Return(2);
            mocks.ReplayAll();
            SaveEmployeeWelfare saveEmployeeWelfare =
                new SaveEmployeeWelfare(1, SocialSecurityTypeEnum.TownInsurance, 0.1m, Convert.ToDateTime("2008-1-1"),
                                        "123", Convert.ToDateTime("2008-1-1"), 0.1m, "admin", "123", 2, 0.2m, 0.3m, 0.4m);
            saveEmployeeWelfare.MockIEmployeeWelfare = iEmployeeWelfare;
            saveEmployeeWelfare.MockIEmployeeWelfareHistroy = iEmployeeWelfareHistory;
            saveEmployeeWelfare.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("测试有记录时，不更新记录，不添加历史"), Ignore]
        public void SaveEmployeeWelfareTest4()
        {
            MockRepository mocks = new MockRepository();
            IEmployeeWelfare iEmployeeWelfare = (IEmployeeWelfare) mocks.CreateMock(typeof (IEmployeeWelfare));
            Expect.Call(iEmployeeWelfare.GetEmployeeWelfareByAccountID(1)).Return(
                new EmployeeWelfare(
                    new EmployeeSocialSecurity(SocialSecurityTypeEnum.TownInsurance, null,
                                               Convert.ToDateTime("2008-1-1"), null, null, null),
                    new EmployeeAccumulationFund("123", 0.1m, Convert.ToDateTime("2008-1-1"), "123", 2)));
            mocks.ReplayAll();
            SaveEmployeeWelfare saveEmployeeWelfare =
                new SaveEmployeeWelfare(1, SocialSecurityTypeEnum.TownInsurance, null, Convert.ToDateTime("2008-1-1"),
                                        "123", Convert.ToDateTime("2008-1-1"), 0.1m, "admin", "123", 2, 0.2m, 0.3m, 0.4m);
            saveEmployeeWelfare.MockIEmployeeWelfare = iEmployeeWelfare;
            saveEmployeeWelfare.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("抛出异常")]
        public void SaveEmployeeWelfareTest5()
        {
            MockRepository mocks = new MockRepository();
            IEmployeeWelfare iEmployeeWelfare = (IEmployeeWelfare) mocks.CreateMock(typeof (IEmployeeWelfare));
            Expect.Call(iEmployeeWelfare.GetEmployeeWelfareByAccountID(1)).Return(null);
            Expect.Call(iEmployeeWelfare.InsertEmployeeWelfareByAccountID(new EmployeeWelfare(null, null), 1)).
                IgnoreArguments().Throw(new Exception("异常"));

            mocks.ReplayAll();
            SaveEmployeeWelfare saveEmployeeWelfare =
                new SaveEmployeeWelfare(1, SocialSecurityTypeEnum.TownInsurance, 0.1m, Convert.ToDateTime("2008-1-1"),
                                        "123", Convert.ToDateTime("2008-1-1"), 0.1m, "admin", "123", 2, 0.2m, 0.3m, 0.4m);
            saveEmployeeWelfare.MockIEmployeeWelfare = iEmployeeWelfare;
            string expection = string.Empty;
            try
            {
                saveEmployeeWelfare.Excute();
            }
            catch (ApplicationException e)
            {
                expection=e.Message;
            }
            Assert.AreEqual("数据库访问错误", expection);
            mocks.VerifyAll();
        }

        [Test, Description("抛出异常")]
        public void SaveEmployeeWelfareTest6()
        {
            MockRepository mocks = new MockRepository();
            IEmployeeWelfare iEmployeeWelfare = (IEmployeeWelfare)mocks.CreateMock(typeof(IEmployeeWelfare));
            Expect.Call(iEmployeeWelfare.GetEmployeeWelfareByAccountID(1)).Return(null);
            Expect.Call(iEmployeeWelfare.InsertEmployeeWelfareByAccountID(new EmployeeWelfare(null, null), 1)).
                IgnoreArguments().Return(1);

            mocks.ReplayAll();
            SaveEmployeeWelfare saveEmployeeWelfare =
                new SaveEmployeeWelfare(1, SocialSecurityTypeEnum.TownInsurance, 0.1m, Convert.ToDateTime("2008-1-1"),
                                        "123", Convert.ToDateTime("2008-1-1"), 0.1m, "admin", "123", 2, 0.2m, 0.3m, 0.4m);
            saveEmployeeWelfare.MockIEmployeeWelfare = iEmployeeWelfare;
            string expection = string.Empty;
            try
            {
                saveEmployeeWelfare.Excute();
            }
            catch (ApplicationException e)
            {
                expection = e.Message;
            }
            Assert.AreEqual("数据库访问错误", expection);
            mocks.VerifyAll();
        }
    }
}