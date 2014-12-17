//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: DutyClass.cs
// 创建者: 王玥琦
// 创建日期: 2008-4-16
// 概述: 设置班别
// ----------------------------------------------------------------

using System;
namespace SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel
{
    ///<summary>
    /// 班别
    ///</summary>
    [Serializable]
    public class DutyClass
    {
        private int _DutyClassID;
        private string _DutyClassName;
        private DateTime _FirstStartFromTime;
        private DateTime _FirstStartToTime;
        private DateTime _FirstEndTime;
        private DateTime _SecondStartTime;
        private DateTime _SecondEndTime;

        private decimal _AllLimitTime;

        private int _LateTime;
        private int _EarlyLeaveTime;
        private int _AbsentLateTime;
        private int _AbsentEarlyLeaveTime;

        ///<summary>
        /// 构造函数
        ///</summary>
        public DutyClass()
        {

        }

        ///<summary>
        ///</summary>
        ///<param name="dutyClassName"></param>
        ///<param name="firstStartFromTime"></param>
        ///<param name="firstStartToTime"></param>
        ///<param name="firstEndTime"></param>
        ///<param name="secondStartTime"></param>
        ///<param name="secondEndTime"></param>
        ///<param name="allLimitTime"></param>
        ///<param name="lateTime"></param>
        ///<param name="earlyLeaveTime"></param>
        ///<param name="absentLateTime"></param>
        ///<param name="absentEarlyLeaveTime"></param>
        public DutyClass(string dutyClassName, DateTime firstStartFromTime,
            DateTime firstStartToTime,DateTime firstEndTime,
            DateTime secondStartTime,DateTime secondEndTime,
            decimal allLimitTime,
            int lateTime, int earlyLeaveTime, int absentLateTime, int absentEarlyLeaveTime)
        {
            _DutyClassName = dutyClassName;
            _FirstStartFromTime = firstStartFromTime;
            _FirstStartToTime = firstStartToTime;
            _FirstEndTime = firstEndTime;
            _SecondStartTime = secondStartTime;
            _SecondEndTime = secondEndTime;
            _AllLimitTime = allLimitTime;
            _LateTime = lateTime;
            _EarlyLeaveTime = earlyLeaveTime;
            _AbsentLateTime = absentLateTime;
            _AbsentEarlyLeaveTime = absentEarlyLeaveTime;
        }

        ///<summary>
        /// -1时表示不上班
        ///</summary>
        public int DutyClassID
        {
            get { return _DutyClassID; }
            set { _DutyClassID = value; }
        }

        ///<summary>
        /// 班别名称
        ///</summary>
        public string DutyClassName
        {
            get { return _DutyClassName; }
            set { _DutyClassName = value; }
        }
 
        /// <summary>
        /// 设定员工在这个时间外为迟到时间
        /// </summary>
        public int LateTime
        {
            get { return _LateTime; }
            set { _LateTime = value; }
        }

        /// <summary>
        /// 设定员工在这个时间外为早退时间
        /// </summary>
        public int EarlyLeaveTime
        {
            get { return _EarlyLeaveTime; }
            set { _EarlyLeaveTime = value; }
        }

        /// <summary>
        /// 是否休息
        /// </summary>
        public bool IsWeek
        {
            get { return _DutyClassID == -1; }
        }
        /// <summary>
        /// 迟到晚于多少分钟算旷工0.5天
        /// </summary>
        public int AbsentLateTime
        {
            get { return _AbsentLateTime; }
            set { _AbsentLateTime = value; }
        }
        /// <summary>
        /// 早退早于多少分钟算旷工0.5天
        /// </summary>
        public int AbsentEarlyLeaveTime
        {
            get { return _AbsentEarlyLeaveTime; }
            set { _AbsentEarlyLeaveTime = value; }
        }
        /// <summary>
        /// 一天上班上班不得少于的时间
        /// </summary>
        public decimal AllLimitTime
        {
            get { return _AllLimitTime; }
            set { _AllLimitTime = value; }
        }

        ///<summary>
        /// 上午上班最早时间
        ///</summary>
        public DateTime FirstStartFromTime
        {
            get { return _FirstStartFromTime; }
            set { _FirstStartFromTime = value; }
        }
        ///<summary>
        /// 上午上班最晚时间
        ///</summary>
        public DateTime FirstStartToTime
        {
            get { return _FirstStartToTime; }
            set { _FirstStartToTime = value; }
        }
        /// <summary>
        /// 上午下班时间
        /// </summary>
        public DateTime FirstEndTime
        {
            get { return _FirstEndTime; }
            set { _FirstEndTime = value; }
        }
        /// <summary>
        /// 下午上班时间
        /// </summary>
        public DateTime SecondStartTime
        {
            get { return _SecondStartTime; }
            set { _SecondStartTime = value; }
        }
        /// <summary>
        /// 下午下班时间
        /// </summary>
        public DateTime SecondEndTime
        {
            get { return _SecondEndTime; }
            set { _SecondEndTime = value; }
        }
    }
}
