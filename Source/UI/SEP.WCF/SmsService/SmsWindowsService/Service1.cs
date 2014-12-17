using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceProcess;
using Logs;
using ProvideSmsServerServices;

namespace WindowsServerHostSmsServer
{
    public partial class Service1 : ServiceBase
    {
        private ServiceHost _SmsServiceTypeHost;
        private ServiceHost _SmsControllerServiceTypeHost;

        private static readonly string _EnableStartHour = ConfigurationManager.AppSettings["EnableStartHour"];
        private static readonly string _EnableEndHour = ConfigurationManager.AppSettings["EnableEndHour"];

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            SmsControllerServiceType controlType = new SmsControllerServiceType();
            controlType.BeforeHostStart();

            try
            {
                _SmsServiceTypeHost = new ServiceHost(typeof (SmsServerServiceType));
                _SmsServiceTypeHost.Open();

                _SmsControllerServiceTypeHost = new ServiceHost(typeof (SmsControllerServiceType));
                _SmsControllerServiceTypeHost.Open();
            }
            catch(Exception e)
            {
                GetLogInstance.GetInstance.DoWriteEventLog(string.Format("开启整个短信服务失败，原因是：{0}", e.Message), EventType.Error);
            }
        }

        protected override void OnStop()
        {
            SmsControllerServiceType controlType = new SmsControllerServiceType();
            controlType.BeforeHostStopped();
            try
            {
                _SmsServiceTypeHost.Close();
                _SmsControllerServiceTypeHost.Close();
            }
            catch(Exception e)
            {
                GetLogInstance.GetInstance.DoWriteEventLog(string.Format("关闭整个短信服务失败，原因是：{0}", e.Message), EventType.Error);
            }
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            int theStartHour;
            if (!int.TryParse(_EnableStartHour, out theStartHour))
            {
                theStartHour = 8;
            }

            int theEndHour;
            if (!int.TryParse(_EnableEndHour, out theEndHour))
            {
                theEndHour = 22;
            }

            if (DateTime.Now.Hour >= theStartHour && DateTime.Now.Hour <= theEndHour)
            {
                new SmsControllerServiceType().ClearBlockMessages();
                GetLogInstance.GetInstance.DoWriteEventLog("重新激活业务短信对象事件被触发", EventType.Information);
            }
        }
    }
}