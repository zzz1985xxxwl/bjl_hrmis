//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IShowCalendarDetail.cs
// 创建者: 王玥琦
// 创建日期: 2008-08-27
// 概述: 接口
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics
{
    public interface IShowCalendarDetail
    {
        string EmployeeID{get;set;}
        string Date{get;set;}
        string ResultMessage{get;set;}
        List<LeaveRequest> LeaveRequestList{get;set;}
        //List<Application> ApplicationList { get;set;}
        List<AttendanceBase> AttendanceBaseList { get;set;}
        bool IsShowInOut { set;}


    }
}
