//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SendMail.cs
// Creater:  Xue.wenlong
// Date:  2009-03-19
// Resume:
// ---------------------------------------------------------------

using Mail.Model;

namespace Mail
{
    public class SendMail : ISendMail
    {
        public string Send(MailBody mailBody, MailSettings mailSettings)
        {
            if (mailSettings.IsMSMQ)
            {
                return new SendMailToMSMQ().SendMail(mailBody, mailSettings);
            }
            else
            {
                return new SendMailCommon().SendMail(mailBody, mailSettings);
            }
        }
    }
}