//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ILeaveTypeListView.cs
// 创建者: wangshlai
// 创建日期: 2008-08-04
// 概述: 假期类型列表视图界面
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType
{
    public interface ILeaveRequestTypeListView
    {
        string LeaveRequestTypeName { get; }

        string Message { set; get;}
        // add syy
        List<Model.Request.LeaveRequestType> LeaveRequestTypes { set; get;}
        //List<LeaveRequestType> LeaveRequestTypes { set; get;}
        /// <summary>
        /// 新增按钮事件
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// 修改按钮事件
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        event DelegateID BtnDeleteEvent;
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
