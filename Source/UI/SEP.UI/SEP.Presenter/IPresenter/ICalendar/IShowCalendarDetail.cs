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
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;

namespace SEP.Presenter.IPresenter.ICalendar
{
    public interface IShowCalendarDetail
    {
        string EmployeeInfo{get;set;}
        string Date{get;set;}
        string ResultMessage{get;set;}
        List<LeaveRequest> LeaveRequestList{get;set;}
        List<OutApplication> OutApplicationDetailList { get;set;}
        List<OverWork> OverWorkDetailList { get;set;}
        List<AttendanceBase> AttendanceBaseList { get;set;}
        List<AttendanceInAndOutRecord> AttendanceInAndOutRecordList { set;}
        List<string> RemindList{ get; set;}
        List<string> CalendarEventList { get; set;}
        bool IsShowInOut { set;}
        bool IsShowSendEmail { set;}
        bool IsShowRemind { set;}
        bool IsShowCalendar { set;}

        void SetNull();
        void RefreshShow();
        event DelegateID RedirectToRemind;
        event DelegateID RedirectToCalendar;
        event DelegateNoParameter BtnSendEmailEvent;
    }
}
