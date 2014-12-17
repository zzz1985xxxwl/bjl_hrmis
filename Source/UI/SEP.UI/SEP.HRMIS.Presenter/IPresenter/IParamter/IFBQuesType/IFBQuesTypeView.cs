//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ISkillTypeView.cs
// 创建者: 张燕
// 创建日期: 2008-11-12
// 概述: 反馈问题类型类型小界面视图
// ----------------------------------------------------------------
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType
{
    public interface IFBQuesTypeView
    {
        string ResultMessage { get;set;}
        string Title { get; set;}

        string FBQuesTypeName { get; set;}
        string NameMessage { get;set;}

        string FBQuesTypeID { get; set;}

        /// <summary>
        /// 确认按钮事件
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;

        /// <summary>
        /// 操作类型
        /// </summary>
        string OperationType { get; set;}

        /// <summary>
        /// 动作是否成功
        /// </summary>
        bool ActionSuccess { get; set;}

        bool SetIDReadonly { set;}

        bool SetNameReadonly { set;}

    }
}
