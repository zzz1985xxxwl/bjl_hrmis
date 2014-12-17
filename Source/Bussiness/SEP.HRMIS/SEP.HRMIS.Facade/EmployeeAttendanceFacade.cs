//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: EmployeeAttendanceFacade.cs
// Creater:  Emma
// Date:  2009-03-25
// Resume:
// ---------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.Bll.EmployeeAdjustRest;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeAttendanceFacade : IEmployeeAttendanceFacade
    {
        public List<Request> GetRequestRecordByCondition(string employeeName, int departmentID,int? gradeType,
                 DateTime searchFrom, DateTime searchTo, ApplicationTypeEnum applicationType,
            RequestStatus applicationStatus, Account loginUser)
        {
            return new ApplicationSearch().GetRequestRecordByCondition(employeeName, departmentID,gradeType,
                                                                searchFrom, searchTo, applicationType, applicationStatus, loginUser);
        }

        public void RecordAbsentAttendance(string empName, DateTime theDay, decimal days, Account loginUser)
        {
            new RecordAbsentAttendance(empName, theDay, days, loginUser).Excute();
        }

        public void RecordLaterAttendance(string empName, DateTime theDay, int laterMinutes, Account loginUser)
        {
            new RecordLaterAttendance(empName, theDay, laterMinutes, loginUser).Excute();
        }

        public void RecordEarlyLeaveAttendance(string empName, DateTime theDay, int earlyLeaveMinutes, Account loginUser)
        {
            new RecordEarlyLeaveAttendance(empName, theDay, earlyLeaveMinutes, loginUser).Excute();
        }

        public void DeleteBadAttendance(int attendanceId, Account loginUser)
        {
            new DeleteBadAttendance(attendanceId, loginUser).Excute();
        }

        public List<Model.EmployeeAttendance.Attendance.AttendanceBase> GetAttendanceByCondition(string employeeName, int? gradesId, DateTime theDayFrom, DateTime theDayTo, string AttendaceType, Account loginUser)
        {
            return new GetBadAttendance(loginUser).GetAttendanceByCondition(employeeName, gradesId, theDayFrom, theDayTo, AttendaceType);
        }

        //public List<Model.EmployeeAttendance.Attendance.AttendanceBase> GetCalendarByEmployee(int employeeId, DateTime theDayFrom, DateTime theDayTo, Model.AttendanceTypeEmnu attendaceType, Account loginUser)
        //{
        //    return new GetBadAttendance(loginUser).GetCalendarByEmployee(employeeId, theDayFrom, theDayTo, attendaceType);
        //}

        public void TurnToDayAttendanceList(Employee employee, Account loginUser)
        {
            new GetBadAttendance(loginUser).TurnToDayAttendanceList(employee);
        }

        public decimal GetAdjustRestRemainedDaysByEmployeeID(int employeeID)
        {
            return new GetAdjustRest().GetAdjustRestRemainedDaysByEmployeeID(employeeID);
        }

        //public decimal GetAvailableAdjustRestDaysByEmployeeID(int employeeID)
        //{
        //    return new GetAdjustRest().GetAvailableAdjustRestDaysByEmployeeID(employeeID);
        //}
        public List<AdjustRest> GetAdjustRestByCondition(string employeeName,
                                                          EmployeeTypeEnum employeeType, int positionID,
                                                          int departmentID,
                                                          bool recursionDepartment, Account _operator, int? powers, int employeeStatus)
        {
            return
                new GetAdjustRest().GetAdjustRestByCondition(employeeName, employeeType, positionID, departmentID,
                                                             recursionDepartment, _operator, powers, employeeStatus);

        }

        public AdjustRest GetAdjustRestByAccountID(int accountID)
        {
            return
                new GetAdjustRest().GetAdjustRestByAccountID(accountID);
        }
        public void UpdateAdjustRest(int adjustID, decimal surplusAdjustRest, string remark, int _operatorID)
        {
            new UpdateAdjustRestByOperator(adjustID, surplusAdjustRest, remark, _operatorID).Excute();
        }

        public AdjustRest GetAdjustRestByPKID(int adjustID)
        {
            return
                new GetAdjustRest().GetAdjustRestByPKID(adjustID);
        }
        public List<AttendanceBase> GetAbsentAttendanceByAccountAndRelatedDate(int accountID, DateTime fromDate,
                                                               DateTime toDate)
        {
            return new GetBadAttendance(null).GetAbsentAttendanceByAccountAndRelatedDate(accountID, fromDate, toDate);
        }
    }
}
