//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SaveTaxCutoffPoint.cs
// Creater:  Xue.wenlong
// Date:  2008-12-24
// Resume:保存起征点，无则新增，有则更新
// ----------------------------------------------------------------



using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.Tax
{
    public class SaveTaxCutoffPoint : Transaction
    {
        private readonly ITax _TaxDal = new TaxDal();
        private readonly decimal _TaxCutoffPoint;
        private readonly decimal _TaxForeignCutoffPoint;
        public SaveTaxCutoffPoint(decimal taxCutoffPoint, decimal taxForeignCutoffPoint)
        {
            _TaxCutoffPoint = taxCutoffPoint;
            _TaxForeignCutoffPoint = taxForeignCutoffPoint;
        }
        /// <summary>
        /// for test
        /// </summary>
        public SaveTaxCutoffPoint(decimal taxCutoffPoint, decimal taxForeignCutoffPoint,ITax mockTaxDal)
            : this(taxCutoffPoint, taxForeignCutoffPoint)
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
                if (_TaxDal.GetTaxCutoffPoint() == -1)
                {
                    _TaxDal.InsertTaxCutoffPoint(_TaxCutoffPoint);
                }
                else
                {
                    _TaxDal.UpdateTaxCutoffPoint(_TaxCutoffPoint);
                }
                if (_TaxDal.GetForeignTaxCutoffPoint() == -1)
                {
                    _TaxDal.InsertForeignTaxCutoffPoint(_TaxForeignCutoffPoint);
                }
                else
                {
                    _TaxDal.UpdateForeignTaxCutoffPoint(_TaxForeignCutoffPoint);
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}