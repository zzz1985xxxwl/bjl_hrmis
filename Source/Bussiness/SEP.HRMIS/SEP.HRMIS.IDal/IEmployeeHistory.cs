using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Departments;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// Ա����ʷ���ݽ���
    /// </summary>
    public interface IEmployeeHistory
    {
        /// <summary>
        /// �־�һ��Ա������
        /// </summary>
        int CreateEmployeeHistory(EmployeeHistory aNewEmployeeHistory);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="employeeHistory"></param>
        int UpdateEmployeeHistory(EmployeeHistory employeeHistory);
        /// <summary>
        /// רΪ�����ã����������ط�����
        /// </summary>
        int DeleteEmployeeHistoryByPKID(int EmployeeHistoryID);
        /// <summary>
        /// ����HistoryID���EmployeeHistory������Ϣ
        /// </summary>
        /// <param name="employeeHistoryID"></param>
        /// <returns></returns>
        EmployeeHistory GetEmployeeHistoryByEmployeeHistoryID(int employeeHistoryID);
        /// <summary>
        /// ����HistoryID���EmployeeHistory������Ϣ
        /// </summary>
        /// <param name="employeeHistoryID"></param>
        /// <returns></returns>
        EmployeeHistory GetEmployeeHistoryBasicInfoByEmployeeHistoryID(int employeeHistoryID);
        /// <summary>
        /// ����Ա���ʺ�ID���EmployeeHistory������Ϣ���б�
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryBasicInfoByAccountID(int accountID);
        /// <summary>
        /// ����Ա���ʺ�ID���EmployeeHistory������Ϣ���б�
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryByAccountID(int accountID);
        /// <summary>
        /// ����ʱ����ȡԱ���б�
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryBasicInfoByDateTime(DateTime dt);
        /// <summary>
        /// ���Ա��ĳһʱ�̵����»�����Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        EmployeeHistory GetEmployeeHistoryBasicInfoByDateTime(int accountID, DateTime date);
        /// <summary>
        /// ���Ա��ĳһʱ�̵�������Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        EmployeeHistory GetEmployeeHistoryByDateTime(int accountID, DateTime date);
        /// <summary>
        /// ���ĳһʱ�̵�����Ա����������Ϣ
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryByDateTime(DateTime date);
        /// <summary>
        /// ����ʱ����ȡĳ����Ա���б������Ϣ
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(int departmentID, DateTime dt);
        /// <summary>
        /// ����ʱ����ȡĳ����Ա���б�������Ϣ
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryByDepartmentIDAndDateTime(int departmentID, DateTime dt);
        /// <summary>
        /// ��ȡԱ����ְʱ�̵����»�����Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        EmployeeHistory GetEmployeeHistoryAtLeaveDate(int accountID);
        /// <summary>
        /// ��ȡԱ����ְʱ�̵�������Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        EmployeeHistory GetEmployeeHistoryBasicInfoAtLeaveDate(int accountID);

        List<EmployeeHistory> GetEmployeeHistoryBasicInfoByDateTimeAndDept(DateTime dt, List<Department> depttree);
        List<EmployeeHistory> GetEmployeeHistoryByDateTimeAndDept(DateTime dt, List<Department> depttree);
    }
}
