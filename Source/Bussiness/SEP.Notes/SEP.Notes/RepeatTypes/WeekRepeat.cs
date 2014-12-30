//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: WeekRepeat.cs
// Creater:  Xue.wenlong
// Date:  2010-04-09
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using SEP.Model.CalendarExt;

namespace SEP.Notes.RepeatTypes
{
    /// <summary>
    /// 按周重复
    /// </summary>
    public class WeekRepeat : IRepeat
    {
        private DateTime _RangeStart;
        private DateTime? _RangeEnd;
        private int _NWeek;
        private List<string> _WeekList=new List<string>();
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime RangeStart
        {
            get { return _RangeStart; }
            set { _RangeStart = value; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? RangeEnd
        {
            get { return _RangeEnd; }
            set { _RangeEnd = value; }
        }
        /// <summary>
        /// 几周重复一次
        /// </summary>
        public int NWeek
        {
            get { return _NWeek; }
            set { _NWeek = value; }
        }

        /// <summary>
        /// 如1;2;3;4;5;6;0，表示星期几重复
        /// </summary>
        public List<string> WeekList
        {
            get { return _WeekList; }
            set { _WeekList = value; }
        }

        public List<CalendarADay> GetByDate(DateTime start, DateTime end, List<Notes> source)
        {
            List<CalendarADay> cd = new List<CalendarADay>();
            if (source != null && source.Count > 0)
            {
                foreach (Notes notes in source)
                {
                    if (notes.RepeatType is WeekRepeat)
                    {
                        WeekRepeat type = (WeekRepeat) notes.RepeatType;

                        DateTime tempstart = type.RangeStart > start ? type.RangeStart : start;
                        DateTime tempend = type.RangeEnd == null || type.RangeEnd > end
                                               ? end
                                               : Convert.ToDateTime(type.RangeEnd);
                        DateTime date = tempstart;
                        int days = (tempend.Date - tempstart.Date).Days;
                        DateTime rangestartmonday =
                            type.RangeStart.AddDays(-Convert.ToInt32(type.RangeStart.DayOfWeek) + 1);
                        for (int i = 0; i <= days; i++)
                        {
                            if ((date.Date.AddDays(-Convert.ToInt32(date.DayOfWeek)+1) - rangestartmonday.Date).Days%type.NWeek == 0 &&
                                type.WeekList.Contains((Convert.ToInt32(date.DayOfWeek)).ToString()))
                            {
                                List<MonthItem> monthitems = new List<MonthItem>();
                                MonthItem monthitem =
                                    new MonthItem(notes.Content, RepeatUtility.DetailString(notes, notes.Start, notes.End), date, CalendarShowType.Note);
                                monthitems.Add(monthitem);
                                List<DayItem> dayitems = new List<DayItem>();
                                DayItem dayItem =
                                    new DayItem(RepeatUtility.ConvertToDateTime(date, notes.Start),
                                                RepeatUtility.ConvertToDateTime(date, notes.End), notes.Content,
                                                CalendarShowType.Note);
                                dayItem.ObjectID = notes.PKID;
                                dayitems.Add(dayItem);
                                CalendarADay aday = new CalendarADay(date, monthitems, dayitems);
                                cd.Add(aday);
                            }
                            date = date.AddDays(1);
                        }
                    }
                }
            }

            return cd;
        }

        public void Valide()
        {
            if (NWeek <= 0)
            {
                throw new ApplicationException("请输入重复周期");
            }
            if (WeekList.Count <= 0)
            {
                throw new ApplicationException("请输入重复周期");
            }
            if (RangeEnd != null)
            {
                if (RangeEnd < RangeStart)
                {
                    throw new ApplicationException("开始时间大于结束时间");
                }
            }
        }

        public IRepeat SqlGetByID(SqlDataReader sdr)
        {
            RangeStart = Convert.ToDateTime(sdr[Params.DBRangeStart]);
            if (sdr[Params.DBRangeEnd] == DBNull.Value)
            {
                RangeEnd = null;
            }
            else
            {
                RangeEnd = Convert.ToDateTime(sdr[Params.DBRangeEnd]);
            }
            StringToType(sdr[Params.DBTypeString].ToString());
            return this;
        }

        public void SqlSave(SqlCommand cmd)
        {
            cmd.Parameters.Add(Params.DBRangeStart, SqlDbType.DateTime).Value = RangeStart;
            cmd.Parameters.Add(Params.DBRangeEnd, SqlDbType.DateTime).Value = RangeEnd.HasValue
                                                                                  ? (object) RangeEnd.Value
                                                                                  : DBNull.Value;
            cmd.Parameters.Add(Params.TypeString, SqlDbType.NVarChar, 250).Value = ToTypeString();
        }

        public void SqlUpdate(SqlCommand cmd)
        {
            cmd.Parameters.Add(Params.DBRangeStart, SqlDbType.DateTime).Value = RangeStart;
            cmd.Parameters.Add(Params.DBRangeEnd, SqlDbType.DateTime).Value = RangeEnd.HasValue
                                                                                  ? (object) RangeEnd.Value
                                                                                  : DBNull.Value;
            cmd.Parameters.Add(Params.TypeString, SqlDbType.NVarChar, 250).Value = ToTypeString();
        }

        private string ToTypeString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string s in WeekList)
            {
                builder.Append(s);
                builder.Append(';');
            }
            if (builder.ToString().EndsWith(";"))
            {
                builder.Remove(builder.Length - 1, 1);
            }
            return string.Format("{0}|{1}", NWeek, builder);
        }

        private void StringToType(string s)
        {
            string[] temp = s.Split('|');
            NWeek = Convert.ToInt32(temp[0]);
            string[] weeks = temp[1].Split(';');
            foreach (string week in weeks)
            {
                WeekList.Add(week);
            }
        }
    }
}