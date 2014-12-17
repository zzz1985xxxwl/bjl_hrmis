//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: LaterAttendance.cs
// ������: �ߺ�
// ��������: 2008-08-06
// ����: Ա������
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.Attendance
{
    [Serializable]
    public class EarlyLeaveAttendance : AttendanceBase
    {
        private int _EarlyLeaveMinutes;

        public EarlyLeaveAttendance(int employeeId, DateTime theDay, int earlyLeaveMinutes)
            : base(employeeId, "����", 0, 0, theDay)
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
                return _EarlyLeaveMinutes + "����";
            }
        }
    }
}
