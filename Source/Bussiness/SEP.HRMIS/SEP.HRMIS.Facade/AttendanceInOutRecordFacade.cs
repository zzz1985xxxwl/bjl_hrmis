using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    using IFacede;
    using Model.EmployeeAttendance.AttendanceInAndOutRecord;
    using Bll.AttendanceStatistics;

    /// <summary>
    /// 
    /// </summary>
    public class AttendanceInOutRecordFacade : IAttendanceInOutRecordFacade
    {

        #region IAttendanceInOutRecordFacade ≥…‘±

        public void InsertAttendanceInOutRecord(int employeeId, AttendanceInAndOutRecord record, 
            AttendanceInAndOutRecordLog attendanceInAndOutRecordLog, Account loginUser)
        {
            new InsertAttendanceInOutRecord(employeeId, record, attendanceInAndOutRecordLog, loginUser).Excute();
        }


        public void DeleteAttendanceInOutRecord(int employeeId, int recordId, DateTime theDate, 
            AttendanceInAndOutRecordLog attendanceInAndOutRecordLog, Account loginUser)
        {
            new DeleteAttendanceInOutRecord(employeeId, recordId, theDate, attendanceInAndOutRecordLog, loginUser).Excute();
        }


        public void UpdateAttendanceInOutRecord(int employeeId, AttendanceInAndOutRecord record, 
            DateTime oldDate, AttendanceInAndOutRecordLog log, Account loginUser)
        {
            new UpdateAttendanceInOutRecord(employeeId, record, oldDate, log, loginUser).Excute();
        }

        public List<Employee> GetAttendanceOutInRecordByCondition(string employeeName,int? gradesId ,
            int departmentID, DateTime from, DateTime to, OutInTimeConditionEnum outInTimeCondition,
            Account loginUser)
        {
            return new AttendanceOutInRecord(loginUser).GetAttendanceOutInRecordByCondition(employeeName,gradesId, departmentID, from, to,
                                                                                   outInTimeCondition);
        }

        public List<AttendanceInAndOutRecord> GetEmployeeInAndOutRecordByCondition(int employeeID, string employeeName, int departmentID, string doorCardNo,
            DateTime iOTimeFrom, DateTime iOTimeTo, InOutStatusEnum iOStatus, 
            OutInRecordOperateStatusEnum operateStatus, DateTime operateTimeFrom,
            DateTime operateTimeTo, Account loginUser)
        {
            return new AttendanceOutInRecord(loginUser).GetEmployeeInAndOutRecordByCondition(employeeID, employeeName,
                                                                                    departmentID, doorCardNo, iOTimeFrom,
                                                                                    iOTimeTo, iOStatus, operateStatus,
                                                                                    operateTimeFrom, operateTimeTo);
        }

        public Employee GetEmployeeInAndOutRecordByEmployeeId(int employeeId, Account loginUser)
        {
            return new AttendanceOutInRecord(loginUser).GetEmployeeInAndOutRecordByEmployeeId(employeeId);
        }


        public List<AttendanceInAndOutRecordLog> GetInAndOutLogByCondition(string employeeName, int DempartmentId, 
            DateTime operateTiemFrom, DateTime operateTimeTo, string operatorName,
            DateTime oldIOTimeFrom, DateTime oldIOTimeTo, Account loginUser)
        {
            return new GetInAndOutRecordLog(loginUser).GetInAndOutLogByCondition(employeeName, DempartmentId, operateTiemFrom,
                                                                        operateTimeTo, operatorName, oldIOTimeFrom,
                                                                        oldIOTimeTo);
        }

        public List<AttendanceInAndOutRecord> GetSelfAttendanceInAndOutRecordByCondition(int accountid, DateTime from,
                                                                                         DateTime to)
        {
            return new AttendanceOutInRecord(null).GetSelfAttendanceInAndOutRecordByCondition(accountid, from, to);
        }

        #endregion
    }
}
