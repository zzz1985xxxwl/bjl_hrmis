//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AttendanceInAndOutStatistics.cs
// ������: ���h��
// ��������: 2008-10-09
// ����: Ա�������򿨼�¼����ͳ����
// ----------------------------------------------------------------
using System;


namespace SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord
{
    [Serializable]
    public class AttendanceInAndOutStatistics
    {
        //����ʱ��
        private DateTime _InTime;
        //�뿪ʱ��
        private DateTime _OutTime;
        //��ٺ�������
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
                    return "����ʱ��Ϊ�ղ����뿪ʱ��Ϊ��";
                case OutInTimeConditionEnum.InOrOutTimeIsNull:
                    return "����ʱ��Ϊ�ջ����뿪ʱ��Ϊ��";
                case OutInTimeConditionEnum.InTimeIsNull:
                    return "����ʱ��Ϊ��";
                case OutInTimeConditionEnum.OutTimeIsNull:
                    return "�뿪ʱ��Ϊ��";
                case OutInTimeConditionEnum.InOrOutTimeOnlyOneIsNull:
                    return "����ʱ��Ϊ�ջ����뿪ʱ��ֻ��һ��Ϊ��";
                default:
                    return "";
            }
        }

    }
}
