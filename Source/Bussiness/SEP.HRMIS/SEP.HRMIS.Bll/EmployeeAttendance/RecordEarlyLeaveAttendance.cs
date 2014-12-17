//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: RecordAbsentAttendance.cs
// 创建者: 倪豪
// 创建日期: 2008-08-08
// 概述: 早退的考勤业务类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    public class RecordEarlyLeaveAttendance : RecordBadAttendance
    {
        private readonly int _EarlyLeaveMinutes;
        private readonly Account _LoginUser;

        public RecordEarlyLeaveAttendance(string empName, DateTime theDay, int earlyLeaveMinutes, Account loginUser)
            : base(empName, theDay,loginUser)
        {
            _LoginUser = loginUser;
            _EarlyLeaveMinutes = earlyLeaveMinutes;
        }

        protected override void ExcuteSelf()
        {
            EarlyLeaveAttendance attendance = new EarlyLeaveAttendance(_ItsAccount.Id, _TheDay, _EarlyLeaveMinutes);
            _CurrentAttendanceId = _AttendanceDal.Insert(attendance);
        }

        protected override bool IsTheSameAttendanceType(AttendanceBase attendance)
        {
            return attendance is EarlyLeaveAttendance;
        }

        protected override string RepetExceptions()
        {
            return BllExceptionConst._EarlyLeave_SameDay;
        }
    }
}
