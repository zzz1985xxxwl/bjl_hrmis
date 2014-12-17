//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TrainStatusEnum.cs
// 创建者: 刘丹
// 创建日期: 2008-11-09
// 概述: 培训状态
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    ///<summary>
    /// 培训状态
    ///</summary>
    public enum TrainStatusEnum
    {
        ///<summary>
        ///</summary>
        All=-1,//所有培训
        /// <summary>
        /// 计划
        /// </summary>
        Plan,
        ///<summary>
        /// 开始的培训
        ///</summary>
        Start, //开始的培训
        ///<summary>
        /// 结束的培训
        ///</summary>
        End, //结束的培训
        ///<summary>
        /// 中断
        ///</summary>
        Interrupt
    }
}
