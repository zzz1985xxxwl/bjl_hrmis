//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CreateTaxBand .cs
// Creater:  Xue.wenlong
// Date:  2008-12-24
// Resume:新增税阶
// ----------------------------------------------------------------


using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.Tax
{
    public class CreateTaxBand : Transaction
    {
        private readonly ITax _TaxDal = PayModuleDataAccess.CreateTax();
        private int _TaxBandID;
        private readonly decimal _BandMin;
        private readonly decimal _TaxRate;

        public CreateTaxBand(decimal bandMin, decimal taxRate)
        {
            _BandMin = bandMin;
            _TaxRate = taxRate;
        }

        /// <summary>
        /// for test
        /// </summary>
        public CreateTaxBand(decimal bandMin, decimal taxRate, ITax mockTaxDal) : this(bandMin, taxRate)
        {
            _TaxDal = mockTaxDal;
        }

        protected override void Validation()
        {
            //判断是否已有相同下限的税阶，有则抛错
            if (_TaxDal.GetTaxBandCountByBindMin(_BandMin) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._TaxBand_BindMin_Repeat);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _TaxBandID = _TaxDal.InsertTaxBand(_BandMin, _TaxRate);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        public int TaxBandID
        {
            get { return _TaxBandID; }
        }
    }
}