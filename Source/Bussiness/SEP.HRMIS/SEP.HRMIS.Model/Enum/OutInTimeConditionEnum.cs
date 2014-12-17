//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: OutInTimeConditionEnum.cs
// 创建者: wangyueqi
// 创建日期: 2008-10-16
// 概述: 进出时间条件
// ----------------------------------------------------------------


namespace SEP.HRMIS.Model
{
    public enum OutInTimeConditionEnum
    {
        /// <summary>
        /// 全部
        /// </summary>
        All=-1,
        /// <summary>
        /// 进入时间为空
        /// </summary>
        InTimeIsNull = 0,
        /// <summary>
        /// 离开时间为空
        /// </summary>
        OutTimeIsNull = 1,
        /// <summary>
        /// 进入时间为空并且离开时间为空
        /// </summary>
        InAndOutTimeIsNull = 2,
        /// <summary>
        /// 进入时间为空或者离开时间为空
        /// </summary>
        InOrOutTimeIsNull = 3,
        /// <summary>
        /// 进入时间为空或者离开时间只有一个为空
        /// </summary>
        InOrOutTimeOnlyOneIsNull = 4,
    }
}

