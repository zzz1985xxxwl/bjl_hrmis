//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CalculateOverWorkHour.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.Requests;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.Model.SpecialDates;

namespace SEP.HRMIS.Bll.OverWorks
{
    /// <summary>
    /// 
    /// </summary>
    public class CalculateOverWorkHour
    {
        private readonly DateTime _From;
        private readonly DateTime _To;
        private readonly int _AccountID;
        private OverWorkType _OverWorkType;
        private CalculateDays _CalculateDays;
        private DateTime _MorningStart;
        private DateTime _MorningEnd;
        private DateTime _AfternoonStart;
        private DateTime _AfternoonEnd;
        private readonly IPlanDutyDal _PlanDutyDal = DalFactory.DataAccess.CreatePlanDutyDal();
        private List<PlanDutyDetail> _PlanDutyDetailList;
        private readonly decimal _OneDayMaxHour = 8;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="accountID"></param>
        public CalculateOverWorkHour(DateTime from, DateTime to, int accountID)
        {
            _From = from;
            _To = to;
            _AccountID = accountID;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal Excute()
        {
            Init();
            return Calculate(_From, _To);
        }

        private void Init()
        {
            _CalculateDays = new CalculateDays(BllInstance.SpecialDateBllInstance.GetAllSpecialDate(null));
            _PlanDutyDetailList = _PlanDutyDal.GetPlanDutyDetailByAccount(_AccountID, _From, _To);
        }

        /// <summary>
        /// 
        /// </summary>
        public OverWorkType OverWorkType
        {
            get { return _OverWorkType; }
            set { _OverWorkType = value; }
        }

        private void JudgeOverWorkType()
        {
            if (_PlanDutyDetailList == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._OverWorkType_Not_OneDay);
            }
            else
            {
                PlanDutyDetail planDutyDetail = InitDate();
                if (_CalculateDays.IsNationalHoliday(_From))
                {
                    OverWorkType = OverWorkType.JieRi;
                }

                else if (planDutyDetail.PlanDutyClass.IsWeek)
                {
                    OverWorkType = OverWorkType.ShuangXiu;
                }
                else
                {
                    OverWorkType = OverWorkType.PuTong;
                }
            }
        }

        private PlanDutyDetail InitDate()
        {
            PlanDutyDetail planDutyDetail = PlanDutyDetail.GetPlanDutyDetailByDate(_PlanDutyDetailList, _From);
            _MorningStart = planDutyDetail.PlanDutyClass.FirstStartToTime == DateTime.MinValue
                                ? CalculateHourUtility.FixMorningStartTo
                                : planDutyDetail.PlanDutyClass.FirstStartToTime;
            _MorningEnd = planDutyDetail.PlanDutyClass.FirstEndTime == DateTime.MinValue
                              ? CalculateHourUtility.FixMorningEnd
                              : planDutyDetail.PlanDutyClass.FirstEndTime;
            _AfternoonStart = planDutyDetail.PlanDutyClass.SecondStartTime == DateTime.MinValue
                                  ? CalculateHourUtility.FixAfternoonStart
                                  : planDutyDetail.PlanDutyClass.SecondStartTime;
            _AfternoonEnd = planDutyDetail.PlanDutyClass.SecondEndTime == DateTime.MinValue
                                ? CalculateHourUtility.FixAfternoonEndFrom
                                : planDutyDetail.PlanDutyClass.SecondEndTime;

            return planDutyDetail;
        }

        private void JudgeIsOneDay()
        {
            if (_From > _To)
            {
                HrmisUtility.ThrowException(HrmisUtility._From_Bigger_To);
            }
            int days = (_To.Date - _From.Date).Days;
            if (days != 0)
            {
                if (!(days == 1 && _To.Hour == 0 && _To.Minute == 0))
                {
                    HrmisUtility.ThrowException(HrmisUtility._OverWorkType_Not_OneDay);
                }
            }
        }

        private decimal Calculate(DateTime from, DateTime to)
        {
            JudgeIsOneDay();
            JudgeOverWorkType();
            decimal costHour = 0m;
            if (from >= to)
            {
                return 0;
            }
            if (OverWorkType == OverWorkType.JieRi || OverWorkType == OverWorkType.ShuangXiu)
            {
                costHour += CalculateShuangXiu();
            }
            else
            {
                costHour += CalculatePuTong();
            }
            return costHour;
        }

        private decimal CalculateShuangXiu()
        {
            TimeSpan ts = _To - _From;
            double ans = ts.TotalHours;
            if (RequestUtility.ConvertToTime(_To) >= RequestUtility.ConvertToTime(_AfternoonStart) &&
                RequestUtility.ConvertToTime(_From) <= RequestUtility.ConvertToTime(_MorningEnd))
            {
                ans -=
                    (RequestUtility.ConvertToTime(_AfternoonStart) - RequestUtility.ConvertToTime(_MorningEnd)).
                        TotalHours;
            }
            return Convert.ToDecimal(ans);
        }

        private decimal CalculatePuTong()
        {
            DateTime fromtemp = RequestUtility.ConvertToTime(_From);
            DateTime totemp = RequestUtility.ConvertToTime(_To);
            if (_To.Hour == 0 && _To.Minute == 0)
            {
                totemp = totemp.AddDays(1);
            }
            _MorningStart = RequestUtility.ConvertToTime(_MorningStart);
            _AfternoonEnd = RequestUtility.ConvertToTime(_AfternoonEnd);
            if (fromtemp <= _AfternoonEnd && fromtemp >= _MorningStart)
            {
                fromtemp = _AfternoonEnd;
            }
            if (totemp <= _AfternoonEnd && totemp >= _MorningStart)
            {
                totemp = _MorningStart;
            }
            TimeSpan ts = totemp - fromtemp;
            TimeSpan tsw = _AfternoonEnd - _MorningStart;
            decimal ans = Convert.ToDecimal(ts.TotalHours);
            if (fromtemp <= _MorningStart && totemp >= _AfternoonEnd)
            {
                ans -= Convert.ToDecimal(tsw.TotalHours);
            }
            return ans > 0 ? ans : 0;
        }

        #region test

        /// <summary>
        /// ≤‚ ‘
        /// </summary>
        public decimal TestCalculate(CalculateDays calculateDays,
                                     List<PlanDutyDetail> planDutyDetailList)
        {
            _PlanDutyDetailList = planDutyDetailList;
            _CalculateDays = calculateDays;
            return Calculate(_From, _To);
        }

        #endregion
    }
}