//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DepartmentHistory.cs
// ������: ���h��
// ��������: 2008-11-10
// ����: ������ʷ��
// ----------------------------------------------------------------

using System;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��¼������ʷ
    /// </summary>
    [Serializable]
    public class DepartmentHistory
    {
        private int _DepartmentHistoryPKID;
        private Department _Department;
        private DateTime _OperationTime;
        private Account _Operator;

        /// <summary>
        /// ����
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
        /// ����ʱ��
        /// </summary>
        public DateTime OperationTime
        {
            get { return _OperationTime; }
            set { _OperationTime = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public Account Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }
        /// <summary>
        /// ������ʷID
        /// </summary>
        public int DepartmentHistoryPKID
        {
            get { return _DepartmentHistoryPKID; }
            set { _DepartmentHistoryPKID = value; }
        }
    }
}
