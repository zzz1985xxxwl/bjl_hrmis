//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: IDepartmentBll.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 部门业务接口
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using System;

namespace SEP.IBll.Departments
{
    /// <summary>
    /// 部门业务接口
    /// </summary>
    public interface IDepartmentBll
    {
        void CreateDept(Department dept, Account loginUser);
        int CreateDept(int parentId, Department dept, Account loginUser);

        void UpdateDept(Department dept, Account loginUser);
        void UpdateDept(int parentId, Department dept, Account loginUser);
        void DeleteDept(int deptId, Account loginUser);

        /// <summary>
        /// 获取当前部门组织结构
        /// </summary>
        List<Department> GetAllDepartment(Account loginUser);
        /// <summary>
        /// 获取当前部门组织结构
        /// </summary>
        List<Department> GetAllDepartmentTree(Account loginUser);

        /// <summary>
        /// 根据部门Id获取部门信息
        /// </summary>
        Department GetDepartmentById(int id, Account loginUser);

        /// <summary>
        /// 根据部门LeaderId获取所有管理的部门
        /// </summary>
        List<Department> GetManageDepts(int leaderId, Account loginUser);

        /// <summary>
        /// 根据员工Id获取所在部门
        /// </summary>
        Department GetDept(int accountId, Account loginUser);

        /// <summary>
        /// 根据部门Id获取上级部门信息
        /// </summary>
        Department GetParentDept(int deptId, Account loginUser);
        /// <summary>
        /// 获取所有部门
        /// </summary>
        List<Department> GetAllDepartmentOrderName();

        /// <summary>
        /// 获取所有部门
        /// </summary>
        List<Department> GetAllDepartment();
        /// <summary>
        /// 获取当前部门组织结构
        /// </summary>
        List<Department> GetAllDepartmentTree();
        /// <summary>
        /// 根据部门LeaderId获取所有管理的部门
        /// </summary>
        /// <param name="leaderId">部门LeaderId</param>
        List<Department> GetManageDepts(int leaderId);
        /// <summary>
        /// 获取EmployeeID所有涉及到的部门，包括EmployeeID所在部门、管理的部门以及管理的部门下的子部门
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        List<Department> GetDepartmentEmployeeInvolve(int employeeID);

        /// <summary>
        /// 递归获取所有子部门
        /// </summary>
        List<Department> GetChildDeptList(int deptId);

        /// <summary>
        /// 当前员工是否负责Department，或所负责的部门的子部门是Department
        /// </summary>
        /// <param name="departmentid"></param>
        /// <param name="employeeid"></param>
        /// <returns>是，true；否，false</returns>
        bool IsDepartmentManagedByEmployee(int departmentid, int employeeid);
        
        /// <summary>
        /// 清空部门树缓存
        /// </summary>
        void ClearCache();
        /// <summary>
        /// 将零散的deptList，可以从最小根节点列出，返回数组结构
        /// </summary>
        /// <param name="deptList"></param>
        /// <returns></returns>
        List<Department> GenerateDeptListWithLittleParentDept(List<Department> deptList);
        /// <summary>
        /// 获取list交集
        /// </summary>
        /// <param name="deptList1"></param>
        /// <param name="deptList2"></param>
        /// <returns></returns>
        List<Department> MixDepartmentList(List<Department> deptList1, List<Department> deptList2);
        /// <summary>
        /// 获取当前员工负责的所有部门，包括负责的部门的所有子子孙孙的部门
        /// </summary>
        /// <param name="leaderID"></param>
        /// <returns></returns>
        List<Department> GetDepartmentAndChildrenDeptByLeaderID(int leaderID);

        List<Department> GetDepartmentByNameString(string sendDepartment, out string errorname);
    }
}
