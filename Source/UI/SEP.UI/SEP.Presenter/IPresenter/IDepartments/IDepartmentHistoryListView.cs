//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IDepartmentHistoryListView.cs
// 创建者: 王玥琦
// 创建日期: 2008-11-13
// 概述: 增加IDepartmentHistoryListView
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.Departments;

namespace SEP.Presenter.IPresenter.IDepartments
{
    public interface IDepartmentHistoryListView
    {
        string Message { set; get;}
        string SearchTime { set; get;}
        bool IsShowSearchTime { set; }
        string Title { set; }
        List<Department> Departments { set; get;}
         /// <summary>
        /// 查看详情事件
        /// </summary>
        event DelegateID BtnDetailEvent;
        /// <summary>
        /// 查询按钮事件
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}
