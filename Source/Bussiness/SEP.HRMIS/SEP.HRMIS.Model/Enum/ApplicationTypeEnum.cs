//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ApplicationType.cs
// 创建者: 薛文龙
// 创建日期: 2008-08-04
// 概述: 申请类型
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 
    /// </summary>
    public enum ApplicationTypeEnum
    {
        /// <summary>
        /// 全部
        /// </summary>
        All = -1,      
        /// <summary>
        /// 加班申请
        /// </summary>
        OverTime,
        /// <summary>
        /// 请假申请
        /// </summary>
        LeaveRequest,
        /// <summary>
        /// 市内外出申请
        /// </summary>
        InCityOut,
        /// <summary>
        /// 出差申请
        /// </summary>
        OutCityOut,
        /// <summary>
        /// 培训外出申请
        /// </summary>
        TrainOut
    }
}

