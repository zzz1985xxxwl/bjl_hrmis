//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IDepartment.cs
// 创建者: 张燕、杨俞彬
// 创建日期: 2008-05-20
// 概述: 员工接口
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Departments;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 员工数据库交互
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// 持久一个员工对象
        /// </summary>
        int CreateEmployee(Employee employee);
        /// <summary>
        /// 更新员工对象，该对象必须工作在对象状态，不可以是查询器状态
        /// </summary>
        void UpdateEmployee(Employee employee);
        /// <summary>
        /// 专为测试用，勿在其他地方调用
        /// </summary>
        int DeleteEmployeeByAccountID(int accountID);
        /// <summary>
        /// 根据AccountID获得所有Employee信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Employee GetEmployeeByAccountID(int accountID);
        /// <summary>
        /// 根据AccountID获得Employee的基本信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Employee GetEmployeeBasicInfoByAccountID(int accountID);
        /// <summary>
        /// 获取Employee表的所有员工的基本信息
        /// </summary>
        /// <returns></returns>
        List<Employee> GetAllEmployeeBasicInfo();

        /// <summary>
        /// 获得公司CompanyID下所有的员工
        /// </summary>
        /// <param name="companyID"></param>
        List<Employee> GetEmployeeBasicInfoByCompanyID(int companyID);
        /// <summary>
        /// 获得系统中所有公司
        /// </summary>
        /// <returns></returns>
        List<Department> GetAllCompanyHaveEmployee();
        ///<summary>
        /// 获取员工照片
        ///</summary>
        byte[] GetEmployeePhotoByAccountID(int accountID);
        /// <summary>
        /// 获得属于某国籍的员工数
        /// </summary>
        /// <param name="nationalityID"></param>
        /// <returns></returns>
        int CountEmployeeByNationalityID(int nationalityID);

        /// <summary>
        /// 获得所有员工的信息
        /// </summary>
        /// <returns></returns>
        List<Employee> GetAllEmployeeInfo();
    }
}
