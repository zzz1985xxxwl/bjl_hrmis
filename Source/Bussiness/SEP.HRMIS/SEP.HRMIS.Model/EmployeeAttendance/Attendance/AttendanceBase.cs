//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AttendanceBase.cs
// 创建者: 倪豪
// 创建日期: 2008-05-20
// 概述: 员工所有考勤的基类，所有统计的出发点
//       包括 外出/请假/旷工。。所有需要统计在出勤表中的数据都应该继承
//       此类
//       例子：2007-11-2日外出，那么就是 名字定义为“外出”,持续1天，
//             增加1出勤日
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.Attendance
{
    [Serializable]
    public class AttendanceBase : IAttendanceAffectTime
    {
        private int _AttendanceId;
        //请假员工的Id
        private int _EmployeeId;
        //假别的名字
        private string _Name;
        //持续的时间
        private decimal _Days;
        //增加的出勤天数
        private decimal _AddDutyDays;
        //请假的这一天日期
        private DateTime _TheDay;
        //员工姓名
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
        ///请假员工的Id
        /// </summary>
        public int EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }
        /// <summary>
        /// 假别的名字
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// 持续的时间
        /// </summary>
        public decimal Days
        {
            get { return _Days; }
            set { _Days = value; }
        }
        /// <summary>
        /// 增加的出勤天数
        /// </summary>
        public decimal AddDutyDays
        {
            get { return _AddDutyDays; }
            set { _AddDutyDays = value; }
        }
        /// <summary>
        /// 请假的这一天日期
        /// </summary>
        public DateTime TheDay
        {
            get { return _TheDay; }
            set { _TheDay = value; }
        }


        #region IAttendanceAffectTime 成员

        public virtual string AffectTime
        {
            get
            {
                return "无影响时间";
            }
        }

        #endregion
    }
}
