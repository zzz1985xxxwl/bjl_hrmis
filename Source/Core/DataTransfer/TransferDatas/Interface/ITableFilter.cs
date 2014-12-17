//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: ITableFilter.cs
// 创建者: 倪豪
// 创建日期: 2009-05-11
// 概述: 对外发布的接口，用于扩展表删选，可以在此处自定义如何根据
//       时间段筛选自己需要的数据，同时需要定义如何去还原这些数据
// ----------------------------------------------------------------
using System;

namespace TransferDatas
{
    public interface ITableFilter:ICloneable
    {
        /// <summary>
        /// 获取是否需要时间条件
        /// </summary>
        bool GetNeedTimeFilter();
        /// <summary>
        /// 设置过滤器其实条件
        /// </summary>
        /// <param name="theRule">传递的完整过滤规则对象，可以自由地在接口中扩充其他的过滤条件</param>
        /// <param name="mainTableName">主表名</param>
        /// <param name="orginDbName">源数据库名字(主系统数据库名)</param>
        /// <param name="orginCopyDbName">拷贝源数据库的名字(主系统的拷贝)</param>
        /// <param name="restoreDbName">待还原数据库名字(从系统数据库名)</param>
        /// <param name="forRestoreCopyDbName">在从系统上的拷贝数据库名(主系统的另一份拷贝)</param>
        void ConfigTheFilter(TransferRule theRule,string mainTableName, string orginDbName, string orginCopyDbName, string restoreDbName, string forRestoreCopyDbName);
        /// <summary>
        /// 开始还原表数据
        /// </summary>
        string RestoreTableData(DateTime? fromDay, DateTime? toDay);
        /// <summary>
        /// 开始过滤表数据
        /// </summary>
        string FilterTableData(DateTime? fromDay, DateTime? toDay);
    }
}