//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: UpdateTaxBand.cs
// Creater:  Xue.wenlong
// Date:  2008-12-24
// Resume:更新税阶
// ----------------------------------------------------------------


using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.Tax
{
    public class UpdateTaxBand : Transaction
    {
        private readonly ITax _TaxDal = new TaxDal();
        private readonly int _TaxBandID;
        private readonly decimal _BandMin;
        private readonly decimal _TaxRate;

        public UpdateTaxBand(int taxBandID, decimal bandMin, decimal taxRate)
        {
            _TaxBandID = taxBandID;
            _BandMin = bandMin;
            _TaxRate = taxRate;
        }

        /// <summary>
        /// for test
        /// </summary>
        public UpdateTaxBand(int taxBandID, decimal bandMin, decimal taxRate, ITax mockTaxDal)
            : this(taxBandID, bandMin, taxRate)
        {
            _TaxDal = mockTaxDal;
        }

        protected override void Validation()
        {
            //判断是否已有相同下限的税阶，有则抛错
            if (_TaxDal.GetTaxBandCountByBindMinDiffPKID(_TaxBandID,_BandMin) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._TaxBand_BindMin_Repeat);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _TaxDal.UpdateTaxBand(_TaxBandID, _BandMin, _TaxRate);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}