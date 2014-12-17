//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: CalculateOutCityHour.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-04
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.Requests;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.Model.Calendar;

namespace SEP.HRMIS.Bll.OutApplications
{
    /// <summary>
    /// 
    /// </summary>
    public class CalculateOutCityHour
    {
        private readonly DateTime _From;
        private readonly DateTime _To;
        private readonly string _TypeName;
        private readonly decimal _OneDayMaxHour = 8;
        private List<DayAttendance> _DayAttendanceList = new List<DayAttendance>();
        private readonly int _AccountID;
        private DateTime _MorningStart;
        private DateTime _MorningEnd;
        private DateTime _AfternoonStart;
        private DateTime _AfternoonEnd;

        /// <summary>
        /// 
        /// </summary>
        public CalculateOutCityHour(DateTime from, DateTime to, int accountid)
            : this(from, to, OutType.OutCity.Name, accountid)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public CalculateOutCityHour(DateTime from, DateTime to, string typename, int accountid)
        {
            _From = from;
            _To = to;
            _AccountID = accountid;
            _TypeName = typename;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal Excute()
        {
            CalculateHourUtility calculateHourUtility = new CalculateHourUtility();
            calculateHourUtility.InitPlanDuty(_From, _To, _AccountID);
            _MorningStart = calculateHourUtility.MorningStart;
            _MorningEnd = calculateHourUtility.MorningEnd;
            _AfternoonStart = calculateHourUtility.AfternoonStart;
            _AfternoonEnd = calculateHourUtility.AfternoonEnd;
            return Calculate(_From, _To);
        }

        private decimal Calculate(DateTime from, DateTime to)
        {
            decimal costHour = 0m;
            if (from >= to)
            {
                _DayAttendanceList.Add(new DayAttendance(-1, _TypeName, 0, 0, from, "", CalendarType.Out));
                return 0;
            }
            int days = (to.Date - from.Date).Days;
            DateTime date = from;

            for (int i = 0; i <= days; i++)
            {
                if (i == 0 || i == days)
                {
                    DateTime fromtemp = _MorningStart;
                    DateTime totemp = _AfternoonEnd;
                    if (i == 0)
                    {
                        fromtemp = from;
                    }
                    if (i == days)
                    {
                        totemp = to;
                    }
                    decimal hour = CalculateOneDay(fromtemp, totemp);
                    costHour += hour;
                    _DayAttendanceList.Add(new DayAttendance(-1, _TypeName, hour, 0, date, "", CalendarType.Out));
                }
                else
                {
                    costHour += _OneDayMaxHour;
                    _DayAttendanceList.Add(
                        new DayAttendance(-1, _TypeName, _OneDayMaxHour, 0, date, "", CalendarType.Out));
                }
                date = date.AddDays(1);
            }
            return costHour;
        }

        private void InitRule()
        {
            _MorningStart = RequestUtility.ConvertToTime(_MorningStart);
            _MorningEnd = RequestUtility.ConvertToTime(_MorningEnd);
            _AfternoonStart = RequestUtility.ConvertToTime(_AfternoonStart);
            _AfternoonEnd = RequestUtility.ConvertToTime(_AfternoonEnd);
        }

        private decimal CalculateOneDay(DateTime from, DateTime to)
        {
            InitRule();
            from = RequestUtility.ConvertToTime(from);
            to = RequestUtility.ConvertToTime(to);
            DateTime fromtemp = from;
            DateTime totemp = to;
            if (from <= _MorningStart)
            {
                fromtemp = _MorningStart;
            }
            else if (from >= _MorningEnd &&
                     from <= _AfternoonStart)
            {
                fromtemp = _AfternoonStart;
            }
            if (RequestUtility.ConvertToTime(to) >= _AfternoonEnd)
            {
                totemp = _AfternoonEnd;
            }
            else if (to >= _MorningEnd &&
                     to <= _AfternoonStart)
            {
                totemp = _MorningEnd;
            }
            TimeSpan ts = totemp - fromtemp;
            decimal costMinutes = ts.TotalMinutes < 0 ? 0m : Convert.ToDecimal(ts.TotalMinutes);
            if (fromtemp <= _MorningEnd &&
                fromtemp >= _MorningStart &&
                totemp <= _AfternoonEnd &&
                totemp >= _AfternoonStart)
            {
                costMinutes -= Convert.ToDecimal((_AfternoonStart - _MorningEnd).TotalMinutes);
            }
            decimal answer = ConvertToHour(costMinutes/60);
            return answer > _OneDayMaxHour ? _OneDayMaxHour : answer;
        }

        private static decimal ConvertToHour(decimal actualHour)
        {
            return decimal.Round(actualHour, 2);
        }

        /// <summary>
        /// 
        /// </summary>
        public List<DayAttendance> DayAttendanceList
        {
            get { return _DayAttendanceList; }
            set { _DayAttendanceList = value; }
        }

        #region test

        /// <summary>
        /// ≤‚ ‘
        /// </summary>
        public decimal TestCalculate(DateTime morningstart,DateTime moringend,DateTime afterstrat,DateTime afterend )
        {
            _MorningStart = morningstart;
            _MorningEnd = moringend;
            _AfternoonStart = afterstrat;
            _AfternoonEnd = afterend;
            return Calculate(_From, _To);
        }

        #endregion
    }
}