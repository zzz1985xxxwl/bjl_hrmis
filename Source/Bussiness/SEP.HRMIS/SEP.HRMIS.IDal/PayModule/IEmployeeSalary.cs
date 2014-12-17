//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IEmployeeSalary.cs
// Creater:  liu.dan
// Date:  2008-12-24
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.IDal.PayModule
{
    ///<summary>
    ///</summary>
    public interface IEmployeeSalary
    {
        ///<summary>
        /// 插入员工工资
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="salary"></param>
        ///<returns></returns>
        int InsertEmployeeSalaryHistory(int employeeID, EmployeeSalaryHistory salary);
        ///<summary>
        /// 更新员工工资
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="salary"></param>
        ///<returns></returns>
        int UpdateEmployeeSalaryHistory(int employeeID, EmployeeSalaryHistory salary);
        ///<summary>
        /// 导入员工工资
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="salary"></param>
        ///<returns></returns>
        int ImportEmployeeSalaryHistory(int employeeID, EmployeeSalaryHistory salary);

        ///<summary>
        /// 获取员工转套
        ///</summary>
        ///<param name="employeeID"></param>
        ///<returns></returns>
        EmployeeSalary GetEmployeeSalaryByEmployeeID(int employeeID);

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="dt"></param>
        ///<returns></returns>
        EmployeeSalaryHistory GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(int employeeID, DateTime dt);

        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        EmployeeSalaryHistory GetEmployeeSalaryHistoryByPKID(int pkid);

        ///<summary>
        /// 根据id获取员工工资
        ///</summary>
        ///<param name="historyid"></param>
        ///<returns></returns>
        EmployeeSalary GetEmployeeSalaryByEmployeeSalaryHistoryID(int historyid);

        ///<summary>
        /// 根据员工id获取员工工资
        ///</summary>
        ///<param name="employeeID"></param>
        ///<returns></returns>
        List<EmployeeSalaryHistory> GetEmployeeSalaryHistoryByEmployeeId(int employeeID);

        ///<summary>
        /// 根据条件查询员工工资
        ///</summary>
        ///<param name="salaryTime"></param>
        ///<param name="accountSetId"></param>
        ///<returns></returns>
        List<EmployeeSalary> GetEmployeeSalaryByCondition(DateTime salaryTime,int accountSetId);
    }
}