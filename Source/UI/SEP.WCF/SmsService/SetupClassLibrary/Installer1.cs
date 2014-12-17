using System;
using System.ComponentModel;
using System.DirectoryServices;
using System.Configuration.Install;
using System.Collections;
using System.Windows.Forms;
using System.ServiceProcess;
namespace SetupClassLibrary
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        private string smsServerDir;
        private readonly string smsServerName;

        private string iis;

        private string physicaldir;

        private string virtualdir;

        public static string VirDirSchemaName = "IIsWebVirtualDir";
        public Installer1()
        {
            InitializeComponent();
            smsServerName = "SEP SMS Server";
        }

        #region 创建虚拟目录 创建虚拟目录

        private void CreateVirtualDir()
        {
            try
            {
                DirectoryEntry IISSchema;
                DirectoryEntry IISAdmin;
                DirectoryEntry VDir;
                bool IISUnderNT;


                //    
                // 确定IIS版本  
                //           
                IISSchema = new DirectoryEntry("IIS://" + iis + "/Schema/AppIsolated");
                if (IISSchema.Properties["Syntax"].Value.ToString().ToUpper() == "BOOLEAN")
                    IISUnderNT = true;
                else
                    IISUnderNT = false;
                IISSchema.Dispose();

                //         
                // Get the admin object          
                // 获得管理权限        
                //            
                IISAdmin = new DirectoryEntry("IIS://" + iis + "/W3SVC/" + 1 + "/Root");

                //           
                // If we're not creating a root directory         
                // 如果我们不能创建一个根目录           
                //               
                //               
                // If the virtual directory already exists then delete it             
                // 如果虚拟目录已经存在则删除     
                //  

                foreach (DirectoryEntry v in IISAdmin.Children)
                {
                    if (v.Name == virtualdir)
                    {
                        // Delete the specified virtual directory if it already exists   
                        try
                        {
                            IISAdmin.Invoke("Delete", new string[] { v.SchemaClassName, virtualdir });
                            IISAdmin.CommitChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }

                //           
                // Create the virtual directory        
                // 创建一个虚拟目录        

                //          
                VDir = IISAdmin.Children.Add(virtualdir, "IIsWebVirtualDir");
                //          
                // Make it a web application       
                // 创建一个web应用         
                // 

                if (IISUnderNT)
                {
                    VDir.Invoke("AppCreate", false);
                }
                else
                {
                    VDir.Invoke("AppCreate", true);
                }
                //           
                // Setup the VDir       
                // 安装虚拟目录       
                //AppFriendlyName,propertyName,, bool chkRead,bool chkWrite, bool chkExecute, bool chkScript,, true, false, false, true 
                VDir.Properties["AppFriendlyName"][0] = virtualdir; //应用程序名称 
                VDir.Properties["AccessRead"][0] = true; //设置读取权限 
                VDir.Properties["AccessExecute"][0] = false;
                VDir.Properties["AccessWrite"][0] = false;
                VDir.Properties["AccessScript"][0] = true; //执行权限[純腳本] 
                //VDir.Properties["AuthNTLM"][0] = chkAuth; 
                VDir.Properties["EnableDefaultDoc"][0] = true;
                VDir.Properties["EnableDirBrowsing"][0] = false;
                VDir.Properties["DefaultDoc"][0] = "Login.aspx"; //设置默认文档,多值情况下中间用逗号分割 
                VDir.Properties["Path"][0] = physicaldir;
                VDir.Properties["AuthFlags"][0] = 0x00000004 | 0x00000001;
                //        
                // NT doesn't support this property      
                // NT格式不支持这特性       
                //          
                if (!IISUnderNT)
                {
                    VDir.Properties["AspEnableParentPaths"][0] = true;
                }

                //    
                // Set the changes        
                // 设置改变          
                //           
                VDir.CommitChanges();

                //启动aspnet_iis.exe程序 
                DirectoryEntry AD = VDir;
                string aspnetRegIIS20 =
                    System.IO.Path.Combine(Environment.GetEnvironmentVariable("windir"),
                                           @"Microsoft.NET\Framework\v2.0.50727\aspnet_regiis.exe");
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo();
                p.StartInfo.FileName = aspnetRegIIS20;
                string arg = AD.Path.ToUpper();
                arg = arg.Substring(arg.IndexOf("W3SVC"));
                p.StartInfo.Arguments = "-s  " + arg;
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.Start();
                p.WaitForExit();
                string errors = p.StandardError.ReadToEnd();
                if (errors != string.Empty)
                    MessageBox.Show(errors);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion
        #region Windows服务

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

        private static void UnInstallService(string serverDir)
        {
            //UnInstall Service
            AssemblyInstaller myAssemblyInstaller = new AssemblyInstaller();
            myAssemblyInstaller.UseNewContext = true;
            myAssemblyInstaller.Path = serverDir;
            myAssemblyInstaller.Uninstall(null);
            myAssemblyInstaller.Dispose();
        }

        #endregion 

        #region Install  从这里开始启动安装 Install  从这里开始启动安装

        public override void Install(IDictionary stateSaver)
        {

            base.Install(stateSaver);

            physicaldir = Context.Parameters["targetdir"] + @"WebControlClient\";
            virtualdir = Context.Parameters["virtualdir"];

            //dbname = this.Context.Parameters["dbname"].ToString();

            //dbserver = this.Context.Parameters["dbserver"].ToString();

            //user = this.Context.Parameters["user"].ToString();

            //pwd = this.Context.Parameters["pwd"].ToString();

            iis = Context.Parameters["iis"];

            // 添加网站
            CreateVirtualDir();
            // 添加服务
            smsServerDir = Context.Parameters["targetdir"] + @"WindowsServerHostSmsServer\" + "WindowsServerHostSmsServer.exe";
            InstallService(stateSaver, smsServerName, smsServerDir);

            // 修改web.config
            //WriteWebConfig();     

        }

        #endregion

        #region  Uninstall 删除 Uninstall 删除

        public override void Uninstall(IDictionary savedState)
        {
            try
            {
                smsServerDir = Context.Parameters["targetdir"] + @"WindowsServerHostSmsServer\" + "WindowsServerHostSmsServer.exe";

                if (ServiceIsExisted(smsServerName))
                {
                    UnInstallService(smsServerDir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("unInstallServiceError\n" + ex.Message);
            }

            //添加自定义的卸载代码
            if (savedState == null)
            {
                throw new ApplicationException("未能卸载！");
            }

            else
            {
                base.Uninstall(savedState);
            }
        }

        #endregion
    }
}