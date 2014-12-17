//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: MailAttachment.cs
// Creater:  Xue.wenlong
// Date:  2009-03-19
// Resume:
// ---------------------------------------------------------------
using System;

namespace Mail.Model
{
    [Serializable]
    public class MailAttachment
    {
        private byte[] _Attachment;
        private string _Name;
        private string _Location;

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
        /// 附件
        /// </summary>
        public byte[] Attachment
        {
            get { return _Attachment; }
            set { _Attachment = value; }
        }

        /// <summary>
        /// 附件名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// 附件路径
        /// </summary>
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
    }
}