//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: UpdateTaxBandTest.cs
// Creater:  Xue.wenlong
// Date:  2008-12-27
// Resume:
// ----------------------------------------------------------------

using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.PayModule.Tax;
using SEP.HRMIS.IDal.PayModule;

namespace SEP.HRMIS.BllUnitTest.PayModuleTest.Tax
{
    [TestFixture]
    public class UpdateTaxBandTest
    {
        private UpdateTaxBand _TheTarget;
        private MockRepository _Mock;
        private ITax _ITax;
        [SetUp]
        public void SetUp()
        {
            _Mock = new MockRepository();
            _ITax = (ITax)_Mock.CreateMock(typeof(ITax));
        }

        [Test, Description("更新")]
        public void Test1()
        {
            Expect.Call(_ITax.GetTaxBandCountByBindMinDiffPKID(2, 10)).Return(0);
            Expect.Call(_ITax.UpdateTaxBand(2,10, 0.01m)).Return(1);
            _Mock.ReplayAll();
            _TheTarget = new UpdateTaxBand(2,10, 0.01m, _ITax);
            _TheTarget.Excute();
            _Mock.VerifyAll();
        }

        [Test, Description("更新,下限重复")]
        public void Test3()
        {
            Expect.Call(_ITax.GetTaxBandCountByBindMinDiffPKID(2, 10)).Return(1);
            _Mock.ReplayAll();
            _TheTarget = new UpdateTaxBand(2, 10, 0.01m, _ITax);
            string expection = string.Empty;
            try
            {
                _TheTarget.Excute();
            }
            catch (ApplicationException e)
            {
                expection = e.Message;
            }
            Assert.AreEqual("税阶下限重复", expection);
            _Mock.VerifyAll();
        }

        [Test, Description("异常")]
        public void Test2()
        {
            Expect.Call(_ITax.GetTaxBandCountByBindMinDiffPKID(2, 10)).Return(0);
            Expect.Call(_ITax.UpdateTaxBand(2,10, 0.01m)).Throw(new Exception());
            _Mock.ReplayAll();
            _TheTarget = new UpdateTaxBand(2,10, 0.01m, _ITax);
            string expection = string.Empty;
            try
            {
                _TheTarget.Excute();
            }
            catch (Exception e)
            {
                expection = e.Message;
            }
            Assert.AreEqual("数据库访问错误", expection);
            _Mock.VerifyAll();
        }
    }
}