//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: RecordLaterAttendance.cs
// 创建者: 倪豪
// 创建日期: 2008-08-08
// 概述: 迟到的考勤业务类
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    public class RecordLaterAttendance : RecordBadAttendance
    {
        private readonly int _LaterMinutes;
        private readonly Account _LoginUser;

        public RecordLaterAttendance(string empName, DateTime theDay, int laterMinutes, Account loginUser)
            : base(empName, theDay,loginUser)
        {
            _LoginUser = loginUser;
            _LaterMinutes = laterMinutes;
        }

        protected override void ExcuteSelf()
        {
            LaterAttendance attendance = new LaterAttendance(_ItsAccount.Id, _TheDay, _LaterMinutes);
            _CurrentAttendanceId = _AttendanceDal.Insert(attendance);
        }

        protected override bool IsTheSameAttendanceType(AttendanceBase attendance)
        {
            return attendance is LaterAttendance;
        }

        protected override string RepetExceptions()
        {
            return BllExceptionConst._Later_SameDay;
        }
    }
}
