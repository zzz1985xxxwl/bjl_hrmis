//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: IEmployeeAdjustRuleFacade.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-04
// Resume: 
// ----------------------------------------------------------------

using SEP.HRMIS.Model.Adjusts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmployeeAdjustRuleFacade
    {
        /// <summary>
        /// 
        /// </summary>
        AdjustRule GetAdjustRuleByAccountID(int id);
    }
}