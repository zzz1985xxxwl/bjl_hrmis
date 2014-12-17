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
            //String CpuSum = Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");// CPU个数：
            //String CpuType = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");// CPU类型：
            ////String ServerSoft = Request.ServerVariables["SERVER_SOFTWARE"]; // 信息服务软件：
            //String MachineName = Server.MachineName;// 服务器名
            //String ServerName = Request.ServerVariables["SERVER_NAME"];// 服务器域名
            //String ServerPath = Request.ServerVariables["APPL_PHYSICAL_PATH"];// 虚拟服务绝对路径
            //String ServerNet = ".NET CLR " + Environment.Version.ToString(); // DotNET 版本
            //String ServerArea = (DateTime.Now - DateTime.UtcNow).TotalHours > 0 ? "+" + (DateTime.Now - DateTime.UtcNow).TotalHours.ToString() : (DateTime.Now - DateTime.UtcNow).TotalHours.ToString();// 服务器时区
            //String ServerTimeOut = Server.ScriptTimeout.ToString(); // 脚本超时时间
            //String ServerStart = ((Double)System.Environment.TickCount / 3600000).ToString("N2");// 开机运行时长
            //// AspNet CPU时间
            //String ServerSessions = Session.Contents.Count.ToString();// Session总数
            //String ServerApp = Application.Contents.Count.ToString(); // Application总数
            ////String ServerCache = Cache.Count.ToString(); //应用程序缓存总数
            //// 应用程序占用内存
            ////  String ServerFso = Check("Scripting.FileSystemObject");                // FSO 文本文件读写
            ////String ServerTimeOut = Server.ScriptTimeout.ToString() + "毫秒"; // 本页执行时间  
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
