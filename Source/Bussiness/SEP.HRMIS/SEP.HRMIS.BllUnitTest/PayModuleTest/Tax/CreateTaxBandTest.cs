//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CreateTaxBandTest.cs
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
    public class CreateTaxBandTest
    {
        private CreateTaxBand _TheTarget;
        private MockRepository _Mock;
        private ITax _ITax;
        [SetUp]
        public void SetUp()
        {
            _Mock = new MockRepository();
            _ITax = (ITax)_Mock.CreateMock(typeof(ITax));
        }

        [Test, Description("新增,成功")]
        public void Test1()
        {
            Expect.Call(_ITax.GetTaxBandCountByBindMin(10)).Return(0);
            Expect.Call(_ITax.InsertTaxBand(10,0.01m)).Return(1);
            _Mock.ReplayAll();
            _TheTarget = new CreateTaxBand(10,0.01m, _ITax);
            _TheTarget.Excute();
            _Mock.VerifyAll();
            Assert.AreEqual(1,_TheTarget.TaxBandID);
        }

        [Test, Description("新增，税阶下限重复")]
        public void Test2()
        {
            Expect.Call(_ITax.GetTaxBandCountByBindMin(10)).Return(1);
            _Mock.ReplayAll();
            _TheTarget = new CreateTaxBand(10, 0.01m, _ITax);
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
            Assert.AreEqual(0, _TheTarget.TaxBandID);
        }

        [Test, Description("异常")]
        public void Test3()
        {
            Expect.Call(_ITax.GetTaxBandCountByBindMin(10)).Return(0);
            Expect.Call(_ITax.InsertTaxBand(10, 0.01m)).Throw(new Exception());
            _Mock.ReplayAll();
            _TheTarget = new CreateTaxBand(10, 0.01m, _ITax);
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
            Assert.AreEqual(0, _TheTarget.TaxBandID);
        }
    }
}