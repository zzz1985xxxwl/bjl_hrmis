//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights ReadIODataFromAccess.
// 文件名: InOutStatusEnum.cs
// 创建者: 刘丹
// 创建日期: 2008-12-01
// 概述: 进出枚举
// ----------------------------------------------------------------

namespace ReadDataAccessModel
{
    public enum InOutStatusEnum
    {
        All = -1,
        /// <summary>
        /// 刷卡状态，：进:0;出:1
        /// </summary>
        In = 0,
        Out = 1
    }
}
