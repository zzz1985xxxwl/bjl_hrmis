//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IAttendanceRuleView.cs
// 创建者: 刘丹
// 创建日期: 2008-10-14
// 概述: 考勤规则视图界面
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IAttendanceRuleView
    {
        /// <summary>
        /// 显示底层的一些信息
        /// </summary>
        string Message { set;}

        string AttendanceRuleId { get; set;}

        /// <summary>
        /// 考勤规则名称
        /// </summary>
        string RuleName { get; set;}

        /// <summary>
        /// 考勤规则名词信息
        /// </summary>
        string RuleNameMessage { set;}

        /// <summary>
        /// 早晨上班时间
        /// </summary>
        string MonringStartWork { get; set;}
        //string MonringStartWorkHour { get; set;}
        //string MonringStartWorkMinute { get; set;}


        /// <summary>
        /// 早晨下班时间
        /// </summary>
        string MonringEndWork { get; set;}
        //string MonringEndWorkHour { get; set;}
        //string MonringEndWorkMinute { get; set;}
        /// <summary>
        /// 下午上班时间
        /// </summary>
        string AfternoonStartWork { get; set;}
        //string AfternoonStartWorkHour { get; set;}
        //string AfternoonStartWorkMinute { get; set;}

        /// <summary>
        /// 下午下班时间
        /// </summary>
        string AfternoonEndWork { get; set;}
        //string AfternoonEndWorkHour { get; set;}
        //string AfternoonEndWorkMinute { get; set;}
        /// <summary>
        /// 显示关于上班时间的信息
        /// </summary>
        string WorkTimeMessage { set;}

        /// <summary>
        /// 设定迟到的定义
        /// </summary>
        string LateTime { get; set;}

        /// <summary>
        /// 显示关于迟到信息
        /// </summary>
        string LateMessage { set;}

        /// <summary>
        /// 设定早退的定义
        /// </summary>
        string EarlyLeaveTime { get; set;}

        /// <summary>
        /// 显示关于早退信息
        /// </summary>
        string EarlyLeaveMessage { set;}

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
    }
}
