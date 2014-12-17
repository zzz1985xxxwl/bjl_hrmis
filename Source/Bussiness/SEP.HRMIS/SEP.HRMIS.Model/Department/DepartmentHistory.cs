//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DepartmentHistory.cs
// 创建者: 王玥琦
// 创建日期: 2008-11-10
// 概述: 部门历史表
// ----------------------------------------------------------------

using System;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 记录部门历史
    /// </summary>
    [Serializable]
    public class DepartmentHistory
    {
        private int _DepartmentHistoryPKID;
        private Department _Department;
        private DateTime _OperationTime;
        private Account _Operator;

        /// <summary>
        /// 部门
        /// </summary>
        public Department Department
        {
            get
            {
                return _Department;
            }
            set
            {
                _Department = value;
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
        /// 部门历史ID
        /// </summary>
        public int DepartmentHistoryPKID
        {
            get { return _DepartmentHistoryPKID; }
            set { _DepartmentHistoryPKID = value; }
        }
    }
}
