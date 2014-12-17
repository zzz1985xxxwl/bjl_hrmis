//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: AttendanceReadRule.cs
// 创建者: 刘丹
// 创建日期: 2008-10-15
// 概述: 读取考勤数据设置
// ----------------------------------------------------------------

using System;


namespace SEP.HRMIS.Model.EmployeeAttendance.ReadData
{
    [Serializable]
    public class AttendanceReadRule
    {
        private int _AttendanceReadTimeId;
        private DateTime _ReadDateTime;
        private bool _IsSendMail;
        private SendEmailRuleType _SendEmailRule;

        public AttendanceReadRule()
        {

        }

        public AttendanceReadRule(DateTime readDateTime, bool isSendMail, SendEmailRuleType sendEmailRule)
        {
            _ReadDateTime = readDateTime;
            _IsSendMail = isSendMail;
            _SendEmailRule = sendEmailRule;
        }

        /// <summary>
        /// 此记录ID
        /// </summary>
        public int AttendanceReadTimeId
        {
            get { return _AttendanceReadTimeId; }
            set { _AttendanceReadTimeId = value; }
        }

        /// <summary>
        /// 设置的读取时间
        /// </summary>
        public DateTime ReadDateTime
        {
            get { return _ReadDateTime; }
            set { _ReadDateTime = value; }
        }

        /// <summary>
        /// 是否发送邮件
        /// </summary>
        public bool IsSendMail
        {
            get { return _IsSendMail; }
            set { _IsSendMail = value; }
        }

        /// <summary>
        /// 发送的规则，默认为进入时间为空
        /// </summary>
        public SendEmailRuleType SendEmailRule
        {
            get { return _SendEmailRule; }
            set { _SendEmailRule = value; }
        }
    }
}
