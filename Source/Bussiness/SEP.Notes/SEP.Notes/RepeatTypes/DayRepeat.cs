//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DayRepeat.cs
// Creater:  Xue.wenlong
// Date:  2010-04-09
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.Facade;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model.CalendarExt;

namespace SEP.Notes.RepeatTypes
{
    /// <summary>
    /// 按天重复
    /// </summary>
    public class DayRepeat : IRepeat
    {
        private DateTime _RangeStart;
        private DateTime? _RangeEnd;
        private bool _EveryWeek;
        private bool _EveryWork;
        private int _NDayOnce;
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
        /// 非工作日
        /// </summary>
        public bool EveryWeek
        {
            get { return _EveryWeek; }
            set
            {
                _EveryWork = false;
                _NDayOnce = 0;
                _EveryWeek = value;
            }
        }

        /// <summary>
        /// 工作日
        /// </summary>
        public bool EveryWork
        {
            get { return _EveryWork; }
            set
            {
                _EveryWeek = false;
                _NDayOnce = 0;
                _EveryWork = value;
            }
        }
        /// <summary>
        /// 几天重复
        /// </summary>
        public int NDayOnce
        {
            get { return _NDayOnce; }
            set
            {
                _EveryWeek = false;
                _EveryWork = false;
                _NDayOnce = value;
            }
        }

        public List<CalendarADay> GetByDate(DateTime start, DateTime end, List<Notes> source)
        {
            List<CalendarADay> cd = new List<CalendarADay>();
            if (source != null && source.Count > 0)
            {
                List<PlanDutyDetail> planDutyDetailList =
                    new PlanDutyFacade().GetPlanDutyDetailByAccount(source[0].Owner.Id, start, end);

                foreach (Notes notes in source)
                {
                    if (notes.RepeatType is DayRepeat)
                    {
                        DayRepeat type = (DayRepeat) notes.RepeatType;

                        DateTime tempstart = type.RangeStart > start ? type.RangeStart : start;
                        DateTime tempend = type.RangeEnd == null || type.RangeEnd > end
                                               ? end
                                               : Convert.ToDateTime(type.RangeEnd);
                        DateTime date = tempstart;
                        int days = (tempend.Date - tempstart.Date).Days;
                        for (int i = 0; i <= days; i++)
                        {
                            bool isadd = false;
                            if (type.EveryWork || type.EveryWeek)
                            {
                                PlanDutyDetail detail = PlanDutyDetail.GetPlanDutyDetailByDate(planDutyDetailList, date);
                                if ((type.EveryWork && !detail.PlanDutyClass.IsWeek) ||
                                    (type.EveryWeek && detail.PlanDutyClass.IsWeek))
                                {
                                    isadd = true;
                                }
                            }
                            else
                            {
                                if ((date.Date - type.RangeStart.Date).Days%type.NDayOnce == 0)
                                {
                                    isadd = true;
                                }
                            }
                            if (isadd)
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
                            date=date.AddDays(1);
                        }
                    }
                }
            }

            return cd;
        }


        public void Valide()
        {
            if (NDayOnce <= 0 && !EveryWork && !EveryWeek)
            {
                throw new ApplicationException("请选择重复日期");
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
            return string.Format("{0}|{1}|{2}", NDayOnce, EveryWork, EveryWeek);
        }

        private void StringToType(string s)
        {
            string[] temp = s.Split('|');
            if (Convert.ToBoolean(temp[1]))
            {
                EveryWork = true;
            }
            else if (Convert.ToBoolean(temp[2]))
            {
                EveryWeek = true;
            }
            else
            {
                NDayOnce = Convert.ToInt32(temp[0]);
            }
        }
    }
}