//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: GetEmployeeWelfare.cs
// Creater:  Xue.wenlong
// Date:  2008-12-24
// Resume:�õ�������Ϣ
// ----------------------------------------------------------------

using System.Collections.Generic;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ���Ա������
    /// </summary>
    public class GetEmployeeWelfare
    {
        private static IEmployeeWelfareHistory _EmployeeWelfareHistoryDal =
            new EmployeeWelfareHistoryDal();

        private static IEmployeeWelfare _EmployeeWelfareDal = new EmployeeWelfareDal();
        /// <summary>
        /// ���캯��
        /// </summary>
        public GetEmployeeWelfare()
        {
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        public GetEmployeeWelfare(IEmployeeWelfareHistory iEmployeeWelfareHistory, IEmployeeWelfare iEmployeeWelfare)
        {
            _EmployeeWelfareHistoryDal = iEmployeeWelfareHistory;
            _EmployeeWelfareDal = iEmployeeWelfare;

        }
        /// <summary>
        /// Ա������������ʷ
        /// </summary>
        public List<EmployeeWelfareHistory> GetEmployeeWelfareHistoryByAccountID(int employeeID)
        {
            return _EmployeeWelfareHistoryDal.GetEmployeeWelfareHistoryByAccountID(employeeID);
        }
        /// <summary>
        /// Ա������
        /// </summary>
        public EmployeeWelfare GetEmployeeWelfareByAccountID(int employeeID)
        {
            return _EmployeeWelfareDal.GetEmployeeWelfareByAccountID(employeeID);
        }
    }
}