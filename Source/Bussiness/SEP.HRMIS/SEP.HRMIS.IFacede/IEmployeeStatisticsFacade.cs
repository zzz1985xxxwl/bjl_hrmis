using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 员工统计
    /// </summary>
    public interface IEmployeeStatisticsFacade
    {
        /// <summary>
        /// 员工统计
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="departmentID"></param>
        /// <param name="accountoperator"></param>
        /// <returns></returns>
        /// <param name="employeeSource"></param>
        EmployeeStatistics BindEmployeeStatistics(DateTime dt, int departmentID, Account accountoperator,
                                                  List<Employee> employeeSource);
        /// <summary>
        /// 员工统计入职离职
        /// </summary>
        /// <param name="time"></param>
        /// <param name="departmentID"></param>
        /// <param name="accountoperator"></param>
        /// <returns></returns>
        List<EmployeeComeAndLeave> ComeAndLeaveStatistics(DateTime time, int departmentID, Account accountoperator);

        /// <summary>
        /// 员工统计入职离职
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="departmentID"></param>
        /// <param name="accountoperator"></param>        
        EmployeeComeAndLeave ComeAndLeaveStatisticsOnlyOneMonth(DateTime dt, int departmentID, Account accountoperator);

        /// <summary>
        /// 员工统计合同工类型分布
        /// </summary>
        /// <param name="time"></param>
        /// <param name="departmentID"></param>
        /// <param name="accountoperator"></param>
        /// <param name="employeeSource"></param>
        /// <returns></returns>
        EmployeeOtherStatistics ResidenceStatistics(DateTime time, int departmentID, Account accountoperator,
                                                  List<Employee> employeeSource);
        /// <summary>
        /// 员工统计年假分布
        /// </summary>
        /// <param name="time"></param>
        /// <param name="departmentID"></param>
        /// <param name="employeeSource"></param>
        /// <returns></returns>
        EmployeeOtherStatistics VocationStatistics(DateTime time, int departmentID, Account accountoperator,
                                                  List<Employee> employeeSource);
        /// <summary>
        /// 员工统计层级构成
        /// </summary>
        /// <param name="time"></param>
        /// <param name="departmentID"></param>
        /// <param name="accountoperator"></param>
        /// <returns></returns>
        /// <param name="employeeSource"></param>
        List<PositionGradeStatistics> PositionGradeStatistics(DateTime time, int departmentID, Account accountoperator,
                                                  List<Employee> employeeSource);

    }
}
