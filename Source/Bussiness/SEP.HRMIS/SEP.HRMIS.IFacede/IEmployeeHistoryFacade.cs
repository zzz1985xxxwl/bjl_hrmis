using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 员工历史
    /// </summary>
    public interface IEmployeeHistoryFacade
    {
        /// <summary>
        /// 给部门下的人员添加历史
        /// </summary>
        /// <param name="department"></param>
        /// <param name="operatorAccount"></param>
        void AddEmployeeHistoryByDepartment(Department department, Account operatorAccount);
        /// <summary>
        /// 根据帐号ID获取员工历史基本信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryBasicInfoByAccountID(int accountID);
        /// <summary>
        /// 根据帐号ID获取员工历史所有信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryByAccountID(int accountID);
        /// <summary>
        /// 通过员工历史表ID得到员工所有信息
        /// </summary>
        /// <param name="employeeHistoryID"></param>
        /// <returns></returns>
        EmployeeHistory GetEmployeeHistoryByEmployeeHistoryID(int employeeHistoryID);
        /// <summary>
        /// 根据某一时刻获得所有员工
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<Employee> GetOnDutyEmployeeBasicInfoByDateTime(DateTime dt);
        /// <summary>
        /// 根据某一时刻获得所有在职员工
        /// allEmployeeSource可以为null
        /// </summary>
        List<Employee> GetEmployeeOnDutyByDepartmentAndDateTime(int departmentID, DateTime dt, bool onlyBasicInfo,
                                                                Account loginUser, int powersID,
                                                                List<Employee> allEmployeeSource);
    }
}