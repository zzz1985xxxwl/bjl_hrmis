//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AbsentAttendance.cs
// ������: �ߺ�
// ��������: 2008-08-06
// ����: Ա������
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.Attendance
{
    [Serializable]
    public class AbsentAttendance : AttendanceBase
    {
        public AbsentAttendance(int employeeId, DateTime theDay, decimal affactDays)
            : base(employeeId, "����", affactDays, 0, theDay)
        {
        }

        public override string AffectTime
        {
            get
            {
                return Days + "��";
            }
        }
    }
}
