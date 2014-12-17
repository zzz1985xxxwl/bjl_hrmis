//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: IEmployeeAdjustRule.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-03
// Resume: 
// ----------------------------------------------------------------

using SEP.HRMIS.Model.Adjusts;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmployeeAdjustRule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        AdjustRule GetAdjustRuleByAccountID(int accoutid);

        /// <summary>
        /// 
        /// </summary>
        int Insert(int accountid, int adjustRuleID);

        /// <summary>
        /// 
        /// </summary>
        int UpdateEmployeeAdjustRuleByAccountID(int accountID, int adjustRuleID);

        /// <summary>
        /// 
        /// </summary>
        int DeleteEmployeeAdjustRuleByAccountID(int accountID);
        /// <summary>
        /// 
        /// </summary>
        int CountAdjustRuleUsedByAdjustRuleID(int ruleID);

    }
}