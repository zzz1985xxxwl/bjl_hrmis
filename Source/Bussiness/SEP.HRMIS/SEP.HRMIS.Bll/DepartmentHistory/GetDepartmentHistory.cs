//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetDepartmentHistory.cs
// 创建者:wangyueqi
// 创建日期: 2008-11-13
// 概述: 实现GetDepartmentHistory接口
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Departments;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 获取部门历史
    /// </summary>
    public class GetDepartmentHistory
    {
        private readonly IDepartmentHistory _DalDepartmentHistory = new DepartmentHistoryDal();
        /// <summary>
        /// 获取部门历史构造函数
        /// </summary>
        public GetDepartmentHistory()
        {
        }
        /// <summary>
        /// 获取部门历史构造函数
        /// </summary>
        /// <param name="mockDalDepartmentHistory"></param>
        public GetDepartmentHistory(IDepartmentHistory mockDalDepartmentHistory)
        {
            _DalDepartmentHistory = mockDalDepartmentHistory;
        }
        /// <summary>
        /// 获得dt时间点的组织架构,无结构
        /// </summary>
        /// <param name="searchTime"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentNoStructByDateTime(DateTime searchTime)
        {
            return _DalDepartmentHistory.GetDepartmentNoStructByDateTime(searchTime);
        }
        /// <summary>
        /// 获得dt时间点deparmentID的树形结构，以列表形式返回
        /// </summary>
        /// <param name="deparmentID"></param>
        /// <param name="searchTime"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentListStructByDepartmentIDAndDateTime(int deparmentID, DateTime searchTime)
        {
            List<Department> departmentList = _DalDepartmentHistory.GetDepartmentNoStructByDateTime(searchTime);
            List<Department> newDepartment = new List<Department>();
            foreach (Department department in departmentList)
            {
                if (department.Id == deparmentID)
                {
                    newDepartment.Add(department);
                    GenerateTreeStruct(departmentList, newDepartment, department);
                    break;
                }
            }
            return newDepartment;
        }

        private static void GenerateTreeStruct(List<Department> oldDepartment,
            List<Department> newDepartment, Department parentDepartment)
        {
            if (oldDepartment == null)
            {
                oldDepartment = new List<Department>();
            }
            if (newDepartment == null)
            {
                newDepartment = new List<Department>();
            }
            foreach (Department department in oldDepartment)
            {
                if (department.ParentDepartment.DepartmentID == parentDepartment.DepartmentID)
                {
                    newDepartment.Add(department);
                    //递归找孩子
                    GenerateTreeStruct(oldDepartment, newDepartment, department);
                }
            }
        }

        /// <summary>
        /// 获得dt时间点的组织架构,有树形结构
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentTreeStructByDateTime(DateTime dt)
        {
            return _DalDepartmentHistory.GetDepartmentTreeStructByDateTime(dt);
        }
    }
}

