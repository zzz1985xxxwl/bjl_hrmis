using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    ///<summary>
    /// 员工考勤统计
    ///</summary>
    public interface IEmployeeAttendanceStatisticsFacade
    {
        ///<summary>
        /// 按部门，员工姓名查询员工考勤
        ///</summary>
        ///<returns></returns>
        List<Employee> GetAllEmployeeAttendanceByCondition(string EmployeeName, int DepartmentID,int? gradesId,
            DateTime Form, DateTime To, Account account, int powers);

        ///<summary>
        /// 把员工的考勤情况，如外出，加班，请假，迟到早退等信息赋值给员工，用于在日历控件中显示员工的考勤情况
        ///</summary>
        ///<param name="EmployeeID"></param>
        ///<param name="Form"></param>
        ///<param name="To"></param>
        ///<param name="account"></param>
        ///<returns></returns>
        Employee GetCalendarByEmployee(int EmployeeID, DateTime Form, DateTime To, Account account);

        /// <summary>
        /// 根据时间段统计员工的考勤信息
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="departmentID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="account"></param>
        /// <param name="powers"></param>
        List<Employee> GetMonthAttendanceStatisticsFacade(string employeeName, int departmentID,int? gradesId, DateTime fromDate,
                                                          DateTime toDate, Account account, int? powers);


        ///<summary>
        /// 得到某一员工，某天的所有请假单
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="date"></param>
        ///<returns></returns>
        List<LeaveRequest> GetLeaveRequestListDetailByEmployee(int employeeID, DateTime date);

        /// <summary>
        /// 得到某一员工，某天的外出申请
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        List<OutApplication> GetOutApplicationDetailByEmployee(int employeeID, DateTime date);

        /// <summary>
        /// 得到某一员工，某天的加班申请
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        List<OverWork> GetOverWorkDetailByEmployee(int employeeID, DateTime date);

        /// <summary>
        /// 得到某一员工，某天的考勤情况（迟到，早退，旷工）
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        List<AttendanceBase> GetAttendanceBaseListDetailByEmployee(int employeeID, DateTime date);


        /// <summary>
        /// 用于自动计算考勤时间
        /// </summary>
        List<PlanDutyDetail> GetPlanDutyDetailByAccount(int AccountID, DateTime dateStart, DateTime dateEnd);
        ///<summary>
        /// 通过employeeID,开始结束时间得到员工的考勤信息,只获得已经结束的考勤
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="startDt"></param>
        ///<param name="endDt"></param>
        ///<returns></returns>
        Employee GetEmployeeAttendanceByCondition(int employeeID, DateTime startDt, DateTime endDt);

        /// <summary>
        /// 根据时间段统计单个员工的考勤信息
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        Employee GetMonthAttendanceStatisticsFacade(int employeeID, DateTime fromDate, DateTime toDate);

    }
}
