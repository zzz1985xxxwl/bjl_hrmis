//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: DeleteAdjustRule.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-31
// Resume: 
// ----------------------------------------------------------------

using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.AdjustRules
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAdjustRule : Transaction
    {
        private static IAdjustRule _AdjustRuleDal = DalFactory.DataAccess.CreateAdjustRule();
        private static IEmployeeAdjustRule _EmployeeAdjustRuleDal = DalFactory.DataAccess.CreateEmployeeAdjustRule();
        private readonly int _AdjustRuleID;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public DeleteAdjustRule(int id)
        {
            _AdjustRuleID = id;
        }

        /// <summary>
        /// test
        /// </summary>
        public DeleteAdjustRule(int id, IEmployeeAdjustRule employeerule, IAdjustRule rule)
        {
            _AdjustRuleID = id;
            _AdjustRuleDal = rule;
            _EmployeeAdjustRuleDal = employeerule;
        }

        protected override void Validation()
        {
            if (_EmployeeAdjustRuleDal.CountAdjustRuleUsedByAdjustRuleID(_AdjustRuleID) > 0)
            {
                HrmisUtility.ThrowException(HrmisUtility._AdjustRule_Used);
            }
        }

        protected override void ExcuteSelf()
        {
            _AdjustRuleDal.DeleteAdjustRule(_AdjustRuleID);
        }
    }
}