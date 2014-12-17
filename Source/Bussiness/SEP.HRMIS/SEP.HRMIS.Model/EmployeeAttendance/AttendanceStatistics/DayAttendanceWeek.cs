//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DayAttendanceWeek.cs
// 创建者: wyq
// 创建日期: 2008-09-02
// 概述: 统计员工的周出勤情况
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics
{
    [Serializable]
    public class DayAttendanceWeek
    {
        private string _Mon = "";
        private string _Tues = "";
        private string _Wedn = "";
        private string _Thurs = "";
        private string _Fri = "";
        private string _Sat = "";
        private string _Sun = "";

        private string _MonColor = "";
        private string _TuesColor = "";
        private string _WednColor = "";
        private string _ThursColor = "";
        private string _FriColor = "";
        private string _SatColor = "";
        private string _SunColor = "";

        //开始日期
        private DateTime _FromDate;
        //结束日期
        private DateTime _ToDate;

        public DayAttendanceWeek(DateTime from, DateTime to)
        {
            _FromDate = from;
            _ToDate = to;
        }

        public string Mon
        {
            get { return _Mon; }
            set { _Mon = value; }
        }
        public string Tues
        {
            get { return _Tues; }
            set { _Tues = value; }
        }
        public string Wedn
        {
            get { return _Wedn; }
            set { _Wedn = value; }
        }
        public string Thurs
        {
            get { return _Thurs; }
            set { _Thurs = value; }
        }
        public string Fri
        {
            get { return _Fri; }
            set { _Fri = value; }
        }
        public string Sat
        {
            get { return _Sat; }
            set { _Sat = value; }
        }
        public string Sun
        {
            get { return _Sun; }
            set { _Sun = value; }
        }

        public string MonColor
        {
            get { return _MonColor; }
            set { _MonColor = value; }
        }
        public string TuesColor
        {
            get { return _TuesColor; }
            set { _TuesColor = value; }
        }
        public string WednColor
        {
            get { return _WednColor; }
            set { _WednColor = value; }
        }
        public string ThursColor
        {
            get { return _ThursColor; }
            set { _ThursColor = value; }
        }
        public string FriColor
        {
            get { return _FriColor; }
            set { _FriColor = value; }
        }
        public string SatColor
        {
            get { return _SatColor; }
            set { _SatColor = value; }
        }
        public string SunColor
        {
            get { return _SunColor; }
            set { _SunColor = value; }
        }
        public DateTime FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }

        }
        public DateTime ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }

        }
    }
}
