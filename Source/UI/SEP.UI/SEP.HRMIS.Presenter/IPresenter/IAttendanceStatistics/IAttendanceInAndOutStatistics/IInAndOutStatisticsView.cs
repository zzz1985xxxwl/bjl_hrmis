//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IInAndOutStatisticsView.cs
// 创建者: 王玥琦
// 创建日期: 2008-10-17
// 概述: 接口
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IAttendanceInAndOutStatistics

{
    public interface IInAndOutStatisticsView
    {
        string EmployeeName { get; set;}

        string DepartmentID { get; set;}

        string SearchFrom { get; set;}

        string SearchTo { get; set;}

        string OutInTimeCondition { get; set;}

        string Message { set; get;}

        string ErrorMessage { set; get;}

        List<Employee> EmployeeList { set; get;}

        List<Department> DepartmentList { set; get;}

        List<OutInTimeConditionEnum> OutInTimeConditionSourse { set; get;}

        List<string> HourFromList { set; get;}

        List<string> HourToList { set; get;}

        List<string> MinutesFromList { set; get;}

        List<string> MinutesToList { set; get;}
        int? GradesId { get; }
        List<GradesType> GradesSource { set; }

        /// <summary>
        /// 设置读取时间按钮事件
        /// </summary>
        event DelegateNoParameter BtnSetReadTimeEvent;
        /// <summary>
        /// 读取Access考勤数据按钮事件
        /// </summary>
        event DelegateNoParameter BtnReadAccessDataEvent;

        /// <summary>
        /// 发送邮件事件
        /// </summary>
        event DelegateID BtnSendEmailEvent;
        /// <summary>
        /// 发送短信事件
        /// </summary>
        event DelegateID BtnSendMessageEvent;
        /// <summary>
        /// 查询按钮事件
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;

        /// <summary>
        /// 读取Excel考勤数据按钮事件
        /// </summary>
        event DelegateNoParameter BtnReadExcelDataEvent;

    }
}