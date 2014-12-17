//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: AttendanceReadRule.cs
// ������: ����
// ��������: 2008-10-15
// ����: ��ȡ������������
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
        /// �˼�¼ID
        /// </summary>
        public int AttendanceReadTimeId
        {
            get { return _AttendanceReadTimeId; }
            set { _AttendanceReadTimeId = value; }
        }

        /// <summary>
        /// ���õĶ�ȡʱ��
        /// </summary>
        public DateTime ReadDateTime
        {
            get { return _ReadDateTime; }
            set { _ReadDateTime = value; }
        }

        /// <summary>
        /// �Ƿ����ʼ�
        /// </summary>
        public bool IsSendMail
        {
            get { return _IsSendMail; }
            set { _IsSendMail = value; }
        }

        /// <summary>
        /// ���͵Ĺ���Ĭ��Ϊ����ʱ��Ϊ��
        /// </summary>
        public SendEmailRuleType SendEmailRule
        {
            get { return _SendEmailRule; }
            set { _SendEmailRule = value; }
        }
    }
}
