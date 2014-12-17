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
        /// �Ƿ����־ example:true 
        /// </summary>
        public string LogForMail
        {
            get { return _LogForMail; }
            set { _LogForMail = value; }
        }

        /// <summary>
        /// �������ַ example:hr@shixintech.com
        /// </summary>
        public string SystemMailAddress
        {
            get { return _SystemMailAddress; }
            set { _SystemMailAddress = value; }
        }

        /// <summary>
        /// example:ʵ��������Դ����ϵͳ
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
        /// �û���
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        /// <summary>
        /// �Ƿ���WCF�����ʼ�
        /// </summary>
        public bool IsMSMQ
        {
            get { return _IsMSMQ; }
            set { _IsMSMQ = value; }
        }
    }
}