//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: LaterAttendance.cs
// 创建者: 倪豪
// 创建日期: 2008-08-06
// 概述: 员工迟到
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.Attendance
{
    [Serializable]
    public class LaterAttendance : AttendanceBase
    {
        private int _LaterMinutes;

        public LaterAttendance(int employeeId, DateTime theDay, int laterMinutes)
            : base(employeeId, "迟到", 0, 0, theDay)
        {
            _LaterMinutes = laterMinutes;
        }

        public int LaterMinutes
        {
            get { return _LaterMinutes; }
            set { _LaterMinutes = value; }
        }

        public override string AffectTime
        {
            get
            {
                return _LaterMinutes + "分钟";
            }
        }
    }
}
