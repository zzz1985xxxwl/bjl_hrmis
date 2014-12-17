//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: DutyClass.cs
// ������: ���h��
// ��������: 2008-4-16
// ����: ���ð��
// ----------------------------------------------------------------

using System;
namespace SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel
{
    ///<summary>
    /// ���
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
        /// ���캯��
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
        /// -1ʱ��ʾ���ϰ�
        ///</summary>
        public int DutyClassID
        {
            get { return _DutyClassID; }
            set { _DutyClassID = value; }
        }

        ///<summary>
        /// �������
        ///</summary>
        public string DutyClassName
        {
            get { return _DutyClassName; }
            set { _DutyClassName = value; }
        }
 
        /// <summary>
        /// �趨Ա�������ʱ����Ϊ�ٵ�ʱ��
        /// </summary>
        public int LateTime
        {
            get { return _LateTime; }
            set { _LateTime = value; }
        }

        /// <summary>
        /// �趨Ա�������ʱ����Ϊ����ʱ��
        /// </summary>
        public int EarlyLeaveTime
        {
            get { return _EarlyLeaveTime; }
            set { _EarlyLeaveTime = value; }
        }

        /// <summary>
        /// �Ƿ���Ϣ
        /// </summary>
        public bool IsWeek
        {
            get { return _DutyClassID == -1; }
        }
        /// <summary>
        /// �ٵ����ڶ��ٷ��������0.5��
        /// </summary>
        public int AbsentLateTime
        {
            get { return _AbsentLateTime; }
            set { _AbsentLateTime = value; }
        }
        /// <summary>
        /// �������ڶ��ٷ��������0.5��
        /// </summary>
        public int AbsentEarlyLeaveTime
        {
            get { return _AbsentEarlyLeaveTime; }
            set { _AbsentEarlyLeaveTime = value; }
        }
        /// <summary>
        /// һ���ϰ��ϰ಻�����ڵ�ʱ��
        /// </summary>
        public decimal AllLimitTime
        {
            get { return _AllLimitTime; }
            set { _AllLimitTime = value; }
        }

        ///<summary>
        /// �����ϰ�����ʱ��
        ///</summary>
        public DateTime FirstStartFromTime
        {
            get { return _FirstStartFromTime; }
            set { _FirstStartFromTime = value; }
        }
        ///<summary>
        /// �����ϰ�����ʱ��
        ///</summary>
        public DateTime FirstStartToTime
        {
            get { return _FirstStartToTime; }
            set { _FirstStartToTime = value; }
        }
        /// <summary>
        /// �����°�ʱ��
        /// </summary>
        public DateTime FirstEndTime
        {
            get { return _FirstEndTime; }
            set { _FirstEndTime = value; }
        }
        /// <summary>
        /// �����ϰ�ʱ��
        /// </summary>
        public DateTime SecondStartTime
        {
            get { return _SecondStartTime; }
            set { _SecondStartTime = value; }
        }
        /// <summary>
        /// �����°�ʱ��
        /// </summary>
        public DateTime SecondEndTime
        {
            get { return _SecondEndTime; }
            set { _SecondEndTime = value; }
        }
    }
}
