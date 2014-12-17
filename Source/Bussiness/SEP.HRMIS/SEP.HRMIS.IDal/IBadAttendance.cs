using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;

namespace SEP.HRMIS.IDal
{
    public interface IBadAttendance
    {
        int Insert(AttendanceBase attendance);
        AttendanceBase GetAttendanceById(int attendanceId);
        void Delete(int _AttendanceId);
        void DeleteEmployeeAttendanceByEmpAndTime(int EmpId, DateTime theDay);

        List<AttendanceBase> GetAttendanceByEmpId(int EmpId);

        List<AttendanceBase> GetAttendanceByCondition(int employeeId, DateTime theDayFrom, DateTime theDayTo,
                                                      AttendanceTypeEmnu AttendaceType);

        List<AttendanceBase> GetCalendarByEmployee(int employeeId, DateTime theDayFrom, DateTime theDayTo,
                                                   AttendanceTypeEmnu AttendaceType);
        /// <summary>
        /// ��Ա���ļ�¼����󣬱�Ϊһ��һ��ļ�¼����Ա�����տ����б���
        /// </summary>
        void TurnToDayAttendanceList(Employee employee);
    }
}
