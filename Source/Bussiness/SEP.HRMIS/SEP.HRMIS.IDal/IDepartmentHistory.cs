//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IDepartmentHistory.cs
// 创建者: 王玥琦
// 创建日期: 2008-11-11
// 概述: DepartmentHistory 接口
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Departments;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 部门历史数据交互
    /// </summary>
    public interface IDepartmentHistory
    {
        /// <summary>
        /// 拍下部门历史
        /// </summary>
        /// <param name="departmentHistoryList"></param>
        /// <returns></returns>
        int InsertDepartmentHistory(List<DepartmentHistory> departmentHistoryList);
        /// <summary>
        /// 获得dt时间点部门的信息
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        DepartmentHistory GetDepartmentByDepartmentIDAndDateTime(int departmentID, DateTime dt);
        /// <summary>
        /// 获得dt时间点的组织架构,无结构
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<Department> GetDepartmentNoStructByDateTime(DateTime dt);
        /// <summary>
        /// 获得dt时间点的组织架构,有树形结构
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<Department> GetDepartmentTreeStructByDateTime(DateTime dt);
    }
}
