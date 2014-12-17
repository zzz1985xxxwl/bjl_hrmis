//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AttendanceInAndOutRecordLog.cs
// 创建者: 刘丹
// 创建日期: 2008-10-23
// 概述: 考勤人员修改进出记录日志
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord
{
    [Serializable]
    public class AttendanceInAndOutRecordLog
    {
        private int _LogID;
        private int _EmployeeID;
        private string _EmployeeName;
        private DateTime _OldIOTime;
        private InOutStatusEnum _OldIOStatus;
        private DateTime _NewIOTime;
        private InOutStatusEnum _NewIOStatus;
        private OutInRecordOperateStatusEnum _OperateStatus;
        private string _Operator;
        private DateTime _OperateTime;
        private string _OperateReason;

        /// <summary>
        /// logid
        /// </summary>
        public int LogID
        {
            get { return _LogID; }
            set { _LogID = value; }
        }

        /// <summary>
        /// 员工id
        /// </summary>
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }

        /// <summary>
        /// 修改之前的进入时间
        /// </summary>
        public DateTime OldIOTime
        {
            get { return _OldIOTime; }
            set { _OldIOTime = value; }
        }

        /// <summary>
        /// 修改之前的状态
        /// </summary>
        public InOutStatusEnum OldIOStatus
        {
            get { return _OldIOStatus; }
            set { _OldIOStatus = value; }
        }

        /// <summary>
        /// 新的进入世界
        /// </summary>
        public DateTime NewIOTime
        {
            get { return _NewIOTime; }
            set { _NewIOTime = value; }
        }

        /// <summary>
        /// 新的进入状态
        /// </summary>
        public InOutStatusEnum NewIOStatus
        {
            get { return _NewIOStatus; }
            set { _NewIOStatus = value; }
        }

        /// <summary>
        /// 操作状态
        /// </summary>
        public OutInRecordOperateStatusEnum OperateStatus
        {
            get { return _OperateStatus; }
            set { _OperateStatus = value; }
        }

        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperateTime
        {
            get { return _OperateTime; }
            set { _OperateTime = value; }
        }

        /// <summary>
        /// 操作原因
        /// </summary>
        public string OperateReason
        {
            get { return _OperateReason; }
            set { _OperateReason = value; }
        }
    }
}
