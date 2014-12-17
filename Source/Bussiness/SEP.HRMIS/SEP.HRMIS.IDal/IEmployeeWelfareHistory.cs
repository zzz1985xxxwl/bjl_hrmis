//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IEmployeeWelfareHistory.cs
// Creater:  Xue.wenlong
// Date:  2008-12-24
// Resume:
// ----------------------------------------------------------------


using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IEmployeeWelfareHistory
    {
        List<EmployeeWelfareHistory> GetEmployeeWelfareHistoryByAccountID(int accountID);
        int CreateEmployeeWelfareHistoryByAccountID(EmployeeWelfareHistory employeeWelfareHistory, int accountID);
        /// <summary>
        /// test
        /// </summary>
        int DeleteEmployeeWelfareHistoryByAccountID(int accountID);
    }
}