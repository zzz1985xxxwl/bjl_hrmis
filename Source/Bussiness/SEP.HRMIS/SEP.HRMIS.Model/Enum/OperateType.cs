//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: OperateType.cs
// 创建者: 倪豪
// 创建日期: 2008-05-29
// 概述: 操作类型
// ----------------------------------------------------------------

using System;
namespace SEP.HRMIS.Model
{
    [Flags]
    public enum OperateType
    {
        ALL = -1,
        HR,
        NotHR
    }
}
