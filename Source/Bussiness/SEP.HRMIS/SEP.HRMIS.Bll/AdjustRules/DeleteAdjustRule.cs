//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: DeleteAdjustRule.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-31
// Resume: 
// ----------------------------------------------------------------


using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.AdjustRules
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAdjustRule : Transaction
    {
        private static IAdjustRule _AdjustRuleDal = new AdjustRuleDal();
        private static IEmployeeAdjustRule _EmployeeAdjustRuleDal = new EmployeeAdjustRuleDal();
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