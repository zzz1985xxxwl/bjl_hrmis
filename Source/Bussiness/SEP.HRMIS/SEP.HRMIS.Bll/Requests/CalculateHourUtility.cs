//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: CalculateHourUtility.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-13
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class CalculateHourUtility
    {
        private IPlanDutyDal _PlanDutyDal = new PlanDutyDal();
        private List<PlanDutyDetail> _PlanDutyDetailList;
        private DateTime _MorningStart;
        private DateTime _MorningEnd;
        private DateTime _AfternoonStart;
        private DateTime _AfternoonEnd;
        private readonly int _OneDayMaxHour = 8;

        /// <summary>
        /// 
        /// </summary>
        public void InitPlanDuty(DateTime from, DateTime to, int accountid)
        {
            _PlanDutyDetailList =
                _PlanDutyDal.GetPlanDutyDetailByAccount(accountid, from.AddMonths(-1), to.AddMonths(1));
            foreach (PlanDutyDetail detail in _PlanDutyDetailList)
            {
                //µ±Ã»ÓÐÅÅ°à
                if (detail.PlanDutyClass.DutyClassID > 0)
                {
                    _MorningStart = detail.PlanDutyClass.FirstStartFromTime;
                    _MorningEnd = detail.PlanDutyClass.FirstEndTime;
                    _AfternoonStart = detail.PlanDutyClass.SecondStartTime;
                    _AfternoonEnd =
                        detail.PlanDutyClass.FirstStartToTime.AddHours((_AfternoonStart - _MorningEnd).TotalHours +
                                                                       _OneDayMaxHour);
                    return;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime MorningStart
        {
            get
            {
                if (_MorningStart == DateTime.MinValue)
                {
                    return FixMorningStart;
                }
                return _MorningStart;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime MorningEnd
        {
            get
            {
                if (_MorningEnd == DateTime.MinValue)
                {
                    return FixMorningEnd;
                }
                return _MorningEnd;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime AfternoonStart
        {
            get
            {
                if (_AfternoonStart == DateTime.MinValue)
                {
                    return FixAfternoonStart;
                }
                return _AfternoonStart;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime AfternoonEnd
        {
            get
            {
                if (_AfternoonEnd == DateTime.MinValue)
                {
                    return FixAfternoonEnd;
                }
                return _AfternoonEnd;
            }
        }


        /// <summary>
        /// 8:00
        /// </summary>
        public static DateTime FixMorningStart
        {
            get { return new DateTime(2009, 1, 1, 8, 0, 0); }
        }

        /// <summary>
        /// 9:00
        /// </summary>
        public static DateTime FixMorningStartTo
        {
            get { return new DateTime(2009, 1, 1, 9, 10, 0); }
        }

        /// <summary>
        /// 11:30
        /// </summary>
        public static DateTime FixMorningEnd
        {
            get { return new DateTime(2009, 1, 1, 11, 30, 0); }
        }

        /// <summary>
        /// 12:30
        /// </summary>
        public static DateTime FixAfternoonStart
        {
            get { return new DateTime(2009, 1, 1, 12, 30, 0); }
        }

        /// <summary>
        /// 18:00
        /// </summary>
        public static DateTime FixAfternoonEnd
        {
            get { return new DateTime(2009, 1, 1, 18, 10, 0); }
        }
        /// <summary>
        /// 17:00
        /// </summary>
        public static DateTime FixAfternoonEndFrom
        {
            get { return new DateTime(2009, 1, 1, 17, 0, 0); }
        }
        /// <summary>
        /// for test
        /// </summary>
        public IPlanDutyDal MockIPlanDutyDal
        {
            set { _PlanDutyDal = value; }
        }
    }
}