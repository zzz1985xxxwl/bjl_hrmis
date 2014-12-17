//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: IAdjustRule.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-31
// Resume: 
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.Adjusts;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAdjustRule
    {
        /// <summary>
        /// 
        /// </summary>
        int InsertAdjustRule(AdjustRule adjustRule);
        /// <summary>
        /// 
        /// </summary>
        int UpdateAdjustRule(AdjustRule adjustRule);
        /// <summary>
        /// 
        /// </summary>
        int DeleteAdjustRule(int pKID);
        /// <summary>
        /// 
        /// </summary>
        AdjustRule GetAdjustRuleByAdjustRuleID(int pKID);
        /// <summary>
        /// 
        /// </summary>
        List<AdjustRule> GetAdjustRuleByNameLike(string name);
        /// <summary>
        /// 
        /// </summary>
        int CountAdjustRuleByNameDiffPKID(string name, int pkid);


    }
}