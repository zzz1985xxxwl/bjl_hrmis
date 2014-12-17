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
            Console.WriteLine("�ʼ��������������벻Ҫ�ر�...");
            while (true)
            {
                //���ӵ����ض���
                MessageQueue myQueue = new MessageQueue(path);
                myQueue.Formatter = new BinaryMessageFormatter();
                SendMailCommon sendMail = new SendMailCommon();
                try
                {
                    //�Ӷ����н�����Ϣ
                    Message myMessage = myQueue.Receive();
                    MailBodyAndSetting context = (MailBodyAndSetting)myMessage.Body; //��ȡ��Ϣ������
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