//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: IDepartmentDal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 部门持久层接口
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.Departments;

namespace SEP.IDal.Departments
{
    /// <summary>
    /// 部门持久层接口
    /// </summary>
    public interface IDepartmentDal
    {
        int InsertDepartment(int parentId, Department obj);
        void UpdateDepartment(int parentId, Department obj);
        void DeleteDepartment(int id);

        List<Department> GetAllDepartment();
        List<Department> GetAllDepartmentOrderName();
        List<Department> GetDepartmentTree();
        Department GetDepartmentById(int deptId);
        bool IsExistDept(int deptId);
        Department GetDepartmentByName(string name);
        bool HasChildDept(int deptId);

        /// <summary>
        /// 获取所有管理的部门
        /// </summary>
        List<Department> GetDepartmentByLeaderId(int leaderId);
        /// <summary>
        /// 获取下级部门
        /// </summary>
        List<Department> GetChildDepartment(int deptId);


        /// <summary>
        /// 获取员工所在的部门
        /// </summary>
        Department GetDepartmentByEmployeeId(int employeeId);

        /// <summary>
        /// 获取上级部门
        /// </summary>
        Department GetParentDepartment(int deptId);

        bool HasEmployee(int deptId);

        /// <summary>
        /// 清空部门树缓存
        /// </summary>
        void ClearCache();
    }
}
