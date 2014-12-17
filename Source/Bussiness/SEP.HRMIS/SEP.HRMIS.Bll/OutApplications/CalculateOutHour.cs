//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CalculateOutHour.cs
// Creater:  Xue.wenlong
// Date:  2009-04-16
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.Request;
using SEP.Model.Calendar;

namespace SEP.HRMIS.Bll.OutApplications
{
    /// <summary>
    /// 
    /// </summary>
    public class CalculateOutHour
    {
        private readonly DateTime _From;
        private readonly DateTime _To;
        private readonly int _AccountID;
        private readonly string _TypeName;
        private decimal _OneDayMaxHour = 8;
        private DateTime _MorningStart;
        private DateTime _MorningEnd;
        private DateTime _AfternoonStart;
        private DateTime _AfternoonEnd;
        private readonly IPlanDutyDal _PlanDutyDal = DalFactory.DataAccess.CreatePlanDutyDal();
        private List<PlanDutyDetail> _PlanDutyDetailList;
        private List<DayAttendance> _DayAttendanceList=new List<DayAttendance>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="accountID"></param>
        /// <param name="typeName"></param>
        public CalculateOutHour(DateTime from, DateTime to, int accountID, string typeName)
        {
            _From = from;
            _To = to;
            _AccountID = accountID;
            _TypeName = typeName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="accountID"></param>
        public CalculateOutHour(DateTime from, DateTime to, int accountID)
        {
            _From = from;
            _To = to;
            _AccountID = accountID;
            _TypeName = "外出";
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Excute()
        {
            _PlanDutyDetailList = _PlanDutyDal.GetPlanDutyDetailByAccount(_AccountID, _From, _To);
            return Calculate(_From, _To);
        }

        private decimal Calculate(DateTime from, DateTime to)
        {
            decimal costHour = 0m;
            if (from >= to)
            {
                DayAttendance dayAttendance = new DayAttendance(-1, _TypeName, 0, 0, from, "", CalendarType.Out);
                dayAttendance.FromTime = from;
                dayAttendance.ToTime = to;
                _DayAttendanceList.Add(dayAttendance);
                return 0;
            }
            int days = (to.Date - from.Date).Days;
            DateTime date = from;
            for (int i = 0; i <= days; i++)
            {
                PlanDutyDetail detail = PlanDutyDetail.GetPlanDutyDetailByDate(_PlanDutyDetailList, date);
                if (detail != null && detail.PlanDutyClass != null)
                {
                    _MorningStart = detail.PlanDutyClass.FirstStartFromTime;
                    _MorningEnd = detail.PlanDutyClass.FirstEndTime;
                    _AfternoonStart = detail.PlanDutyClass.SecondStartTime;
                    _AfternoonEnd = detail.PlanDutyClass.FirstStartToTime.AddHours((_AfternoonStart - _MorningEnd).TotalHours + (double)_OneDayMaxHour);
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
                    //排除双休日,节假日
                    if (!detail.PlanDutyClass.IsWeek)
                    {
                        decimal hour = CalculateOneDay(fromtemp, totemp);
                        costHour += hour;
                        DayAttendance dayAttendance = new DayAttendance(-1, _TypeName, hour, 0, date, "", CalendarType.Out);
                        dayAttendance.FromTime = from;
                        dayAttendance.ToTime = to;
                        _DayAttendanceList.Add(dayAttendance);
                    }
                    date = date.AddDays(1);
                }
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
        /// 测试
        /// </summary>
        public decimal TestCalculate(decimal oneDayMaxHour, List<PlanDutyDetail> planDutyDetailList)
        {
            _OneDayMaxHour = oneDayMaxHour;
            _PlanDutyDetailList = planDutyDetailList;
            return Calculate(_From, _To);
        }

        #endregion
    }
}