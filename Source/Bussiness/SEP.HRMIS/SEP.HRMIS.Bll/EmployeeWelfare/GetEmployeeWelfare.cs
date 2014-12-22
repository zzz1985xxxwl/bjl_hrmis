//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: GetEmployeeWelfare.cs
// Creater:  Xue.wenlong
// Date:  2008-12-24
// Resume:得到福利信息
// ----------------------------------------------------------------

using System.Collections.Generic;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 获得员工福利
    /// </summary>
    public class GetEmployeeWelfare
    {
        private static IEmployeeWelfareHistory _EmployeeWelfareHistoryDal =
            new EmployeeWelfareHistoryDal();

        private static IEmployeeWelfare _EmployeeWelfareDal = new EmployeeWelfareDal();
        /// <summary>
        /// 构造函数
        /// </summary>
        public GetEmployeeWelfare()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public GetEmployeeWelfare(IEmployeeWelfareHistory iEmployeeWelfareHistory, IEmployeeWelfare iEmployeeWelfare)
        {
            _EmployeeWelfareHistoryDal = iEmployeeWelfareHistory;
            _EmployeeWelfareDal = iEmployeeWelfare;

        }
        /// <summary>
        /// 员工福利更新历史
        /// </summary>
        public List<EmployeeWelfareHistory> GetEmployeeWelfareHistoryByAccountID(int employeeID)
        {
            return _EmployeeWelfareHistoryDal.GetEmployeeWelfareHistoryByAccountID(employeeID);
        }
        /// <summary>
        /// 员工福利
        /// </summary>
        public EmployeeWelfare GetEmployeeWelfareByAccountID(int employeeID)
        {
            return _EmployeeWelfareDal.GetEmployeeWelfareByAccountID(employeeID);
        }
    }
}