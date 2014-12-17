//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: MonthAttendance.cs
// 创建者: wsl
// 创建日期: 2008-08-28
// 概述: 员工月考勤情况
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.Request;
using SEP.Model.Calendar;

namespace SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics
{
    /// <summary>
    /// 迟到早退统计
    /// </summary>
    [Serializable]
    public class ArriveLeaveStatistics
    {
        private int _Count;
        private decimal _TotalData;
        private string _Unit;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="count"></param>
        /// <param name="unit"></param>
        public ArriveLeaveStatistics(int count, string unit)
        {
            _Count = count;
            _Unit = unit;
        }
        /// <summary>
        /// 次数
        /// </summary>
        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }
        /// <summary>
        /// 总计
        /// </summary>
        public decimal TotalData
        {
            get { return _TotalData; }
            set { _TotalData = value; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

    }
     /// <summary>
    /// 员工请假统计
    /// </summary>
    [Serializable]
    public class LeaveRequestStatistics
    {
        private readonly LeaveRequestType _LeaveRequestType;
        private decimal _Hours;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="leaveRequestType"></param>
        public LeaveRequestStatistics(LeaveRequestType leaveRequestType)
        {
            _LeaveRequestType = leaveRequestType;
        }
        /// <summary>
        /// 请假类型
        /// </summary>
        public LeaveRequestType LeaveRequestType
        {
            get { return _LeaveRequestType; }
        }
        /// <summary>
        /// 小时数
        /// </summary>
        public decimal Hours
        {
            get { return _Hours; }
            set { _Hours = value; }
        }
        /// <summary>
        /// 天
        /// </summary>
        public decimal Days
        {
            get { return _Hours / 8; }
        }
    }
    /// <summary>
    /// 一段时期内的考勤统计信息
    /// </summary>
    [Serializable]
    public class MonthAttendance
    {
        private List<LeaveRequestStatistics> _LeaveRequestStatisticsList;
        private List<DayAttendance> _DayAttendanceList;
        private decimal _ExpectedOnDutyDays;
        private decimal _ActualOnDutyDays;
        private ArriveLeaveStatistics _LeaveEarly;
        private ArriveLeaveStatistics _ArriveLate;
        private decimal _HoursofAdjustRestRemained;
        private decimal _HoursofOvertime;
        private decimal _HoursofCommonOvertime;
        private decimal _HoursofWeekendOvertime;
        private decimal _HoursofHolidayOvertime;
        private decimal _HoursofCommonOvertimeNotAdjust;
        private decimal _HoursofWeekendOvertimeNotAdjust;
        private decimal _HoursofHolidayOvertimeNotAdjust;
        private decimal _HoursofAdjustRestLeave;
        private decimal _HoursofPersonalReasonLeave;
        private decimal _HoursofLunarPeriodLeave;
        private decimal _HoursofSickLeave;
        private decimal _HoursofOtherLeave;
        private decimal _HoursofNoReasonLeave;
        private decimal _HoursofPrenatalLeave;
        private decimal _HoursofMaternityLeave;
        private decimal _HoursofOnDutyMaternityLeave;
        private decimal _HoursofBreastFeedLeave;
        private decimal _HoursofMarriageLeave;
        private decimal _HoursofCareLeave;
        private decimal _HoursofBereavementLeave;
        private decimal _HoursofOutCity;
        

        /// <summary>
        /// 构造函数
        /// </summary>
        public MonthAttendance()
        {
            ArriveLate = new ArriveLeaveStatistics(0, "分钟");
            LeaveEarly = new ArriveLeaveStatistics(0, "分钟");
            LeaveRequestStatisticsList = new List<LeaveRequestStatistics>();
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 当前员工请假明细
        /// </summary>
        public List<LeaveRequestStatistics> LeaveRequestStatisticsList
        {
            get { return _LeaveRequestStatisticsList; }
            set { _LeaveRequestStatisticsList = value; }
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
        /// FromDate到ToDate时间段内的 应出勤天数
        /// </summary>
        public decimal ExpectedOnDutyDays
        {
            get { return _ExpectedOnDutyDays; }
            set { _ExpectedOnDutyDays = value; }
        }

        /// <summary>
        /// FromDate到ToDate时间段内的 出勤天数
        /// </summary>
        public decimal ActualOnDutyDays
        {
            get { return _ActualOnDutyDays; }
            set { _ActualOnDutyDays = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 旷工天数
        /// </summary>
        public decimal HoursofNoReasonLeave
        {
            get
            {
                return _HoursofNoReasonLeave;
            }
            set { _HoursofNoReasonLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 旷工天数
        /// </summary>
        public decimal DaysofNoReasonLeave
        {
            get
            {
                return _HoursofNoReasonLeave / 8;
            }
            //set { _DaysofNoReasonLeave = value; }
        }
        /// <summary>
        /// 丧假小时
        /// </summary>
        public decimal HoursofBereavementLeave
        {
            get
            {
                return _HoursofBereavementLeave;
            }
            set { _HoursofBereavementLeave = value; }
        }
        /// <summary>
        /// 丧假天数
        /// </summary>
        public decimal DaysofBereavementLeave
        {
            get
            {
                return _HoursofBereavementLeave / 8;
            }
            //set { _AdjustRestRemainedDays = value; }
        }
        /// <summary>
        /// 护理假小时
        /// </summary>
        public decimal HoursofCareLeave
        {
            get
            {
                return _HoursofCareLeave;
            }
            set { _HoursofCareLeave = value; }
        }
        /// <summary>
        /// 护理假天数
        /// </summary>
        public decimal DaysofCareLeave
        {
            get
            {
                return _HoursofCareLeave / 8;
            }
            //set { _AdjustRestRemainedDays = value; }
        }
        /// <summary>
        /// 婚假小时
        /// </summary>
        public decimal HoursofMarriageLeave
        {
            get
            {
                return _HoursofMarriageLeave;
            }
            set { _HoursofMarriageLeave = value; }
        }
        /// <summary>
        /// 婚假天数
        /// </summary>
        public decimal DaysofMarriageLeave
        {
            get
            {
                return _HoursofMarriageLeave / 8;
            }
            //set { _AdjustRestRemainedDays = value; }
        }
        /// <summary>
        /// 剩余调休小时
        /// </summary>
        public decimal HoursofAdjustRestRemained
        {
            get
            {
                return _HoursofAdjustRestRemained;
            }
            set { _HoursofAdjustRestRemained = value; }
        }
        /// <summary>
        /// 剩余调休天数
        /// </summary>
        public decimal DaysofAdjustRestRemained
        {
            get
            {
                return _HoursofAdjustRestRemained / 8;
            }
            //set { _AdjustRestRemainedDays = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 加班小时
        /// </summary>
        public decimal HoursofOvertime
        {
            get { return _HoursofOvertime; }
            set { _HoursofOvertime = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 出差小时
        /// </summary>
        public decimal HoursofOutCity
        {
            get { return _HoursofOutCity; }
            set { _HoursofOutCity = value; }
        }

        /// <summary>
        /// FromDate到ToDate时间段内的 加班天数
        /// </summary>
        public decimal DaysofOvertime
        {
            get { return _HoursofOvertime / 8; }
            //set { _OvertimeDays = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 调休天数
        /// </summary>
        public decimal DaysofAdjustRestLeave
        {
            get { return _HoursofAdjustRestLeave / 8; }
            //set { _DaysofAdjustRestLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 调休小时
        /// </summary>
        public decimal HoursofAdjustRestLeave
        {
            get { return _HoursofAdjustRestLeave; }
            set { _HoursofAdjustRestLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 事假天数
        /// </summary>
        public decimal DaysofPersonalReasonLeave
        {
            get { return _HoursofPersonalReasonLeave / 8; }
            //set { _DaysofPersonalReasonLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 事假小时
        /// </summary>
        public decimal HoursofPersonalReasonLeave
        {
            get { return _HoursofPersonalReasonLeave; }
            set { _HoursofPersonalReasonLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 年假天数
        /// </summary>
        public decimal DaysofLunarPeriodLeave
        {
            get { return _HoursofLunarPeriodLeave / 8; }
            //set { _DaysofLunarPeriodLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 年假小时
        /// </summary>
        public decimal HoursofLunarPeriodLeave
        {
            get { return _HoursofLunarPeriodLeave; }
            set { _HoursofLunarPeriodLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 病假天数
        /// </summary>
        public decimal DaysofSickLeave
        {
            get { return _HoursofSickLeave / 8; }
            //set { _DaysofSickLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 病假小时
        /// </summary>
        public decimal HoursofSickLeave
        {
            get { return _HoursofSickLeave; }
            set { _HoursofSickLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 其他请假天数
        /// </summary>
        public decimal DaysofOtherLeave
        {
            get { return _HoursofOtherLeave / 8; }
            //set { _DaysofOtherLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 其他请假小时
        /// </summary>
        public decimal HoursofOtherLeave
        {
            get { return _HoursofOtherLeave; }
            set { _HoursofOtherLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 产前假小时
        /// </summary>
        public decimal HoursofPrenatalLeave
        {
            get { return _HoursofPrenatalLeave; }
            set { _HoursofPrenatalLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 工作日产假小时
        /// </summary>
        public decimal HoursofOnDutyMaternityLeave
        {
            get { return _HoursofOnDutyMaternityLeave; }
            set { _HoursofOnDutyMaternityLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 产假小时
        /// </summary>
        public decimal HoursofMaternityLeave
        {
            get { return _HoursofMaternityLeave; }
            set { _HoursofMaternityLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 哺乳假小时
        /// </summary>
        public decimal HoursofBreastFeedLeave
        {
            get { return _HoursofBreastFeedLeave; }
            set { _HoursofBreastFeedLeave = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 产前假天
        /// </summary>
        public decimal DaysofPrenatalLeave
        {
            get { return _HoursofPrenatalLeave / 8; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 工作日产假天
        /// </summary>
        public decimal DaysofOnDutyMaternityLeave
        {
            get { return _HoursofOnDutyMaternityLeave / 8; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 产假天
        /// </summary>
        public decimal DaysofMaternityLeave
        {
            get { return _HoursofMaternityLeave / 8; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 哺乳假天
        /// </summary>
        public decimal DaysofBreastFeedLeave
        {
            get { return _HoursofBreastFeedLeave / 8; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 普通加班小时
        /// </summary>
        public decimal HoursofCommonOvertime
        {
            get { return _HoursofCommonOvertime; }
            set { _HoursofCommonOvertime = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 普通加班小时 无换休
        /// </summary>
        public decimal HoursofCommonOvertimeNotAdjust
        {
            get { return _HoursofCommonOvertimeNotAdjust; }
            set { _HoursofCommonOvertimeNotAdjust = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 普通加班小时 获得换休
        /// </summary>
        public decimal HoursofCommonOvertimeAdjust
        {
            get { return _HoursofCommonOvertime - _HoursofCommonOvertimeNotAdjust; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 双休加班小时
        /// </summary>
        public decimal HoursofWeekendOvertime
        {
            get { return _HoursofWeekendOvertime; }
            set { _HoursofWeekendOvertime = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 双休加班小时 无换休
        /// </summary>
        public decimal HoursofWeekendOvertimeNotAdjust
        {
            get { return _HoursofWeekendOvertimeNotAdjust; }
            set { _HoursofWeekendOvertimeNotAdjust = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 双休加班小时 获得换休
        /// </summary>
        public decimal HoursofWeekendOvertimeAdjust
        {
            get { return _HoursofWeekendOvertime - _HoursofWeekendOvertimeNotAdjust; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 节日加班小时
        /// </summary>
        public decimal HoursofHolidayOvertime
        {
            get { return _HoursofHolidayOvertime; }
            set { _HoursofHolidayOvertime = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 节日加班小时 无换休
        /// </summary>
        public decimal HoursofHolidayOvertimeNotAdjust
        {
            get { return _HoursofHolidayOvertimeNotAdjust; }
            set { _HoursofHolidayOvertimeNotAdjust = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 节日加班小时 获得换休
        /// </summary>
        public decimal HoursofHolidayOvertimeAdjust
        {
            get { return _HoursofHolidayOvertime - _HoursofHolidayOvertimeNotAdjust; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 普通加班天
        /// </summary>
        public decimal DaysofCommonOvertime
        {
            get { return _HoursofCommonOvertime / 8; }
        }
        /// <summary>
        ///  FromDate到ToDate时间段内的换得调休 普通加班天
        /// </summary>
        public decimal DaysofCommonOvertimeAdjust
        {
            get { return (_HoursofCommonOvertime - _HoursofCommonOvertimeNotAdjust) / 8; }
        }
        /// <summary>
        ///  FromDate到ToDate时间段内的无调休 普通加班天
        /// </summary>
        public decimal DaysofCommonOvertimeNotAdjust
        {
            get { return _HoursofCommonOvertimeNotAdjust / 8; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 双休加班天
        /// </summary>
        public decimal DaysofWeekendOvertime
        {
            get { return _HoursofWeekendOvertime / 8; }
        }
        /// <summary>
        ///  FromDate到ToDate时间段内的换得调休 双休加班天
        /// </summary>
        public decimal DaysofWeekendOvertimeAdjust
        {
            get { return (_HoursofWeekendOvertime - _HoursofWeekendOvertimeNotAdjust) / 8; }
        }
        /// <summary>
        ///  FromDate到ToDate时间段内的无调休 双休加班天
        /// </summary>
        public decimal DaysofWeekendOvertimeNotAdjust
        {
            get { return _HoursofWeekendOvertimeNotAdjust / 8; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 节日加班天
        /// </summary>
        public decimal DaysofHolidayOvertime
        {
            get { return HoursofHolidayOvertime / 8; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的换得调休 节日加班天
        /// </summary>
        public decimal DaysofHolidayOvertimeAdjust
        {
            get { return (_HoursofHolidayOvertime - _HoursofHolidayOvertimeNotAdjust) / 8; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的无调休 节日加班天
        /// </summary>
        public decimal DaysofHolidayOvertimeNotAdjust
        {
            get { return _HoursofHolidayOvertimeNotAdjust / 8; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 早退信息
        /// </summary>
        public ArriveLeaveStatistics LeaveEarly
        {
            get { return _LeaveEarly; }
            set { _LeaveEarly = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 迟到信息
        /// </summary>
        public ArriveLeaveStatistics ArriveLate
        {
            get { return _ArriveLate; }
            set { _ArriveLate = value; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 出差天数
        /// </summary>
        public decimal DaysofOutCity
        {
            get { return _HoursofOutCity / 8; }
        }
        /// <summary>
        /// FromDate到ToDate时间段内的 出勤率
        /// 出勤率=(应出勤天数-事假-病假-旷工)/应出勤天
        /// 出勤率=(应出勤天数-事假-病假-旷工-产检假-产假-哺乳假)/应出勤天 
        /// </summary>
        public decimal RateofOnDuty
        {
            get
            {
                if (ExpectedOnDutyDays == 0)
                {
                    return 1;
                }
                decimal ondays = ExpectedOnDutyDays - DaysofPersonalReasonLeave - DaysofSickLeave - DaysofNoReasonLeave -
                                 DaysofPrenatalLeave - DaysofOnDutyMaternityLeave - DaysofBreastFeedLeave;
                if (ondays < 0)
                {
                    return 0;
                }
                return
                    (ExpectedOnDutyDays - DaysofPersonalReasonLeave - DaysofSickLeave - DaysofNoReasonLeave -
                     DaysofPrenatalLeave - DaysofOnDutyMaternityLeave - DaysofBreastFeedLeave)/
                    ExpectedOnDutyDays;
            }
        }
        /// <summary>
        /// 界面显示
        /// </summary>
        /// <returns></returns>
        public string LateToString()
        {
            return Convert.ToSingle(decimal.Round(Convert.ToDecimal(_ArriveLate.Count), 2)) + "次;共" +
                   Convert.ToSingle(decimal.Round(Convert.ToDecimal(_ArriveLate.TotalData), 2)) + "分钟";
        }
        /// <summary>
        /// 界面显示
        /// </summary>
        /// <returns></returns>
        public string EarlyLeaveToString()
        {
            return Convert.ToSingle(decimal.Round(Convert.ToDecimal(_LeaveEarly.Count), 2)) + "次;共" +
                   Convert.ToSingle(decimal.Round(Convert.ToDecimal(_LeaveEarly.TotalData), 2)) + "分钟";
        }

    }

}