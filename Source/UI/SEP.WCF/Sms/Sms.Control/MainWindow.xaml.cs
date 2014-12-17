using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Sms.Bll;
using Sms.Bll.Mail;
using Sms.Entity;

namespace Sms.Control
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer smsTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            smsTimer.Tick += new EventHandler(smsTimer_Tick);
            smsTimer.Interval = TimeSpan.FromSeconds(30);   //设置刷新的间隔时间

             mailThread = new Thread(new ThreadStart(ReadAndSendMail));
        }

        #region 邮件

        private Thread mailThread;
        SendMail _sendMail = new SendMail();


        void ReadAndSendMail()
        {
            string path = (".\\Private$\\Mail");
            if (!MessageQueue.Exists(path))
            {
                MessageQueue.Create(path);
            }
            //连接到本地队列
            MessageQueue myQueue = new MessageQueue(path);
            myQueue.Formatter = new BinaryMessageFormatter();
           
            try
            {
                //从队列中接收消息
                Message myMessage = myQueue.Receive();
                MailBodyAndSetting context = (MailBodyAndSetting)myMessage.Body; //获取消息的内容
                _sendMail.Send(context.Body);
            }
            catch (Exception ex)
            {
                txtMailError.Text += ex.Message + Environment.NewLine;
            }
        }

        private void btnMail_Click(object sender, RoutedEventArgs e)
        {
            if (btnMail.Content.ToString().Contains("启动"))
            {
                mailThread.Start();
                btnMail.Content = "停止邮件服务";

            }
            else
            {
                mailThread.Abort();
                btnMail.Content = "启动邮件服务";
            }
        }
        private void btnSendMail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailBody mailModel = new MailBody();
                mailModel.MailTo = new List<string>();
                mailModel.MailTo.Add(txtMailTo.Text);
                mailModel.Subject = txtMailSubject.Text;
                mailModel.Body = txtMailBody.Text;
                mailModel.IsAsync = false;
                mailModel.IsHtmlBody = true;
                AddMail a = new AddMail();
                a.Send(mailModel, new MailSettings("", "", "", "", "", "", true));
                MessageBox.Show("ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            // _sendMail.Send(mailModel);
        }
        #endregion


        #region 短信
        void smsTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour <= 22)
            {
                ReceiveMessagesBll.ClearBlockMessage();
            }
        }
        private void btnSms_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                TheMachineController.StartConnection();
                TheMachineController.StartTheSmsThread();
                smsTimer.Start();
                btnSms.Content = "已启动";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStopSms_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TheMachineController.StopTheSmsThread();
                TheMachineController.StopConnection();
                smsTimer.Stop();
                btnSms.Content = "启动短信服务";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendSms_Click(object sender, RoutedEventArgs e)
        {
            TheMachineController.SendAMessage(new SendMessagesEntity()
            {
                SendToNumber = txtNumber.Text,
                Content = txtContent.Text
            });

        }

        #endregion




    }
}
