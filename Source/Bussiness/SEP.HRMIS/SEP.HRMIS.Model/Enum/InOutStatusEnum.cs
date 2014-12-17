//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InOutStatusEnum.cs
// 创建者: wangyueqi
// 创建日期: 2008-10-16
// 概述: 进出状态
// ----------------------------------------------------------------


namespace SEP.HRMIS.Model
{
    public enum InOutStatusEnum
    {
        All=-1,
        /// <summary>
        /// 刷卡状态，0：进，1：出
        /// </summary>
        In = 0,
        Out = 1
    }
}
