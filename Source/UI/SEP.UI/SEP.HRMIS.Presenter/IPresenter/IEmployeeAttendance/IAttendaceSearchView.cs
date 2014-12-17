//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IAttendaceSearchView.cs
// 创建者: 刘丹
// 创建日期: 2008-08-12
// 概述: 缺勤查询界面接口
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeAttendance
{
    public interface IAttendaceSearchView
    {
        List<AttendanceBase> attendances { set;}
        List<GradesType> GradesSource { set; }
        int? GradesId { get; }
        List<string> AttendanceTypes { set;}
        string SelectedType { get; set; }
        string TheDayFrom { get;}
        string TheDayTo { get;}
        string EmployeeName { get;}

        string Message { set;}

        event DelegateID OnAttendanceDelete;
        event DelegateNoParameter OnSearch;
        event DelegateNoParameter OnAdd;
    }
}
