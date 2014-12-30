//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: MonthRepeat.cs
// Creater:  Xue.wenlong
// Date:  2010-04-15
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
    /// 按月重复
    /// </summary>
    public class MonthRepeat : IRepeat
    {
        private DateTime _RangeStart;
        private DateTime? _RangeEnd;
        private int _NMonth;
        private NDayMonthEnum _NDayMonthEnum;
        private MonthDayTypeEnum _MonthDayTypeEnum;
        /// <summary>
        /// 几个月重复一次
        /// </summary>
        public int NMonth
        {
            get { return _NMonth; }
            set { _NMonth = value; }
        }
        /// <summary>
        /// 这个月的第几天
        /// </summary>
        public NDayMonthEnum NDayMonthEnum
        {
            get { return _NDayMonthEnum; }
            set { _NDayMonthEnum = value; }
        }
        /// <summary>
        /// 工作日，自然日，星期一，星期二...
        /// </summary>
        public MonthDayTypeEnum MonthDayTypeEnum
        {
            get { return _MonthDayTypeEnum; }
            set { _MonthDayTypeEnum = value; }
        }
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

        public List<CalendarADay> GetByDate(DateTime start, DateTime end, List<Notes> source)
        {
            List<CalendarADay> cd = new List<CalendarADay>();
            if (source != null && source.Count > 0)
            {
                _AccountID = source[0].Owner.Id;
                foreach (Notes notes in source)
                {
                    if (notes.RepeatType is MonthRepeat)
                    {
                        MonthRepeat type = (MonthRepeat) notes.RepeatType;

                        DateTime tempstart = type.RangeStart > start ? type.RangeStart : start;
                        DateTime tempend = type.RangeEnd == null || type.RangeEnd > end
                                               ? end
                                               : Convert.ToDateTime(type.RangeEnd);
                        DateTime date = tempstart;
                        int days = (tempend.Date - tempstart.Date).Days;
                        _PlanDutyFrom = new DateTime(tempstart.Year,tempstart.Month,1);
                        _PlanDutyTo = GetLastDate(tempend);
                        for (int i = 0; i <= days; i++)
                        {
                            if (RepeatValid(type, date))
                            {
                                List<MonthItem> monthitems = new List<MonthItem>();
                                MonthItem monthitem =
                                    new MonthItem(notes.Content,
                                                  RepeatUtility.DetailString(notes, notes.Start, notes.End), date,
                                                  CalendarShowType.Note);
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

        private static DateTime? GetSequenceDayOfWeek(int sequence, DayOfWeek dayOfWeek, DateTime monthDate)
        {
            if (sequence > 0)
            {
                DateTime dt = new DateTime(monthDate.Year, monthDate.Month, 1);
                dt = dt.AddDays((7 + Convert.ToInt32(dayOfWeek) - (int) dt.DayOfWeek)%7 + (sequence - 1)*7);
                if (dt.Month == monthDate.Month)
                {
                    return dt;
                }
            }
            //最后一天
            if (sequence == 0)
            {
                DateTime dt = GetLastDate(monthDate);
                return dt.AddDays((Convert.ToInt32(dayOfWeek) - (int)dt.DayOfWeek - 7) % 7);
            }
            return null;
        }

        private static DateTime GetLastDate(DateTime monthDate)
        {
            DateTime dt = new DateTime(monthDate.Year, monthDate.Month, 28);
            for (int i = 1; i < 4; i++)
            {
                if (dt.AddDays(1).Month == monthDate.Month)
                {
                    dt = dt.AddDays(1);
                }
                else
                {
                    return dt;
                }
            }
            return dt;
        }


        private static DateTime GetSequenceDayOfNaturl(int sequence, DateTime monthDate)
        {
            if (sequence > 0)
            {
                return (new DateTime(monthDate.Year, monthDate.Month, 1)).AddDays(sequence - 1);
            }
            else
            {
                return GetLastDate(monthDate);
            }
        }


        private List<PlanDutyDetail> _PlanDutyDetailList;
        private DateTime _PlanDutyFrom;
        private DateTime _PlanDutyTo;
        private int _AccountID;

        private DateTime? GetSequenceDayOfWork(int sequence, DateTime monthDate)
        {
            if (_PlanDutyDetailList == null)
            {
                _PlanDutyDetailList = (new PlanDutyFacade()).GetPlanDutyDetailByAccount(_AccountID, _PlanDutyFrom,
                    _PlanDutyTo);
            }
            DateTime dt = new DateTime(monthDate.Year, monthDate.Month, 1);
            if (sequence > 0)
            {
                int find = 0;
                for (int i = 0; i < (_PlanDutyTo.Date - _PlanDutyFrom.Date).Days; i++)
                {
                    PlanDutyDetail detail = PlanDutyDetail.GetPlanDutyDetailByDate(_PlanDutyDetailList, dt);
                    if (!detail.PlanDutyClass.IsWeek)
                    {
                        find++;
                        if (find == sequence)
                        {
                            return dt;
                        }
                    }
                    dt = dt.AddDays(1);
                }
            }
            else if (sequence == 0)
            {
                dt = GetLastDate(monthDate);
                for (int i = 0; i < (_PlanDutyTo.Date - _PlanDutyFrom.Date).Days; i++)
                {
                    PlanDutyDetail detail = PlanDutyDetail.GetPlanDutyDetailByDate(_PlanDutyDetailList, dt);
                    if (!detail.PlanDutyClass.IsWeek)
                    {
                        return dt;
                    }
                    dt = dt.AddDays(-1);
                }
            }
            return null;
        }

        private bool RepeatValid(MonthRepeat repeat, DateTime date)
        {
            bool valid = false;
            if (((date.Month - repeat.RangeStart.Month) + 12*(date.Year - repeat.RangeStart.Year))%repeat.NMonth == 0)
            {
                if (repeat.MonthDayTypeEnum.Value == MonthDayTypeEnum.Monday.Value)
                {
                    DateTime? dt = GetSequenceDayOfWeek(repeat.NDayMonthEnum.Value, DayOfWeek.Monday, date);
                    return dt != null && Convert.ToDateTime(dt).Date == date.Date;
                }
                else if (repeat.MonthDayTypeEnum.Value == MonthDayTypeEnum.Tuesday.Value)
                {
                    DateTime? dt = GetSequenceDayOfWeek(repeat.NDayMonthEnum.Value, DayOfWeek.Tuesday, date);
                    return dt != null && Convert.ToDateTime(dt).Date == date.Date;
                }
                else if (repeat.MonthDayTypeEnum.Value == MonthDayTypeEnum.Wednesday.Value)
                {
                    DateTime? dt = GetSequenceDayOfWeek(repeat.NDayMonthEnum.Value, DayOfWeek.Wednesday, date);
                    return dt != null && Convert.ToDateTime(dt).Date == date.Date;
                }
                else if (repeat.MonthDayTypeEnum.Value == MonthDayTypeEnum.Thursday.Value)
                {
                    DateTime? dt = GetSequenceDayOfWeek(repeat.NDayMonthEnum.Value, DayOfWeek.Thursday, date);
                    return dt != null && Convert.ToDateTime(dt).Date == date.Date;
                }
                else if (repeat.MonthDayTypeEnum.Value == MonthDayTypeEnum.Friday.Value)
                {
                    DateTime? dt = GetSequenceDayOfWeek(repeat.NDayMonthEnum.Value, DayOfWeek.Friday, date);
                    return dt != null && Convert.ToDateTime(dt).Date == date.Date;
                }
                else if (repeat.MonthDayTypeEnum.Value == MonthDayTypeEnum.Saturday.Value)
                {
                    DateTime? dt = GetSequenceDayOfWeek(repeat.NDayMonthEnum.Value, DayOfWeek.Saturday, date);
                    return dt != null && Convert.ToDateTime(dt).Date == date.Date;
                }
                else if (repeat.MonthDayTypeEnum.Value == MonthDayTypeEnum.Sunday.Value)
                {
                    DateTime? dt = GetSequenceDayOfWeek(repeat.NDayMonthEnum.Value, DayOfWeek.Sunday, date);
                    return dt != null && Convert.ToDateTime(dt).Date == date.Date;
                }
                else if (repeat.MonthDayTypeEnum.Value == MonthDayTypeEnum.Work.Value)
                {
                    DateTime? dt = GetSequenceDayOfWork(repeat.NDayMonthEnum.Value, date);
                    return dt != null && Convert.ToDateTime(dt).Date == date.Date;
                }
                else if (repeat.MonthDayTypeEnum.Value == MonthDayTypeEnum.Nature.Value)
                {
                    return GetSequenceDayOfNaturl(repeat.NDayMonthEnum.Value, date).Date == date.Date;
                }
            }
            return valid;
        }

        public void Valide()
        {
            if (NMonth <= 0)
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
            StringToEnum(sdr[Params.DBTypeString].ToString());
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
            return string.Format("{0}|{1}|{2}", NMonth, NDayMonthEnum.Value, MonthDayTypeEnum.Value);
        }

        public void StringToEnum(string s)
        {
            string[] temp = s.Split('|');
            NMonth = Convert.ToInt32(temp[0]);
            NDayMonthEnum = NDayMonthEnum.GetByValue(Convert.ToInt32(temp[1]));
            MonthDayTypeEnum = MonthDayTypeEnum.GetByValue(Convert.ToInt32(temp[2]));
        }
    }

    public class MonthDayTypeEnum
    {
        private int _Value;
        private string _Name;

        public MonthDayTypeEnum(int value, string name)
        {
            _Value = value;
            _Name = name;
        }

        public static MonthDayTypeEnum Monday = new MonthDayTypeEnum(1, "星期一");
        public static MonthDayTypeEnum Tuesday = new MonthDayTypeEnum(2, "星期二");
        public static MonthDayTypeEnum Wednesday = new MonthDayTypeEnum(3, "星期三");
        public static MonthDayTypeEnum Thursday = new MonthDayTypeEnum(4, "星期四");
        public static MonthDayTypeEnum Friday = new MonthDayTypeEnum(5, "星期五");
        public static MonthDayTypeEnum Saturday = new MonthDayTypeEnum(6, "星期六");
        public static MonthDayTypeEnum Sunday = new MonthDayTypeEnum(0, "星期日");
        public static MonthDayTypeEnum Nature = new MonthDayTypeEnum(8, "自然日");
        public static MonthDayTypeEnum Work = new MonthDayTypeEnum(9, "工作日");

        public int Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public static List<MonthDayTypeEnum> GetAll()
        {
            List<MonthDayTypeEnum> temp = new List<MonthDayTypeEnum>();
            temp.Add(Nature);
            temp.Add(Work);
            temp.Add(Monday);
            temp.Add(Tuesday);
            temp.Add(Wednesday);
            temp.Add(Thursday);
            temp.Add(Friday);
            temp.Add(Saturday);
            temp.Add(Sunday);
            return temp;
        }

        public static MonthDayTypeEnum GetByValue(int value)
        {
            List<MonthDayTypeEnum> temp = GetAll();
            foreach (MonthDayTypeEnum typeEnum in temp)
            {
                if (typeEnum.Value == value)
                {
                    return typeEnum;
                }
            }
            return null;
        }
    }

    public class NDayMonthEnum
    {
        private int _Value;
        private string _Name;

        public NDayMonthEnum(int value, string name)
        {
            _Value = value;
            _Name = name;
        }

        public static NDayMonthEnum First = new NDayMonthEnum(1, "第一个");
        public static NDayMonthEnum Second = new NDayMonthEnum(2, "第二个");
        public static NDayMonthEnum Third = new NDayMonthEnum(3, "第三个");
        public static NDayMonthEnum Fourth = new NDayMonthEnum(4, "第四个");
        public static NDayMonthEnum Last = new NDayMonthEnum(0, "最后一个");

        public int Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public static List<NDayMonthEnum> GetAll()
        {
            List<NDayMonthEnum> temp = new List<NDayMonthEnum>();
            temp.Add(First);
            temp.Add(Second);
            temp.Add(Third);
            temp.Add(Fourth);
            temp.Add(Last);
            return temp;
        }

        public static NDayMonthEnum GetByValue(int value)
        {
            List<NDayMonthEnum> temp = GetAll();
            foreach (NDayMonthEnum typeEnum in temp)
            {
                if (typeEnum.Value == value)
                {
                    return typeEnum;
                }
            }
            return null;
        }
    }
}