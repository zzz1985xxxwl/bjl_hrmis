//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IDayAttendanceWeekView.cs
// 创建者: 王玥琦
// 创建日期: 2008-09-02
// 概述: 日考勤周显示接口
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics
{
    public interface IDayAttendanceWeekView
    {
        int CurrentPage{ set;}
        string CurrentDate { set;}
        List<Employee> DayAttendanceWeekList { set;}
    }
}
