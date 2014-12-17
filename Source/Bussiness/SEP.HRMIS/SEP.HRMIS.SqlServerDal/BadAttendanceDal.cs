//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BadAttendanceDal.cs
// 创建者: 刘丹
// 创建日期: 2008-8-11
// 概述: 数据库访问类
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.Model.Calendar;

namespace SEP.HRMIS.SqlServerDal
{
    public class BadAttendanceDal:IBadAttendance
    {
        private const string _PKID = "@PKID";
        private const string _EmployeeId = "@EmployeeId";
        private const string _EmployeeName = "@EmployeeName";
        private const string _Name = "@Name";
        private const string _Days = "@Days";
        private const string _AddDutyDays = "@AddDutyDays";
        private const string _Munite = "@Munite";
        private const string _TheDay = "@TheDay";
        private const string _AttendanceType = "@AttendanceType";
        private const string _DayFrom = "@DayFrom";
        private const string _DayTo = "@DayTo";
        private const string _DbPKID = "PKID";
        private const string _DbEmployeeId = "EmployeeId";
        private const string _DbDays = "Days";
        private const string _DbAddDutyDays = "AddDutyDays";
        private const string _DbEarlyAndLateMunite = "EarlyAndLateMunite";
        private const string _DbTheDay = "TheDay";
        private const string _DbAttendanceType = "AttendanceType";
        private const string _DbEmployeeName = "EmployeeName";

        public int Insert(AttendanceBase attendance)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_EmployeeId, SqlDbType.Int).Value = attendance.EmployeeId;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 50).Value = attendance.Name;
            cmd.Parameters.Add(_Days, SqlDbType.Decimal).Value = attendance.Days;
            cmd.Parameters.Add(_AddDutyDays, SqlDbType.Decimal).Value = attendance.AddDutyDays;
            cmd.Parameters.Add(_TheDay, SqlDbType.DateTime).Value = attendance.TheDay;
            EarlyLeaveAttendance early;
            LaterAttendance late;
            if(attendance is AbsentAttendance)
            {
                cmd.Parameters.Add(_Munite, SqlDbType.Int).Value = 0;
                cmd.Parameters.Add(_AttendanceType, SqlDbType.Int).Value = AttendanceTypeEmnu.Absenter;
            }
            else if((early=attendance as EarlyLeaveAttendance)!=null)
            {
                cmd.Parameters.Add(_Munite, SqlDbType.Int).Value = early.EarlyLeaveMinutes;
                cmd.Parameters.Add(_AttendanceType, SqlDbType.Int).Value = AttendanceTypeEmnu.Early;
            }
            else if ((late = attendance as LaterAttendance) != null)
            {
                cmd.Parameters.Add(_Munite, SqlDbType.Int).Value = late.LaterMinutes;
                cmd.Parameters.Add(_AttendanceType, SqlDbType.Int).Value = AttendanceTypeEmnu.Late;
            }
            SqlHelper.ExecuteNonQueryReturnPKID("EmployeeAttendanceInsert", cmd, out pkid);
            return pkid;
        }

        public AttendanceBase GetAttendanceById(int attendanceId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = attendanceId;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAttendanceById", cmd))
            {
                while (sdr.Read())
                {
                    switch ((AttendanceTypeEmnu) sdr[_DbAttendanceType])
                    {
                        case AttendanceTypeEmnu.Absenter:
                            AbsentAttendance absent =
                                new AbsentAttendance(Convert.ToInt32(sdr[_DbEmployeeId]),
                                                     Convert.ToDateTime(sdr[_DbTheDay]),
                                                     Convert.ToDecimal(sdr[_DbDays]));
                            absent.AttendanceId = Convert.ToInt32(sdr[_DbPKID]);
                            absent.AddDutyDays = Convert.ToDecimal(sdr[_DbAddDutyDays]);
                            absent.Days = Convert.ToDecimal(sdr[_DbDays]);
                            return absent;
                        case AttendanceTypeEmnu.Early:
                            EarlyLeaveAttendance early =
                                new EarlyLeaveAttendance(Convert.ToInt32(sdr[_DbEmployeeId]),
                                                         Convert.ToDateTime(sdr[_DbTheDay]),
                                                         Convert.ToInt32(sdr[_DbEarlyAndLateMunite]));
                            early.AttendanceId = Convert.ToInt32(sdr[_DbPKID]);
                            early.AddDutyDays = Convert.ToDecimal(sdr[_DbAddDutyDays]);
                            early.Days = Convert.ToDecimal(sdr[_DbDays]);
                            return early;
                        case AttendanceTypeEmnu.Late:
                            LaterAttendance late =
                                new LaterAttendance(Convert.ToInt32(sdr[_DbEmployeeId]),
                                                    Convert.ToDateTime(sdr[_DbTheDay]),
                                                    Convert.ToInt32(sdr[_DbEarlyAndLateMunite]));
                            late.AttendanceId = Convert.ToInt32(sdr[_DbPKID]);
                            late.AddDutyDays = Convert.ToDecimal(sdr[_DbAddDutyDays]);
                            late.Days = Convert.ToDecimal(sdr[_DbDays]);
                            return late;
                    }
                }
                return null;
            }
        }

        public void Delete(int _AttendanceId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = _AttendanceId;
            SqlHelper.ExecuteNonQuery("EmployeeAttendanceDelete", cmd);
        }

        public void DeleteEmployeeAttendanceByEmpAndTime(int EmpId, DateTime theDay)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_EmployeeId, SqlDbType.Int).Value = EmpId;
            cmd.Parameters.Add(_TheDay, SqlDbType.DateTime).Value = theDay;
            SqlHelper.ExecuteNonQuery("EmployeeAttendanceDeleteByEmpAndTime", cmd);
        }


        public List<AttendanceBase> GetAttendanceByEmpId(int EmpId)
        {
            List<AttendanceBase> attendances=new List<AttendanceBase>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_EmployeeId, SqlDbType.Int).Value = EmpId;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAttendanceByEmpId", cmd))
            {
                while (sdr.Read())
                {
                    switch ((AttendanceTypeEmnu)sdr[_DbAttendanceType])
                    {
                        case AttendanceTypeEmnu.Absenter:
                            AbsentAttendance absent =
                                new AbsentAttendance(Convert.ToInt32(sdr[_DbEmployeeId]),
                                                     Convert.ToDateTime(sdr[_DbTheDay]), Convert.ToDecimal(sdr[_DbDays]));
                            absent.AttendanceId = Convert.ToInt32(sdr[_DbPKID]);
                            absent.AddDutyDays = Convert.ToDecimal(sdr[_DbAddDutyDays]);
                            absent.Days = Convert.ToDecimal(sdr[_DbDays]);
                            attendances.Add(absent);
                            break;
                        case AttendanceTypeEmnu.Early:
                            EarlyLeaveAttendance early =
                                new EarlyLeaveAttendance(Convert.ToInt32(sdr[_DbEmployeeId]),
                                                         Convert.ToDateTime(sdr[_DbTheDay]),
                                                         Convert.ToInt32(sdr[_DbEarlyAndLateMunite]));
                            early.AttendanceId = Convert.ToInt32(sdr[_DbPKID]);
                            early.AddDutyDays = Convert.ToDecimal(sdr[_DbAddDutyDays]);
                            early.Days = Convert.ToDecimal(sdr[_DbDays]);
                            attendances.Add(early);
                            break;
                        case AttendanceTypeEmnu.Late:
                            LaterAttendance late =
                                new LaterAttendance(Convert.ToInt32(sdr[_DbEmployeeId]),
                                                    Convert.ToDateTime(sdr[_DbTheDay]),
                                                    Convert.ToInt32(sdr[_DbEarlyAndLateMunite]));
                            late.AttendanceId = Convert.ToInt32(sdr[_DbPKID]);
                            late.AddDutyDays = Convert.ToDecimal(sdr[_DbAddDutyDays]);
                            late.Days = Convert.ToDecimal(sdr[_DbDays]);
                            attendances.Add(late);
                            break;

                    }
                }
                return attendances;
            }
        }

        public List<AttendanceBase> GetAttendanceByCondition(int employeeId, DateTime theDayFrom, DateTime theDayTo,
                                                     AttendanceTypeEmnu AttendaceType)
        {
            List<AttendanceBase> attendances = new List<AttendanceBase>();
            SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.Add(_EmployeeName, SqlDbType.NVarChar, 50).Value = employeeName;
            cmd.Parameters.Add(_EmployeeId, SqlDbType.Int).Value = employeeId;
            cmd.Parameters.Add(_DayFrom, SqlDbType.DateTime).Value = theDayFrom;
            cmd.Parameters.Add(_DayTo, SqlDbType.DateTime).Value = theDayTo;
            cmd.Parameters.Add(_AttendanceType, SqlDbType.Int).Value = AttendaceType;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAttendanceByCondition", cmd))
            {
                while (sdr.Read())
                {
                    switch ((AttendanceTypeEmnu)sdr[_DbAttendanceType])
                    {
                        case AttendanceTypeEmnu.Absenter:
                            AbsentAttendance absent =
                                new AbsentAttendance(Convert.ToInt32(sdr[_DbEmployeeId]),
                                                     Convert.ToDateTime(sdr[_DbTheDay]), Convert.ToDecimal(sdr[_DbDays]));
                            absent.AttendanceId = Convert.ToInt32(sdr[_DbPKID]);
                            absent.AddDutyDays = Convert.ToDecimal(sdr[_DbAddDutyDays]);
                            absent.Days = Convert.ToDecimal(sdr[_DbDays]);
                            //absent.EmployeeName = sdr[_DbEmployeeName].ToString();
                            attendances.Add(absent);
                            break;
                        case AttendanceTypeEmnu.Early:
                            EarlyLeaveAttendance early =
                                new EarlyLeaveAttendance(Convert.ToInt32(sdr[_DbEmployeeId]),
                                                         Convert.ToDateTime(sdr[_DbTheDay]),
                                                         Convert.ToInt32(sdr[_DbEarlyAndLateMunite]));

                            early.AttendanceId = Convert.ToInt32(sdr[_DbPKID]);
                            early.AddDutyDays = Convert.ToDecimal(sdr[_DbAddDutyDays]);
                            early.Days = Convert.ToDecimal(sdr[_DbDays]);
                            //early.EmployeeName = sdr[_DbEmployeeName].ToString();  
                            attendances.Add(early);
                            break;
                        case AttendanceTypeEmnu.Late:
                            LaterAttendance late =
                                new LaterAttendance(Convert.ToInt32(sdr[_DbEmployeeId]),
                                                    Convert.ToDateTime(sdr[_DbTheDay]),
                                                    Convert.ToInt32(sdr[_DbEarlyAndLateMunite]));


                            late.AttendanceId = Convert.ToInt32(sdr[_DbPKID]);
                            late.AddDutyDays = Convert.ToDecimal(sdr[_DbAddDutyDays]);
                            late.Days = Convert.ToDecimal(sdr[_DbDays]);
                            //late.EmployeeName = sdr[_DbEmployeeName].ToString();
                            attendances.Add(late);
                            break;

                    }
                }
                return attendances;
            }
        }

        public List<AttendanceBase> GetCalendarByEmployee(int employeeId, DateTime theDayFrom, DateTime theDayTo,
                                                          AttendanceTypeEmnu AttendaceType)
        {
            List<AttendanceBase> attendances = new List<AttendanceBase>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_EmployeeId, SqlDbType.NVarChar, 50).Value = employeeId;
            cmd.Parameters.Add(_DayFrom, SqlDbType.DateTime).Value = theDayFrom;
            cmd.Parameters.Add(_DayTo, SqlDbType.DateTime).Value = theDayTo;
            cmd.Parameters.Add(_AttendanceType, SqlDbType.Int).Value = AttendaceType;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAttendanceViewCalendarByCondition", cmd))
            {
                while (sdr.Read())
                {
                    switch ((AttendanceTypeEmnu)sdr[_DbAttendanceType])
                    {
                        case AttendanceTypeEmnu.Absenter:
                            AbsentAttendance absent =
                                new AbsentAttendance(Convert.ToInt32(sdr[_DbEmployeeId]),
                                                     Convert.ToDateTime(sdr[_DbTheDay]), Convert.ToDecimal(sdr[_DbDays]));
                            absent.AttendanceId = Convert.ToInt32(sdr[_DbPKID]);
                            absent.AddDutyDays = Convert.ToDecimal(sdr[_DbAddDutyDays]);
                            absent.Days = Convert.ToDecimal(sdr[_DbDays]);
                            //absent.EmployeeName = sdr[_DbEmployeeName].ToString();
                            attendances.Add(absent);
                            break;
                        case AttendanceTypeEmnu.Early:
                            EarlyLeaveAttendance early =
                                new EarlyLeaveAttendance(Convert.ToInt32(sdr[_DbEmployeeId]),
                                                         Convert.ToDateTime(sdr[_DbTheDay]),
                                                         Convert.ToInt32(sdr[_DbEarlyAndLateMunite]));
                            early.AttendanceId = Convert.ToInt32(sdr[_DbPKID]);
                            early.AddDutyDays = Convert.ToDecimal(sdr[_DbAddDutyDays]);
                            early.Days = Convert.ToDecimal(sdr[_DbDays]);
                            //early.EmployeeName = sdr[_DbEmployeeName].ToString();
                            attendances.Add(early);
                            break;
                        case AttendanceTypeEmnu.Late:
                            LaterAttendance late =
                                new LaterAttendance(Convert.ToInt32(sdr[_DbEmployeeId]),
                                                    Convert.ToDateTime(sdr[_DbTheDay]),
                                                    Convert.ToInt32(sdr[_DbEarlyAndLateMunite]));
                            late.AttendanceId = Convert.ToInt32(sdr[_DbPKID]);
                            late.AddDutyDays = Convert.ToDecimal(sdr[_DbAddDutyDays]);
                            late.Days = Convert.ToDecimal(sdr[_DbDays]);
                            //late.EmployeeName = sdr[_DbEmployeeName].ToString();
                            attendances.Add(late);
                            break;

                    }
                }
                return attendances;
            }
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
                    dayAttendance =
                        new DayAttendance(-1, attendanceBase.Name, attendanceBase.Days, 0, attendanceBase.TheDay,
                                          string.Empty, CalendarType.Absent);
                }
                else if ((early = attendanceBase as EarlyLeaveAttendance) != null)
                {
                    dayAttendance =
                        new DayAttendance(-1, early.Name, early.Days, early.EarlyLeaveMinutes, early.TheDay,
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
            employee.EmployeeAttendance.DayAttendanceList.AddRange(dayAttendances);
        }
    }
}
