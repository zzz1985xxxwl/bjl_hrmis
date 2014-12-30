//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: NotesCalendarList.cs
// Creater:  Xue.wenlong
// Date:  2010-04-08
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.Model.CalendarExt;
using SEP.Notes.RepeatTypes;


namespace SEP.Notes.NotesCalendar
{
    /// <summary>
    /// </summary>
    public class NotesCalendarList
    {
        public List<CalendarADay> GetByDate(DateTime start, DateTime end, int accountID)
        {
           
            List<Notes> notes =Notes.GetNotesByDate(start,end,accountID);
            List<CalendarADay> cal=new List<CalendarADay>();
            var repeaters = RepeatUtility.GetAllRepeat();
            foreach (IRepeat repeat in repeaters)
            {
                cal.AddRange(repeat.GetByDate(start, end, notes));
            }
            return cal;
        }
    }
}