//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CalculateDays.cs
// Creater:  Xue.wenlong
// Date:  2009-03-26
// Resume:�����ж��Ƿ��ǹ����յ�
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
        /// ���ÿ�ʼ����
        /// </summary>
        public DateTime StartDate
        {
            set { _StartDate = value; }
        }


        /// <summary>
        /// ���ý�������
        /// </summary>
        public DateTime EndDate
        {
            set { _EndDate = value; }
        }

        /// <summary>
        /// ��ȡ��ʼ���ڵ��������ڵĹ���������
        /// ��ʼ�պͽ����վ���������
        /// </summary>
        public int WorkDays
        {
            get { return GetWorkDays(); }
        }


        /// <summary>
        /// ������������
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
        /// �ж������Ƿ�Ϊ��һ�����壬��������������
        /// </summary>
        /// <returns>����һ�����巵��true</returns>
        private static bool IsWorkDay(DateTime dt)
        {
            return !IsWeekends(dt);
        }

        /// <summary>
        /// �õ�һ��ʱ����Ϊ�����գ���һ�����壩��������������ѯ����ֹ����
        /// </summary>
        /// <returns>�����յ�����</returns>
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
        /// �ж��Ƿ�����������
        /// </summary>
        private bool IsSpecialDay(DateTime dateTime)
        {
            return _SpecialDate.Contains(dateTime.Date);
        }

        /// <summary>
        /// �ж��Ƿ�����������
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
        /// ����(�����������ж�)����֮��
        /// ʵ�ʹ�����
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
        /// ��������֮��
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
        /// ����һ��ʱ���ڣ�Ϊ�����յ�����
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
        /// �ж�ĳһ���Ƿ��ǹ�����
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
        /// ����һ��ʱ���ڣ����е�����
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
        /// �ж��Ƿ�������������
        /// </summary>
        /// <returns>����һ�����巵��true</returns>
        public static bool IsWeekends(DateTime dt)
        {
            return (dt.DayOfWeek == DayOfWeek.Saturday) || (dt.DayOfWeek == DayOfWeek.Sunday);
        }
    }
}