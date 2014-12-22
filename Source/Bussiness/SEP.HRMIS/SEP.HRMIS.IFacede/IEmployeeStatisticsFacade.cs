using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// Ա��ͳ��
    /// </summary>
    public interface IEmployeeStatisticsFacade
    {
        /// <summary>
        /// Ա��ͳ��
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="departmentID"></param>
        /// <param name="accountoperator"></param>
        /// <returns></returns>
        /// <param name="employeeSource"></param>
        EmployeeStatistics BindEmployeeStatistics(DateTime dt, int departmentID, Account accountoperator,
                                                  List<Employee> employeeSource);
        /// <summary>
        /// Ա��ͳ����ְ��ְ
        /// </summary>
        /// <param name="time"></param>
        /// <param name="departmentID"></param>
        /// <param name="accountoperator"></param>
        /// <returns></returns>
        List<EmployeeComeAndLeave> ComeAndLeaveStatistics(DateTime time, int departmentID, Account accountoperator);

        /// <summary>
        /// Ա��ͳ����ְ��ְ
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="departmentID"></param>
        /// <param name="accountoperator"></param>        
        EmployeeComeAndLeave ComeAndLeaveStatisticsOnlyOneMonth(DateTime dt, int departmentID, Account accountoperator);

        /// <summary>
        /// Ա��ͳ�ƺ�ͬ�����ͷֲ�
        /// </summary>
        /// <param name="time"></param>
        /// <param name="departmentID"></param>
        /// <param name="accountoperator"></param>
        /// <param name="employeeSource"></param>
        /// <returns></returns>
        EmployeeOtherStatistics ResidenceStatistics(DateTime time, int departmentID, Account accountoperator,
                                                  List<Employee> employeeSource);
        /// <summary>
        /// Ա��ͳ����ٷֲ�
        /// </summary>
        /// <param name="time"></param>
        /// <param name="departmentID"></param>
        /// <param name="employeeSource"></param>
        /// <returns></returns>
        EmployeeOtherStatistics VocationStatistics(DateTime time, int departmentID, Account accountoperator,
                                                  List<Employee> employeeSource);
        /// <summary>
        /// Ա��ͳ�Ʋ㼶����
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
