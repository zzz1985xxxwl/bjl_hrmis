//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: MonthAttendance.cs
// ������: wsl
// ��������: 2008-08-28
// ����: Ա���¿������
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.Request;
using SEP.Model.Calendar;

namespace SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics
{
    /// <summary>
    /// �ٵ�����ͳ��
    /// </summary>
    [Serializable]
    public class ArriveLeaveStatistics
    {
        private int _Count;
        private decimal _TotalData;
        private string _Unit;
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="count"></param>
        /// <param name="unit"></param>
        public ArriveLeaveStatistics(int count, string unit)
        {
            _Count = count;
            _Unit = unit;
        }
        /// <summary>
        /// ����
        /// </summary>
        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }
        /// <summary>
        /// �ܼ�
        /// </summary>
        public decimal TotalData
        {
            get { return _TotalData; }
            set { _TotalData = value; }
        }
        /// <summary>
        /// ��λ
        /// </summary>
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

    }
     /// <summary>
    /// Ա�����ͳ��
    /// </summary>
    [Serializable]
    public class LeaveRequestStatistics
    {
        private readonly LeaveRequestType _LeaveRequestType;
        private decimal _Hours;
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="leaveRequestType"></param>
        public LeaveRequestStatistics(LeaveRequestType leaveRequestType)
        {
            _LeaveRequestType = leaveRequestType;
        }
        /// <summary>
        /// �������
        /// </summary>
        public LeaveRequestType LeaveRequestType
        {
            get { return _LeaveRequestType; }
        }
        /// <summary>
        /// Сʱ��
        /// </summary>
        public decimal Hours
        {
            get { return _Hours; }
            set { _Hours = value; }
        }
        /// <summary>
        /// ��
        /// </summary>
        public decimal Days
        {
            get { return _Hours / 8; }
        }
    }
    /// <summary>
    /// һ��ʱ���ڵĿ���ͳ����Ϣ
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
        /// ���캯��
        /// </summary>
        public MonthAttendance()
        {
            ArriveLate = new ArriveLeaveStatistics(0, "����");
            LeaveEarly = new ArriveLeaveStatistics(0, "����");
            LeaveRequestStatisticsList = new List<LeaveRequestStatistics>();
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ��ǰԱ�������ϸ
        /// </summary>
        public List<LeaveRequestStatistics> LeaveRequestStatisticsList
        {
            get { return _LeaveRequestStatisticsList; }
            set { _LeaveRequestStatisticsList = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ��ǰԱ���տ�����ϸ
        /// </summary>
        public List<DayAttendance> DayAttendanceList
        {
            get { return _DayAttendanceList; }
            set { _DayAttendanceList = value; }
        }

        /// <summary>
        /// FromDate��ToDateʱ����ڵ� Ӧ��������
        /// </summary>
        public decimal ExpectedOnDutyDays
        {
            get { return _ExpectedOnDutyDays; }
            set { _ExpectedOnDutyDays = value; }
        }

        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ��������
        /// </summary>
        public decimal ActualOnDutyDays
        {
            get { return _ActualOnDutyDays; }
            set { _ActualOnDutyDays = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ��������
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
        /// FromDate��ToDateʱ����ڵ� ��������
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
        /// ɥ��Сʱ
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
        /// ɥ������
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
        /// �����Сʱ
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
        /// ���������
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
        /// ���Сʱ
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
        /// �������
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
        /// ʣ�����Сʱ
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
        /// ʣ���������
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
        /// FromDate��ToDateʱ����ڵ� �Ӱ�Сʱ
        /// </summary>
        public decimal HoursofOvertime
        {
            get { return _HoursofOvertime; }
            set { _HoursofOvertime = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ����Сʱ
        /// </summary>
        public decimal HoursofOutCity
        {
            get { return _HoursofOutCity; }
            set { _HoursofOutCity = value; }
        }

        /// <summary>
        /// FromDate��ToDateʱ����ڵ� �Ӱ�����
        /// </summary>
        public decimal DaysofOvertime
        {
            get { return _HoursofOvertime / 8; }
            //set { _OvertimeDays = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ��������
        /// </summary>
        public decimal DaysofAdjustRestLeave
        {
            get { return _HoursofAdjustRestLeave / 8; }
            //set { _DaysofAdjustRestLeave = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ����Сʱ
        /// </summary>
        public decimal HoursofAdjustRestLeave
        {
            get { return _HoursofAdjustRestLeave; }
            set { _HoursofAdjustRestLeave = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� �¼�����
        /// </summary>
        public decimal DaysofPersonalReasonLeave
        {
            get { return _HoursofPersonalReasonLeave / 8; }
            //set { _DaysofPersonalReasonLeave = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� �¼�Сʱ
        /// </summary>
        public decimal HoursofPersonalReasonLeave
        {
            get { return _HoursofPersonalReasonLeave; }
            set { _HoursofPersonalReasonLeave = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� �������
        /// </summary>
        public decimal DaysofLunarPeriodLeave
        {
            get { return _HoursofLunarPeriodLeave / 8; }
            //set { _DaysofLunarPeriodLeave = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ���Сʱ
        /// </summary>
        public decimal HoursofLunarPeriodLeave
        {
            get { return _HoursofLunarPeriodLeave; }
            set { _HoursofLunarPeriodLeave = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ��������
        /// </summary>
        public decimal DaysofSickLeave
        {
            get { return _HoursofSickLeave / 8; }
            //set { _DaysofSickLeave = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ����Сʱ
        /// </summary>
        public decimal HoursofSickLeave
        {
            get { return _HoursofSickLeave; }
            set { _HoursofSickLeave = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� �����������
        /// </summary>
        public decimal DaysofOtherLeave
        {
            get { return _HoursofOtherLeave / 8; }
            //set { _DaysofOtherLeave = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� �������Сʱ
        /// </summary>
        public decimal HoursofOtherLeave
        {
            get { return _HoursofOtherLeave; }
            set { _HoursofOtherLeave = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ��ǰ��Сʱ
        /// </summary>
        public decimal HoursofPrenatalLeave
        {
            get { return _HoursofPrenatalLeave; }
            set { _HoursofPrenatalLeave = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� �����ղ���Сʱ
        /// </summary>
        public decimal HoursofOnDutyMaternityLeave
        {
            get { return _HoursofOnDutyMaternityLeave; }
            set { _HoursofOnDutyMaternityLeave = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ����Сʱ
        /// </summary>
        public decimal HoursofMaternityLeave
        {
            get { return _HoursofMaternityLeave; }
            set { _HoursofMaternityLeave = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� �����Сʱ
        /// </summary>
        public decimal HoursofBreastFeedLeave
        {
            get { return _HoursofBreastFeedLeave; }
            set { _HoursofBreastFeedLeave = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ��ǰ����
        /// </summary>
        public decimal DaysofPrenatalLeave
        {
            get { return _HoursofPrenatalLeave / 8; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� �����ղ�����
        /// </summary>
        public decimal DaysofOnDutyMaternityLeave
        {
            get { return _HoursofOnDutyMaternityLeave / 8; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ������
        /// </summary>
        public decimal DaysofMaternityLeave
        {
            get { return _HoursofMaternityLeave / 8; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� �������
        /// </summary>
        public decimal DaysofBreastFeedLeave
        {
            get { return _HoursofBreastFeedLeave / 8; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ��ͨ�Ӱ�Сʱ
        /// </summary>
        public decimal HoursofCommonOvertime
        {
            get { return _HoursofCommonOvertime; }
            set { _HoursofCommonOvertime = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ��ͨ�Ӱ�Сʱ �޻���
        /// </summary>
        public decimal HoursofCommonOvertimeNotAdjust
        {
            get { return _HoursofCommonOvertimeNotAdjust; }
            set { _HoursofCommonOvertimeNotAdjust = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ��ͨ�Ӱ�Сʱ ��û���
        /// </summary>
        public decimal HoursofCommonOvertimeAdjust
        {
            get { return _HoursofCommonOvertime - _HoursofCommonOvertimeNotAdjust; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ˫�ݼӰ�Сʱ
        /// </summary>
        public decimal HoursofWeekendOvertime
        {
            get { return _HoursofWeekendOvertime; }
            set { _HoursofWeekendOvertime = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ˫�ݼӰ�Сʱ �޻���
        /// </summary>
        public decimal HoursofWeekendOvertimeNotAdjust
        {
            get { return _HoursofWeekendOvertimeNotAdjust; }
            set { _HoursofWeekendOvertimeNotAdjust = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ˫�ݼӰ�Сʱ ��û���
        /// </summary>
        public decimal HoursofWeekendOvertimeAdjust
        {
            get { return _HoursofWeekendOvertime - _HoursofWeekendOvertimeNotAdjust; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ���ռӰ�Сʱ
        /// </summary>
        public decimal HoursofHolidayOvertime
        {
            get { return _HoursofHolidayOvertime; }
            set { _HoursofHolidayOvertime = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ���ռӰ�Сʱ �޻���
        /// </summary>
        public decimal HoursofHolidayOvertimeNotAdjust
        {
            get { return _HoursofHolidayOvertimeNotAdjust; }
            set { _HoursofHolidayOvertimeNotAdjust = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ���ռӰ�Сʱ ��û���
        /// </summary>
        public decimal HoursofHolidayOvertimeAdjust
        {
            get { return _HoursofHolidayOvertime - _HoursofHolidayOvertimeNotAdjust; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ��ͨ�Ӱ���
        /// </summary>
        public decimal DaysofCommonOvertime
        {
            get { return _HoursofCommonOvertime / 8; }
        }
        /// <summary>
        ///  FromDate��ToDateʱ����ڵĻ��õ��� ��ͨ�Ӱ���
        /// </summary>
        public decimal DaysofCommonOvertimeAdjust
        {
            get { return (_HoursofCommonOvertime - _HoursofCommonOvertimeNotAdjust) / 8; }
        }
        /// <summary>
        ///  FromDate��ToDateʱ����ڵ��޵��� ��ͨ�Ӱ���
        /// </summary>
        public decimal DaysofCommonOvertimeNotAdjust
        {
            get { return _HoursofCommonOvertimeNotAdjust / 8; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ˫�ݼӰ���
        /// </summary>
        public decimal DaysofWeekendOvertime
        {
            get { return _HoursofWeekendOvertime / 8; }
        }
        /// <summary>
        ///  FromDate��ToDateʱ����ڵĻ��õ��� ˫�ݼӰ���
        /// </summary>
        public decimal DaysofWeekendOvertimeAdjust
        {
            get { return (_HoursofWeekendOvertime - _HoursofWeekendOvertimeNotAdjust) / 8; }
        }
        /// <summary>
        ///  FromDate��ToDateʱ����ڵ��޵��� ˫�ݼӰ���
        /// </summary>
        public decimal DaysofWeekendOvertimeNotAdjust
        {
            get { return _HoursofWeekendOvertimeNotAdjust / 8; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ���ռӰ���
        /// </summary>
        public decimal DaysofHolidayOvertime
        {
            get { return HoursofHolidayOvertime / 8; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵĻ��õ��� ���ռӰ���
        /// </summary>
        public decimal DaysofHolidayOvertimeAdjust
        {
            get { return (_HoursofHolidayOvertime - _HoursofHolidayOvertimeNotAdjust) / 8; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ��޵��� ���ռӰ���
        /// </summary>
        public decimal DaysofHolidayOvertimeNotAdjust
        {
            get { return _HoursofHolidayOvertimeNotAdjust / 8; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ������Ϣ
        /// </summary>
        public ArriveLeaveStatistics LeaveEarly
        {
            get { return _LeaveEarly; }
            set { _LeaveEarly = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� �ٵ���Ϣ
        /// </summary>
        public ArriveLeaveStatistics ArriveLate
        {
            get { return _ArriveLate; }
            set { _ArriveLate = value; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ��������
        /// </summary>
        public decimal DaysofOutCity
        {
            get { return _HoursofOutCity / 8; }
        }
        /// <summary>
        /// FromDate��ToDateʱ����ڵ� ������
        /// ������=(Ӧ��������-�¼�-����-����)/Ӧ������
        /// ������=(Ӧ��������-�¼�-����-����-�����-����-�����)/Ӧ������ 
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
        /// ������ʾ
        /// </summary>
        /// <returns></returns>
        public string LateToString()
        {
            return Convert.ToSingle(decimal.Round(Convert.ToDecimal(_ArriveLate.Count), 2)) + "��;��" +
                   Convert.ToSingle(decimal.Round(Convert.ToDecimal(_ArriveLate.TotalData), 2)) + "����";
        }
        /// <summary>
        /// ������ʾ
        /// </summary>
        /// <returns></returns>
        public string EarlyLeaveToString()
        {
            return Convert.ToSingle(decimal.Round(Convert.ToDecimal(_LeaveEarly.Count), 2)) + "��;��" +
                   Convert.ToSingle(decimal.Round(Convert.ToDecimal(_LeaveEarly.TotalData), 2)) + "����";
        }

    }

}