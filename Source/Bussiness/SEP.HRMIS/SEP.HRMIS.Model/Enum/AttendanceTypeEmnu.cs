//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AttendanceTypeEmnu.cs
// 创建者: 刘丹
// 创建日期: 2008-08-11
// 概述: 缺勤类型
// ----------------------------------------------------------------
namespace SEP.HRMIS.Model
{
    public enum AttendanceTypeEmnu
    {
        All = -1,
        Early,  //早退
        Late, //迟到
        Absenter //旷工
    }
}
