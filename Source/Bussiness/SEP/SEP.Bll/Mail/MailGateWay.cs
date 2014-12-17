//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: MailGateWay.cs
// Creater:  Xue.wenlong
// Date:  2009-03-20
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using Mail;
using Mail.Model;
using SEP.IBll.Mail;
using SEP.Model.Utility;

namespace SEP.Bll.Mail
{
    public class MailGateWay : IMailGateWay
    {
        private MailBody _MailBody;
        private readonly ISendMail _SendMail = new SendMail();
        private MailFilter _MailFilter;


        public void Send(MailBody mailBody)
        {
            Send(mailBody, true);
        }

        public void Send(MailBody mailBody, bool addLoginAddress)
        {
            _MailFilter = new MailFilter();
            InitMail(mailBody, addLoginAddress);
            if (_MailBody.MailTo != null && _MailBody.MailTo.Count > 0)
            {
                string error = _SendMail.Send(_MailBody, MailConfig.MailSet);
                if (!string.IsNullOrEmpty(error))
                {
                    throw new ApplicationException(error);
                }
            }
        }

        private void InitMail(MailBody mailBody, bool addLoginAddress)
        {
            if (addLoginAddress)
            {
                AddWebSiteToBody(mailBody);
            }
            _MailBody = mailBody;
            FilterTheMailAddress();
        }

        private static void AddWebSiteToBody(MailBody mailBody)
        {
            mailBody.Body += Environment.NewLine;
            mailBody.Body += CompanyConfig.LOCALHOSTADDRESS;
        }

        private void FilterTheMailAddress()
        {
            FilterMailAddress(_MailBody.MailCc);
            FilterMailAddress(_MailBody.MailBcc);
            for (int i = _MailBody.MailTo.Count - 1; i >= 0; i--)
            {
                if (_MailFilter.IsInBlackList(_MailBody.MailTo[i]))
                {
                    _MailBody.MailTo.RemoveAt(i);
                }
            }
        }

        private void FilterMailAddress(IList<string> mailAddressList)
        {
            if (mailAddressList != null)
            {
                for (int i = mailAddressList.Count - 1; i >= 0; i--)
                {
                    if (_MailFilter.IsInBlackList(mailAddressList[i]))
                    {
                        mailAddressList.RemoveAt(i);
                    }
                }
            }
        }
    }
}