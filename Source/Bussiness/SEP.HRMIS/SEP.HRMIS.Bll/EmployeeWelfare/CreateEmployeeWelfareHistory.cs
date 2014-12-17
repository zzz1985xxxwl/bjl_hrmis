//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CreateEmployeeWelfareHistoryByAccountID.cs
// Creater:  Xue.wenlong
// Date:  2008-12-24
// Resume:为员工福利记录历史
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 记录员工福利历史
    /// </summary>
    public class CreateEmployeeWelfareHistoryByAccountID : Transaction
    {
        private static IEmployeeWelfareHistory _EmployeeWelfareHistoryDal;

        private readonly EmployeeWelfareHistory _EmployeeWelfareHistory;
        private readonly int _EmployeeID;
        /// <summary>
        /// 记录员工福利历史构造函数
        /// </summary>
        /// <param name="employeeWelfare"></param>
        /// <param name="employeeID"></param>
        /// <param name="operationName"></param>
        /// <param name="dt"></param>
        /// <param name="MockEmployeeWelfareHistory"></param>
        public CreateEmployeeWelfareHistoryByAccountID(EmployeeWelfare employeeWelfare, int employeeID, string operationName,
                                            DateTime dt, IEmployeeWelfareHistory MockEmployeeWelfareHistory)
        {
            _EmployeeWelfareHistoryDal = MockEmployeeWelfareHistory;
            _EmployeeID = employeeID;
            _EmployeeWelfareHistory = new EmployeeWelfareHistory(employeeWelfare, dt, operationName);
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            _EmployeeWelfareHistoryDal.CreateEmployeeWelfareHistoryByAccountID(_EmployeeWelfareHistory, _EmployeeID);
        }
    }
}