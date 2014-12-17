//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IDepartmentHistoryInfoView.cs
// 创建者: 王玥琦
// 创建日期: 2008-11-13
// 概述: 增加IDepartmentHistoryInfoView
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter
{
    public interface IDepartmentHistoryInfoView
    {
        /// <summary>
        /// 大界面
        /// </summary>
        IDepartmentHistoryListView DepartmentHistoryListView { get;set;}
        /// <summary>
        /// 小界面
        /// </summary>
        //IDepartmentView DepartmentView { get;set;}
        /// <summary>
        /// 小界面可见
        /// </summary>
        bool DepartmentViewVisible { get;set;}
    }
}

