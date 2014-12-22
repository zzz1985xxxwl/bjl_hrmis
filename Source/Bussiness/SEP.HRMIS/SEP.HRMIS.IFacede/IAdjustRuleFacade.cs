//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: IAdjustRuleFacade.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-31
// Resume: 
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.Adjusts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAdjustRuleFacade
    {
        /// <summary>
        /// 
        /// </summary>
        void InsertAdjustRule(AdjustRule adjustRule);
        /// <summary>
        /// 
        /// </summary>
        void UpdateAdjustRule(AdjustRule adjustRule);
        /// <summary>
        /// 
        /// </summary>
        void DeleteAdjustRule(int pKID);
        /// <summary>
        /// 
        /// </summary>
        AdjustRule GetAdjustRuleByAdjustRuleID(int pKID);
        /// <summary>
        /// 
        /// </summary>
        List<AdjustRule> GetAdjustRuleByNameLike(string name);
    }
}