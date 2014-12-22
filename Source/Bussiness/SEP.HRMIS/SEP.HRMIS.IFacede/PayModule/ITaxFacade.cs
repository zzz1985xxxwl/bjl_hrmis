//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ITax.cs
// Creater:  Xue.wenlong
// Date:  2008-12-24
// Resume:
// ----------------------------------------------------------------

using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.IFacede.PayModule
{
    ///<summary>
    ///</summary>
    public interface ITaxFacade
    {
        ///<summary>
        ///</summary>
        ///<param name="taxCutoffPoint"></param>
        void SaveTaxCutoffPoint(decimal taxCutoffPoint, decimal taxForeignCutoffPoint);
        ///<summary>
        ///</summary>
        ///<param name="bandMin"></param>
        ///<param name="taxRate"></param>
        ///<returns></returns>
        int CreateTaxBand(decimal bandMin, decimal taxRate);
        ///<summary>
        ///</summary>
        ///<param name="taxBandID"></param>
        ///<param name="bandMin"></param>
        ///<param name="taxRate"></param>
        void UpdateTaxBand(int taxBandID, decimal bandMin, decimal taxRate);
        ///<summary>
        ///</summary>
        ///<param name="taxBandID"></param>
        void DeleteTaxBand(int taxBandID);
        ///<summary>
        ///</summary>
        ///<param name="taxBandID"></param>
        ///<returns></returns>
        TaxBand GetTaxBandByTaxBandID(int taxBandID);
        ///<summary>
        ///</summary>
        ///<returns></returns>
        IndividualIncomeTax GetIndividualIncomeTax();
    }
}