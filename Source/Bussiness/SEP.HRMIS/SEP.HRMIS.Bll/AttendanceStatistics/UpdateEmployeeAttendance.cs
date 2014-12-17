//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateEmployeeAttendance.cs
// 创建者: 王玥琦
// 创建日期: 2008-10-28
// 概述: 更新考勤统计
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.OutApplications;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.Model.Accounts;
using SEP.HRMIS.Bll.OverWorks;

namespace SEP.HRMIS.Bll
{
    ///<summary>
    ///</summary>
    public class UpdateEmployeeAttendance
    {
        private readonly Account _LoginUser;

        protected static IBadAttendance _AttendanceDal = DalFactory.DataAccess.CreateBadAttendanceDal();

        ///<summary>
        ///</summary>
        public UpdateEmployeeAttendance(Account loginUser)
        {
            _LoginUser = loginUser;
        }

        ///<summary>
        ///</summary>
        public int UpdateEmployeeDayAttendanceWithOld(Employee employee, DateTime theDate, DateTime OldDate)
        {
            //如果修改的不是同一天
            if (!theDate.Date.Equals(OldDate.Date))
            {
                UpdateEmployeeDayAttendance(employee, theDate);
            }
            return UpdateEmployeeDayAttendance(employee, OldDate);
        }

        ///<summary>
        ///</summary>
        public int UpdateEmployeeDayAttendance(Employee employee, DateTime theDate)
        {
            //如果修改的日期是当天或当天以后，则不计算
            if (DateTime.Compare(Convert.ToDateTime(theDate.ToShortDateString()), 
                Convert.ToDateTime(DateTime.Now.ToShortDateString()))>=0)
            {
                return 1;
            }
            employee.EmployeeAttendance.AttendanceBaseStatisticList = new List<AttendanceBase>();
            DateTime from = Convert.ToDateTime(theDate.ToShortDateString() + " 00:00:00");
            DateTime to = Convert.ToDateTime(theDate.ToShortDateString() + " 23:59:59");
            employee.EmployeeAttendance.FromDate = from;
            employee.EmployeeAttendance.ToDate = to;

            //请假
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                new GetLeaveRequest().GetCalendarByEmployee(employee.Account.Id, from, to));
            
            //加班
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                new GetOverWork().GetCalendarByEmployee(employee.Account.Id, from, to));

            //外出
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                new GetOutApplication().GetCalendarByEmployee(employee.Account.Id, from, to));

            if (employee.EmployeeAttendance.StatisticLateAndEarly(employee, theDate))
            {
                //删除该员工当天所有考勤记录
                _AttendanceDal.DeleteEmployeeAttendanceByEmpAndTime(employee.Account.Id, theDate);
                foreach (AttendanceBase attendanceBase in employee.EmployeeAttendance.AttendanceBaseStatisticList)
                {
                    _AttendanceDal.Insert(attendanceBase);
                }
            }
            return 1;
        }
    }
}
