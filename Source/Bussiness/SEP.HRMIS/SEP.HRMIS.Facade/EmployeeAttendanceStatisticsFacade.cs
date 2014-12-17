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
    /// ����ͳ��
    ///</summary>
    public class EmployeeAttendanceStatisticsFacade : IEmployeeAttendanceStatisticsFacade
    {
        ///<summary>
        /// �����ţ�Ա��������ѯԱ������
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
        /// �õ�ĳһԱ����ĳ���������ٵ�
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
        /// �õ�ĳһԱ����ĳ����������
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
        /// �õ�ĳһԱ����ĳ��ļӰ�����
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
        /// �õ�ĳһԱ����ĳ��Ŀ���������ٵ������ˣ�������
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
        /// ��Ա���Ŀ����������������Ӱ࣬��٣��ٵ����˵���Ϣ��ֵ��Ա���������������ؼ�����ʾԱ���Ŀ������
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
        /// �����Զ����㿼��ʱ��
        /// </summary>
        public List<PlanDutyDetail> GetPlanDutyDetailByAccount(int AccountID, DateTime dateStart, DateTime dateEnd)
        {
            GetPlanDutyTable getPlanDutyTable=new GetPlanDutyTable();
            return getPlanDutyTable.GetPlanDutyDetailByAccount(AccountID, dateStart, dateEnd);
        }
        ///<summary>
        /// ͨ��employeeID,��ʼ����ʱ��õ�Ա���Ŀ�����Ϣ,ֻ����Ѿ������Ŀ���
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
        /// ����ʱ���ͳ��Ա���Ŀ�����Ϣ
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
        /// ����ʱ���ͳ�Ƶ���Ա���Ŀ�����Ϣ
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
