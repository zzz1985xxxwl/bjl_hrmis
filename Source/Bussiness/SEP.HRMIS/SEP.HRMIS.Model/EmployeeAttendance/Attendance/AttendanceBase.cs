//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AttendanceBase.cs
// ������: �ߺ�
// ��������: 2008-05-20
// ����: Ա�����п��ڵĻ��࣬����ͳ�Ƶĳ�����
//       ���� ���/���/��������������Ҫͳ���ڳ��ڱ��е����ݶ�Ӧ�ü̳�
//       ����
//       ���ӣ�2007-11-2���������ô���� ���ֶ���Ϊ�������,����1�죬
//             ����1������
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.Attendance
{
    [Serializable]
    public class AttendanceBase : IAttendanceAffectTime
    {
        private int _AttendanceId;
        //���Ա����Id
        private int _EmployeeId;
        //�ٱ������
        private string _Name;
        //������ʱ��
        private decimal _Days;
        //���ӵĳ�������
        private decimal _AddDutyDays;
        //��ٵ���һ������
        private DateTime _TheDay;
        //Ա������
        private string _EmployeeName;

        public AttendanceBase(int employeeId, string name, decimal days, decimal addDutyDays, DateTime theDay)
        {
            _EmployeeId = employeeId;
            _Name = name;
            _Days = days;
            _AddDutyDays = addDutyDays;
            _TheDay = theDay;
        }
        /// <summary>
        /// PKID
        /// </summary>
        public int AttendanceId
        {
            get { return _AttendanceId; }
            set { _AttendanceId = value; }
        }
        /// <summary>
        ///���Ա����Id
        /// </summary>
        public int EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }
        /// <summary>
        /// Ա������
        /// </summary>
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }
        /// <summary>
        /// �ٱ������
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// ������ʱ��
        /// </summary>
        public decimal Days
        {
            get { return _Days; }
            set { _Days = value; }
        }
        /// <summary>
        /// ���ӵĳ�������
        /// </summary>
        public decimal AddDutyDays
        {
            get { return _AddDutyDays; }
            set { _AddDutyDays = value; }
        }
        /// <summary>
        /// ��ٵ���һ������
        /// </summary>
        public DateTime TheDay
        {
            get { return _TheDay; }
            set { _TheDay = value; }
        }


        #region IAttendanceAffectTime ��Ա

        public virtual string AffectTime
        {
            get
            {
                return "��Ӱ��ʱ��";
            }
        }

        #endregion
    }
}
