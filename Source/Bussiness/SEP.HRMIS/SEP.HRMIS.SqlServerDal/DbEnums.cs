//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DbEnums.cs
// 创建者: 倪豪
// 创建日期: 2008-6-3
// 概述: 用于枚举数据库字段的type值
// ----------------------------------------------------------------

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 数据库assessActivityItem的表的type字段的枚举
    /// </summary>
   public enum  DbAssessActivityItemType
   {
       HrItem,
       PersonalItem,
       ManagerItem,
   }

    /// <summary>
    /// 数据库assessActivityPaper表中type字段的枚举
    /// </summary>
    public enum  DbSubmitInfoType
    {
        Hr,
        Personal,
        Manager,
        Direct,
        Ceo,
        SummarizeCommment,
    }
}
