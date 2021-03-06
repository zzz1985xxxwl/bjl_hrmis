﻿//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IViewCalendar.cs
// 创建者: 王玥琦
// 创建日期: 2008-08-11
// 概述: 接口
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using SEP.Model.SpecialDates;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics
{
    public interface IMyDayAttendance
    {
        string EmployeeID { get;set;}
        string Type { get;set;}
        string ResultMessage { get;set;}
        DataTable CalendarTable { get;set;}
        List<SpecialDate> SpecialDates { get;set;}
        string CurrentMonth { get;set;}
        bool IBtnCloseVisible { set;}
        bool EmployeeNameVisible { set;}
        string EmployeeName { set;}
        DateTime CalendarStatusSet{ set;}
    }
}

