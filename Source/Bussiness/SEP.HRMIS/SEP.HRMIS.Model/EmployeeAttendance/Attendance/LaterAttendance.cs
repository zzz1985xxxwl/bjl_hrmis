//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: LaterAttendance.cs
// ������: �ߺ�
// ��������: 2008-08-06
// ����: Ա���ٵ�
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.Attendance
{
    [Serializable]
    public class LaterAttendance : AttendanceBase
    {
        private int _LaterMinutes;

        public LaterAttendance(int employeeId, DateTime theDay, int laterMinutes)
            : base(employeeId, "�ٵ�", 0, 0, theDay)
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
                return _LaterMinutes + "����";
            }
        }
    }
}
