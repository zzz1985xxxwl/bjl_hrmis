//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DepartmentEnum.cs
// 创建者: 杨俞彬
// 创建日期: 2008-05-28
// 概述: 部门编号 有意义的初始数据
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    public enum DepartmentEnum
    {
        /// <summary>
        /// 部门的根结点，一般为公司
        /// </summary>
        Root = 1,
        /// <summary>
        /// 人事部门
        /// </summary>
        HRDepartment = 2
    }
}
