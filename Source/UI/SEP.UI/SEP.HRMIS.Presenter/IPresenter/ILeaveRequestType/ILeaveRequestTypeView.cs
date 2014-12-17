//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ILeaveTypeView.cs
// 创建者: wangshlai
// 创建日期: 2008-08-04
// 概述: 假期类型视图界面
// ----------------------------------------------------------------


using SEP.HRMIS.Model.Request;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType
{
    public interface ILeaveRequestTypeView
    {

        string Message { get;set;}
        string NameMsg { get;set;}
        string LeastHourMsg { get;set;}
        string LeaveRequestTypeID { get; set; }
        string LeaveRequestTypeName { get; set;}
        string LeaveRequestTypeDescription { get; set;}

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
        /// 确认按钮显示的字符
        /// </summary>
        string ActionButtonTxt { get; set;}
        /// <summary>
        /// 动作是否成功
        /// </summary>
        bool ActionSuccess { get; set;}
        
        bool SetReadonly { set; }
        bool SetIDReadonly { set;}
        // add syy ==modify by wyq
        LegalHoliday IncludeLegalHoliday{ get; set;}

        RestDay IncludeRestDay { get; set;}

        string LeastHour { get; set;}

    }
}
