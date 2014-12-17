//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeHistory.cs
// 创建者: 杨俞彬
// 创建日期: 2008-11-05
// 概述: 员工历史表
// ----------------------------------------------------------------

using System;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 员工历史
    /// </summary>
    [Serializable]
    public class EmployeeHistory
    {
        #region 私有变量

        private int _EmployeeHistoryPKID;
        private Employee _Employee;
        private DateTime _OperationTime;
        private Account _Operator;
        private string _Remark;

        #endregion

        #region 构造函数
        /// <summary>
        /// 为部门历史显示员工建立
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="operationTime"></param>
        public EmployeeHistory(int accountID, DateTime operationTime)
        {
            _Employee = new Employee(accountID, EmployeeTypeEnum.All);
            _OperationTime = operationTime;
        }
        /// <summary>
        /// 员工历史构造函数
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="operationTime"></param>
        /// <param name="Operator"></param>
        /// <param name="remark"></param>
        public EmployeeHistory(Employee employee, DateTime operationTime, Account Operator, string remark)
        {
            _Employee = employee;
            _OperationTime = operationTime;
            _Operator = Operator;
            _Remark = remark;
        }

        #endregion

        #region 属性
        /// <summary>
        /// 员工历史PKID
        /// </summary>
        public int EmployeeHistoryPKID
        {
            get { return _EmployeeHistoryPKID; }
            set { _EmployeeHistoryPKID = value; }
        }


        /// <summary>
        /// 员工
        /// </summary>
        public Employee Employee
        {
            get
            {
                return _Employee;
            }
            set
            {
                _Employee = value;
            }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime
        {
            get { return _OperationTime; }
            set { _OperationTime = value; }
        }

        /// <summary>
        /// 操作人
        /// </summary>
        public Account Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }

        #endregion
    }
}
