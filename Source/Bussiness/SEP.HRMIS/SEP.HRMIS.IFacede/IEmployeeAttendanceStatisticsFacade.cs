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
    /// Ա������ͳ��
    ///</summary>
    public interface IEmployeeAttendanceStatisticsFacade
    {
        ///<summary>
        /// �����ţ�Ա��������ѯԱ������
        ///</summary>
        ///<returns></returns>
        List<Employee> GetAllEmployeeAttendanceByCondition(string EmployeeName, int DepartmentID,int? gradesId,
            DateTime Form, DateTime To, Account account, int powers);

        ///<summary>
        /// ��Ա���Ŀ����������������Ӱ࣬��٣��ٵ����˵���Ϣ��ֵ��Ա���������������ؼ�����ʾԱ���Ŀ������
        ///</summary>
        ///<param name="EmployeeID"></param>
        ///<param name="Form"></param>
        ///<param name="To"></param>
        ///<param name="account"></param>
        ///<returns></returns>
        Employee GetCalendarByEmployee(int EmployeeID, DateTime Form, DateTime To, Account account);

        /// <summary>
        /// ����ʱ���ͳ��Ա���Ŀ�����Ϣ
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
        /// �õ�ĳһԱ����ĳ���������ٵ�
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="date"></param>
        ///<returns></returns>
        List<LeaveRequest> GetLeaveRequestListDetailByEmployee(int employeeID, DateTime date);

        /// <summary>
        /// �õ�ĳһԱ����ĳ����������
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        List<OutApplication> GetOutApplicationDetailByEmployee(int employeeID, DateTime date);

        /// <summary>
        /// �õ�ĳһԱ����ĳ��ļӰ�����
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        List<OverWork> GetOverWorkDetailByEmployee(int employeeID, DateTime date);

        /// <summary>
        /// �õ�ĳһԱ����ĳ��Ŀ���������ٵ������ˣ�������
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        List<AttendanceBase> GetAttendanceBaseListDetailByEmployee(int employeeID, DateTime date);


        /// <summary>
        /// �����Զ����㿼��ʱ��
        /// </summary>
        List<PlanDutyDetail> GetPlanDutyDetailByAccount(int AccountID, DateTime dateStart, DateTime dateEnd);
        ///<summary>
        /// ͨ��employeeID,��ʼ����ʱ��õ�Ա���Ŀ�����Ϣ,ֻ����Ѿ������Ŀ���
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="startDt"></param>
        ///<param name="endDt"></param>
        ///<returns></returns>
        Employee GetEmployeeAttendanceByCondition(int employeeID, DateTime startDt, DateTime endDt);

        /// <summary>
        /// ����ʱ���ͳ�Ƶ���Ա���Ŀ�����Ϣ
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        Employee GetMonthAttendanceStatisticsFacade(int employeeID, DateTime fromDate, DateTime toDate);

    }
}
