//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IAttendanceRuleListView.cs
// 创建者: 刘丹
// 创建日期: 2008-10-14
// 概述: 考勤规则列表视图界面
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IAttendanceRuleListView
    {
        string Message { get; set;}

        string RuleName { get;}

        /// <summary>
        /// 考勤规则
        /// </summary>
        List<AttendanceRule> AttendanceRules{ set; get;}

        /// <summary>
        /// 新增事件
        /// </summary>
        event DelegateNoParameter BtnAddEvent;

        /// <summary>
        /// 修改事件
        /// </summary>
        event DelegateID BtnUpdateEvent;

        /// <summary>
        /// 详情
        /// </summary>
        event DelegateID BtnDetailEvent;

        /// <summary>
        /// 查询
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;


    }
}
