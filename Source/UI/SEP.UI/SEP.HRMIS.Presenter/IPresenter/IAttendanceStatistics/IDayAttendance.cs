//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IDayAttendance.cs
// 创建者: 王玥琦
// 创建日期: 2008-09-02
// 概述: 日考勤接口
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics
{
    public interface IDayAttendance
    {
        string ResultMessage { set; get; }
        string EmployeeName { set; get; }
        string FromDate { set; get; }
        string ToDate { set; get; }

        List<Department> DepartmentSource { set; get; }
        string DepartmentId { get; set; }
        int? GradesId { get; }
        List<GradesType> GradesSource { set; }

        List<Employee> DayAttendanceWeek1List { set; get; }
        List<Employee> DayAttendanceWeek2List { set; get; }
        List<Employee> DayAttendanceWeek3List { set; get; }
        List<Employee> DayAttendanceWeek4List { set; get; }
        List<Employee> DayAttendanceWeek5List { set; get; }
        List<Employee> DayAttendanceWeek6List { set; get; }
        List<string> Week1List { set; get; }
        List<string> Week2List { set; get; }
        List<string> Week3List { set; get; }
        List<string> Week4List { set; get; }
        List<string> Week5List { set; get; }
        List<string> Week6List { set; get; }

    }
}
