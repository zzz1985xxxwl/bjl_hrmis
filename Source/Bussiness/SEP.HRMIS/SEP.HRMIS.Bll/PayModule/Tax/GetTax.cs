//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: GetTax.cs
// Creater:  Xue.wenlong
// Date:  2008-12-24
// Resume:
// ----------------------------------------------------------------



using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.Tax
{
    public class GetTax
    {
        private readonly ITax _TaxDal = new TaxDal();

        public GetTax()
        {
        }

        /// <summary>
        /// for test
        /// </summary>
        public GetTax(ITax mockTaxDal)
        {
            _TaxDal = mockTaxDal;
        }

        public TaxBand GetTaxBandByTaxBandID(int taxBandID)
        {
            return _TaxDal.GetTaxBandByTaxBandID(taxBandID);
        }

        public IndividualIncomeTax GetIndividualIncomeTax()
        {
            IndividualIncomeTax individualIncomeTax =
                new IndividualIncomeTax(GetTaxCutoffPoint(),GetForeignTaxCutoffPoint(), _TaxDal.GetAllTaxBand());
            individualIncomeTax.GetBandMax();
            return individualIncomeTax;
        }

        private decimal GetTaxCutoffPoint()
        {
            decimal d = _TaxDal.GetTaxCutoffPoint();
            return d == -1 ? 0 : d;
        }
        private decimal GetForeignTaxCutoffPoint()
        {
            decimal d = _TaxDal.GetForeignTaxCutoffPoint();
            return d == -1 ? 0 : d;
        }
    }
}