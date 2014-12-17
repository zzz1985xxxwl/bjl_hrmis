using System.ServiceProcess;

namespace ReadDataFromAccessWindowsService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase ServicesToRun = new ReadDataHostService();

            ServiceBase.Run(ServicesToRun);
        }
    }
}