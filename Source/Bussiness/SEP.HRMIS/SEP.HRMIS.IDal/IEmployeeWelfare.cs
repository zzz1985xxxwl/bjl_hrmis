//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IEmployeeWelfare.cs
// Creater:  Xue.wenlong
// Date:  2008-12-24
// Resume:
// ----------------------------------------------------------------


using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IEmployeeWelfare
    {
        int InsertEmployeeWelfareByAccountID(EmployeeWelfare employeeWelfare, int accountID);
        int UpdateEmployeeWelfareByAccountID(EmployeeWelfare employeeWelfare, int accountID);
        EmployeeWelfare GetEmployeeWelfareByAccountID(int accountID);

        /// <summary>
        /// Dal≤‚ ‘
        /// </summary>
        int DeleteEmployeeWelfareByAccountID(int accountID);
    }
}