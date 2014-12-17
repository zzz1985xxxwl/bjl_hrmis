//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: MailSettings.cs
// Creater:  Xue.wenlong
// Date:  2009-03-19
// Resume:
// ---------------------------------------------------------------

using System;

namespace Mail.Model
{
    [Serializable]
    public class MailSettings
    {
        private string _LogForMail;
        private string _SystemMailAddress;
        private string _SystemMailCommand;
        private string _SMTPHost;
        private string _UserName;
        private string _Password;
        private bool _IsMSMQ;

        public MailSettings(string logForMail, string systemMailAddress, string systemMailCommand, string sMTPHost,
                            string userName, string password)
        {
            _LogForMail = logForMail;
            _SystemMailCommand = systemMailCommand;
            _SystemMailAddress = systemMailAddress;
            _SMTPHost = sMTPHost;
            _UserName = userName;
            _Password = password;
        }

        public MailSettings(string logForMail, string systemMailAddress, string systemMailCommand, string sMTPHost,
                            string userName, string password, bool isMSMQ)
            : this(logForMail, systemMailAddress, systemMailCommand, sMTPHost, userName, password)
        {
            _IsMSMQ = isMSMQ;
        }

        /// <summary>
        /// 是否记日志 example:true 
        /// </summary>
        public string LogForMail
        {
            get { return _LogForMail; }
            set { _LogForMail = value; }
        }

        /// <summary>
        /// 发件箱地址 example:hr@shixintech.com
        /// </summary>
        public string SystemMailAddress
        {
            get { return _SystemMailAddress; }
            set { _SystemMailAddress = value; }
        }

        /// <summary>
        /// example:实信人力资源管理系统
        /// </summary>
        public string SystemMailCommand
        {
            get { return _SystemMailCommand; }
            set { _SystemMailCommand = value; }
        }

        /// <summary>
        /// example:mail.shixintech.com
        /// </summary>
        public string SMTPHost
        {
            get { return _SMTPHost; }
            set { _SMTPHost = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        /// <summary>
        /// 是否用WCF发送邮件
        /// </summary>
        public bool IsMSMQ
        {
            get { return _IsMSMQ; }
            set { _IsMSMQ = value; }
        }
    }
}