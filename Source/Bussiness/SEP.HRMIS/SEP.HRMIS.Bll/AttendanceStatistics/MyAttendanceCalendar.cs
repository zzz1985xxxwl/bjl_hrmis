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
        /// �����๤��
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
        /// ��Ա���Ŀ����������������Ӱ࣬��٣��ٵ����˵���Ϣ��ֵ��Ա���������������ؼ�����ʾԱ���Ŀ������
        /// </summary>
        public Employee GetCalendarByEmployee(int EmployeeID, DateTime From, DateTime To)
        {
            Employee employee = _dalEmployee.GetEmployeeByAccountID(EmployeeID);
            employee.EmployeeAttendance = new EmployeeAttendance(From, To);

            //�ٵ����˿�������
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                _GetBadAttendance.GetCalendarByEmployee(EmployeeID, From, To, AttendanceTypeEmnu.All));
            //�������
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                _GetLeaveRequest.GetAllCalendarByEmployee(EmployeeID, From, To));
            //�Ӱ��������
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
        //    //�ٵ����˿�������
        //    employee.EmployeeAttendance.DayAttendanceList.AddRange(
        //        _GetBadAttendance.GetCalendarByEmployee(EmployeeID, From, To, AttendanceTypeEmnu.All));
        //    //�������
        //    employee.EmployeeAttendance.DayAttendanceList.AddRange(
        //        _GetLeaveRequest.GetCalendarByEmployee(EmployeeID, From, To));
        //    //�Ӱ��������
        //    employee.EmployeeAttendance.DayAttendanceList.AddRange(
        //        _GetOutApplication.GetCalendarByEmployee(EmployeeID, From, To));
        //    employee.EmployeeAttendance.DayAttendanceList.AddRange(
        //        _GetOverWork.GetCalendarByEmployee(EmployeeID, From, To));

        //    return employee.EmployeeAttendance.DayAttendanceList;
        //}

    }
}

