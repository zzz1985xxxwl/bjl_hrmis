//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IInAndOutStatisticsBuildView.cs
// 创建者: 王玥琦
// 创建日期: 2008-10-17
// 概述: 接口
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.ReadDataViews;
using SEP.HRMIS.Presenter.IPresenter.IChoseEmployee;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IAttendanceInAndOutStatistics
{
    public interface IInAndOutStatisticsBuildView
    {
        /// <summary>
        /// 大界面
        /// </summary>
        IInAndOutStatisticsView InAndOutStatisticsView { get;set;}
        /// <summary>
        /// 小界面
        /// </summary>
        IReadAttendanceRuleView ReadAttendanceRuleView { get;set;}
        /// <summary>
        /// 小界面
        /// </summary>
        IReadHistoryListView ReadHistoryListView { get;set;}
        ///// <summary>
        ///// 小界面
        ///// </summary>
        //ICreateAttendanceForOperator CreateAttendanceForOperatorView { get;set;}
        /// <summary>
        /// 小界面可见
        /// </summary>
        bool ReadAttendanceRuleViewVisible { get;set;}
        bool ReadHistoryListViewVisible { get;set;}
        bool CreateAttendanceForOperatorViewVisible { get;set;}


        #region for ICreateAttendanceForOperator
        Account LoginUser { get; set;}
        string Message { set;}
        string SearchFrom { get;}
        string SearchTo { get;}
        /// <summary>
        /// 从XSL读取事件
        /// </summary>
        event DelegateID BtnReadFromXLSEvent;
        /// <summary>
        /// 取消
        /// </summary>
        event DelegateNoParameter BtnCancelEvent;

        event DelegateNoParameter ShowCreateAttendanceForOperator;

        /// <summary>
        /// 小界面
        /// </summary>
        IChoseEmployeeView ChoseEmployeeView { get; set;}
        /// <summary>
        /// 小界面是否可见
        /// </summary>
        bool IChoseEmployeeViewVisible { get; set;}
        List<Account> EmployeeList { get; set;}
        #endregion
    }
}
