//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DayAttendance.cs
// 创建者: wyq
// 创建日期: 2008-08-08
// 概述: 统计员工的请出勤情况
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
        ////员工(id,name)
        //private Employee _Employee;
        //假别的名字
        private string _TypeName;
        //小时
        private decimal _Hours;
        //分钟（用于迟到，早退）
        private decimal _Minites;
        //日期
        private DateTime _Date;
        //理由
        private string _Reason;
        //类型
        private CalendarType _CalendarType;

        //开始时间
        private DateTime _FromTime;
        //结束时间
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