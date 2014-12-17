//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeWithAttendanceList.cs
// 创建者: 王玥琦
// 创建日期: 2008-09-10
// 概述: EmployeeWithAttendanceList类
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics
{
    [Serializable]
    public class EmployeeWithAttendanceList
    {
        //开始日期
        private DateTime _FromDate;
        //结束日期
        private DateTime _ToDate;
        private List<Employee> _EmployeeList;

        private List<Employee> _DayAttendanceWeek1List;
        private List<Employee> _DayAttendanceWeek2List;
        private List<Employee> _DayAttendanceWeek3List;
        private List<Employee> _DayAttendanceWeek4List;
        private List<Employee> _DayAttendanceWeek5List;
        private List<Employee> _DayAttendanceWeek6List;
        private List<string> _Week1List;
        private List<string> _Week2List;
        private List<string> _Week3List;
        private List<string> _Week4List;
        private List<string> _Week5List;
        private List<string> _Week6List;

        public EmployeeWithAttendanceList(List<Employee> employeeList, DateTime from, DateTime to)
        {
            _EmployeeList = employeeList;
            _FromDate = from;
            _ToDate = to;
        }
        public List<Employee> DayAttendanceWeek1List
        {
            get { return _DayAttendanceWeek1List; }
            set { _DayAttendanceWeek1List = value; }
        }
        public List<Employee> DayAttendanceWeek2List
        {
            get { return _DayAttendanceWeek2List; }
            set { _DayAttendanceWeek2List = value; }
        }
        public List<Employee> DayAttendanceWeek3List
        {
            get { return _DayAttendanceWeek3List; }
            set { _DayAttendanceWeek3List = value; }
        }
        public List<Employee> DayAttendanceWeek4List
        {
            get { return _DayAttendanceWeek4List; }
            set { _DayAttendanceWeek4List = value; }
        }
        public List<Employee> DayAttendanceWeek5List
        {
            get { return _DayAttendanceWeek5List; }
            set { _DayAttendanceWeek5List = value; }
        }
        public List<Employee> DayAttendanceWeek6List
        {
            get { return _DayAttendanceWeek6List; }
            set { _DayAttendanceWeek6List = value; }
        }
        public List<string> Week1List
        {
            get { return _Week1List; }
            set { _Week1List = value; }
        }
        public List<string> Week2List
        {
            get { return _Week2List; }
            set { _Week2List = value; }
        }
        public List<string> Week3List
        {
            get { return _Week3List; }
            set { _Week3List = value; }
        }
        public List<string> Week4List
        {
            get { return _Week4List; }
            set { _Week4List = value; }
        }
        public List<string> Week5List
        {
            get { return _Week5List; }
            set { _Week5List = value; }
        }
        public List<string> Week6List
        {
            get { return _Week6List; }
            set { _Week6List = value; }
        }
        public List<Employee> EmployeeList
        {
            get { return _EmployeeList; }
            set { _EmployeeList = value; }
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

        public void SplitWeek()
        {
            #region 第一周
            DateTime weekStart = _FromDate;
            DateTime weekEnd = _FromDate.AddDays(7 - (int)_FromDate.DayOfWeek);
            //得到第一周的日期
            _Week1List = GetWeekList(weekStart);
            //得到第一周的考勤信息
            _DayAttendanceWeek1List = GetDayAttendanceWeekList(weekStart, weekEnd);
            #endregion

            #region 第二周
            weekStart = weekEnd.AddDays(1);
            weekEnd = weekEnd.AddDays(7);
            _Week2List = GetWeekList(weekStart);
            _DayAttendanceWeek2List = GetDayAttendanceWeekList(weekStart, weekEnd);
            #endregion

            #region 第三周
            weekStart = weekEnd.AddDays(1);
            weekEnd = weekEnd.AddDays(7);
            _Week3List = GetWeekList(weekStart);
            _DayAttendanceWeek3List = GetDayAttendanceWeekList(weekStart, weekEnd);
            #endregion

            #region 第四周
            weekStart = weekEnd.AddDays(1);
            weekEnd = weekEnd.AddDays(7);
            _Week4List = GetWeekList(weekStart);
            _DayAttendanceWeek4List = GetDayAttendanceWeekList(weekStart, weekEnd);
            #endregion

            #region 第五,六周
            if (DateTime.Compare(_ToDate, weekEnd) <= 0)//如果只有4周
            {
                _Week5List = new List<string>();
                _DayAttendanceWeek5List = new List<Employee>();
                _Week6List = new List<string>();
                _DayAttendanceWeek6List = new List<Employee>();
            }
            else
            {
                weekStart = weekEnd.AddDays(1);
                weekEnd = weekEnd.AddDays(7);
                _Week5List = GetWeekList(weekStart);
                _DayAttendanceWeek5List = GetDayAttendanceWeekList(weekStart, weekEnd);

                if (DateTime.Compare(_ToDate, weekEnd) <= 0)//如果只有5周
                {
                    _Week6List = new List<string>();
                    _DayAttendanceWeek6List = new List<Employee>();
                }
                else
                {
                    weekStart = weekEnd.AddDays(1);
                    weekEnd = weekEnd.AddDays(7);
                    _Week6List = GetWeekList(weekStart);
                    _DayAttendanceWeek6List = GetDayAttendanceWeekList(weekStart, weekEnd);
                }
            }
            #endregion
        }

        private List<Employee> GetDayAttendanceWeekList(DateTime from, DateTime to)
        {
            List<Employee> employeeList = new List<Employee>();
            //循环每个员工，查找这一周的考勤信息
            for (int i = 0; i < _EmployeeList.Count; i++)
            {
                Employee employee =new Employee(_EmployeeList[i].Account,_EmployeeList[i].Account.Email1,
                    _EmployeeList[i].Account.Email2,_EmployeeList[i].EmployeeType,_EmployeeList[i].Account.Position,
                    _EmployeeList[i].Account.Dept);
                employee.EmployeeDetails = _EmployeeList[i].EmployeeDetails;
                employee.EmployeeAttendance = new EmployeeAttendance(from, to);
                employee.EmployeeAttendance.DayAttendanceWeek = new DayAttendanceWeek(from, to);
                employee.EmployeeAttendance.FromDate = from;
                employee.EmployeeAttendance.ToDate = to;
                employee.EmployeeAttendance.DayAttendanceList = _EmployeeList[i].EmployeeAttendance.DayAttendanceList;
                employee.EmployeeAttendance.AttendanceInAndOutRecordList = _EmployeeList[i].EmployeeAttendance.AttendanceInAndOutRecordList;
                employee.EmployeeAttendance.PlanDutyDetailList = _EmployeeList[i].EmployeeAttendance.PlanDutyDetailList;
                employee.EmployeeAttendance.GetDayAttendanceWeekByDate(employee);
                employeeList.Add(employee);
            }
            return employeeList;
        }

        private static List<string> GetWeekList(DateTime Date)
        {
            List<string> weekList = new List<string>();
            weekList.Add(Date.ToShortDateString());
            weekList.Add(Date.AddDays(1).ToShortDateString());
            weekList.Add(Date.AddDays(2).ToShortDateString());
            weekList.Add(Date.AddDays(3).ToShortDateString());
            weekList.Add(Date.AddDays(4).ToShortDateString());
            weekList.Add(Date.AddDays(5).ToShortDateString());
            weekList.Add(Date.AddDays(6).ToShortDateString());
            return weekList;
        }

    }
}
