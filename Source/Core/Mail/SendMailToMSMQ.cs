//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SendMailWCF.cs
// Creater:  Xue.wenlong
// Date:  2009-03-19
// Resume:
// ---------------------------------------------------------------

using System;
using System.Messaging;
using Mail.Model;

namespace Mail
{
    public class SendMailToMSMQ
    {
        public string SendMail(MailBody mailBody, MailSettings mailSettings)
        {
            string result = string.Empty;
            string path = ".\\Private$\\MailBack";
            try
            {
                if (!MessageQueue.Exists(path))
                {
                    MessageQueue.Create(path);
                }
                //连接到本地的队列
                MessageQueue myQueue = new MessageQueue(path);
                Message myMessage = new Message();
                MailBodyAndSetting body = new MailBodyAndSetting(mailBody, mailSettings);
                myMessage.Body = body;
                myMessage.Formatter = new BinaryMessageFormatter();
                //发送消息到队列中
                myQueue.Send(myMessage);
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
    }
}