//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SaveTaxCutoffPointTest.cs
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
    public class SaveTaxCutoffPointTest
    {
        private SaveTaxCutoffPoint _TheTarget;
        private MockRepository _Mock;
        private ITax _ITax;
        [SetUp]
        public void SetUp()
        {
            _Mock = new MockRepository();
            _ITax = (ITax)_Mock.CreateMock(typeof(ITax));
        }
        
        [Test, Description("新增")]
        public void SaveTaxCutoffPointTest1()
        {
            Expect.Call(_ITax.InsertTaxCutoffPoint(10)).Return(1);
            Expect.Call(_ITax.InsertForeignTaxCutoffPoint(20)).Return(1);
            Expect.Call(_ITax.GetTaxCutoffPoint()).Return(-1);
            Expect.Call(_ITax.GetForeignTaxCutoffPoint()).Return(-1);

            _Mock.ReplayAll();
            _TheTarget = new SaveTaxCutoffPoint(10, 20,_ITax);
            _TheTarget.Excute();
            _Mock.VerifyAll();
        }
        [Test, Description("修改")]
        public void SaveTaxCutoffPointTest2()
        {
            Expect.Call(_ITax.UpdateTaxCutoffPoint(10)).Return(1);
            Expect.Call(_ITax.UpdateForeignTaxCutoffPoint(20)).Return(1);
            Expect.Call(_ITax.GetTaxCutoffPoint()).Return(2);
            Expect.Call(_ITax.GetForeignTaxCutoffPoint()).Return(2);
            _Mock.ReplayAll();
            _TheTarget = new SaveTaxCutoffPoint(10, 20, _ITax);
            _TheTarget.Excute();
            _Mock.VerifyAll();
        }

        [Test, Description("exception")]
        public void SaveTaxCutoffPointTest3()
        {
            Expect.Call(_ITax.GetTaxCutoffPoint()).Throw(new Exception());
            _Mock.ReplayAll();
            _TheTarget = new SaveTaxCutoffPoint(10, 20, _ITax);
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