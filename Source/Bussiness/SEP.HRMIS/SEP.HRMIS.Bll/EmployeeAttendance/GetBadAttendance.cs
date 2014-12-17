//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetBadAttendance.cs
// 创建者: 刘丹
// 创建日期: 2008-08-11
// 概述:缺勤查询
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;
using SEP.Model.Calendar;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll
{
    public class GetBadAttendance
    {
        //private static readonly IEmployee _dalEmployee = DalFactory.DataAccess.CreateEmployee();
        public static IBadAttendance _AttendanceDal = DalFactory.DataAccess.CreateBadAttendanceDal();
        private static IBll.Accounts.IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private readonly Account _LoginUser;

        public GetBadAttendance(Account loginUser)
        {
            _LoginUser = loginUser;
        }

        public List<AttendanceBase> GetAttendanceByCondition(string employeeName,int? gradesID, DateTime theDayFrom, DateTime theDayTo, string AttendaceType)
        {
            AttendanceTypeEmnu type;
            switch (AttendaceType)
            {
                case "早退":
                    type = AttendanceTypeEmnu.Early;
                    break;
                case "迟到":
                    type = AttendanceTypeEmnu.Late;
                    break;
                case "旷工":
                    type = AttendanceTypeEmnu.Absenter;
                    break;
                default:
                    type = AttendanceTypeEmnu.All;
                    break;
            }

            //from sep accountList
            List<Account> accountList = _IAccountBll.GetAccountByBaseCondition(employeeName, -1, -1, gradesID, true, null);
            accountList = Tools.RemoteUnAuthAccount(accountList, AuthType.HRMIS, _LoginUser, HrmisPowers.A505);

            //from hrmis AttendanceBase
            List<AttendanceBase> attendanceBase = _AttendanceDal.GetAttendanceByCondition(-1, theDayFrom, theDayTo, type);

            return ChangeEmployeeAttendanceList(attendanceBase, accountList);
        }
        /// <summary>
        /// 获得与fromDate-toDate事件上有交集的缺勤信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<AttendanceBase> GetAbsentAttendanceByAccountAndRelatedDate(int accountID, DateTime fromDate,
                                                                         DateTime toDate)
        {
            return _AttendanceDal.GetCalendarByEmployee(accountID, fromDate, toDate, AttendanceTypeEmnu.All);
        }
        ///<summary>
        /// 转换为日历显示
        ///</summary>
        ///<param name="employeeId"></param>
        ///<param name="theDayFrom"></param>
        ///<param name="theDayTo"></param>
        ///<param name="attendaceType"></param>
        ///<returns></returns>
        public List<DayAttendance> GetCalendarByEmployee(int employeeId, DateTime theDayFrom, DateTime theDayTo, AttendanceTypeEmnu attendaceType)
        {
            //获取员工缺勤信息
            List<AttendanceBase> baseList = _AttendanceDal.GetCalendarByEmployee(employeeId, theDayFrom, theDayTo,
                                                                                 attendaceType);
            List<DayAttendance> dayAttendances = new List<DayAttendance>();
            //转换为日历
            foreach (AttendanceBase attendanceBase in baseList)
            {
                DayAttendance dayAttendance = null;
                EarlyLeaveAttendance early;
                LaterAttendance late;

                if (attendanceBase is AbsentAttendance)
                {
                    dayAttendance =
                        new DayAttendance(-1, attendanceBase.Name, attendanceBase.Days*8, 0, attendanceBase.TheDay,
                                          string.Empty, CalendarType.Absent);
                }
                else if ((early = attendanceBase as EarlyLeaveAttendance) != null)
                {
                    dayAttendance = new DayAttendance(-1, early.Name, early.Days, early.EarlyLeaveMinutes, early.TheDay,
                                                      string.Empty, CalendarType.LeaveEarly);
                }
                else if ((late = attendanceBase as LaterAttendance) != null)
                {
                    dayAttendance =
                        new DayAttendance(-1, late.Name, late.Days, late.LaterMinutes, late.TheDay, string.Empty,
                                          CalendarType.Late);
                }
                dayAttendances.Add(dayAttendance);
            }
            return dayAttendances;
        }

        public void TurnToDayAttendanceList(Employee employee)
        {
            List<DayAttendance> dayAttendances = new List<DayAttendance>();
            foreach (AttendanceBase attendanceBase in employee.EmployeeAttendance.AttendanceBaseList)
            {
                DayAttendance dayAttendance = null;
                EarlyLeaveAttendance early;
                LaterAttendance late;

                if (attendanceBase is AbsentAttendance)
                {
                    dayAttendance = new DayAttendance(-1, attendanceBase.Name, attendanceBase.Days*8, 0, attendanceBase.TheDay, string.Empty, CalendarType.Absent);
                }
                else if ((early = attendanceBase as EarlyLeaveAttendance) != null)
                {
                    dayAttendance = new DayAttendance(-1, early.Name, early.Days*8, early.EarlyLeaveMinutes, early.TheDay, string.Empty, CalendarType.LeaveEarly);
                }
                else if ((late = attendanceBase as LaterAttendance) != null)
                {
                    dayAttendance = new DayAttendance(-1, late.Name, late.Days*8, late.LaterMinutes, late.TheDay, string.Empty, CalendarType.Late);
                }
                dayAttendances.Add(dayAttendance);
            }
            if(employee.EmployeeAttendance.DayAttendanceList==null)
                employee.EmployeeAttendance.DayAttendanceList = new List<DayAttendance>();
            employee.EmployeeAttendance.DayAttendanceList.AddRange(dayAttendances);
        }

        /// <summary>
        /// 获取某一天的出勤情况
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<AttendanceBase> GetAttendanceBaseListDetailByEmployee(int employeeID, DateTime date)
        {
           return   _AttendanceDal.GetCalendarByEmployee(employeeID, date, date,
                                                                     AttendanceTypeEmnu.All);
        }



        private int attendanceBaseID;
        private List<AttendanceBase> ChangeEmployeeAttendanceList(List<AttendanceBase> attendanceBaseList, List<Account> accountList)
        {
            List<AttendanceBase> returnAttendanceBase = new List<AttendanceBase>();
            foreach (AttendanceBase attendance in attendanceBaseList)
            {
                attendanceBaseID = attendance.EmployeeId;
                Account account = accountList.Find(FindEmployeeAttendance);
                if (account != null)
                {
                    //attendance.Account.Name = account.Name;
                    returnAttendanceBase.Add(attendance);
                }
            }
            return returnAttendanceBase;
        }
        private bool FindEmployeeAttendance(Account account)
        {
            if (account.Id == attendanceBaseID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
