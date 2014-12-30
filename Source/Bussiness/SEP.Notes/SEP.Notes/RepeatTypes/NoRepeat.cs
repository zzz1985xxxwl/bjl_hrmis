//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: NoRepeat.cs
// Creater:  Xue.wenlong
// Date:  2010-04-09
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SEP.Model.CalendarExt;

namespace SEP.Notes.RepeatTypes
{
    /// <summary>
    /// Œﬁ÷ÿ∏¥
    /// </summary>
    public class NoRepeat : IRepeat
    {
        public List<CalendarADay> GetByDate(DateTime start, DateTime end, List<Notes> source)
        {
            List<CalendarADay> cd = new List<CalendarADay>();
            foreach (Notes notes in source)
            {
                if (notes.RepeatType is NoRepeat)
                {
                    DateTime from = notes.Start;
                    DateTime to = notes.End;
                    if (to >= from)
                    {
                        int days = (to.Date - from.Date).Days;
                        DateTime date = from;
                        for (int i = 0; i <= days; i++)
                        {
                            if (date.Date <= end.Date && date.Date >= start.Date)
                            {
                                DateTime fromtemp = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                                DateTime totemp = fromtemp.AddDays(1).AddSeconds(-1);
                                if (i == 0)
                                {
                                    fromtemp = from;
                                }
                                if (i == days)
                                {
                                    totemp = to;
                                }
                                List<MonthItem> monthitems = new List<MonthItem>();
                                MonthItem monthitem =
                                    new MonthItem(notes.Content,RepeatUtility.DetailString(notes, fromtemp, totemp), fromtemp, CalendarShowType.Note);
                                monthitems.Add(monthitem);
                                List<DayItem> dayitems = new List<DayItem>();
                                DayItem dayItem = new DayItem(fromtemp, totemp, notes.Content, CalendarShowType.Note);
                                dayItem.ObjectID = notes.PKID;
                                dayitems.Add(dayItem);
                                CalendarADay aday = new CalendarADay(fromtemp.Date, monthitems, dayitems);
                                cd.Add(aday);
                                date=date.AddDays(1);
                            }
                        }
                    }
                }
            }
            return cd;
        }

        public void Valide()
        {
            
        }

        public void SqlSave(SqlCommand cmd)  
        {
        }

        public void SqlUpdate(SqlCommand cmd)
        {
        }

        public IRepeat SqlGetByID(SqlDataReader sdr)
        {
            return this;
        }
    }
}