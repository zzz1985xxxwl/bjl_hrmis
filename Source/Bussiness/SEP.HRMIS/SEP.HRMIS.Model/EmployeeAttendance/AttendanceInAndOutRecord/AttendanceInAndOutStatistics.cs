//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AttendanceInAndOutStatistics.cs
// 创建者: 王玥琦
// 创建日期: 2008-10-09
// 概述: 员工进出打卡记录汇总统计类
// ----------------------------------------------------------------
using System;


namespace SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord
{
    [Serializable]
    public class AttendanceInAndOutStatistics
    {
        //进入时间
        private DateTime _InTime;
        //离开时间
        private DateTime _OutTime;
        //请假和外出情况
        private string _LeaveRequestAndOut;

        public AttendanceInAndOutStatistics(DateTime inTime, DateTime outTime,
            string leaveRequestAndOut)
        {
            _InTime = inTime;
            _OutTime = outTime;
            _LeaveRequestAndOut = leaveRequestAndOut;
        }

        public DateTime InTime
        {
            get
            {
                return _InTime;
            }
            set
            {
                _InTime = value;
            }
        }
        public DateTime OutTime
        {
            get
            {
                return _OutTime;
            }
            set
            {
                _OutTime = value;
            }
        }
        public string LeaveRequestAndOut
        {
            get
            {
                return _LeaveRequestAndOut;
            }
            set
            {
                _LeaveRequestAndOut = value;
            }
        }
        ///<summary>
        ///</summary>
        ///<param name="outInTimeCondition"></param>
        ///<returns></returns>
        public static string GetOutInTimeConditionEnumName(OutInTimeConditionEnum outInTimeCondition)
        {
            switch (outInTimeCondition)
            {
                case OutInTimeConditionEnum.All:
                    return "";
                case OutInTimeConditionEnum.InAndOutTimeIsNull:
                    return "进入时间为空并且离开时间为空";
                case OutInTimeConditionEnum.InOrOutTimeIsNull:
                    return "进入时间为空或者离开时间为空";
                case OutInTimeConditionEnum.InTimeIsNull:
                    return "进入时间为空";
                case OutInTimeConditionEnum.OutTimeIsNull:
                    return "离开时间为空";
                case OutInTimeConditionEnum.InOrOutTimeOnlyOneIsNull:
                    return "进入时间为空或者离开时间只有一个为空";
                default:
                    return "";
            }
        }

    }
}
