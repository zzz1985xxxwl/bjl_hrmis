//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ITax.cs
// Creater:  Xue.wenlong
// Date:  2008-12-24
// Resume:
// ----------------------------------------------------------------


using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.IDal.PayModule
{
    

    ///<summary>
    ///</summary>
    public interface ITax
    {
        ///<summary>
        ///</summary>
        ///<param name="taxCutoffPoint"></param>
        ///<returns></returns>
        int InsertTaxCutoffPoint(decimal taxCutoffPoint);
        ///<summary>
        ///</summary>
        ///<param name="taxCutoffPoint"></param>
        ///<returns></returns>
        int UpdateTaxCutoffPoint(decimal taxCutoffPoint);
        ///<summary>
        ///</summary>
        ///<param name="taxForeignCutoffPoint"></param>
        ///<returns></returns>
        int InsertForeignTaxCutoffPoint(decimal taxForeignCutoffPoint);
        ///<summary>
        ///</summary>
        ///<param name="taxForeignCutoffPoint"></param>
        ///<returns></returns>
        int UpdateForeignTaxCutoffPoint(decimal taxForeignCutoffPoint);
        /// <summary>
        /// 得到起征点
        /// </summary>
        /// <returns>为空则返回-1</returns>
        decimal GetTaxCutoffPoint();
        /// <summary>
        /// 得到外国起征点
        /// </summary>
        /// <returns>为空则返回-1</returns>
        decimal GetForeignTaxCutoffPoint();

        ///<summary>
        ///</summary>
        ///<param name="bandMin"></param>
        ///<param name="taxRate"></param>
        ///<returns></returns>
        int  InsertTaxBand(decimal bandMin, decimal taxRate);
        ///<summary>
        ///</summary>
        ///<param name="taxBandID"></param>
        ///<param name="bandMin"></param>
        ///<param name="taxRate"></param>
        ///<returns></returns>
        int UpdateTaxBand(int taxBandID, decimal bandMin, decimal taxRate);
        ///<summary>
        ///</summary>
        ///<param name="taxBandID"></param>
        ///<returns></returns>
        int DeleteTaxBandByTaxBandID(int taxBandID);
        ///<summary>
        ///</summary>
        ///<param name="taxBandID"></param>
        ///<returns></returns>
        TaxBand GetTaxBandByTaxBandID(int taxBandID);
        /// <summary>
        /// 得到说阶，不包括起征点
        /// </summary>
        List<TaxBand> GetAllTaxBand();

        ///<summary>
        ///</summary>
        ///<param name="bandMin"></param>
        ///<returns></returns>
        int GetTaxBandCountByBindMin(decimal bandMin);
        ///<summary>
        ///</summary>
        ///<param name="taxBandID"></param>
        ///<param name="bandMin"></param>
        ///<returns></returns>
        int GetTaxBandCountByBindMinDiffPKID(int taxBandID, decimal bandMin);
    }
}