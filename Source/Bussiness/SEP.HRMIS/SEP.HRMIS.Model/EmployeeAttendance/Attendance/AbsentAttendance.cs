//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AbsentAttendance.cs
// 创建者: 倪豪
// 创建日期: 2008-08-06
// 概述: 员工旷工
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.Attendance
{
    [Serializable]
    public class AbsentAttendance : AttendanceBase
    {
        public AbsentAttendance(int employeeId, DateTime theDay, decimal affactDays)
            : base(employeeId, "旷工", affactDays, 0, theDay)
        {
        }

        public override string AffectTime
        {
            get
            {
                return Days + "天";
            }
        }
    }
}
