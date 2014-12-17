//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EmployeeHistory.cs
// ������: �����
// ��������: 2008-11-05
// ����: Ա����ʷ��
// ----------------------------------------------------------------

using System;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// Ա����ʷ
    /// </summary>
    [Serializable]
    public class EmployeeHistory
    {
        #region ˽�б���

        private int _EmployeeHistoryPKID;
        private Employee _Employee;
        private DateTime _OperationTime;
        private Account _Operator;
        private string _Remark;

        #endregion

        #region ���캯��
        /// <summary>
        /// Ϊ������ʷ��ʾԱ������
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="operationTime"></param>
        public EmployeeHistory(int accountID, DateTime operationTime)
        {
            _Employee = new Employee(accountID, EmployeeTypeEnum.All);
            _OperationTime = operationTime;
        }
        /// <summary>
        /// Ա����ʷ���캯��
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

        #region ����
        /// <summary>
        /// Ա����ʷPKID
        /// </summary>
        public int EmployeeHistoryPKID
        {
            get { return _EmployeeHistoryPKID; }
            set { _EmployeeHistoryPKID = value; }
        }


        /// <summary>
        /// Ա��
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
        /// ��ע
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
