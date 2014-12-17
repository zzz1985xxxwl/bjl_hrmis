//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: TaxFacade.cs
// Creater:  Xue.wenlong
// Date:  2008-12-24
// Resume:
// ----------------------------------------------------------------
using SEP.HRMIS.Bll.PayModule.Tax;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Facade.PayModule
{
    ///<summary>
    ///</summary>
    public class TaxFacade : ITaxFacade
    {
        private readonly GetTax _GetTax = new GetTax();
        /// <summary>
        /// 保存起征点
        /// </summary>
        /// <param name="taxCutoffPoint">起征点，不可小于0</param>
        /// <param name="taxForeignCutoffPoint"></param>
        public void SaveTaxCutoffPoint(decimal taxCutoffPoint,decimal taxForeignCutoffPoint)
        {
            new SaveTaxCutoffPoint(taxCutoffPoint,taxForeignCutoffPoint).Excute();
        }
        /// <summary>
        /// 新增税阶
        /// </summary>
        /// <param name="bandMin">下限，即超过起征点多少</param>
        /// <param name="taxRate">税率</param>
        /// <returns>pkid</returns>
        public int CreateTaxBand(decimal bandMin, decimal taxRate)
        {
            CreateTaxBand createTaxBand = new CreateTaxBand(bandMin, taxRate);
            createTaxBand.Excute();
            return createTaxBand.TaxBandID;
        }
        /// <summary>
        /// 更新税阶
        /// </summary>
        /// <param name="taxBandID">pkid</param>
        /// <param name="bandMin">下限，即超过起征点多少</param>
        /// <param name="taxRate">税率</param>
        public void UpdateTaxBand(int taxBandID, decimal bandMin, decimal taxRate)
        {
            new UpdateTaxBand(taxBandID, bandMin, taxRate).Excute();
        }
        /// <summary>
        /// 删除税阶
        /// </summary>
        /// <param name="taxBandID">pkid</param>
        public void DeleteTaxBand(int taxBandID)
        {
            new DeleteTaxBand(taxBandID).Excute();
        }

        #region Get
        /// <summary>
        /// 通过pkid得到税阶
        /// </summary>
        /// <param name="taxBandID">pkid</param>
        /// <returns>税阶，只包括下限，税率</returns>
        public TaxBand GetTaxBandByTaxBandID(int taxBandID)
        {
            return _GetTax.GetTaxBandByTaxBandID(taxBandID);
        }
        /// <summary>
        /// 税的所有信息
        /// </summary>
        /// <returns>税，包括起征点，所有的税阶，税阶的上下限，税率</returns>
        public IndividualIncomeTax GetIndividualIncomeTax()
        {
            return _GetTax.GetIndividualIncomeTax();
        }

        #endregion
    }
}