//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CalendarShowType.cs
// Creater:  Xue.wenlong
// Date:  2010-02-22
// Resume:
// ----------------------------------------------------------------

using System.Collections.Generic;

namespace SEP.Model.CalendarExt
{
    public class CalendarShowType
    {
        private readonly int _ID;
        private readonly string _Name;
        private readonly string _Color;
        private readonly bool _DefalutChecked;

        public CalendarShowType(int id, string name, string color, bool defalutChecked)
        {
            _ID = id;
            _Name = name;
            _Color = color;
            _DefalutChecked = defalutChecked;
        }
        /// <summary>
        /// 班别  休息的背景色为#FFEDED
        /// </summary>
        public static CalendarShowType DutyClass = new CalendarShowType(0, "班别", "#407f9f",true);
        /// <summary>
        /// 打卡
        /// </summary>
        public static CalendarShowType Attendance = new CalendarShowType(1, "打卡记录", "#8517e2",false);
        /// <summary>
        /// 请假
        /// </summary>
        public static CalendarShowType Leave = new CalendarShowType(2, "请假", "#c98502",true);
        public static CalendarShowType Out = new CalendarShowType(3, "外出", "#008000",true);
        public static CalendarShowType OverWork = new CalendarShowType(4, "加班", "#e21717",false);
        /// <summary>
        /// 任务
        /// </summary>
        public static CalendarShowType Task = new CalendarShowType(5, "任务", "#000000",false);
        /// <summary>
        /// 便签
        /// </summary>
        public static CalendarShowType Note = new CalendarShowType(6, "便签", "#cc1a7b",true);
        /// <summary>
        /// 缺勤
        /// </summary>
        public static CalendarShowType Absent = new CalendarShowType(7, "缺勤", "#0c75b8",true);
         /// <summary>
        /// 工作计划
        /// </summary>
        public static CalendarShowType WorkTask = new CalendarShowType(9, "工作计划", "#ff6501", true);
        

        public int ID
        {
            get { return _ID; }
        }

        public string Name
        {
            get { return _Name; }
        }

        public string Color
        {
            get { return _Color; }
        }

        public bool DefaultChecked
        {
            get { return _DefalutChecked; }
        }

        public static List<CalendarShowType> GetHrType()
        {
            List<CalendarShowType> list = new List<CalendarShowType>();
            list.Add(DutyClass);
            list.Add(Attendance);
            list.Add(Leave);
            list.Add(Out);
            list.Add(OverWork);
            list.Add(Absent);
            return list;
        }
        public static List<CalendarShowType> GetSepType()
        {
            List<CalendarShowType> list = new List<CalendarShowType>();
            list.Add(Task);
            list.Add(Note);
            list.Add(WorkTask);
            return list;
        }
    }
}