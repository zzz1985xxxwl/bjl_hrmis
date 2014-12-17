//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PositionEnum.cs
// 创建者: 杨俞彬
// 创建日期: 2008-05-28
// 概述: 部门编号 有意义的初始数据
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    public enum PositionEnum
    {
        /// <summary>
        /// 系统管理员
        /// </summary>
        SystemAdmin = 100,
        /// <summary>
        /// 首席执行官
        /// </summary>
        CEO = 101,
        /// <summary>
        /// 人事经理
        /// </summary>
        HRDirector = 102,
        /// <summary>
        /// 人事主管
        /// </summary>
        HRManager = 103,
        /// <summary>
        /// 行政人事助理
        /// </summary>
        HRAssistant = 37,
        /// <summary>
        /// 行政人事专员
        /// </summary>
        HRCommissioner = 38
    }
}