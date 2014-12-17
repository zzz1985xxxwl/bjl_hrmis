using System;
using Sms.Entity;

namespace Sms.Bll.Mail
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
            get { return _Body; }
            set { _Body = value; }
        }

        public MailSettings Settings
        {
            get { return _Settings; }
            set { _Settings = value; }
        }
    }
}