//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeAttendance.cs
// 创建者: wyq
// 创建日期: 2008-09-02
// 概述: 统计员工的请出勤情况
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.Model.Calendar;
using SEP.Model.Utility;
namespace SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics
{
    ///<summary>
    /// 员工考勤统计
    ///</summary>
    [Serializable]
    public class EmployeeAttendance
    {
        private DateTime _FromDate;
        private DateTime _ToDate;

        //进出打卡记录统计
        private AttendanceInAndOutStatistics _AttendanceInAndOutStatistics;
        //进出打卡记录列表
        private List<AttendanceInAndOutRecord.AttendanceInAndOutRecord> _AttendanceInAndOutRecordList;
        //排班表
        private List<PlanDutyTable> _PlanDutyTableList;
        //排班细节列表
        private List<PlanDutyDetail> _PlanDutyDetailList;

        ////统计出的迟到早退旷工记录列表
        private List<AttendanceBase> _AttendanceBaseStatisticList;
        //门禁卡卡号
        private string _DoorCardNo;  //员工门禁卡卡号
        private List<OutApplication.OutApplication> _OutApplication;
        private List<OverWork.OverWork> _OverWork;
        private List<LeaveRequest> _LeaveRequestList;
        private List<AttendanceBase> _AttendanceBaseList;
        private List<DayAttendance> _DayAttendanceList;
        private MonthAttendance _MonthAttendance;
        private DayAttendanceWeek _DayAttendanceWeek;
        private Vacation _Vacation;

        /// <summary>
        /// 上班时间总合允许两分钟的误差
        /// </summary>
        private const decimal AllowJudgeErrorMinOfWorkTime = 2;
        /// <summary>
        /// 构造函数
        /// </summary>
        ///<summary>
        /// 构造函数
        ///</summary>
        public EmployeeAttendance()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dtFrom"></param>
        /// <param name="dtTo"></param>
        public EmployeeAttendance(DateTime dtFrom, DateTime dtTo)
        {
            _FromDate = dtFrom;
            _ToDate = dtTo;
            //_Employee = employee;
            _DayAttendanceList = new List<DayAttendance>();
            _MonthAttendance = new MonthAttendance();
            _AttendanceBaseList = new List<AttendanceBase>();
            _OutApplication = new List<OutApplication.OutApplication>();
            _OverWork = new List<OverWork.OverWork>();
            _LeaveRequestList = new List<LeaveRequest>();
        }
        /// <summary>
        /// 年假信息
        /// </summary>
        public Vacation Vacation
        {
            get { return _Vacation; }
            set { _Vacation = value; }
        }
        /// <summary>
        /// 周考勤信息
        /// </summary>
        public DayAttendanceWeek DayAttendanceWeek
        {
            get { return _DayAttendanceWeek; }
            set { _DayAttendanceWeek = value; }
        }

        /// <summary>
        /// FromDate到ToDate时间段内的 当前员工加班外出详情
        /// </summary>
        //public List<Application> ApplicationList
        //{
        //    get { return _ApplicationList; }
        //    set { _ApplicationList = value; }
        //}
        /// <summary>
        /// FromDate到ToDate时间段内的 当前员工请假详情
        /// </summary>
        public List<LeaveRequest> LeaveRequestList
        {
            get { return _LeaveRequestList; }
            set { _LeaveRequestList = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 当前员工迟到早退矿工详情
        /// </summary>
        public List<AttendanceBase> AttendanceBaseList
        {
            get { return _AttendanceBaseList; }
            set { _AttendanceBaseList = value; }
        }
        ///// <summary>
        ///// 当前员工信息
        ///// </summary>
        //public Employee Employee
        //{
        //    get { return _Employee; }
        //    set { _Employee = value; }
        //}
        /// <summary>
        /// 当前统计开始时间
        /// </summary>
        public DateTime FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        /// <summary>
        /// 当前统计结束时间
        /// </summary>
        public DateTime ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 当前员工日考勤明细
        /// </summary>
        public List<DayAttendance> DayAttendanceList
        {
            get { return _DayAttendanceList; }
            set { _DayAttendanceList = value; }
        }
        /// <summary>
        /// 员工月考勤情况
        /// </summary>
        public MonthAttendance MonthAttendance
        {
            get { return _MonthAttendance; }
            set { _MonthAttendance = value; }
        }
        /// <summary>
        /// 员工进入时间统计
        /// </summary>
        public AttendanceInAndOutStatistics AttendanceInAndOutStatistics
        {
            get
            {
                return _AttendanceInAndOutStatistics;
            }
            set
            {
                _AttendanceInAndOutStatistics = value;
            }
        }
        /// <summary>
        /// 进出时间列表
        /// </summary>
        public List<AttendanceInAndOutRecord.AttendanceInAndOutRecord> AttendanceInAndOutRecordList
        {
            get
            {
                return _AttendanceInAndOutRecordList;
            }
            set
            {
                _AttendanceInAndOutRecordList = value;
            }
        }
        /// <summary>
        /// 统计出的迟到早退旷工列表
        /// </summary>
        public List<AttendanceBase> AttendanceBaseStatisticList
        {
            get
            {
                return _AttendanceBaseStatisticList;
            }
            set
            {
                _AttendanceBaseStatisticList = value;
            }
        }
        /// <summary>
        /// 员工门禁卡卡号
        /// </summary>
        public string DoorCardNo
        {
            get
            {
                return _DoorCardNo;
            }
            set
            {
                _DoorCardNo = value;
            }
        }
        ///<summary>
        /// 排班表列表
        ///</summary>
        public List<PlanDutyTable> PlanDutyTableList
        {
            get { return _PlanDutyTableList; }
            set { _PlanDutyTableList = value; }
        }
        /// <summary>
        /// 排班表详情
        /// </summary>
        public List<PlanDutyDetail> PlanDutyDetailList
        {
            get { return _PlanDutyDetailList; }
            set { _PlanDutyDetailList = value; }
        }

        ///<summary>
        /// 外出申请
        ///</summary>
        public List<OutApplication.OutApplication> OutApplicationList
        {
            get { return _OutApplication; }
            set { _OutApplication = value; }
        }
        /// <summary>
        /// 加班申请
        /// </summary>
        public List<OverWork.OverWork> OverWorkList
        {
            get { return _OverWork; }
            set { _OverWork = value; }
        }


        #region DayAttendanceWeek
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        public void GetDayAttendanceWeekByDate(Employee employee)
        {
            //查找一段时间内，某一员工的考勤信息
            List<DayAttendance> dayAttendanceList = _DayAttendanceList.FindAll(FindDayAttendance);
            for (int i = 0; i < dayAttendanceList.Count; i++)
            {
                switch (dayAttendanceList[i].Date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        _DayAttendanceWeek.Sun += ShowTitle(dayAttendanceList[i]) + "<br />";
                        _DayAttendanceWeek.SunColor = SetColor(dayAttendanceList[i]);
                        break;
                    case DayOfWeek.Monday:
                        _DayAttendanceWeek.Mon += ShowTitle(dayAttendanceList[i]) + "<br />";
                        _DayAttendanceWeek.MonColor = SetColor(dayAttendanceList[i]);
                        break;
                    case DayOfWeek.Tuesday:
                        _DayAttendanceWeek.Tues += ShowTitle(dayAttendanceList[i]) + "<br />";
                        _DayAttendanceWeek.TuesColor = SetColor(dayAttendanceList[i]);
                        break;
                    case DayOfWeek.Wednesday:
                        _DayAttendanceWeek.Wedn += ShowTitle(dayAttendanceList[i]) + "<br />";
                        _DayAttendanceWeek.WednColor = SetColor(dayAttendanceList[i]);
                        break;
                    case DayOfWeek.Thursday:
                        _DayAttendanceWeek.Thurs += ShowTitle(dayAttendanceList[i]) + "<br />";
                        _DayAttendanceWeek.ThursColor = SetColor(dayAttendanceList[i]);
                        break;
                    case DayOfWeek.Friday:
                        _DayAttendanceWeek.Fri += ShowTitle(dayAttendanceList[i]) + "<br />";
                        _DayAttendanceWeek.FriColor = SetColor(dayAttendanceList[i]);
                        break;
                    case DayOfWeek.Saturday:
                        _DayAttendanceWeek.Sat += ShowTitle(dayAttendanceList[i]) + "<br />";
                        _DayAttendanceWeek.SatColor = SetColor(dayAttendanceList[i]);
                        break;
                    default:
                        break;
                }
            }
            string color;
            _DayAttendanceWeek.Mon = SetDefaultWeek(employee, _DayAttendanceWeek.Mon, _FromDate, _DayAttendanceWeek.MonColor, out color);
            _DayAttendanceWeek.MonColor = color;
            _DayAttendanceWeek.Tues = SetDefaultWeek(employee, _DayAttendanceWeek.Tues, _FromDate.AddDays(1), _DayAttendanceWeek.TuesColor, out color);
            _DayAttendanceWeek.TuesColor = color;
            _DayAttendanceWeek.Wedn = SetDefaultWeek(employee, _DayAttendanceWeek.Wedn, _FromDate.AddDays(2), _DayAttendanceWeek.WednColor, out color);
            _DayAttendanceWeek.WednColor = color;
            _DayAttendanceWeek.Thurs = SetDefaultWeek(employee, _DayAttendanceWeek.Thurs, _FromDate.AddDays(3), _DayAttendanceWeek.ThursColor, out color);
            _DayAttendanceWeek.ThursColor = color;
            _DayAttendanceWeek.Fri = SetDefaultWeek(employee, _DayAttendanceWeek.Fri, _FromDate.AddDays(4), _DayAttendanceWeek.FriColor, out color);
            _DayAttendanceWeek.FriColor = color;
            _DayAttendanceWeek.Sat = SetDefaultWeek(employee, _DayAttendanceWeek.Sat, _FromDate.AddDays(5), _DayAttendanceWeek.SatColor, out color);
            _DayAttendanceWeek.SatColor = color;
            _DayAttendanceWeek.Sun = SetDefaultWeek(employee, _DayAttendanceWeek.Sun, _FromDate.AddDays(6), _DayAttendanceWeek.SunColor, out color);
            _DayAttendanceWeek.SunColor = color;
        }
        private DateTime _Date;
        public string SetDefaultWeek(Employee employee, string weekTitle,
            DateTime date, string oldColor, out string color)
        {
            //查看这一天员工是否进入公司
            if (DateTime.Compare(employee.EmployeeDetails.Work.ComeDate, date) > 0)
            {
                color = "#eeeeee";
                weekTitle = "未入职";
                return weekTitle;
            }
            //查看这一天员工是否离开公司
            if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee &&
                employee.EmployeeDetails.Work.DimissionInfo != null &&
                DateTime.Compare(employee.EmployeeDetails.Work.DimissionInfo.DimissionDate, date) < 0)
            {
                color = "#eeeeee";
                weekTitle = "离职";
                return weekTitle;
            }
            _Date = date;
            PlanDutyDetail planDutyDetail;
            if (_PlanDutyDetailList != null)
            {
                planDutyDetail = _PlanDutyDetailList.Find(FindThePlanDutyDetail);
            }
            else
            {
                planDutyDetail = null;
            }
            if (planDutyDetail == null)
            {
                if (date.DayOfWeek == DayOfWeek.Sunday ||
                    date.DayOfWeek == DayOfWeek.Saturday)
                {
                    color = (!string.IsNullOrEmpty(oldColor)) ? oldColor : "#ffeded";
                    weekTitle = (!string.IsNullOrEmpty(weekTitle)) ? weekTitle : "休息" + "<br />";
                }
                else
                {
                    color = (!string.IsNullOrEmpty(oldColor)) ? oldColor : "#FFFFFF";
                    weekTitle = (!string.IsNullOrEmpty(weekTitle)) ? weekTitle : "工作" + "<br />";
                }
            }
            else
            {
                color = (!string.IsNullOrEmpty(oldColor)) ? oldColor :
                    (planDutyDetail.PlanDutyClass.DutyClassID == -1 ? "#ffeded" : "#FFFFFF");
                weekTitle = (!string.IsNullOrEmpty(weekTitle)) ? weekTitle :
                    (planDutyDetail.PlanDutyClass.DutyClassName);
            }
            InAndOutStatistics(date);
            //目前认为进或出仅有一个为空的情况就是数据有误
            
            string absentString="";

            bool isIncludeOutInTime;
            if (bool.TryParse(CompanyConfig.ATTENDANCEISNORMALISINCLUDEOUTINTIME, out isIncludeOutInTime)
                && isIncludeOutInTime &&
                date.Date < DateTime.Now.Date
                && (IsOutInTimeCondition(OutInTimeConditionEnum.InOrOutTimeOnlyOneIsNull) ||
                !StatisticIsNormal(date, out absentString)))
            {
                color = "#ff0000";
                weekTitle = weekTitle + "数据有误！" + absentString;
            }
            return weekTitle;
        }


        private bool FindDayAttendance(DayAttendance dayAttendance)
        {
            if ((DateTime.Compare(dayAttendance.Date.Date, _FromDate) >= 0 &&
                DateTime.Compare(dayAttendance.Date.Date, _ToDate) <= 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string SetColor(DayAttendance dayAttendance)
        {
            switch (dayAttendance.CalendarType)
            {
                case CalendarType.Absent:
                    return "#fac3ff";
                case CalendarType.Out:
                    return "#bcffb3";
                case CalendarType.Leave:
                    return "#c6edff";
                case CalendarType.Late:
                case CalendarType.LeaveEarly:
                    return "#fff9c2";
                case CalendarType.OverTime:
                    return "#9ffffe";
                case CalendarType.NotEntryDayNum://未入职
                case CalendarType.DimissionDayNum://离职
                    return "#eeeeee";
                default:
                    return "";
            }
        }
        private static string ShowTitle(DayAttendance dayAttendance)
        {
            if (dayAttendance.CalendarType == CalendarType.Late ||
                dayAttendance.CalendarType == CalendarType.LeaveEarly)//如果迟到或早退,显示分钟
            {
                return dayAttendance.TypeName + dayAttendance.Minites + "分";
            }
            else
            {
                //return dayAttendance.TypeName + dayAttendance.Days*8 + "小时";
                return dayAttendance.TypeName +
                    Convert.ToSingle(decimal.Round(Convert.ToDecimal(dayAttendance.Hours), 2)) + "小时";
            }
        }
        #endregion

        #region MonthAttendance
        /// <summary>
        /// 计算FromDate到ToDate时间段内的 请假天数
        /// </summary>
        public void MonthAttendanceCaculateLeaveInfo()
        {
            for (int i = 0; i < _DayAttendanceList.Count; i++)
            {
                if (DateTime.Compare(_DayAttendanceList[i].Date.Date, _FromDate.Date) < 0
                    || DateTime.Compare(_DayAttendanceList[i].Date.Date, _ToDate.Date) > 0)
                {
                    continue;
                }
                if (_DayAttendanceList[i].CalendarType != CalendarType.Leave)
                {
                    continue;
                }
                BindLeaveRequestStatistics(_DayAttendanceList[i]);
                BindLeaveRequestTypeEnum(_DayAttendanceList[i].TypeID, _DayAttendanceList[i].Hours);
                BindLeaveRequestOnDutyStatistics(_DayAttendanceList[i].TypeID, _DayAttendanceList[i].Hours,
                                                 _DayAttendanceList[i].Date);
            }
        }
        /// <summary>
        /// 计算上班时请假天数，目前用于bjl的计算工作日请产假天数
        /// </summary>
        /// <param name="typeID"></param>
        /// <param name="hours"></param>
        /// <param name="date"></param>
        private void BindLeaveRequestOnDutyStatistics(int typeID, decimal hours, DateTime date)
        {
            if (PlanDutyDetailList == null)
            {
                return;
            }

            #region 判断date是否应该上班

            bool isShouldWork = false;
            foreach (PlanDutyDetail pdd in PlanDutyDetailList)
            {
                if (DateTime.Compare(pdd.Date.Date, date.Date) == 0 && pdd.PlanDutyClass.DutyClassID > -1)
                {
                    isShouldWork = true;
                    break;
                }
            }
            if (!isShouldWork)
            {
                return;
            }

            #endregion

            switch (typeID)
            {
                case (int) LeaveRequestTypeEnum.ChanJia:
                    _MonthAttendance.HoursofOnDutyMaternityLeave += hours;
                    break;
                default:
                    break;
            }
        }

        private void BindLeaveRequestStatistics(DayAttendance dayAttendance)
        {
            foreach (LeaveRequestStatistics item in _MonthAttendance.LeaveRequestStatisticsList)
            {
                if(dayAttendance.TypeID == item.LeaveRequestType.LeaveRequestTypeID)
                {
                    item.Hours += dayAttendance.Hours;
                    return;
                }
            }
            LeaveRequestStatistics newLeaveRequestStatistics =
                new LeaveRequestStatistics(
                    new LeaveRequestType(dayAttendance.TypeID, dayAttendance.TypeName, "", LegalHoliday.Include,
                                         RestDay.Include, 0));
            newLeaveRequestStatistics.Hours = dayAttendance.Hours;
            _MonthAttendance.LeaveRequestStatisticsList.Add(newLeaveRequestStatistics);
        }

        private void BindLeaveRequestTypeEnum(int typeID, decimal hours)
        {
            switch (typeID)
            {
                case (int) LeaveRequestTypeEnum.ShiJia:
                    _MonthAttendance.HoursofPersonalReasonLeave += hours;
                    break;
                case (int) LeaveRequestTypeEnum.AnnualLeave:
                    _MonthAttendance.HoursofLunarPeriodLeave += hours;
                    break;
                case (int) LeaveRequestTypeEnum.BingJia:
                    _MonthAttendance.HoursofSickLeave += hours;
                    break;
                case (int) LeaveRequestTypeEnum.AdjustRest:
                    _MonthAttendance.HoursofAdjustRestLeave += hours;
                    break;
                case (int) LeaveRequestTypeEnum.ChanQianJia:
                    _MonthAttendance.HoursofPrenatalLeave += hours;
                    _MonthAttendance.HoursofOtherLeave += hours;
                    break;
                case (int) LeaveRequestTypeEnum.BuRuJia:
                    _MonthAttendance.HoursofBreastFeedLeave += hours;
                    _MonthAttendance.HoursofOtherLeave += hours;
                    break;
                case (int) LeaveRequestTypeEnum.ChanJia:
                    _MonthAttendance.HoursofMaternityLeave += hours;
                    _MonthAttendance.HoursofOtherLeave += hours;
                    break;
                case (int) LeaveRequestTypeEnum.SangJia:
                    _MonthAttendance.HoursofBereavementLeave += hours;
                    _MonthAttendance.HoursofOtherLeave += hours;
                    break;
                case (int) LeaveRequestTypeEnum.HunJia:
                    _MonthAttendance.HoursofMarriageLeave += hours;
                    _MonthAttendance.HoursofOtherLeave += hours;
                    break;
                case (int) LeaveRequestTypeEnum.HuLiJia:
                    _MonthAttendance.HoursofCareLeave += hours;
                    _MonthAttendance.HoursofOtherLeave += hours;
                    break;
                default:
                    _MonthAttendance.HoursofOtherLeave += hours;
                    break;
            }
        }

        /// <summary>
        /// 计算FromDate到ToDate时间段内的 加班天数
        /// </summary>
        public void MonthAttendanceCaculateOvertimeInfo()
        {
            for (int i = 0; i < _DayAttendanceList.Count; i++)
            {
                if (DateTime.Compare(_DayAttendanceList[i].Date.Date, _FromDate.Date) < 0
                    || DateTime.Compare(_DayAttendanceList[i].Date.Date, _ToDate.Date) > 0)
                {
                    continue;
                }

                if (_DayAttendanceList[i].CalendarType != CalendarType.OverTime)
                {
                    continue;
                }
                OverWorkType owt = OverWorkUtility.GetOverWorkTypeByName(_DayAttendanceList[i].TypeName);
                switch (owt)
                {
                    case OverWorkType.PuTong:
                        _MonthAttendance.HoursofCommonOvertime += _DayAttendanceList[i].Hours;
                        _MonthAttendance.HoursofOvertime += _DayAttendanceList[i].Hours;
                        break;
                    case OverWorkType.ShuangXiu:
                        _MonthAttendance.HoursofWeekendOvertime += _DayAttendanceList[i].Hours;
                        _MonthAttendance.HoursofOvertime += _DayAttendanceList[i].Hours;
                        break;
                    case OverWorkType.JieRi:
                        _MonthAttendance.HoursofHolidayOvertime += _DayAttendanceList[i].Hours;
                        _MonthAttendance.HoursofOvertime += _DayAttendanceList[i].Hours;
                        break;
                    case OverWorkType.PuTongNotAdjust:
                        _MonthAttendance.HoursofCommonOvertimeNotAdjust += _DayAttendanceList[i].Hours;
                        break;
                    case OverWorkType.ShuangXiuNotAdjust:
                        _MonthAttendance.HoursofWeekendOvertimeNotAdjust += _DayAttendanceList[i].Hours;
                        break;
                    case OverWorkType.JieRiNotAdjust:
                        _MonthAttendance.HoursofHolidayOvertimeNotAdjust += _DayAttendanceList[i].Hours;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 计算FromDate到ToDate时间段内的 出差天数
        /// </summary>
        public void MonthAttendanceCaculateOutCityInfo()
        {
            for (int i = 0; i < _DayAttendanceList.Count; i++)
            {
                if (DateTime.Compare(_DayAttendanceList[i].Date.Date, _FromDate.Date) < 0
                    || DateTime.Compare(_DayAttendanceList[i].Date.Date, _ToDate.Date) > 0)
                {
                    continue;
                }

                if (_DayAttendanceList[i].CalendarType != CalendarType.Out)
                {
                    continue;
                }
                OutType ot = OutType.GetOutTypeByName(_DayAttendanceList[i].TypeName);
                if(ot.ID==OutType.OutCity.ID)
                {
                    _MonthAttendance.HoursofOutCity += _DayAttendanceList[i].Hours;
                }
            }
        }


        /// <summary>
        /// 计算FromDate到ToDate时间段内的 迟到早退数据
        /// </summary>
        public void MonthAttendanceCaculateArriveLeaveInfo()
        {
            //迟到早退是发生在某一天内的，不需要像请假和加班一样通过基本的List信息判断，直接从衍生数据DayAttendanceList中统计即可
            for (int i = 0; i < _DayAttendanceList.Count; i++)
            {
                if (DateTime.Compare(_DayAttendanceList[i].Date.Date, _FromDate.Date) < 0
                    || DateTime.Compare(_DayAttendanceList[i].Date.Date, _ToDate.Date) > 0)
                {
                    continue;
                }
                if (_DayAttendanceList[i].CalendarType == CalendarType.Late)
                {
                    _MonthAttendance.ArriveLate.Count++;
                    _MonthAttendance.ArriveLate.TotalData += _DayAttendanceList[i].Minites;
                }
                if (_DayAttendanceList[i].CalendarType == CalendarType.LeaveEarly)
                {
                    _MonthAttendance.LeaveEarly.Count++;
                    _MonthAttendance.LeaveEarly.TotalData += _DayAttendanceList[i].Minites;
                }
                if (_DayAttendanceList[i].CalendarType == CalendarType.Absent)
                {
                    _MonthAttendance.HoursofNoReasonLeave += _DayAttendanceList[i].Hours;
                }
            }
        }

        /// <summary>
        /// 计算FromDate到ToDate时间段内的 出勤天数
        /// </summary>
        public void MonthAttendanceCaculateOnDutyDays()
        {
            foreach (PlanDutyDetail planDutyDetail in _PlanDutyDetailList)
            {
                if (!planDutyDetail.PlanDutyClass.IsWeek)
                {
                    _MonthAttendance.ExpectedOnDutyDays++;
                    _MonthAttendance.ActualOnDutyDays++;
                    //扣除旷工和请假天数
                    _MonthAttendance.ActualOnDutyDays -= DaysofAbsentAndLeave(_DayAttendanceList, planDutyDetail.Date);
                }
            }
        }
        private static decimal DaysofAbsentAndLeave(IEnumerable<DayAttendance> dayAttendanceList, DateTime date)
        {
            decimal ret = 0;
            foreach (DayAttendance dayAttendance in dayAttendanceList)
            {
                if (DateTime.Compare(dayAttendance.Date.Date, date.Date) == 0)
                {
                    if (dayAttendance.CalendarType == CalendarType.Absent)
                    {
                        ret += dayAttendance.Days;
                    }
                    if (dayAttendance.CalendarType == CalendarType.Leave
                        && dayAttendance.TypeID != (int)LeaveRequestTypeEnum.AdjustRest
                        && dayAttendance.TypeID != (int)LeaveRequestTypeEnum.AnnualLeave
                        && dayAttendance.TypeID != (int)LeaveRequestTypeEnum.ChanQianJia
                        && dayAttendance.TypeID != (int)LeaveRequestTypeEnum.BuRuJia)
                    {
                        ret += dayAttendance.Days;
                    }
                }
            }
            return ret;
        }

        #endregion

        #region AttendanceInAndOutStatistics

        /// <summary>
        /// 前提：统计过考勤；判断是否满足进出时间是否为空的条件
        /// </summary>
        /// <param name="outInTimeCondition"></param>
        /// <returns></returns>
        public bool IsOutInTimeCondition(OutInTimeConditionEnum outInTimeCondition)
        {
            //没有考勤规则的员工不需要判断
            if (_PlanDutyDetailList == null || _PlanDutyDetailList.Count == 0)
            {
                return false;
            }
            bool inTimeIsNull = _AttendanceInAndOutStatistics.InTime.Equals(Convert.ToDateTime("2999-12-31"));
            bool outTimeIsNull = _AttendanceInAndOutStatistics.OutTime.Equals(Convert.ToDateTime("1900-1-1"));
            switch (outInTimeCondition)
            {
                case OutInTimeConditionEnum.All:
                    return true;
                case OutInTimeConditionEnum.InAndOutTimeIsNull:
                    return inTimeIsNull && outTimeIsNull;
                case OutInTimeConditionEnum.InOrOutTimeIsNull:
                    return inTimeIsNull || outTimeIsNull;
                case OutInTimeConditionEnum.InTimeIsNull:
                    return inTimeIsNull;
                case OutInTimeConditionEnum.OutTimeIsNull:
                    return outTimeIsNull;
                case OutInTimeConditionEnum.InOrOutTimeOnlyOneIsNull:
                    return (!outTimeIsNull == inTimeIsNull);
                default:
                    return false;
            }
        }

        #region 找出一段时间内的最早进入时间，最晚离开时间，没有则为空

        /// <summary>
        /// 前提：统计过_DayAttendanceList，查过_AttendanceInAndOutRecordList；某天的进出，请假，外出统计
        /// </summary>
        /// <param name="theDay"></param>
        public void InAndOutStatistics(DateTime theDay)
        {
            string leaveRequestAndOut = FindLeaveRequestAndOut(theDay);
            List<AttendanceInAndOutRecord.AttendanceInAndOutRecord> attendanceInAndOutRecordList =
                _AttendanceInAndOutRecordList.FindAll(FindAttendanceInAndOutRecordList);
            if (attendanceInAndOutRecordList == null ||
                attendanceInAndOutRecordList.Count == 0)
            {
                _AttendanceInAndOutStatistics =
                    new AttendanceInAndOutStatistics(Convert.ToDateTime("2999-12-31"), Convert.ToDateTime("1900-1-1"),
                                                     leaveRequestAndOut);
            }
            else
            {
                DateTime inTime =
                    AttendanceInAndOutRecord.AttendanceInAndOutRecord.FindEarlistTime(attendanceInAndOutRecordList);
                DateTime outTime =
                    AttendanceInAndOutRecord.AttendanceInAndOutRecord.FindLatestTime(attendanceInAndOutRecordList);
                _AttendanceInAndOutStatistics = new AttendanceInAndOutStatistics(inTime, outTime, leaveRequestAndOut);
            }
        }

        /// <summary>
        /// 找出某天的考勤记录
        /// </summary>
        /// <param name="attendanceInAndOutRecord"></param>
        /// <returns></returns>
        private bool FindAttendanceInAndOutRecordList(AttendanceInAndOutRecord.AttendanceInAndOutRecord attendanceInAndOutRecord)
        {
            if (DateTime.Compare(attendanceInAndOutRecord.IOTime.Date, _Date.Date) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 找出外出或请假情况
        /// </summary>
        /// <param name="theDay"></param>
        /// <returns></returns>
        public string FindLeaveRequestAndOut(DateTime theDay)
        {
            _Date = theDay;
            string leaveRequestAndOut = "";
            List<DayAttendance> dayAttendanceList = _DayAttendanceList.FindAll(FindTheDayAttendance);
            if (dayAttendanceList != null)
            {
                for (int i = 0; i < dayAttendanceList.Count; i++)
                {
                    if (dayAttendanceList[i].CalendarType == CalendarType.Out ||
                        dayAttendanceList[i].CalendarType == CalendarType.Leave)
                    {
                        leaveRequestAndOut = leaveRequestAndOut + dayAttendanceList[i].TypeName +
                                             dayAttendanceList[i].Days + "天 ";
                    }
                }
            }
            return leaveRequestAndOut;
        }
        private bool FindTheDayAttendance(DayAttendance dayAttendance)
        {
            if ((DateTime.Compare(dayAttendance.Date.Date, _Date.Date)) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        private bool FindThePlanDutyDetail(PlanDutyDetail planDutyDetail)
        {
            if (planDutyDetail.Date.ToShortDateString() == _Date.ToShortDateString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 统计迟到早退旷工情况
        /// <summary>
        /// 找出某天外出或请假.的总小时情况
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <param name="dateTimeList"></param>
        public decimal FindLeaveRequestAndOutHours(DateTime date, out List<DateTime[]> dateTimeList)
        {
            decimal leaveRequestAndOutHours = 0;
            dateTimeList=new List<DateTime[]>();
            if (_DayAttendanceList != null && _DayAttendanceList.Count > 0)
            {
                for (int i = 0; i < _DayAttendanceList.Count; i++)
                {
                    //如果这一天有请假或外出,且已审核通过
                    if (_DayAttendanceList[i].Date.Date.Equals(date.Date) && 
                        !_DayAttendanceList[i].TypeName.Contains("(") &&
                        (_DayAttendanceList[i].CalendarType == CalendarType.Leave ||
                        _DayAttendanceList[i].CalendarType == CalendarType.Out))
                    {
                        DateTime[] dt=new DateTime[2];
                        dt[0] = _DayAttendanceList[i].FromTime;
                        dt[1] = _DayAttendanceList[i].ToTime;
                        dateTimeList.Add(dt);
                        leaveRequestAndOutHours = leaveRequestAndOutHours + _DayAttendanceList[i].Hours;
                    }
                }
            }
            return leaveRequestAndOutHours;
        }
        /// <summary>
        /// 找出外出的List
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<DateTime[]> FindOutList(DateTime date)
        {
            List<DateTime[]> dateTimeList = new List<DateTime[]>();
            if (_DayAttendanceList != null && _DayAttendanceList.Count > 0)
            {
                for (int i = 0; i < _DayAttendanceList.Count; i++)
                {
                    //如果这一天有外出
                    if (_DayAttendanceList[i].Date.Date.Equals(date.Date) &&
                        (_DayAttendanceList[i].CalendarType == CalendarType.Out))
                    {
                        DateTime[] dt = new DateTime[2];
                        dt[0] = _DayAttendanceList[i].FromTime;
                        dt[1] = _DayAttendanceList[i].ToTime;
                        dateTimeList.Add(dt);
                    }
                }
            }
            return dateTimeList;
        }
        /// <summary>
        /// 找出请假的List
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<DateTime[]> FindLeaveRequestList(DateTime date)
        {
            List<DateTime[]> dateTimeList = new List<DateTime[]>();
            if (_DayAttendanceList != null && _DayAttendanceList.Count > 0)
            {
                for (int i = 0; i < _DayAttendanceList.Count; i++)
                {
                    //如果这一天有请假
                    if (_DayAttendanceList[i].Date.Date.Equals(date.Date) &&
                        (_DayAttendanceList[i].CalendarType == CalendarType.Leave))
                    {
                        DateTime[] dt = new DateTime[2];
                        dt[0] = _DayAttendanceList[i].FromTime;
                        dt[1] = _DayAttendanceList[i].ToTime;
                        dateTimeList.Add(dt);
                    }
                }
            }
            return dateTimeList;
        }
        /// <summary>
        /// 找出加班的List
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<DateTime[]> FindOverTimeList(DateTime date)
        {
            List<DateTime[]> dateTimeList = new List<DateTime[]>();
            if (_DayAttendanceList != null && _DayAttendanceList.Count > 0)
            {
                for (int i = 0; i < _DayAttendanceList.Count; i++)
                {
                    //如果这一天有加班
                    if (_DayAttendanceList[i].Date.Date.Equals(date.Date) &&
                        (_DayAttendanceList[i].CalendarType == CalendarType.OverTime))
                    {
                        DateTime[] dt = new DateTime[2];
                        dt[0] = _DayAttendanceList[i].FromTime;
                        dt[1] = _DayAttendanceList[i].ToTime;
                        dateTimeList.Add(dt);
                    }
                }
            }
            return dateTimeList;
        }
        /// <summary>
        /// 找出某天迟到早退旷工的总分钟情况
        /// </summary>
        /// <param name="dayAttendanceList"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <param name="isLate"></param>
        /// <param name="isEarly"></param>
        public decimal FindTotalMinutesAndOutOverTimeLeaveList
            (List<DayAttendance> dayAttendanceList, DateTime date,
            out int isLate, out int isEarly)
        {
            decimal totalMinutes = 0;
            isLate = 0;
            isEarly = 0;
            if (dayAttendanceList != null && dayAttendanceList.Count > 0)
            {
                foreach (DayAttendance dayAttendance in dayAttendanceList)
                {
                    switch (dayAttendance.CalendarType)
                    {
                        case CalendarType.Late:
                            isLate = isLate + 1;
                            totalMinutes = totalMinutes + dayAttendance.Minites;
                            //迟到
                            break;
                        case CalendarType.LeaveEarly:
                            isEarly = isEarly + 1;
                            totalMinutes = totalMinutes + dayAttendance.Minites;
                            //早退
                            break;
                        case CalendarType.Absent:
                            totalMinutes = totalMinutes + dayAttendance.Hours*60;
                            //旷工
                            break;
                        default:
                            break;
                    }
                }
            }
            return totalMinutes;
        }
        ///<summary>
        ///</summary>
        ///<param name="dateTimeList"></param>
        ///<returns></returns>
        public List<DateTime[]> SortDateTime(List<DateTime[]> dateTimeList)
        {
            int j;
            bool done = false;
            j = 1;
            while ((j < dateTimeList.Count) && (!done))
            {
                done = true;
                int i;
                for (i = 0; i < dateTimeList.Count - j; i++)
                {
                    if (dateTimeList[i][0] > dateTimeList[i + 1][0])
                    {
                        done = false;
                        DateTime[] temp = dateTimeList[i];
                        dateTimeList[i] = dateTimeList[i + 1];
                        dateTimeList[i + 1] = temp;
                    }
                }
                j++;
            }
            return dateTimeList;
        }
        ///<summary>
        ///</summary>
        ///<param name="dateTimeList"></param>
        ///<returns></returns>
        ///<param name="from"></param>
        ///<param name="to"></param>
        public List<DateTime[]> AdjustTime(List<DateTime[]> dateTimeList,DateTime from,DateTime to)
        {
            List<DateTime[]> timeList = new List<DateTime[]>();
            for (int i=0;i<dateTimeList.Count;i++)
            {
                if (dateTimeList[i][0] < from)
                {
                    if (dateTimeList[i][1] <= from)
                    {
                        timeList.Add(dateTimeList[i]);
                        continue;
                    }
                    dateTimeList[i][0] = from;
                }
                if (dateTimeList[i][1] > to)
                {
                    if (dateTimeList[i][0] >= to)
                    {
                        timeList.Add(dateTimeList[i]);
                        continue;
                    }
                    dateTimeList[i][1] = to;
                }
            }
            foreach (DateTime[] dt in timeList)
            {
                dateTimeList.Remove(dt);
            }

            return dateTimeList;
        }
        /// <summary>
        /// 起止时间，去除午休时间后的分钟差
        /// </summary>
        /// <param name="dtfrom"></param>
        /// <param name="dtto"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int CalculateTimeSpanMinutes(DateTime dtfrom, DateTime dtto, DateTime from, DateTime to)
        {
            int timeSpanMinutes;
            TimeSpan ts ;
            TimeSpan ts1;
            if (dtfrom < from)
            {
                if (dtto <= from)
                {
                    ts = dtto - dtfrom;
                    timeSpanMinutes = ts.Minutes + ts.Hours*60;
                }
                else if (dtto > from && dtto <= to)
                {
                    ts = from - dtfrom;
                    timeSpanMinutes =ts.Minutes  + ts.Hours*60;
                }
                else
                {
                    ts = dtto - to;
                    ts1 = from - dtfrom;
                    timeSpanMinutes = ts.Minutes + ts.Hours * 60 + ts1.Minutes + ts1.Hours * 60;
                }
            }
            else if (dtfrom >= from && dtfrom<=to)
            {
                if (dtto <= to)
                {
                    timeSpanMinutes = 0;
                }
                else
                {
                    ts = dtto - to;
                    timeSpanMinutes = ts.Minutes + ts.Hours * 60;
                }
            }
            else
            {
                ts = dtto - dtfrom;
                timeSpanMinutes = ts.Minutes + ts.Hours * 60;
            }
            return timeSpanMinutes;
        }
        private bool IsIntegrateTime(List<DateTime[]> dateTimeList)
        {
            bool isIntegrate = false;
            if (dateTimeList.Count > 0)
            {
                //排序
                dateTimeList = SortDateTime(dateTimeList);
                for (int i = 0; i < dateTimeList.Count - 1; i++)
                {
                    //如果有重合
                    if (dateTimeList[i][1] > dateTimeList[i + 1][0])
                    {
                        isIntegrate = true;
                    }
                }
            }
            return isIntegrate;
        }
        ///<summary>
        ///</summary>
        ///<param name="dateTimeList"></param>
        ///<param name="from"></param>
        ///<param name="to"></param>
        public int TotalTime(List<DateTime[]> dateTimeList,  DateTime from, DateTime to)
        {
            int totalTime = 0;
            if (dateTimeList.Count > 0)
            {
                //排序
                dateTimeList = SortDateTime(dateTimeList);
                List<DateTime[]> tempDateTimeList=new List<DateTime[]>();
                foreach (DateTime[] times in dateTimeList)
                {
                    DateTime[] dt = new DateTime[2];
                    dt[0] = times[0]; 
                    dt[1] = times[1];
                    tempDateTimeList.Add(dt);
                }
                for (int i = 0; i < tempDateTimeList.Count - 1; i++)
                {
                    //如果有重合
                    if (tempDateTimeList[i][1] > tempDateTimeList[i + 1][0])
                    {
                        tempDateTimeList[i + 1][0] = tempDateTimeList[i][0];
                        if (tempDateTimeList[i][1] > tempDateTimeList[i + 1][1])
                        {
                            tempDateTimeList[i + 1][1] = tempDateTimeList[i][1];
                        }
                    }
                    else
                    {
                        totalTime = totalTime +
                            CalculateTimeSpanMinutes(tempDateTimeList[i][0], tempDateTimeList[i][1], from, to);

                    }
                }
                totalTime = totalTime +
                    CalculateTimeSpanMinutes(tempDateTimeList[dateTimeList.Count - 1][0], tempDateTimeList[dateTimeList.Count - 1][1], from, to);
            }
            return totalTime;
        }


    //    /// <summary>
    //    /// 前提:有特殊时间:统计某一天迟到早退旷工情况,
    //    /// 如果进出时间有一个有空,进入晚于离开，或当天为休息日则返回false;
    //    /// 如果统计时间小于8小时，且时间段有重叠则返回false;
    //    /// 否则返回true
    //    /// </summary>
    //    /// <param name="employee"></param>
    //    /// <param name="date"></param>
    //    public bool StatisticLateAndEarly(Employee employee, DateTime date)
    //    {
    //        int employeeID = employee.Account.Id;
    //        #region 查看这一天员工是否进入公司
    //        if (DateTime.Compare(employee.EmployeeDetails.Work.ComeDate, date) > 0)
    //        {
    //            return false;
    //        }
    //        #endregion
    //        #region 查看这一天员工是否离开公司
    //        if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee &&
    //            employee.EmployeeDetails.Work.DimissionInfo != null &&
    //            DateTime.Compare(employee.EmployeeDetails.Work.DimissionInfo.DimissionDate, date) < 0)
    //        {
    //            return false;
    //        }
    //        #endregion
    //        #region 如果是休息日
    //        if (_PlanDutyDetailList == null || _PlanDutyDetailList.Count == 0)
    //        {
    //            return false;
    //        }
    //        _Date = date;
    //        PlanDutyDetail planDutyDetail = _PlanDutyDetailList.Find(FindThePlanDutyDetail);
    //        if (planDutyDetail == null || planDutyDetail.PlanDutyClass == null)
    //        {
    //            return false;
    //        }
    //        //如果休息
    //        if (planDutyDetail.PlanDutyClass.DutyClassID == -1)
    //        {
    //            return false;
    //        }
    //        #endregion
    //        InAndOutStatistics(date);
    //        if (_AttendanceInAndOutStatistics == null)
    //        {
    //            return false;
    //        }
    //        bool inTimeIsNull = _AttendanceInAndOutStatistics.InTime.Equals(Convert.ToDateTime("2999-12-31"));
    //        bool outTimeIsNull = _AttendanceInAndOutStatistics.OutTime.Equals(Convert.ToDateTime("1900-1-1"));

    //        #region 如果进出时间有一个有空则返回false
    //        if (!inTimeIsNull == outTimeIsNull)
    //        {
    //            return false;
    //        }
    //        AbsentAttendance absentAttendance;
    //        #endregion
    //        List<DateTime[]> dateTimeList;
    //        decimal leaveRequestAndOutHours = FindLeaveRequestAndOutHours(date, out dateTimeList);

    //        #region 如果进出都为空

    //        if (inTimeIsNull && outTimeIsNull)
    //        {
    //            decimal affectDays;
    //            if (leaveRequestAndOutHours < 4)
    //            {
    //                affectDays = 1;
    //            }
    //            else if (leaveRequestAndOutHours >= 4 && leaveRequestAndOutHours < 8)
    //            {
    //                affectDays = (decimal)0.5;
    //            }
    //            else
    //            {
    //                return true;
    //            }
    //            absentAttendance = new AbsentAttendance(employeeID, date, affectDays);
    //            _AttendanceBaseStatisticList.Add(absentAttendance);
    //            return true;
    //        }
    //        #endregion
    //        #region 如果进入晚于离开
    //        if (DateTime.Compare(_AttendanceInAndOutStatistics.InTime, _AttendanceInAndOutStatistics.OutTime) >= 0)
    //        {
    //            return false;
    //        }
    //        #endregion

    //        List<DateTime[]> inOutdateTimeList = new List<DateTime[]>();
    //        DateTime[] dt = new DateTime[2];
    //        dt[0] = _AttendanceInAndOutStatistics.InTime;
    //        dt[1] = _AttendanceInAndOutStatistics.OutTime;
    //        inOutdateTimeList.Add(dt);
    //        dateTimeList.Add(dt);

    //        DateTime firstStartFromTime = planDutyDetail.PlanDutyClass.FirstStartFromTime;
    //        DateTime firstStartToTime = planDutyDetail.PlanDutyClass.FirstStartToTime;
    //        DateTime firstEndTime = planDutyDetail.PlanDutyClass.FirstEndTime;
    //        DateTime secondStartTime = planDutyDetail.PlanDutyClass.SecondStartTime;
    //        firstStartFromTime = new DateTime(date.Year, date.Month, date.Day,
    //firstStartFromTime.Hour, firstStartFromTime.Minute, firstStartFromTime.Second);
    //        firstStartToTime = new DateTime(date.Year, date.Month, date.Day,
    //firstStartToTime.Hour, firstStartToTime.Minute, firstStartToTime.Second);
    //        firstEndTime = new DateTime(date.Year, date.Month, date.Day,
    //            firstEndTime.Hour, firstEndTime.Minute, firstEndTime.Second);
    //        secondStartTime = new DateTime(date.Year, date.Month, date.Day,
    //            secondStartTime.Hour, secondStartTime.Minute, secondStartTime.Second);

    //        DateTime from = firstStartFromTime;
    //        TimeSpan noonBreak = planDutyDetail.PlanDutyClass.SecondStartTime -
    //                             planDutyDetail.PlanDutyClass.FirstEndTime;
    //        DateTime to = firstStartToTime.AddHours(8).Add(noonBreak);
    //        //早于最早上班时间，晚于最晚上班时间的时间段都去掉
    //        dateTimeList = AdjustTime(dateTimeList, from, to);

    //        decimal totalTime = TotalTime(dateTimeList, firstEndTime, secondStartTime);
    //        //对个时间段进行整合，返回值表示是否有重合，totalTime表示去除中午午休时间的总共时间
    //        bool isIntegrate = IsIntegrateTime(dateTimeList);

    //        decimal inOutTotalTime = TotalTime(inOutdateTimeList, firstEndTime, secondStartTime);

    //        if (!isIntegrate && inOutTotalTime + leaveRequestAndOutHours * 60 >= 480 &&
    //            dateTimeList[0][0] <= firstStartToTime)
    //        {
    //            return true;
    //        }
    //        decimal absent = 0;
    //        LaterAttendance laterAttendance = null;
    //        EarlyLeaveAttendance earlyLeaveAttendance = null;

    //        int maxAbsent = planDutyDetail.PlanDutyClass.AbsentEarlyLeaveTime;
    //        //大于8属于正常上班
    //        if (totalTime < 480)
    //        {
    //            if (isIntegrate)
    //            {
    //                return false;
    //            }
    //            else
    //            {
    //                #region 0{旷工1天}4-maxAbsent{旷工0.5天。。}4{旷工0.5天}8-maxAbsent{。。}8

    //                if (totalTime < 240 - maxAbsent)
    //                {
    //                    absent = 1;
    //                }
    //                else if (totalTime >= 240 && totalTime < 480 - maxAbsent)
    //                {
    //                    absent = (decimal)0.5;
    //                }
    //                else
    //                {
    //                    decimal spanTime;
    //                    if (totalTime < 240)
    //                    {
    //                        absent = (decimal)0.5;
    //                        spanTime = 240 - totalTime;
    //                    }
    //                    else
    //                    {
    //                        spanTime = 480 - totalTime;
    //                    }
    //                    TimeSpan inMorningSpan = dateTimeList[0][0] - firstStartToTime;
    //                    int inMorningSpanTime = inMorningSpan.Hours * 60 + inMorningSpan.Minutes;

    //                    if (inMorningSpanTime > planDutyDetail.PlanDutyClass.LateTime &&
    //                        inMorningSpanTime <= planDutyDetail.PlanDutyClass.AbsentLateTime)
    //                    {
    //                        laterAttendance = new LaterAttendance(employeeID, date, inMorningSpanTime);
    //                        if (spanTime > inMorningSpanTime)
    //                        {
    //                            if ((int)(spanTime) - inMorningSpanTime > planDutyDetail.PlanDutyClass.EarlyLeaveTime)
    //                            {
    //                                earlyLeaveAttendance =
    //                                    new EarlyLeaveAttendance(employeeID, date, (int)(spanTime) - inMorningSpanTime);
    //                            }
    //                        }
    //                    }
    //                    else
    //                    {
    //                        if ((int)(spanTime) > planDutyDetail.PlanDutyClass.EarlyLeaveTime)
    //                        {
    //                            earlyLeaveAttendance = new EarlyLeaveAttendance(employeeID, date, (int)(spanTime));
    //                        }
    //                    }
    //                }
    //                if (absent > 0)
    //                {
    //                    absentAttendance = new AbsentAttendance(employeeID, date, absent);
    //                    _AttendanceBaseStatisticList.Add(absentAttendance);
    //                }
    //                if (earlyLeaveAttendance != null)
    //                {
    //                    _AttendanceBaseStatisticList.Add(earlyLeaveAttendance);
    //                }
    //                if (laterAttendance != null)
    //                {
    //                    _AttendanceBaseStatisticList.Add(laterAttendance);
    //                }

    //                #endregion
    //            }
    //        }
    //        return true;
    //    }

        #endregion

        #region 统计某一天数据是否正常
        /// <summary>
        /// 前提：统计过考勤，和请假等情况；如果正常返回true,否则返回false
        /// (不正常分两种：满足给的查询条件的不正常；和请假等合并起来的不正常)
        /// 加一种：如果这一天是工作日，且无打卡记录,则需要判断这天totalDay是否等于1，不等于1属于不正常数据
        /// 加一种：时间重叠属于不正常数据
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <param name="absentString"></param>
        public bool StatisticIsNormal(DateTime date, out string absentString)
        {
            absentString = "";
            //没有考勤规则的员工不需要判断
            if (_PlanDutyDetailList == null || _PlanDutyDetailList.Count == 0)
            {
                return true;
            }
            _Date = date;
            PlanDutyDetail planDutyDetail = _PlanDutyDetailList.Find(FindThePlanDutyDetail);
            if (planDutyDetail == null || planDutyDetail.PlanDutyClass == null)
            {
                return true;
            }

            #region 如果不是休息日
            if (planDutyDetail.PlanDutyClass.DutyClassID != -1)
            {
                //如果没有统计过
                if (_AttendanceInAndOutStatistics == null)
                {
                    return false;
                }
                //如果进晚于出
                if (!_AttendanceInAndOutStatistics.InTime.Equals(Convert.ToDateTime("2999-12-31")) &&
                    !_AttendanceInAndOutStatistics.OutTime.Equals(Convert.ToDateTime("1900-1-1")) &&
                    DateTime.Compare(_AttendanceInAndOutStatistics.InTime, _AttendanceInAndOutStatistics.OutTime) >= 0)
                {
                    absentString = "打卡数据错误";
                    return false;
                }

                List<DateTime[]> dateTimeOutLeaveList;
                decimal leaveRequestAndOutHours = FindLeaveRequestAndOutHours(date, out dateTimeOutLeaveList);

                //List<DateTime[]> dateTimeLeaveList = FindLeaveRequestList(date);
                //List<DateTime[]> dateTimeOutList = FindOutList(date);
                //List<DateTime[]> dateTimeOutLeaveList = new List<DateTime[]>();
                //dateTimeOutLeaveList.AddRange(dateTimeOutList);
                //dateTimeOutLeaveList.AddRange(dateTimeLeaveList);

                List<DateTime[]> dateTimeList =new List<DateTime[]>();
                //如果进出都不为空
                if (!_AttendanceInAndOutStatistics.InTime.Equals(Convert.ToDateTime("2999-12-31")) &&
                    !_AttendanceInAndOutStatistics.OutTime.Equals(Convert.ToDateTime("1900-1-1")))
                {
                    DateTime[] dt = new DateTime[2];
                    dt[0] =
                        new DateTime(_AttendanceInAndOutStatistics.InTime.Year,
                                     _AttendanceInAndOutStatistics.InTime.Month,
                                     _AttendanceInAndOutStatistics.InTime.Day, _AttendanceInAndOutStatistics.InTime.Hour,
                                     _AttendanceInAndOutStatistics.InTime.Minute, 0);
                    dt[1] =
                        new DateTime(_AttendanceInAndOutStatistics.OutTime.Year,
                                     _AttendanceInAndOutStatistics.OutTime.Month,
                                     _AttendanceInAndOutStatistics.OutTime.Day,
                                     _AttendanceInAndOutStatistics.OutTime.Hour,
                                     _AttendanceInAndOutStatistics.OutTime.Minute, 0);
                    dateTimeOutLeaveList.Add(dt);
                    dateTimeList.Add(dt);
                }

                //对各时间段进行整合，返回值表示是否有重合，totalTime表示去除中午午休时间的总共时间
                DateTime firstStartFromTime = planDutyDetail.PlanDutyClass.FirstStartFromTime;
                DateTime firstStartToTime = planDutyDetail.PlanDutyClass.FirstStartToTime;
                DateTime firstEndTime = planDutyDetail.PlanDutyClass.FirstEndTime;
                DateTime secondStartTime = planDutyDetail.PlanDutyClass.SecondStartTime;
                firstStartFromTime = new DateTime(date.Year, date.Month, date.Day,
        firstStartFromTime.Hour, firstStartFromTime.Minute, firstStartFromTime.Second);
                firstStartToTime = new DateTime(date.Year, date.Month, date.Day,
        firstStartToTime.Hour, firstStartToTime.Minute, firstStartToTime.Second);
                firstEndTime = new DateTime(date.Year, date.Month, date.Day,
                    firstEndTime.Hour, firstEndTime.Minute, firstEndTime.Second);
                secondStartTime = new DateTime(date.Year, date.Month, date.Day,
                    secondStartTime.Hour, secondStartTime.Minute, secondStartTime.Second);

                DateTime from = firstStartFromTime;
                TimeSpan noonBreak = planDutyDetail.PlanDutyClass.SecondStartTime -
                                     planDutyDetail.PlanDutyClass.FirstEndTime;
                DateTime to = firstStartToTime.AddHours(8).Add(noonBreak);


                //早于最早上班时间，晚于最晚上班时间的时间段都去掉
                dateTimeList = AdjustTime(dateTimeList, from, to);
                dateTimeOutLeaveList= AdjustTime(dateTimeOutLeaveList, from, to);
                decimal totalTime = TotalTime(dateTimeOutLeaveList, firstEndTime, secondStartTime);
                decimal totalInOutTime = TotalTime(dateTimeList, firstEndTime, secondStartTime);

                //对个时间段进行整合，返回值表示是否有重合
                bool isIntegrate = IsIntegrateTime(dateTimeOutLeaveList);

                //如果数据不重合
                if (!isIntegrate)
                {
                    decimal absentMinutes = 480 - totalInOutTime - leaveRequestAndOutHours * 60 -
                                            AllowJudgeErrorMinOfWorkTime;//（允许2分钟的误差）
                    if (absentMinutes > 0)
                    {
                        decimal absentHours = (absentMinutes + AllowJudgeErrorMinOfWorkTime) / 60;
                        absentString = "缺勤" + absentHours.ToString("0.00") + "小时";
                        return false;
                    }
                }
                else //如果数据重合，且不足8小时（允许2分钟的误差）
                {
                    decimal absentMinutes = 480 - totalTime - AllowJudgeErrorMinOfWorkTime;
                    if (absentMinutes > 0)
                    {
                        decimal absentHours = (absentMinutes + AllowJudgeErrorMinOfWorkTime) / 60;
                        absentString = "数据重合，缺勤" + absentHours.ToString("0.00") + "小时";
                        return false;
                    }
                }
            }
            #endregion
            #region 如果是休息日
            else
            {
                //如果一个为空一个不为空
                if (!_AttendanceInAndOutStatistics.InTime.Equals(Convert.ToDateTime("2999-12-31")) ==
                _AttendanceInAndOutStatistics.OutTime.Equals(Convert.ToDateTime("1900-1-1")))
                {
                    absentString = "打卡数据错误";
                    return false;
                }
            }
            #endregion
            return true;
        }

        #endregion

        #endregion

        #region  AttendanceInAndOutRecordList 中查找和删除

        ///<summary>
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        public AttendanceInAndOutRecord.AttendanceInAndOutRecord FindInAndOutRecordByRecordId(int id)
        {
            if (AttendanceInAndOutRecordList == null)
            {
                return null;
            }
            foreach (AttendanceInAndOutRecord.AttendanceInAndOutRecord record in AttendanceInAndOutRecordList)
            {
                if (record.RecordID == id)
                {
                    return record;
                }
            }
            return null;
        }

        ///<summary>
        ///</summary>
        ///<param name="id"></param>
        public void RemoveInAndOutRecordByRecordId(int id)
        {
            if (AttendanceInAndOutRecordList == null)
            {
                return;
            }
            for (int i = 0; i < AttendanceInAndOutRecordList.Count; i++)
            {
                if (AttendanceInAndOutRecordList[i].RecordID == id)
                {
                    AttendanceInAndOutRecordList.RemoveAt(i);
                    break;
                }
            }
            return;
        }

        #endregion

    }
}
