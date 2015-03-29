//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CalculateCostHour.cs
// Creater:  Xue.wenlong
// Date:  2009-03-25
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.SpecialDates;
using SEP.Model.Calendar;
using SEP.Model.SpecialDates;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 
    /// </summary>
    public class CalculateCostHour
    {
        private readonly ILeaveRequestType _LeaveRequestTypeDal = new LeaveRequestTypeDal();
        private readonly DateTime _From;
        private readonly DateTime _To;
        private readonly RequestStatus _RequestStatus;
        private readonly int _AccountID;
        private readonly int _LeaveRequestTypeID;
        private decimal _LeastHour;
        private string _LeaveRequestTypeName;
        private decimal _OneDayMaxHour = 8;
        private bool _IncludeLegalHoliday;
        private bool _IncludeRestDay;
        private readonly IPlanDutyDal _PlanDutyDal = new PlanDutyDal();
        private List<PlanDutyDetail> _PlanDutyDetailList;
        private DateTime _MorningStart;
        private DateTime _MorningEnd;
        private DateTime _AfternoonStart;
        private DateTime _AfternoonEnd;
        private List<DayAttendance> _DayAttendanceList = new List<DayAttendance>();
        private readonly ISpecialDateBll _SpecialDateBll = BllInstance.SpecialDateBllInstance;
        private readonly ILeaveRequestDal _leaveRequestDal=new LeaveRequestDal();
        private CalculateDays _CalculateDays;
        private List<LeaveRequest> _LeaveRequests=new List<LeaveRequest>(); 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="requestStatus"></param>
        /// <param name="accountID"></param>
        /// <param name="leaveRequestTypeID"></param>
        public CalculateCostHour(DateTime from, DateTime to, RequestStatus requestStatus, int accountID,
                                 int leaveRequestTypeID)
        {
            _From = from;
            _To = to;
            _RequestStatus = requestStatus;
            _AccountID = accountID;
            _LeaveRequestTypeID = leaveRequestTypeID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="accountID"></param>
        /// <param name="leaveRequestTypeID"></param>
        public CalculateCostHour(DateTime from, DateTime to, int accountID, int leaveRequestTypeID)
        {
            _From = from;
            _To = to;
            _AccountID = accountID;
            _LeaveRequestTypeID = leaveRequestTypeID;
            _RequestStatus = RequestStatus.All;
        }

        /// <summary>
        /// 
        /// </summary>
        public CalculateCostHour(DateTime from, DateTime to, int accountID, int leaveRequestTypeID,
                                 ILeaveRequestType mockILeaveRequestType, IPlanDutyDal mockIPlanDutyDal)
        {
            _From = from;
            _To = to;
            _AccountID = accountID;
            _LeaveRequestTypeID = leaveRequestTypeID;
            _LeaveRequestTypeDal = mockILeaveRequestType;
            _PlanDutyDal = mockIPlanDutyDal;
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
            LeaveRequestType leaveRequestType = _LeaveRequestTypeDal.GetLeaveRequestTypeByPkid(_LeaveRequestTypeID);
            _LeaveRequests=_leaveRequestDal.GetLeaveRequestByCondition(_AccountID, _From.Date, _To.Date.AddHours(24), RequestStatus.All);
            _LeaveRequestTypeName = leaveRequestType.Name;
            _LeastHour = leaveRequestType.LeastHour;
            _IncludeLegalHoliday = leaveRequestType.IncludeLegalHoliday == LegalHoliday.Include;
            _IncludeRestDay = leaveRequestType.IncludeRestDay == RestDay.Include;
            _PlanDutyDetailList = _PlanDutyDal.GetPlanDutyDetailByAccount(_AccountID, _From, _To);
            _CalculateDays = new CalculateDays(_SpecialDateBll.GetAllSpecialDate(null));
        }

        private decimal Calculate(DateTime from, DateTime to)
        {
            // -1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
            if (_RequestStatus == RequestStatus.New ||
                _RequestStatus == RequestStatus.Submit ||
                _RequestStatus == RequestStatus.Approving ||
                _RequestStatus == RequestStatus.CancelApproving ||
                _RequestStatus == RequestStatus.Cancelled)
            {
                _LeaveRequestTypeName = _LeaveRequestTypeName + "(" + _RequestStatus.Name + ")";
            }
            decimal costHour = 0m;
            if (from >= to)
            {
                DayAttendance dayAttendance =
                    new DayAttendance(_LeaveRequestTypeID, _LeaveRequestTypeName, 0, 0, from, "", CalendarType.Leave);
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
                    InitDateTime(detail);
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
                    decimal hour;
                    //排除双休日,节假日
                    if (_IncludeLegalHoliday && _CalculateDays.IsNationalHoliday(date))
                    {
                        if (detail.PlanDutyClass.IsWeek)
                        {
                            hour = _OneDayMaxHour;
                            costHour += hour;
                        }
                        else
                        {
                            hour = CalculateOneDay(fromtemp, totemp);
                            costHour += hour;
                        }
                        DayAttendance dayAttendance = 
                            new DayAttendance(_LeaveRequestTypeID, _LeaveRequestTypeName, hour, 0, date, "",
                                              CalendarType.Leave);
                        dayAttendance.FromTime = from;
                        dayAttendance.ToTime = to;
                        _DayAttendanceList.Add(dayAttendance);
                    }
                    else if (_IncludeRestDay && detail.PlanDutyClass.IsWeek && ! _CalculateDays.IsNationalHoliday(date))
                    {
                        hour = _OneDayMaxHour;
                        costHour += hour;
                        DayAttendance dayAttendance =
                            new DayAttendance(_LeaveRequestTypeID, _LeaveRequestTypeName, hour, 0, date, "",
                                              CalendarType.Leave);
                        dayAttendance.FromTime = from;
                        dayAttendance.ToTime = to;
                        _DayAttendanceList.Add(dayAttendance);
                    }
                    else if (!detail.PlanDutyClass.IsWeek)
                    {
                        hour = CalculateOneDay(fromtemp, totemp);
                        costHour += hour;
                        DayAttendance dayAttendance =
                            new DayAttendance(_LeaveRequestTypeID, _LeaveRequestTypeName, hour, 0, date, "",
                                              CalendarType.Leave);
                        dayAttendance.FromTime = from;
                        dayAttendance.ToTime = to;
                        _DayAttendanceList.Add(dayAttendance);
                    }
                    date = date.AddDays(1);
                }
            }
            return costHour;
        }

        private void InitDateTime(PlanDutyDetail detail)
        {
            DateTime lastenddate =
                detail.PlanDutyClass.FirstStartToTime.AddHours(
                    (detail.PlanDutyClass.SecondStartTime - detail.PlanDutyClass.FirstEndTime).
                        TotalHours + (double) _OneDayMaxHour);
            if (RequestUtility.ConvertToTime(_From) >=
                RequestUtility.ConvertToTime(detail.PlanDutyClass.FirstStartFromTime) &&
                RequestUtility.ConvertToTime(_From) <=
                RequestUtility.ConvertToTime(detail.PlanDutyClass.FirstStartToTime))
            {
                _MorningStart = RequestUtility.ConvertToTime(_From);
            }
            else
            {
                _MorningStart = RequestUtility.ConvertToTime(detail.PlanDutyClass.FirstStartFromTime);
            }
            if (RequestUtility.ConvertToTime(_To) >=
                RequestUtility.ConvertToTime(detail.PlanDutyClass.SecondEndTime) &&
                RequestUtility.ConvertToTime(_To) <=
                RequestUtility.ConvertToTime(lastenddate))
            {
                _AfternoonEnd = RequestUtility.ConvertToTime(_To);
            }
            else
            {
                _AfternoonEnd =
                    RequestUtility.ConvertToTime(lastenddate);
            }
            _MorningEnd = detail.PlanDutyClass.FirstEndTime;
            _AfternoonStart = detail.PlanDutyClass.SecondStartTime;
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
            DateTime fromDate = from.Date;
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
            //查询当天其它请假，总和不能超过8
            var requestsInDaysCostTime = 0m;
            foreach (var leaveRequest in _LeaveRequests)
            {
               var item= leaveRequest.LeaveRequestItems.Where(x => x.FromDate.Date == fromDate);
                if (item.Count() > 0)
                {
                    requestsInDaysCostTime += item.Sum(x => x.CostTime);
                }
            }
            answer=answer > _OneDayMaxHour ? _OneDayMaxHour : answer;
            var leftCostHour = _OneDayMaxHour - requestsInDaysCostTime;
            return answer > leftCostHour ? (leftCostHour < 0 ? 0 : leftCostHour) : answer;
        }

        private decimal ConvertToHour(decimal actualHour)
        {
            return decimal.Ceiling(decimal.ToInt32((actualHour/_LeastHour))*_LeastHour +
                   (actualHour%_LeastHour == 0 ? 0 : _LeastHour) );
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
        public decimal TestCalculate(decimal leastHour, bool includeRestDay, bool includeLegalHoliday,
                                     decimal oneDayMaxHour, List<PlanDutyDetail> planDutyDetaillist,
                                     CalculateDays calculateDays)
        {
            _LeastHour = leastHour;
            _IncludeLegalHoliday = includeLegalHoliday;
            _IncludeRestDay = includeRestDay;
            _OneDayMaxHour = oneDayMaxHour;
            _PlanDutyDetailList = planDutyDetaillist;
            _CalculateDays = calculateDays;
            return Calculate(_From, _To);
        }

        #endregion
    }
}