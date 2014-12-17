//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: EmployeeWelfareHistory.cs
// Creater:  Xue.wenlong
// Date:  2008-12-23
// Resume:
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class EmployeeWelfareHistory
    {
        private int _EmployeeWelfareHistoryID;
        private DateTime _OperationTime;
        private string _AccountsBackName;
        private EmployeeWelfare _EmployeeWelfare;

        public EmployeeWelfareHistory(EmployeeWelfare employeeWelfare, DateTime operationTime, string accountsBackName)
        {
            _EmployeeWelfare = employeeWelfare;
            _OperationTime = operationTime;
            _AccountsBackName = accountsBackName;
        }

        public EmployeeWelfareHistory(int employeeWelfareHistoryID, EmployeeWelfare employeeWelfare, DateTime operationTime, string accountsBackName)
            : this(employeeWelfare, operationTime, accountsBackName)
        {
            _EmployeeWelfareHistoryID = employeeWelfareHistoryID;
        }

        public DateTime OperationTime
        {
            get { return _OperationTime; }
            set { _OperationTime = value; }
        }

        public string AccountsBackName
        {
            get { return _AccountsBackName; }
            set { _AccountsBackName = value; }
        }

        public EmployeeWelfare EmployeeWelfare
        {
            get { return _EmployeeWelfare; }
            set { _EmployeeWelfare = value; }
        }

        public int EmployeeWelfareHistoryID
        {
            get { return _EmployeeWelfareHistoryID; }
            set { _EmployeeWelfareHistoryID = value; }
        }
    }
}