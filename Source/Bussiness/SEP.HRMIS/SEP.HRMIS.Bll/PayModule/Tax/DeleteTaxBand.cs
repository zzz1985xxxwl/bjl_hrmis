//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DeleteTaxBandByTaxBandID.cs
// Creater:  Xue.wenlong
// Date:  2008-12-24
// Resume:É¾³ýË°½×
// ----------------------------------------------------------------



using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.Tax
{
    public class DeleteTaxBand : Transaction
    {
        private readonly ITax _TaxDal = new TaxDal();
        private readonly int _TaxBandID;

        public DeleteTaxBand(int taxBandID)
        {
            _TaxBandID = taxBandID;
        }

        /// <summary>
        /// for test
        /// </summary>
        public DeleteTaxBand(int taxBandID, ITax mockTaxDal) : this(taxBandID)
        {
            _TaxDal = mockTaxDal;
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _TaxDal.DeleteTaxBandByTaxBandID(_TaxBandID);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}