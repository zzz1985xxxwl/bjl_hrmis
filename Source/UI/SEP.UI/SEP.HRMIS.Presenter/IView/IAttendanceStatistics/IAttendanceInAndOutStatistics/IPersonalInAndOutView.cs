//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IPersonalInAndOutView.cs
// 创建者: 刘丹
// 创建日期: 2008-10-20
// 概述: 个人考勤新增，修改，删除控件
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IPersonalInAndOutView
    {
        /// <summary>
        /// 条数信息
        /// </summary>
        string Message { set;}

        /// <summary>
        /// 员工姓名
        /// </summary>
        string EmployeeName { get; set;}

        /// <summary>
        /// 员工id
        /// </summary>
        string EmployeeId { get; set;}
        string DoorCardNo { get; set;}

        string RecordId { get; set;}

        /// <summary>
        /// 查询时间开始值
        /// </summary>
        string IOTime { get; set;}

        /// <summary>
        /// 查询时间结束值
        /// </summary>
        string TimeMessage { set;}

        /// <summary>
        /// 进出状态
        /// </summary>
        string IOStatusId { get; set;}
        Dictionary<string,string> IOStatusSource { set;}

        /// <summary>
        /// 原因
        /// </summary>
        string Reason { get; set;}

        /// <summary>
        /// 原因不能为空
        /// </summary>
        string ReasonMessage { set; get;}

        /// <summary>
        /// 操作类型;新增，修改，详细
        /// </summary>
        string OperationTitle { set; get;}

        /// <summary>
        /// 确认按钮事件
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;

        /// <summary>
        /// 取消按钮事件
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;

        /// <summary>
        /// 动作是否成功
        /// </summary>
        bool ActionSuccess { get; set;}

        /// <summary>
        /// 操作类型
        /// </summary>
        string OperationType { get; set;}

        List<string> HoursSource { set;}
        List<string> MinutesSource { set;}

        bool SetReadOnly { set;}
        bool SetReasonReadOnly { set;}
    }
}
