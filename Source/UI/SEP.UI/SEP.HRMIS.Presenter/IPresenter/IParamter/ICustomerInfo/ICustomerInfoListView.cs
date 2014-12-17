//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ICustomerInfoListView.cs
// 创建者: 刘丹
// 创建日期: 2009-08-17
// 概述: 列表
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.ICustomerInfo
{
    public interface ICustomerInfoListView
    {
        string CompnayName { get; }

        string Message { set; }

        List<CustomerInfo> CustomerInfos { set;}
        /// <summary>
        /// 新增按钮事件
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        event DelegateID BtnDeleteEvent;
        /// <summary>
        /// 更新按钮事件
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// 查询按钮事件
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}
