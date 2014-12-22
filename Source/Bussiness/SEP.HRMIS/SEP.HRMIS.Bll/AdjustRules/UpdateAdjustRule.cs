//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: UpdateAdjustRule.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-31
// Resume: 
// ----------------------------------------------------------------


using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.AdjustRules
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAdjustRule : Transaction
    {
        private static IAdjustRule _AdjustRuleDal = new AdjustRuleDal();
        private readonly AdjustRule _AdjustRule;

        /// <summary>
        /// 
        /// </summary>
        public UpdateAdjustRule(AdjustRule adjustRule)
        {
            _AdjustRule = adjustRule;
        }

        /// <summary>
        /// test
        /// </summary>
        public UpdateAdjustRule(AdjustRule adjustRule, IAdjustRule ruledal)
        {
            _AdjustRule = adjustRule;
            _AdjustRuleDal = ruledal;
        }

        protected override void Validation()
        {
            if (_AdjustRuleDal.GetAdjustRuleByAdjustRuleID(_AdjustRule.AdjustRuleID) == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._AdjustRule_Not_Exit);
            }
            else if (_AdjustRuleDal.CountAdjustRuleByNameDiffPKID(_AdjustRule.AdjustRuleName, _AdjustRule.AdjustRuleID) >
                     0)
            {
                HrmisUtility.ThrowException(HrmisUtility._AdjustRule_Name_Repeat);
            }
        }

        protected override void ExcuteSelf()
        {
            _AdjustRuleDal.UpdateAdjustRule(_AdjustRule);
        }
    }
}