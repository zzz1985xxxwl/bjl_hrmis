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
        /// ����������
        /// </summary>
        /// <param name="taxCutoffPoint">�����㣬����С��0</param>
        /// <param name="taxForeignCutoffPoint"></param>
        public void SaveTaxCutoffPoint(decimal taxCutoffPoint,decimal taxForeignCutoffPoint)
        {
            new SaveTaxCutoffPoint(taxCutoffPoint,taxForeignCutoffPoint).Excute();
        }
        /// <summary>
        /// ����˰��
        /// </summary>
        /// <param name="bandMin">���ޣ����������������</param>
        /// <param name="taxRate">˰��</param>
        /// <returns>pkid</returns>
        public int CreateTaxBand(decimal bandMin, decimal taxRate)
        {
            CreateTaxBand createTaxBand = new CreateTaxBand(bandMin, taxRate);
            createTaxBand.Excute();
            return createTaxBand.TaxBandID;
        }
        /// <summary>
        /// ����˰��
        /// </summary>
        /// <param name="taxBandID">pkid</param>
        /// <param name="bandMin">���ޣ����������������</param>
        /// <param name="taxRate">˰��</param>
        public void UpdateTaxBand(int taxBandID, decimal bandMin, decimal taxRate)
        {
            new UpdateTaxBand(taxBandID, bandMin, taxRate).Excute();
        }
        /// <summary>
        /// ɾ��˰��
        /// </summary>
        /// <param name="taxBandID">pkid</param>
        public void DeleteTaxBand(int taxBandID)
        {
            new DeleteTaxBand(taxBandID).Excute();
        }

        #region Get
        /// <summary>
        /// ͨ��pkid�õ�˰��
        /// </summary>
        /// <param name="taxBandID">pkid</param>
        /// <returns>˰�ף�ֻ�������ޣ�˰��</returns>
        public TaxBand GetTaxBandByTaxBandID(int taxBandID)
        {
            return _GetTax.GetTaxBandByTaxBandID(taxBandID);
        }
        /// <summary>
        /// ˰��������Ϣ
        /// </summary>
        /// <returns>˰�����������㣬���е�˰�ף�˰�׵������ޣ�˰��</returns>
        public IndividualIncomeTax GetIndividualIncomeTax()
        {
            return _GetTax.GetIndividualIncomeTax();
        }

        #endregion
    }
}