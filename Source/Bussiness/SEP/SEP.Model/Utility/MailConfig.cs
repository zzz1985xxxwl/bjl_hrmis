//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: MailConfig.cs
// Creater:  Xue.wenlong
// Date:  2009-03-20
// Resume:
// ----------------------------------------------------------------

using System;
using System.Configuration;
using Mail.Model;

namespace SEP.Model.Utility
{
    [Serializable]
    public class MailConfig
    {
        private static readonly string MSMQMail = ConfigurationManager.AppSettings["MSMQMail"];
        private static readonly string LogForMail = ConfigurationManager.AppSettings["MailLog"];

        public static MailSettings MailSet
        {
            get
            {
                bool isMSMQMail = !string.IsNullOrEmpty(MSMQMail) && MSMQMail.ToLower() == "true";
                return
                    new MailSettings(LogForMail, CompanyConfig.SYSTEMMAILADDRESS, CompanyConfig.SYSTEMMAILCOMMAND,
                                     CompanyConfig.SMTPHOST, CompanyConfig.USERNAMEMAILADDRESS,
                                     CompanyConfig.USERNAMEPASSWORD, isMSMQMail);
            }
        }
    }
}