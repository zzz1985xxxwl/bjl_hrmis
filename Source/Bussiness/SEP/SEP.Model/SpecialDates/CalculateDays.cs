//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CalculateDays.cs
// Creater:  Xue.wenlong
// Date:  2009-03-26
// Resume:用于判断是否是工作日等
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.Model.SpecialDates
{
    /// <summary>
    /// 
    /// </summary>
    public class CalculateDays
    {
        private DateTime _StartDate;
        private DateTime _EndDate;
        private List<DateTime> _SpecialDate;
        private List<SpecialDate> _SpecialDates;

        #region Constructor

        public CalculateDays()
        {
            _SpecialDate = new List<DateTime>();
        }

        public CalculateDays(List<DateTime> specialDate)
        {
            _SpecialDate = specialDate;
        }

        public CalculateDays(List<SpecialDate> specialDates)
        {
            SpecialDates = specialDates;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 设置开始日期
        /// </summary>
        public DateTime StartDate
        {
            set { _StartDate = value; }
        }


        /// <summary>
        /// 设置结束日期
        /// </summary>
        public DateTime EndDate
        {
            set { _EndDate = value; }
        }

        /// <summary>
        /// 获取开始日期到结束日期的工作日天数
        /// 开始日和结束日均计算在内
        /// </summary>
        public int WorkDays
        {
            get { return GetWorkDays(); }
        }


        /// <summary>
        /// 设置特殊日期
        /// </summary>
        private List<SpecialDate> SpecialDates
        {
            set
            {
                _SpecialDates = value;
                _SpecialDate = new List<DateTime>();
                for (int i = 0; i < value.Count; i++)
                {
                    _SpecialDate.Add(Convert.ToDateTime(value[i].SpecialDateTime));
                }
            }
            get { return _SpecialDates; }
        }

        #endregion

        #region Private Method

        /// <summary>
        /// 判断日期是否为周一到周五，还是周六和周日
        /// </summary>
        /// <returns>是周一到周五返回true</returns>
        private static bool IsWorkDay(DateTime dt)
        {
            return !IsWeekends(dt);
        }

        /// <summary>
        /// 得到一段时间内为工作日（周一到周五）的天数，包括查询的起止日期
        /// </summary>
        /// <returns>工作日的天数</returns>
        private int GetWorkDays()
        {
            int count = 0;
            for (DateTime dt = _StartDate.Date; dt <= _EndDate.Date; dt = dt.AddDays(1))
            {
                if (IsWorkDay(dt))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// 判断是否是特殊日期
        /// </summary>
        private bool IsSpecialDay(DateTime dateTime)
        {
            return _SpecialDate.Contains(dateTime.Date);
        }

        /// <summary>
        /// 判断是否是特殊日期
        /// </summary>
        private bool IsWorkDayForSpecialDay(DateTime dateTime)
        {
            int i = _SpecialDate.IndexOf(dateTime.Date);
            return SpecialDates[i].IsWork == 1;
        }

        #endregion

        public bool IsNationalHoliday(DateTime dateTime)
        {
            int i = _SpecialDate.IndexOf(dateTime.Date);
            if (i != -1)
            {
                return SpecialDates[i].IsWork == 2;
            }
            return false;
        }

        /// <summary>
        /// 计算(加特殊日期判断)日期之差
        /// 实际工作日
        /// </summary>
        public int CountDaySpecial()
        {
            int count = 0;
            for (DateTime dt = _StartDate.Date; dt <= _EndDate.Date;)
            {
                if (IsSpecialDay(dt))
                {
                    if (IsWorkDayForSpecialDay(dt))
                    {
                        count++;
                    }
                }
                else
                {
                    if (IsWorkDay(dt))
                    {
                        count++;
                    }
                }
                dt = dt.AddDays(1);
            }
            return count;
        }

        /// <summary>
        /// 计算日期之差
        /// </summary>
        public int CountDay()
        {
            int count = 0;
            for (DateTime dt = _StartDate.Date; dt <= _EndDate.Date;)
            {
                count++;
                dt = dt.AddDays(1);
            }
            return count;
        }

        /// <summary>
        /// 查找一段时间内，为工作日的日子
        /// </summary>
        public List<DateTime> GetWorkDayOfDays()
        {
            List<DateTime> dt_Special = new List<DateTime>();

            for (DateTime dt = _StartDate.Date; dt <= _EndDate.Date;)
            {
                if (IsSpecialDay(dt))
                {
                    if (IsWorkDayForSpecialDay(dt))
                    {
                        dt_Special.Add(dt);
                    }
                }
                else
                {
                    if (IsWorkDay(dt))
                    {
                        dt_Special.Add(dt);
                    }
                }
                dt = dt.AddDays(1);
            }

            return dt_Special;
        }

        /// <summary>
        /// 判断某一天是否是工作日
        /// </summary>
        public bool IsWork(DateTime theDate)
        {
            if (IsSpecialDay(theDate))
            {
                return IsWorkDayForSpecialDay(theDate);
            }
            else
            {
                return IsWorkDay(theDate);
            }
        }

        /// <summary>
        /// 查找一段时间内，所有的日子
        /// </summary>
        public List<DateTime> GetAllDays()
        {
            List<DateTime> dt_Days = new List<DateTime>();
            for (DateTime dt = _StartDate.Date; dt <= _EndDate.Date;)
            {
                dt_Days.Add(dt);
                dt = dt.AddDays(1);
            }
            return dt_Days;
        }


        /// <summary>
        /// 判断是否是周六和周日
        /// </summary>
        /// <returns>是周一到周五返回true</returns>
        public static bool IsWeekends(DateTime dt)
        {
            return (dt.DayOfWeek == DayOfWeek.Saturday) || (dt.DayOfWeek == DayOfWeek.Sunday);
        }
    }
}