//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteBadAttendance.cs
// 创建者: 倪豪
// 创建日期: 2008-08-08
// 概述: 删除一条考勤记录
// ----------------------------------------------------------------
using SEP.HRMIS.IDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    public class DeleteBadAttendance : Transaction
    {
        private readonly int _AttendanceId;
        private readonly Account _LoginUser;

        protected static IBadAttendance _AttendanceDal = DalFactory.DataAccess.CreateBadAttendanceDal();

        public DeleteBadAttendance(int attendanceId, Account loginUser)
        {
            _LoginUser = loginUser;
            _AttendanceId = attendanceId;
        }

        public IBadAttendance AttendanceDal
        {
            set
            {
                _AttendanceDal = value;
            }
        }

        protected override void Validation()
        {
            if (_AttendanceDal.GetAttendanceById(_AttendanceId) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Attendance_Not_Exist);
            }
        }

        protected override void ExcuteSelf()
        {
            _AttendanceDal.Delete(_AttendanceId);
        }
    }
}
