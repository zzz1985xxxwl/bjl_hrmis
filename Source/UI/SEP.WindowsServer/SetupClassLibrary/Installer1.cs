using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Collections;
using System.ServiceProcess;
using System.Windows.Forms;

namespace SetupClassLibrary
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        private string autoRemindServerDir;
        private string readDataServerDir;
        private string autoremind;
        private string readdata;
        private readonly string autoRemindServerName;
        private readonly string readDataServerName;

        public Installer1()
        {
            InitializeComponent();
            autoRemindServerName = "SEP Auto Remind Server";
            readDataServerName = "SEP ReadData Server";
        }

        #region Install  从这里开始启动安装 Install  从这里开始启动安装

        private static bool ServiceIsExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName == serviceName)
                {
                    return true;
                }
            }
            return false;
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            autoRemindServerDir = Context.Parameters["targetdir"] + "SEP.AutoRemindServer.exe";
            readDataServerDir = Context.Parameters["targetdir"] + "SEP.ReadExternalAttendanceData.exe";
            autoremind = Context.Parameters["autoremind"];
            readdata = Context.Parameters["readdata"];
            if (autoremind == "1")
            {
                InstallService(stateSaver, autoRemindServerName, autoRemindServerDir);
            }
            if (readdata == "1")
            {
                InstallService(stateSaver, readDataServerName, readDataServerDir);
            }
        }

        private static void InstallService(IDictionary stateSaver, string serverName, string serverDir)
        {
            try
            {
                ServiceController service = new ServiceController(serverName);
                if (ServiceIsExisted(serverName))
                {
                    UnInstallService(serverDir);
                }
                //Install Service
                AssemblyInstaller myAssemblyInstaller = new AssemblyInstaller();
                myAssemblyInstaller.UseNewContext = true;
                myAssemblyInstaller.Path = serverDir;
                myAssemblyInstaller.Install(stateSaver);
                myAssemblyInstaller.Commit(stateSaver);
                myAssemblyInstaller.Dispose();
                //--Start Service
                service.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("installServiceError\n" + ex.Message);
            }
        }

        #endregion

        #region  Uninstall 删除 Uninstall 删除

        private static void UnInstallService(string serverDir)
        {
            //UnInstall Service
            AssemblyInstaller myAssemblyInstaller = new AssemblyInstaller();
            myAssemblyInstaller.UseNewContext = true;
            myAssemblyInstaller.Path = serverDir;
            myAssemblyInstaller.Uninstall(null);
            myAssemblyInstaller.Dispose();
        }

        public override void Uninstall(IDictionary savedState)
        {
            try
            {
                autoRemindServerDir = Context.Parameters["targetdir"] + "SEP.AutoRemindServer.exe";
                readDataServerDir = Context.Parameters["targetdir"] + "SEP.ReadExternalAttendanceData.exe";

                if (ServiceIsExisted(autoRemindServerName))
                {
                    UnInstallService(autoRemindServerDir);
                }
                if (ServiceIsExisted(readDataServerName))
                {
                    UnInstallService(readDataServerDir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("unInstallServiceError\n" + ex.Message);
            }
            //Process p = new Process();
            //p.StartInfo.FileName = "cmd.exe";
            //p.StartInfo.UseShellExecute = false;
            //p.StartInfo.RedirectStandardInput = true;
            //p.StartInfo.RedirectStandardOutput = true;
            //p.StartInfo.RedirectStandardError = true;
            //p.StartInfo.CreateNoWindow = true;

            //try
            //{
            //    p.Start();
            //    p.StandardInput.Write("cd " + physicaldir);
            //    p.StandardInput.Write(p.StandardInput.NewLine);
            //    p.StandardInput.Write("InstallUtil SEP.AutoRemindServer.exe -u");
            //    p.StandardInput.Write(p.StandardInput.NewLine);
            //    p.StandardInput.WriteLine("exit");

            //    p.StandardOutput.ReadToEnd();
            //    p.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}     
            //添加自定义的卸载代码
            if (savedState == null)
            {
                MessageBox.Show("未能卸载！");
            }

            else
            {
                base.Uninstall(savedState);
            }

        }

        #endregion
    }
}