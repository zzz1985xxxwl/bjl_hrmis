using System;
using System.Collections.Generic;

namespace Sms.Entity
{
    [Serializable]
    public class MailBody
    {
        private string _Body;
        private bool _IsAsync;
        private bool _IsHtmlBody = true;
        private List<MailAttachment> _MailAttachments = new List<MailAttachment>();
        private List<string> _MailBcc = new List<string>();
        private List<string> _MailCc = new List<string>();
        private List<string> _MailTo;
        private string _Subject;


        /// <summary>
        ///     发送至
        /// </summary>
        public List<string> MailTo
        {
            get { return _MailTo; }
            set { _MailTo = value; }
        }

        /// <summary>
        ///     抄送
        /// </summary>
        public List<string> MailCc
        {
            get { return _MailCc; }
            set { _MailCc = value; }
        }

        /// <summary>
        ///     秘送
        /// </summary>
        public List<string> MailBcc
        {
            get { return _MailBcc; }
            set { _MailBcc = value; }
        }

        /// <summary>
        ///     主题
        /// </summary>
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        /// <summary>
        ///     正文
        /// </summary>
        public string Body
        {
            get { return _Body; }
            set { _Body = value; }
        }

        /// <summary>
        ///     是否是Html文本
        /// </summary>
        public bool IsHtmlBody
        {
            get { return _IsHtmlBody; }
            set { _IsHtmlBody = value; }
        }

        /// <summary>
        ///     附件
        /// </summary>
        public List<MailAttachment> MailAttachments
        {
            get { return _MailAttachments; }
            set { _MailAttachments = value; }
        }

        /// <summary>
        ///     是否异步发送Mail
        /// </summary>
        public bool IsAsync
        {
            get { return _IsAsync; }
            set { _IsAsync = value; }
        }
    }

    [Serializable]
    public class MailAttachment
    {
        private byte[] _Attachment;
        private string _Location;
        private string _Name;

        public MailAttachment()
        {
        }

        public MailAttachment(byte[] attachment)
        {
            _Attachment = attachment;
        }

        public MailAttachment(byte[] attachment, string name)
            : this(attachment)
        {
            _Name = name;
        }

        /// <summary>
        ///     附件
        /// </summary>
        public byte[] Attachment
        {
            get { return _Attachment; }
            set { _Attachment = value; }
        }

        /// <summary>
        ///     附件名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        ///     附件路径
        /// </summary>
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
    }

    [Serializable]
    public class MailSettings
    {
        private bool _IsMSMQ;
        private string _LogForMail;
        private string _Password;
        private string _SMTPHost;
        private string _SystemMailAddress;
        private string _SystemMailCommand;
        private string _UserName;

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
        ///     是否记日志 example:true
        /// </summary>
        public string LogForMail
        {
            get { return _LogForMail; }
            set { _LogForMail = value; }
        }

        /// <summary>
        ///     发件箱地址 example:hr@shixintech.com
        /// </summary>
        public string SystemMailAddress
        {
            get { return _SystemMailAddress; }
            set { _SystemMailAddress = value; }
        }

        /// <summary>
        ///     example:实信人力资源管理系统
        /// </summary>
        public string SystemMailCommand
        {
            get { return _SystemMailCommand; }
            set { _SystemMailCommand = value; }
        }

        /// <summary>
        ///     example:mail.shixintech.com
        /// </summary>
        public string SMTPHost
        {
            get { return _SMTPHost; }
            set { _SMTPHost = value; }
        }

        /// <summary>
        ///     用户名
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        /// <summary>
        ///     密码
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        /// <summary>
        ///     是否用WCF发送邮件
        /// </summary>
        public bool IsMSMQ
        {
            get { return _IsMSMQ; }
            set { _IsMSMQ = value; }
        }
    }
}