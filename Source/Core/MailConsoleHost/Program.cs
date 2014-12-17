using System;
using System.Messaging;
using Mail;

namespace MailConsoleHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string path = (".\\Private$\\MailBack");
            if (!MessageQueue.Exists(path))
            {
                MessageQueue.Create(path);
            }
            Console.WriteLine("邮件服务已启动，请不要关闭...");
            while (true)
            {
                //连接到本地队列
                MessageQueue myQueue = new MessageQueue(path);
                myQueue.Formatter = new BinaryMessageFormatter();
                SendMailCommon sendMail = new SendMailCommon();
                try
                {
                    //从队列中接收消息
                    Message myMessage = myQueue.Receive();
                    MailBodyAndSetting context = (MailBodyAndSetting)myMessage.Body; //获取消息的内容
                    sendMail.SendMail(context.Body, context.Settings);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}