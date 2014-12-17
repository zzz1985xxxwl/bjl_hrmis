//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ISkillTypeListView.cs
// 创建者: 张珍
// 创建日期: 2008-11-06
// 概述: 技能类型列表视图界面
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
   public interface ISkillTypeListView
    {
        string SkillTypeName { get; }

        string Message { set; get;}
        string ErrorMessage { set; get;}

        List<SkillType> SkillTypes { set; get;}
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
