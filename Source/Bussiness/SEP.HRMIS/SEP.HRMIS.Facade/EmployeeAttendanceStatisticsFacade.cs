using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.Bll.OutApplications;
using SEP.HRMIS.Bll.OverWorks;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model.Accounts;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Facade
{
    ///<summary>
    /// 考勤统计
    ///</summary>
    public class EmployeeAttendanceStatisticsFacade : IEmployeeAttendanceStatisticsFacade
    {
        ///<summary>
        /// 按部门，员工姓名查询员工考勤
        ///</summary>
        ///<returns></returns>
        public List<Employee> GetAllEmployeeAttendanceByCondition(string EmployeeName, int DepartmentID,int? gradesId,
            DateTime Form, DateTime To, Account account, int powers)
        {
            GetEmployeeAttendanceStatistics employeeAttendanceStatistics =
                new GetEmployeeAttendanceStatistics();
            return employeeAttendanceStatistics.GetAllEmployeeAttendanceByCondition(EmployeeName, DepartmentID,gradesId, Form, To, account, powers);
        }
        ///<summary>
        /// 得到某一员工，某天的所有请假单
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="date"></param>
        ///<returns></returns>
        public List<LeaveRequest> GetLeaveRequestListDetailByEmployee(int employeeID, DateTime date)
        {
            GetLeaveRequest getLeaveRequest=new GetLeaveRequest();
            return getLeaveRequest.GetLeaveRequestDetailByAccountIDAndDate(employeeID, date);
        }
        /// <summary>
        /// 得到某一员工，某天的外出申请
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<OutApplication> GetOutApplicationDetailByEmployee(int employeeID, DateTime date)
        {
            GetOutApplication getOutApplication=new GetOutApplication();
            return getOutApplication.GetOutApplicationDetailByEmployee(employeeID, date);
        }
        /// <summary>
        /// 得到某一员工，某天的加班申请
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<OverWork> GetOverWorkDetailByEmployee(int employeeID, DateTime date)
        {
            GetOverWork getOverWork=new GetOverWork();
            return getOverWork.GetOverWorkDetailByEmployee(employeeID, date);
        }
        /// <summary>
        /// 得到某一员工，某天的考勤情况（迟到，早退，旷工）
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<AttendanceBase> GetAttendanceBaseListDetailByEmployee(int employeeID, DateTime date)
        {
            GetBadAttendance  getBadAttendance=new GetBadAttendance(null);
            return getBadAttendance.GetAttendanceBaseListDetailByEmployee(employeeID, date);
        }

        ///<summary>
        /// 把员工的考勤情况，如外出，加班，请假，迟到早退等信息赋值给员工，用于在日历控件中显示员工的考勤情况
        ///</summary>
        ///<param name="EmployeeID"></param>
        ///<param name="Form"></param>
        ///<param name="To"></param>
        ///<param name="account"></param>
        ///<returns></returns>
        public Employee GetCalendarByEmployee(int EmployeeID, DateTime Form, DateTime To, Account account)
        {
            MyAttendanceCalendar myAttendanceCalendar = new MyAttendanceCalendar(account);
            return myAttendanceCalendar.GetCalendarByEmployee(EmployeeID, Form, To);
        }

        /// <summary>
        /// 用于自动计算考勤时间
        /// </summary>
        public List<PlanDutyDetail> GetPlanDutyDetailByAccount(int AccountID, DateTime dateStart, DateTime dateEnd)
        {
            GetPlanDutyTable getPlanDutyTable=new GetPlanDutyTable();
            return getPlanDutyTable.GetPlanDutyDetailByAccount(AccountID, dateStart, dateEnd);
        }
        ///<summary>
        /// 通过employeeID,开始结束时间得到员工的考勤信息,只获得已经结束的考勤
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="startDt"></param>
        ///<param name="endDt"></param>
        ///<returns></returns>
        public Employee GetEmployeeAttendanceByCondition(int employeeID, DateTime startDt, DateTime endDt)
        {
            GetEmployeeAttendanceStatistics employeeAttendanceStatistics =
                new GetEmployeeAttendanceStatistics();
            return employeeAttendanceStatistics.GetEmployeeAttendanceByCondition(employeeID, startDt, endDt);
        }

        /// <summary>
        /// 根据时间段统计员工的考勤信息
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="departmentID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="account"></param>
        /// <param name="powers"></param>
        public List<Employee> GetMonthAttendanceStatisticsFacade(string employeeName, int departmentID,int? gradesId, DateTime fromDate,
                                            DateTime toDate, Account account, int? powers)
        {
            return
                new MonthAttendanceStatistics().GetMonthAttendanceStatistics(employeeName, departmentID,gradesId, fromDate,
                                                                             toDate,
                                                                             account, powers);
        }
        /// <summary>
        /// 根据时间段统计单个员工的考勤信息
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public Employee GetMonthAttendanceStatisticsFacade(int employeeID, DateTime fromDate, DateTime toDate)
        {
            return
                new MonthAttendanceStatistics().GetMonthAttendanceStatistics(employeeID, fromDate,toDate);
        }

    }
}
