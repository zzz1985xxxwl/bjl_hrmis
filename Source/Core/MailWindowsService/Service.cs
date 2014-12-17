using System;
using System.Messaging;
using System.ServiceProcess;
using System.Threading;
using Mail;

namespace MailWindowsService
{
    public partial class Service : ServiceBase
    {
        private Thread td;

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            td = new Thread(ReceiveMessage);
            td.Start();
        }

        protected override void OnStop()
        {
            td.Abort();
        }

        /// <summary>
        /// 连接消息队列并从队列中接收消息
        /// </summary>
        private static void ReceiveMessage()
        {
            string path = (".\\Private$\\MailBack");
            if (!MessageQueue.Exists(path))
            {
                MessageQueue.Create(path);
            }
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
                    MailBodyAndSetting context = (MailBodyAndSetting) myMessage.Body; //获取消息的内容
                    sendMail.SendMail(context.Body, context.Settings);
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                }
            }
        }
    }
}