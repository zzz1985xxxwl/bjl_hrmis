using System;
using SmsClientServices;
using SmsDataContract;

namespace WebDataClient
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String serverOS = Environment.OSVersion.ToString();
            //String CpuSum = Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");// CPU������
            //String CpuType = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");// CPU���ͣ�
            ////String ServerSoft = Request.ServerVariables["SERVER_SOFTWARE"]; // ��Ϣ���������
            //String MachineName = Server.MachineName;// ��������
            //String ServerName = Request.ServerVariables["SERVER_NAME"];// ����������
            //String ServerPath = Request.ServerVariables["APPL_PHYSICAL_PATH"];// ����������·��
            //String ServerNet = ".NET CLR " + Environment.Version.ToString(); // DotNET �汾
            //String ServerArea = (DateTime.Now - DateTime.UtcNow).TotalHours > 0 ? "+" + (DateTime.Now - DateTime.UtcNow).TotalHours.ToString() : (DateTime.Now - DateTime.UtcNow).TotalHours.ToString();// ������ʱ��
            //String ServerTimeOut = Server.ScriptTimeout.ToString(); // �ű���ʱʱ��
            //String ServerStart = ((Double)System.Environment.TickCount / 3600000).ToString("N2");// ��������ʱ��
            //// AspNet CPUʱ��
            //String ServerSessions = Session.Contents.Count.ToString();// Session����
            //String ServerApp = Application.Contents.Count.ToString(); // Application����
            ////String ServerCache = Cache.Count.ToString(); //Ӧ�ó��򻺴�����
            //// Ӧ�ó���ռ���ڴ�
            ////  String ServerFso = Check("Scripting.FileSystemObject");                // FSO �ı��ļ���д
            ////String ServerTimeOut = Server.ScriptTimeout.ToString() + "����"; // ��ҳִ��ʱ��  
            //string s = HostingEnvironment.ApplicationVirtualPath;

            SmsClientProcessCenter.ReActiveTheService();
            this.Label1.Text = SmsClientProcessCenter.GetSmsServiceEnable.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SmsServiceProxy.SendAMessage(new SendMessageDataModel(-888, "13761760956", "hai",SmsClientProcessCenter._HrmisId));
        }
    }
}
