//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DeleteTaxBandTest.cs
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
    public class DeleteTaxBandTest
    {
        private DeleteTaxBand _TheTarget;
        private MockRepository _Mock;
        private ITax _ITax;
        [SetUp]
        public void SetUp()
        {
            _Mock = new MockRepository();
            _ITax = (ITax)_Mock.CreateMock(typeof(ITax));
        }

        [Test, Description("É¾³ý")]
        public void DeleteTaxBandTest1()
        {
            Expect.Call(_ITax.DeleteTaxBandByTaxBandID(1)).Return(1);
            _Mock.ReplayAll();
            _TheTarget = new DeleteTaxBand(1, _ITax);
            _TheTarget.Excute();
            _Mock.VerifyAll();
        }

        [Test, Description("Òì³£")]
        public void DeleteTaxBandTest2()
        {
            Expect.Call(_ITax.DeleteTaxBandByTaxBandID(1)).Throw(new Exception());
            _Mock.ReplayAll();
            _TheTarget = new DeleteTaxBand(1, _ITax);
            string expection = string.Empty;
            try
            {
                _TheTarget.Excute();
            }
            catch (Exception e)
            {
                expection = e.Message;
            }
            Assert.AreEqual("Êý¾Ý¿â·ÃÎÊ´íÎó", expection);
            _Mock.VerifyAll();
        }
    }
}