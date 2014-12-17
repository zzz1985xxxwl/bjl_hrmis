using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Departments;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 员工历史数据交互
    /// </summary>
    public interface IEmployeeHistory
    {
        /// <summary>
        /// 持久一个员工对象
        /// </summary>
        int CreateEmployeeHistory(EmployeeHistory aNewEmployeeHistory);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="employeeHistory"></param>
        int UpdateEmployeeHistory(EmployeeHistory employeeHistory);
        /// <summary>
        /// 专为测试用，勿在其他地方调用
        /// </summary>
        int DeleteEmployeeHistoryByPKID(int EmployeeHistoryID);
        /// <summary>
        /// 根据HistoryID获得EmployeeHistory所有信息
        /// </summary>
        /// <param name="employeeHistoryID"></param>
        /// <returns></returns>
        EmployeeHistory GetEmployeeHistoryByEmployeeHistoryID(int employeeHistoryID);
        /// <summary>
        /// 根据HistoryID获得EmployeeHistory基本信息
        /// </summary>
        /// <param name="employeeHistoryID"></param>
        /// <returns></returns>
        EmployeeHistory GetEmployeeHistoryBasicInfoByEmployeeHistoryID(int employeeHistoryID);
        /// <summary>
        /// 根据员工帐号ID获得EmployeeHistory基本信息的列表
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryBasicInfoByAccountID(int accountID);
        /// <summary>
        /// 根据员工帐号ID获得EmployeeHistory基本信息的列表
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryByAccountID(int accountID);
        /// <summary>
        /// 根据时间点获取员工列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryBasicInfoByDateTime(DateTime dt);
        /// <summary>
        /// 获得员工某一时刻的最新基础信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        EmployeeHistory GetEmployeeHistoryBasicInfoByDateTime(int accountID, DateTime date);
        /// <summary>
        /// 获得员工某一时刻的最新信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        EmployeeHistory GetEmployeeHistoryByDateTime(int accountID, DateTime date);
        /// <summary>
        /// 获得某一时刻的所有员工的最新信息
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryByDateTime(DateTime date);
        /// <summary>
        /// 根据时间点获取某部门员工列表基本信息
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(int departmentID, DateTime dt);
        /// <summary>
        /// 根据时间点获取某部门员工列表完整信息
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<EmployeeHistory> GetEmployeeHistoryByDepartmentIDAndDateTime(int departmentID, DateTime dt);
        /// <summary>
        /// 获取员工离职时刻的最新基本信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        EmployeeHistory GetEmployeeHistoryAtLeaveDate(int accountID);
        /// <summary>
        /// 获取员工离职时刻的最新信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        EmployeeHistory GetEmployeeHistoryBasicInfoAtLeaveDate(int accountID);

        List<EmployeeHistory> GetEmployeeHistoryBasicInfoByDateTimeAndDept(DateTime dt, List<Department> depttree);
        List<EmployeeHistory> GetEmployeeHistoryByDateTimeAndDept(DateTime dt, List<Department> depttree);
    }
}
