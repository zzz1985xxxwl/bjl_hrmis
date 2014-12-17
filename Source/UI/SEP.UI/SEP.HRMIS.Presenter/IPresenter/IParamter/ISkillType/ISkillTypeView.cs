//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ISkillTypeView.cs
// 创建者: 张珍
// 创建日期: 2008-11-06
// 概述: 技能类型小界面视图
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
   public interface ISkillTypeView
    {
        string Message { set;}
        string NameMsg { set;}

        string SkillTypeID { get; set; }
        string SkillTypeName { get; set;}
       

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
