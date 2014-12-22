using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// Ա����ʷ
    /// </summary>
    public interface IEmployeeHistoryFacade
    {
        /// <summary>
        /// �������µ���Ա�����ʷ
        /// </summary>
        /// <param name="department"></param>
        /// <param name="operatorAccount"></param>
        void AddEmployeeHistoryByDepartment(Department department, Account operatorAccount);
        /// <summary>
        /// �����ʺ�ID��ȡԱ����ʷ������Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryBasicInfoByAccountID(int accountID);
        /// <summary>
        /// �����ʺ�ID��ȡԱ����ʷ������Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryByAccountID(int accountID);
        /// <summary>
        /// ͨ��Ա����ʷ��ID�õ�Ա��������Ϣ
        /// </summary>
        /// <param name="employeeHistoryID"></param>
        /// <returns></returns>
        EmployeeHistory GetEmployeeHistoryByEmployeeHistoryID(int employeeHistoryID);
        /// <summary>
        /// ����ĳһʱ�̻������Ա��
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<Employee> GetOnDutyEmployeeBasicInfoByDateTime(DateTime dt);
        /// <summary>
        /// ����ĳһʱ�̻��������ְԱ��
        /// allEmployeeSource����Ϊnull
        /// </summary>
        List<Employee> GetEmployeeOnDutyByDepartmentAndDateTime(int departmentID, DateTime dt, bool onlyBasicInfo,
                                                                Account loginUser, int powersID,
                                                                List<Employee> allEmployeeSource);
    }
}