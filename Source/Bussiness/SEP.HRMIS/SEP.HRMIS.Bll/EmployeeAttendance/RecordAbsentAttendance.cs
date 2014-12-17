using System;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    public class RecordAbsentAttendance : RecordBadAttendance
    {
        private readonly decimal _Days;
        private readonly Account _LoginUser;

        public RecordAbsentAttendance(string empName, DateTime theDay, decimal days, Account loginUser)
            : base(empName, theDay,loginUser)
        {
            _LoginUser = loginUser;
            _Days = days;
        }
        protected override void ExcuteSelf()
        {
            AbsentAttendance _AbsentAttendance = new AbsentAttendance(_ItsAccount.Id, _TheDay, _Days);
            _CurrentAttendanceId = _AttendanceDal.Insert(_AbsentAttendance);
        }

        protected override bool IsTheSameAttendanceType(AttendanceBase attendance)
        {
            return attendance is AbsentAttendance;
        }

        protected override string RepetExceptions()
        {
            return BllExceptionConst._Absent_SameDay;
        }
    }
}
