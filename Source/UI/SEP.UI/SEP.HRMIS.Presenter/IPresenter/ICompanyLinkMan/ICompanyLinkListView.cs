//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ICompanyLinkListView.cs
// 创建者: liudan
// 创建日期: 2009-06-30
// 概述: 公司联系人列表
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Presenter.Core;
using ComService.ServiceModels;

namespace SEP.HRMIS.Presenter.IPresenter.ICompanyLinkMan
{
    public interface ICompanyLinkListView
    {
        string ContactName { get; }

        string Message { set; get;}

        List<Linkman> Linkmans { set; get;}

        /// <summary>
        /// 新增按钮事件
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// 修改按钮事件
        /// </summary>
        event DelegateGUID BtnUpdateEvent;
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        event DelegateGUID BtnDeleteEvent;
        /// <summary>
        /// 查看详情事件
        /// </summary>
        event DelegateGUID BtnDetailEvent;
        /// <summary>
        /// 查询按钮事件
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}