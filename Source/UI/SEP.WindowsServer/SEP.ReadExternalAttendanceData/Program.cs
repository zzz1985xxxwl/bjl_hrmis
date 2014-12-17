using System.ServiceProcess;
using System.Windows.Forms;
using SEP.Model.Utility;

namespace SEP.ReadExternalAttendanceData
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase ServicesToRun = new SystemReadDataServer();

            //读取Company.config路径
            CompanyConfig.FileName = Application.StartupPath;
            ServiceBase.Run(ServicesToRun);
        }
    }
}