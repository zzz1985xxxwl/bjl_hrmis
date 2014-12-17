//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: MailBodyAndSetting.cs
// Creater:  Xue.wenlong
// Date:  2010-03-16
// Resume:
// ----------------------------------------------------------------

using System;
using Mail.Model;

namespace Mail
{
    /// <summary>
    /// </summary>
    [Serializable]
    public class MailBodyAndSetting
    {
        private MailBody _Body;
        private MailSettings _Settings;

        public MailBodyAndSetting(MailBody body, MailSettings settings)
        {
            _Body = body;
            _Settings = settings;
        }
        public MailBody Body
        {
            get
            {
                return _Body;
            }
            set
            {
                _Body = value;
            }
        }
        public MailSettings Settings
        {
            get
            {
                return _Settings;
            }
            set
            {
                _Settings = value;
            }
        }
    }
}