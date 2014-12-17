//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DayAttendance.cs
// ������: wyq
// ��������: 2008-08-08
// ����: ͳ��Ա������������
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class DayAttendance
    {
        ////Ա��(id,name)
        //private Employee _Employee;
        //�ٱ������
        private string _TypeName;
        //Сʱ
        private decimal _Hours;
        //���ӣ����ڳٵ������ˣ�
        private decimal _Minites;
        //����
        private DateTime _Date;
        //����
        private string _Reason;
        //����
        private CalendarType _CalendarType;

        //��ʼʱ��
        private DateTime _FromTime;
        //����ʱ��
        private DateTime _ToTime;


        private string _Color;
        /// <summary>
        /// 
        /// </summary>
        public DayAttendance() { }
        /// <summary>
        /// 
        /// </summary>
        public DayAttendance(string typeName, decimal hours,
            decimal minites, DateTime date, string reason, CalendarType calendarType)
        {
            //_Employee = employee;
            _TypeName = typeName;
            _Hours = hours;
            _Minites = minites;
            _Date = date;
            _Reason = reason;
            _CalendarType = calendarType;
        }

        //public Employee Employee
        //{
        //    get { return _Employee; }
        //    set { _Employee = value; }
        //}
        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Days
        {
            get { return _Hours / 8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Minites
        {
            get { return _Minites; }
            set { _Minites = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime FromTime
        {
            get { return _FromTime; }
            set { _FromTime = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ToTime
        {
            get { return _ToTime; }
            set { _ToTime = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public CalendarType CalendarType
        {
            get { return _CalendarType; }
            set { _CalendarType = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Hours
        {
            get { return _Hours; }
            set { _Hours = value; }
        }
    }
}