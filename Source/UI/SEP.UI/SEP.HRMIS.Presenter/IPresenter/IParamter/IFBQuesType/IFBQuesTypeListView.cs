//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IFBQuesTypeListView.cs
// 创建者: 张燕
// 创建日期: 2008-11-12
// 概述:  反馈问题类型列表视图界面
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType
{
    public interface IFBQuesTypeListView
    {
        string FBQuesTypeName { get; set;}

        List<TrainFBQuesType> FBQuesTypes { set; get;}


        /// <summary>
        /// 新增按钮事件
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        event DelegateID BtnDeleteEvent;
        /// <summary>
        /// 修改按钮事件
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// 查看详情按钮事件
        /// </summary>
        event DelegateID BtnDetailEvent;
        /// <summary>
        /// 查询按钮事件
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}
