//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: LaterAttendance.cs
// 创建者: 倪豪
// 创建日期: 2008-08-06
// 概述: 员工早退
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.Attendance
{
    [Serializable]
    public class EarlyLeaveAttendance : AttendanceBase
    {
        private int _EarlyLeaveMinutes;

        public EarlyLeaveAttendance(int employeeId, DateTime theDay, int earlyLeaveMinutes)
            : base(employeeId, "早退", 0, 0, theDay)
        {
            _EarlyLeaveMinutes = earlyLeaveMinutes;
        }

        public int EarlyLeaveMinutes
        {
            get { return _EarlyLeaveMinutes; }
            set { _EarlyLeaveMinutes = value; }
        }

        public override string AffectTime
        {
            get
            {
                return _EarlyLeaveMinutes + "分钟";
            }
        }
    }
}
