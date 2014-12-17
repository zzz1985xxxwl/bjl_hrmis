//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: LeaveRequestTypeEnum.cs
// 创建者: 杨俞彬
// 创建日期: 2008-08-15
// 概述: 参数类型
// ----------------------------------------------------------------


namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 请假类型
    /// </summary>
    public enum LeaveRequestTypeEnum
    {
        /// <summary>
        /// 所有
        /// </summary>
        All = -1,
        /// <summary>
        /// 年假
        /// </summary>
        AnnualLeave = 1,
        /// <summary>
        /// 事假
        /// </summary>
        ShiJia = 2,
        /// <summary>
        /// 病假
        /// </summary>
        BingJia = 3,
        /// <summary>
        /// 调休
        /// </summary>
        AdjustRest = 4,
        /// <summary>
        /// 婚假
        /// </summary>
        HunJia = 5,
        /// <summary>
        /// 丧假
        /// </summary>
        SangJia = 6,
        /// <summary>
        /// 产前假
        /// </summary>
        ChanQianJia = 7,
        /// <summary>
        /// 哺乳假
        /// </summary>
        BuRuJia = 8,
        /// <summary>
        /// 产假
        /// </summary>
        ChanJia = 9,
        /// <summary>
        /// 护理假
        /// </summary>
        HuLiJia = 10,
    }
}
