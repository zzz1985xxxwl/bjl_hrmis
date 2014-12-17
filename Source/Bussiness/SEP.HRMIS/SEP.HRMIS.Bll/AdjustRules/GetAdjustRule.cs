//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: GetAdjustRule.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-31
// Resume: 
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Adjusts;

namespace SEP.HRMIS.Bll.AdjustRules
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAdjustRule
    {
        private static readonly IAdjustRule _AdjustRuleDal = DalFactory.DataAccess.CreateAdjustRule();

        /// <summary>
        /// 
        /// </summary>
        public AdjustRule GetAdjustRuleByAdjustRuleID(int pKID)
        {
            return _AdjustRuleDal.GetAdjustRuleByAdjustRuleID(pKID);
        }

        /// <summary>
        /// 
        /// </summary>
        public List<AdjustRule> GetAdjustRuleByNameLike(string name)
        {
            return _AdjustRuleDal.GetAdjustRuleByNameLike(name);
        }
    }
}