//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ICustomerInfoView.cs
// 创建者: 刘丹
// 创建日期: 2009-11-06
// 概述: 技能类型的总界面的View要实现的接口
// ----------------------------------------------------------------
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.ICustomerInfo
{
    public interface ICustomerInfoView
    {
        string Message { set;}
        string NameMsg { set;}

        string CustomerInfoID { get; set; }
        string CompanyName { get; set;}


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
