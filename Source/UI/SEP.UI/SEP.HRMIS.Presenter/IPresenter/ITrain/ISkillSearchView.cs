//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ISkillSearchView.cs
// 创建者: ZZ
// 创建日期: 2008-11-07
// 概述: 技能大界面要实现接口
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter
{
    public interface ISkillSearchView
    {
        string SkillName { get; }

        string Message { set; get;}
        string ErrorMessage { set; get;}

        List<Skill> Skills { set; get;}
        List<SkillType> SkillTypeList { set;}

        int SelectedSkillTypeID { get; }
        
        /// <summary>
        /// 新增按钮事件
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        event DelegateID BtnDeleteEvent;
        /// <summary>
        ///修改按钮事件
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// 查询按钮事件
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;

        
    }
}
