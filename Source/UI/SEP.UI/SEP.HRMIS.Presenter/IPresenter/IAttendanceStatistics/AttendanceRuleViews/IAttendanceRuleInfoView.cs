//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IAttendanceRuleInfoView.cs
// 创建者: 刘丹
// 创建日期: 2008-10-14
// 概述: 考勤规则整合视图界面
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter
{
    public interface IAttendanceRuleInfoView
    {
        /// <summary>
        /// 考勤规则列表界面
        /// </summary>
        IAttendanceRuleListView RuleListView { get; set;}

        /// <summary>
        /// 考勤规则界面
        /// </summary>
        IAttendanceRuleView RuleView { get; set;}

        /// <summary>
        /// 小界面可见
        /// </summary>
        bool AttendanceRuleViewVisible { get;set;}
    }
}
