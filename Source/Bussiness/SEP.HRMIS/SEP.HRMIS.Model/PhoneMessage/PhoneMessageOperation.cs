//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: PhoneMessaeOperation.cs
// Creater:  Xue.wenlong
// Date:  2009-05-25
// Resume:
// ---------------------------------------------------------------

using System;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.PhoneMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class PhoneMessageOperation
    {
        private Account _Assessor;
        private PhoneMessageStatus _Status;
        private int _PKID;
        private string _Answer;
        private DateTime? _SendTime;
        /// <summary>
        /// 
        /// </summary>
        public PhoneMessageOperation(int pkid, Account assessor, PhoneMessageStatus status, string answer)
        {
            _PKID = pkid;
            _Assessor = assessor;
            _Answer = answer;
            _Status = status;
        }
        /// <summary>
        /// 
        /// </summary>
        public PhoneMessageOperation()
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