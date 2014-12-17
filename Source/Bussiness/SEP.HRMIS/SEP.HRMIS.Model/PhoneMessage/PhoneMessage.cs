//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: PhoneMessage.cs
// Creater:  Xue.wenlong
// Date:  2009-05-22
// Resume:
// ---------------------------------------------------------------

using System;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.PhoneMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class PhoneMessage
    {
        private Account _Requester;
        private string _Message;
        private PhoneMessageType _PhoneMessageType;
        private int _PKID;
        private Account _Assessor;
        private PhoneMessageStatus _Status;
        private string _Answer;
        private DateTime? _SendTime;

        /// <summary>
        /// 
        /// </summary>
        public PhoneMessage(int pkid, Account requester,  Account assessor, PhoneMessageStatus status, string answer, string message)
        {
            _PKID = pkid;
            _Requester = requester;
            _Message = message;
            _Assessor = assessor;
            _Answer = answer;
            _Status = status;
        }

        /// <summary>
        /// 
        /// </summary>
        public PhoneMessage()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        /// <summary>
        /// 申请人
        /// </summary>
        public Account Requester
        {
            get { return _Requester; }
            set { _Requester = value; }
        }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public PhoneMessageType PhoneMessageType
        {
            get { return _PhoneMessageType; }
            set { _PhoneMessageType = value; }
        }

        /// <summary>
        /// 审核人
        /// </summary>
        public Account Assessor
        {
            get { return _Assessor; }
            set { _Assessor = value; }
        }


        /// <summary>
        /// 是否已发送
        /// </summary>
        public PhoneMessageStatus Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Answer
        {
            get { return _Answer; }
            set { _Answer = value; }
        }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime? SendTime
        {
            get { return _SendTime; }
            set { _SendTime = value; }
        }
    }
}