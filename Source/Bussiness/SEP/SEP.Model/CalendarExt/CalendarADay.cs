//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CalendarADay.cs
// Creater:  Xue.wenlong
// Date:  2010-02-22
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.Model.CalendarExt
{
    /// <summary>
    /// һ���ڵ�����
    /// </summary>
    public class CalendarADay
    {
        private DateTime _Date;
        private List<MonthItem> _MonthItems;
        private List<DayItem> _DayItems;

        public CalendarADay(DateTime date, List<MonthItem> monthitems, List<DayItem> dayitems)
        {
            _Date = date;
            _MonthItems = monthitems;
            _DayItems = dayitems;
        }

        /// <summary>
        /// ��һ��
        /// </summary>
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        /// <summary>
        /// ��һ���е�����ͼ�е�ѡ��
        /// </summary>
        public List<MonthItem> MonthItems
        {
            get { return _MonthItems; }
            set { _MonthItems = value; }
        }
        /// <summary>
        /// ��һ���е�����ͼ�е�ѡ��
        /// </summary>
        public List<DayItem> DayItems
        {
            get { return _DayItems; }
            set { _DayItems = value; }
        }

        public static CalendarADay FindCalendarDayByDate(List<CalendarADay> list, DateTime date)
        {
            foreach (CalendarADay day in list)
            {
                if (DateTime.Compare(day.Date, date) == 0)
                {
                    return day;
                }
            }
            return null;
        }

        public static CalendarADay CreateOrGetCalendarADayByDate(List<CalendarADay> retList, DateTime date)
        {
            CalendarADay calendarADay = FindCalendarDayByDate(retList, date);
            if (calendarADay == null)
            {
                calendarADay = new CalendarADay(date, new List<MonthItem>(), new List<DayItem>());
                retList.Add(calendarADay);
            }
            return calendarADay;
        }
    }
}