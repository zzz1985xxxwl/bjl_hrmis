//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: GetTaxTest.cs
// Creater:  Xue.wenlong
// Date:  2008-12-27
// Resume:
// ----------------------------------------------------------------
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.PayModule.Tax;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.BllUnitTest.PayModuleTest.Tax
{
    [TestFixture]
    public class GetTaxTest
    {
        private GetTax _TheTarget;
        private MockRepository _Mock;
        private ITax _ITax;

        [SetUp]
        public void SetUp()
        {
            _Mock = new MockRepository();
            _ITax = (ITax) _Mock.CreateMock(typeof (ITax));
        }

        [Test, Description("GetTaxBandByTaxBandID")]
        public void Test0()
        {
            TaxBand taxBand = new TaxBand(0, 0.01m);
            Expect.Call(_ITax.GetTaxBandByTaxBandID(1)).Return(taxBand);
            _Mock.ReplayAll();
            _TheTarget = new GetTax(_ITax);
            TaxBand actual = _TheTarget.GetTaxBandByTaxBandID(1);
            _Mock.VerifyAll();
            Assert.AreEqual(taxBand, actual);
        }

        [Test, Description("GetIndividualIncomeTax,没有起征点")]
        public void Test1()
        {
            Expect.Call(_ITax.GetTaxCutoffPoint()).Return(-1);
            Expect.Call(_ITax.GetForeignTaxCutoffPoint()).Return(-1);
            Expect.Call(_ITax.GetAllTaxBand()).Return(null);
            _Mock.ReplayAll();
            _TheTarget = new GetTax(_ITax);
            IndividualIncomeTax actual = _TheTarget.GetIndividualIncomeTax();
            _Mock.VerifyAll();
            Assert.AreEqual(0, actual.TaxCutoffPoint);
            Assert.AreEqual(0, actual.ForeignTaxCutoffPoint);

            Assert.IsNull(actual.TaxBands);
        }

        [Test, Description("GetIndividualIncomeTax,有起征点,测试上限是否正确，并测试排序")]
        public void Test2()
        {
            List<TaxBand> expect = new List<TaxBand>();
            TaxBand taxBand1 = new TaxBand(0, 0.01m);
            taxBand1.BandMax = 500;
            TaxBand taxBand2 = new TaxBand(500, 0.02m);
            expect.Add(taxBand2);
            expect.Add(taxBand1);
            List<TaxBand> taxBandList = new List<TaxBand>();
            foreach (TaxBand band in expect)
            {
                taxBandList.Add(new TaxBand(band.BandMin, band.TaxRate));
            }
            Expect.Call(_ITax.GetTaxCutoffPoint()).Return(2000);
            Expect.Call(_ITax.GetForeignTaxCutoffPoint()).Return(4000);
            Expect.Call(_ITax.GetAllTaxBand()).Return(taxBandList);
            _Mock.ReplayAll();
            _TheTarget = new GetTax(_ITax);
            IndividualIncomeTax actual = _TheTarget.GetIndividualIncomeTax();
            _Mock.VerifyAll();
            Assert.AreEqual(2000, actual.TaxCutoffPoint);
            Assert.AreEqual(4000, actual.ForeignTaxCutoffPoint);
            Assert.AreEqual(2, actual.TaxBands.Count);
            AssertTaxBand(taxBand1, actual.TaxBands[0]);
            AssertTaxBand(taxBand2, actual.TaxBands[1]);
            Assert.AreEqual("超过0元至500元", actual.TaxBands[0].TaxBandRange);
            Assert.AreEqual("超过500元至----元", actual.TaxBands[1].TaxBandRange);
        }

        private static void AssertTaxBand(TaxBand expect, TaxBand actual)
        {
            Assert.AreEqual(expect.BandMin, actual.BandMin);
            Assert.AreEqual(expect.BandMax, actual.BandMax);
            Assert.AreEqual(expect.TaxRate, actual.TaxRate);
        }
    }
}