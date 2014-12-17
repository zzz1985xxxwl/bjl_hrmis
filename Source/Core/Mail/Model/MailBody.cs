//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: MailBody.cs
// Creater:  Xue.wenlong
// Date:  2009-03-19
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Mail.Model
{
    [Serializable]
    public class MailBody
    {
        private List<string> _MailTo;
        private string _Subject;
        private string _Body;
        private bool _IsAsync = false;
        private bool _IsHtmlBody = true;
        private List<string> _MailBcc = new List<string>();
        private List<string> _MailCc = new List<string>();
        private List<MailAttachment> _MailAttachments = new List<MailAttachment>();


        /// <summary>
        /// 发送至
        /// </summary>
        public List<string> MailTo
        {
            get { return _MailTo; }
            set { _MailTo = value; }
        }

        /// <summary>
        /// 抄送
        /// </summary>
        public List<string> MailCc
        {
            get { return _MailCc; }
            set { _MailCc = value; }
        }

        /// <summary>
        /// 秘送
        /// </summary>
        public List<string> MailBcc
        {
            get { return _MailBcc; }
            set { _MailBcc = value; }
        }

        /// <summary>
        /// 主题
        /// </summary>
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        /// <summary>
        /// 正文
        /// </summary>
        public string Body
        {
            get { return _Body; }
            set { _Body = value; }
        }

        /// <summary>
        /// 是否是Html文本
        /// </summary>
        public bool IsHtmlBody
        {
            get { return _IsHtmlBody; }
            set { _IsHtmlBody = value; }
        }

        /// <summary>
        /// 附件
        /// </summary>
        public List<MailAttachment> MailAttachments
        {
            get { return _MailAttachments; }
            set { _MailAttachments = value; }
        }

        /// <summary>
        /// 是否异步发送Mail
        /// </summary>
        public bool IsAsync
        {
            get { return _IsAsync; }
            set { _IsAsync = value; }
        }
    }
}