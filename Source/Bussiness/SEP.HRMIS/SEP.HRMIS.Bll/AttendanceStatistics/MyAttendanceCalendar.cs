using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.OutApplications;
using SEP.HRMIS.Bll.OverWorks;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;

using SEP.Model.Accounts;
using SEP.Model.Calendar;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    ///<summary>
    ///</summary>
    public class MyAttendanceCalendar 
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static GetBadAttendance _GetBadAttendance;
        private static GetOutApplication _GetOutApplication;
        private static GetOverWork _GetOverWork;
        private static GetLeaveRequest _GetLeaveRequest;

        private static readonly IEmployee _dalEmployee = DalFactory.DataAccess.CreateEmployee();

        ///<summary>
        ///</summary>
        public MyAttendanceCalendar(Account account)
        {
            _GetBadAttendance = new GetBadAttendance(account);
            _GetOutApplication = new GetOutApplication();
            _GetOverWork=new GetOverWork();
            _GetLeaveRequest = new GetLeaveRequest();
        }

        /// <summary>
        /// 把员工的考勤情况，如外出，加班，请假，迟到早退等信息赋值给员工，用于在日历控件中显示员工的考勤情况
        /// </summary>
        public Employee GetCalendarByEmployee(int EmployeeID, DateTime From, DateTime To)
        {
            Employee employee = _dalEmployee.GetEmployeeByAccountID(EmployeeID);
            employee.EmployeeAttendance = new EmployeeAttendance(From, To);

            //迟到早退旷工详情
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                _GetBadAttendance.GetCalendarByEmployee(EmployeeID, From, To, AttendanceTypeEmnu.All));
            //请假详情
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                _GetLeaveRequest.GetAllCalendarByEmployee(EmployeeID, From, To));
            //加班外出申请
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                _GetOutApplication.GetAllCalendarByEmployee(EmployeeID, From, To));
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                _GetOverWork.GetAllCalendarByEmployee(EmployeeID, From, To));

            return employee;
        }

        ///// <summary>
        ///// add by wyq for Calendar
        ///// </summary>
        ///// <param name="EmployeeID"></param>
        ///// <param name="From"></param>
        ///// <param name="To"></param>
        ///// <returns></returns>
        //public List<DayAttendance> GetCalendar(int EmployeeID, DateTime From, DateTime To)
        //{
        //    Employee employee = _dalEmployee.GetEmployeeByAccountID(EmployeeID);
        //    employee.EmployeeAttendance = new EmployeeAttendance(From, To);
        //    //迟到早退旷工详情
        //    employee.EmployeeAttendance.DayAttendanceList.AddRange(
        //        _GetBadAttendance.GetCalendarByEmployee(EmployeeID, From, To, AttendanceTypeEmnu.All));
        //    //请假详情
        //    employee.EmployeeAttendance.DayAttendanceList.AddRange(
        //        _GetLeaveRequest.GetCalendarByEmployee(EmployeeID, From, To));
        //    //加班外出申请
        //    employee.EmployeeAttendance.DayAttendanceList.AddRange(
        //        _GetOutApplication.GetCalendarByEmployee(EmployeeID, From, To));
        //    employee.EmployeeAttendance.DayAttendanceList.AddRange(
        //        _GetOverWork.GetCalendarByEmployee(EmployeeID, From, To));

        //    return employee.EmployeeAttendance.DayAttendanceList;
        //}

    }
}

