using System;
using System.Messaging;
using Sms.Entity;

namespace Sms.Bll.Mail
{
    public class AddMail
    {
        public string Send(MailBody mailBody, MailSettings mailSettings)
        {
            string result = string.Empty;
            string path = ".\\Private$\\Mail";
            try
            {
                MessageQueue.Delete(path);
                return "";
                if (!MessageQueue.Exists(path))
                {
                    MessageQueue.Create(path);
                }
                //连接到本地的队列
                var myQueue = new MessageQueue(path);
                var myMessage = new Message();
                var body = new MailBodyAndSetting(mailBody, mailSettings);
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