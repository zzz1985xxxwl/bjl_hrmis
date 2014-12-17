//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: SkillPresenter.cs
// 创建者: ZZ
// 创建日期: 2008-11-07
// 概述: 技能小界面要实现接口
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter
{
    public interface ISkillView
    {
        string Message { set; get;}
        string SkillNameMsg { set; get;}

        string SkillID { get; set; }
        string SkillName { get; set;}
        string SkillType { get; set;}
        string SkillTypeMsg { get; set;}
        List<SkillType> SkillTypes { get; set;}
        //string SelectedType { get; set;}
        /// <summary>
        /// 确认按钮事件
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;
        /// <summary>
        /// 界面标题
        /// </summary>
        string OperationTitle { set; get;}
        /// <summary>
        /// 操作类型
        /// </summary>
        string OperationType { get; set;}

        /// <summary>
        /// 动作是否成功
        /// </summary>
        bool ActionSuccess { get; set;}
       
    }
}
