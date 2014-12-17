using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 月统计
    /// </summary>
    public class MonthAttendanceStatistics
    {
        //private static readonly IAdjustRest _dalAdjustRest = DalFactory.DataAccess.CreateAdjustRest();
        private static readonly IVacation _dalVacation = DalFactory.DataAccess.CreateVacation();
        private readonly GetAdjustRest _GetAdjustRest=new GetAdjustRest();
        /// <summary>
        /// 计算员工的考勤情况
        /// </summary>
        public List<Employee> GetMonthAttendanceStatistics(string employeeName, int departmentID,int? gradesId, DateTime fromDate,
            DateTime toDate, Account account, int? powers)
        {
            List<Employee> employeeList =
                new GetEmployeeAttendanceStatistics().
                    GetEmployeeAttendanceByCondition(employeeName, departmentID,gradesId, fromDate, toDate, account, powers);
            for (int i = 0; i < employeeList.Count; i++)
            {
                MonthAttendanceCaculate(employeeList[i]);
            }
            return employeeList;
        }
        
        /// <summary>
        /// 计算员工的考勤情况
        /// </summary>
        public Employee GetMonthAttendanceStatistics(int employeeID,  DateTime fromDate,DateTime toDate)
        {
            Employee employee =
                new GetEmployeeAttendanceStatistics().GetEmployeeAttendanceByCondition(employeeID, fromDate, toDate);
            if (employee == null)
            {
                return null;
            }
            MonthAttendanceCaculate(employee);
            return employee;
        }

        private  void MonthAttendanceCaculate(Employee employee)
        {
            //获取剩余调休
            employee.EmployeeAttendance.MonthAttendance.HoursofAdjustRestRemained =
                _GetAdjustRest.GetNowAdjustRestByAccountID(employee.Account.Id).SurplusHours;
            //获取剩余年假
            employee.EmployeeAttendance.Vacation =new GetVacation().GetLastVacationByAccountID(employee.Account.Id);
            if (employee.EmployeeAttendance.Vacation == null)
            {
                employee.EmployeeAttendance.Vacation =
                    new Vacation(0, employee, 0, Convert.ToDateTime("1900-1-1"),
                                 Convert.ToDateTime("2999-12-31"), 0, 0, "");
            }
            employee.EmployeeAttendance.MonthAttendanceCaculateLeaveInfo();
            employee.EmployeeAttendance.MonthAttendanceCaculateOvertimeInfo();
            employee.EmployeeAttendance.MonthAttendanceCaculateArriveLeaveInfo();
            employee.EmployeeAttendance.MonthAttendanceCaculateOnDutyDays();
            employee.EmployeeAttendance.MonthAttendanceCaculateOutCityInfo();
        }
    }
}