//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ICompnayLinkManView.cs
// 创建者: wangshlai
// 创建日期: 2009-06-30
// 概述: 公司联系人视图界面
// ----------------------------------------------------------------

using System;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ICompanyLinkMan
{
    public interface ICompnayLinkManView
    {

        string Message { get; set;}

        Guid LinkManId { get; set;}
        string LinkManName { get; set;}
        string MobileNo { get; set;}
        string HomeNo { get; set;}
        string OfficeNo { get; set;}
        string EmailAddr { get; set;}

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

        bool SetReadonly { set; }


    }
}