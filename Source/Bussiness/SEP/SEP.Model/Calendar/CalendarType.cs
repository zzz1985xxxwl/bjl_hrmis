
//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CalendarType.cs
// 创建者: 王玥琦
// 创建日期: 2008-08-11
// 概述: 日期统计类型类
// ----------------------------------------------------------------

namespace SEP.Model.Calendar
{
    public enum CalendarType
    {
        Out,//外出
        OverTime,//加班
        Late,//迟到
        LeaveEarly,//早退
        Absent,//旷工
        Leave,//请假
        //如有需要继续添加
        NotEntryDayNum,//未入职
        DimissionDayNum,//离职
        Remind,//提醒
        CalendarEvent //日程

    }
}
