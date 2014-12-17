//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SendMailTest.cs
// Creater:  Xue.wenlong
// Date:  2009-03-19
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Net.Mail;
using Mail.Model;
using NUnit.Framework;

namespace Mail.UnitTest
{
    [TestFixture]
    public class SendMailTest
    {
        private readonly List<MailAddress> MailCc = new List<MailAddress>();

        [Test]
        public void Send()
        {
            Assert.AreEqual("", new SendMail().Send(GetMailBody(), GetMailSettings()));
        }


        [Test]
        public void ConvertToString()
        {
            List<string> strlist = new List<string>();
            strlist.Add("");
            strlist.Add("");
            strlist.Add("");
            string[] ret = SendMailCommon.ConvertToString(strlist);
            Assert.AreEqual(0, ret.Length);
            strlist.Clear();
            strlist.Add("sdfdf");
            strlist.Add("");
            strlist.Add("sfsfs");
            ret = SendMailCommon.ConvertToString(strlist);
            Assert.AreEqual(2, ret.Length);
        }

        private MailBody GetMailBody()
        {
            MailBody mailModel = new MailBody();
            mailModel.MailTo = new List<string>();
            mailModel.MailTo.Add("Br-hrmis@br-automation.com");
            mailModel.Subject = "sfsfsa";
            mailModel.Body = "<a>dfsdfdsdfÊÇµÄËï·Æ·Æo</a>";
            mailModel.IsAsync = false;
            mailModel.IsHtmlBody = true;
            //MailAttachment at=new MailAttachment();
            //at.Location = @"C:\test1.xls";
            //mailModel.MailAttachments.Add(at);
            if (MailCc != null)
            {
                foreach (MailAddress mailAddress in MailCc)
                {
                    mailModel.MailCc.Add(mailAddress.Address);
                }
            }
            return mailModel;
        }

        private static MailSettings GetMailSettings()
        {
            return
                new MailSettings("true", "hr@shixintech.com", "hr@shixintech.com", "cnshan01/shanghai/cn/b&r",
                                 "hr@shixintech.com", "7AsHs9wD", false);
        }
    }
}