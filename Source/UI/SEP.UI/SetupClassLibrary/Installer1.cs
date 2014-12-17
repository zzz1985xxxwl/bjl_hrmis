using System;
using System.ComponentModel;
using System.DirectoryServices;
using System.Configuration.Install;
using System.Collections;
using System.Windows.Forms;
namespace SetupClassLibrary
{


    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        //������˽�г�Ա����Ӧ��װ��������յ����û�����
        //private string dbname;

        //private string dbserver;

        //private string user;

        //private string pwd;

        private string iis;

        private string physicaldir;

        private string virtualdir;

        public static string VirDirSchemaName = "IIsWebVirtualDir";


        public Installer1()
        {
            InitializeComponent();
        }

        #region WriteWebConfig �޸�web.config���������ݿ���ַ��� WriteWebConfig �޸�web.config���������ݿ���ַ���
        //private void WriteWebConfig()
        //{
        //   //���������ļ�
        //    System.IO.FileInfo FileInfo = new System.IO.FileInfo(this.Context.Parameters["targetdir"] + "/web.config");
        //    MessageBox.Show(this.Context.Parameters["targetdir"] + "web.config");
        //    if (!FileInfo.Exists)
        //    {
        //        throw new InstallException("ȱ�������ļ� :" + this.Context.Parameters["targetdir"] + "/web.config");
        //    }
        //    System.Xml.XmlDocument xmlDocument  = new System.Xml.XmlDocument();
        //    xmlDocument.Load(FileInfo.FullName);

        //   //�޸������ַ���
        //    foreach (System.Xml.XmlNode Node in xmlDocument["configuration"]["connectionStrings"])
        //    {
        //        if (Node.Name == "add")
        //        {
        //             if (Node.Attributes.GetNamedItem("name").Value == "myDataBase")
        //            {
        //                Node.Attributes.GetNamedItem( "connectionString").Value = String.Format("Database={0};Server={1};Uid={2};Pwd={3};", dbname, dbserver, user, pwd);
                       
        //            } 

        //        } 
        //    }
                   
        //    xmlDocument.Save(FileInfo.FullName);

        //}

        #endregion

        #region ��������Ŀ¼ ��������Ŀ¼

        private void CreateVirtualDir()
        {
            try
            {
                DirectoryEntry IISSchema;
                DirectoryEntry IISAdmin;
                DirectoryEntry VDir;
                bool IISUnderNT;


                //    
                // ȷ��IIS�汾  
                //           
                IISSchema = new DirectoryEntry("IIS://" + iis + "/Schema/AppIsolated");
                if (IISSchema.Properties["Syntax"].Value.ToString().ToUpper() == "BOOLEAN")
                    IISUnderNT = true;
                else
                    IISUnderNT = false;
                IISSchema.Dispose();

                //         
                // Get the admin object          
                // ��ù���Ȩ��        
                //            
                IISAdmin = new DirectoryEntry("IIS://" + iis + "/W3SVC/" + 1 + "/Root");

                //           
                // If we're not creating a root directory         
                // ������ǲ��ܴ���һ����Ŀ¼           
                //               
                //               
                // If the virtual directory already exists then delete it             
                // �������Ŀ¼�Ѿ�������ɾ��     
                //  

                foreach (DirectoryEntry v in IISAdmin.Children)
                {
                    if (v.Name == virtualdir)
                    {
                        // Delete the specified virtual directory if it already exists   
                        try
                        {
                            IISAdmin.Invoke("Delete", new string[] {v.SchemaClassName, virtualdir});
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
                // ����һ������Ŀ¼        

                //          
                VDir = IISAdmin.Children.Add(virtualdir, "IIsWebVirtualDir");
                //          
                // Make it a web application       
                // ����һ��webӦ��         
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
                // ��װ����Ŀ¼       
                //AppFriendlyName,propertyName,, bool chkRead,bool chkWrite, bool chkExecute, bool chkScript,, true, false, false, true 
                VDir.Properties["AppFriendlyName"][0] = virtualdir; //Ӧ�ó������� 
                VDir.Properties["AccessRead"][0] = true; //���ö�ȡȨ�� 
                VDir.Properties["AccessExecute"][0] = false;
                VDir.Properties["AccessWrite"][0] = false;
                VDir.Properties["AccessScript"][0] = true; //ִ��Ȩ��[���_��] 
                //VDir.Properties["AuthNTLM"][0] = chkAuth; 
                VDir.Properties["EnableDefaultDoc"][0] = true;
                VDir.Properties["EnableDirBrowsing"][0] = false;
                VDir.Properties["DefaultDoc"][0] = "Login.aspx"; //����Ĭ���ĵ�,��ֵ������м��ö��ŷָ� 
                VDir.Properties["Path"][0] = physicaldir;
                VDir.Properties["AuthFlags"][0] = 0x00000004 | 0x00000001;
                //        
                // NT doesn't support this property      
                // NT��ʽ��֧��������       
                //          
                if (!IISUnderNT)
                {
                    VDir.Properties["AspEnableParentPaths"][0] = true;
                }

                //    
                // Set the changes        
                // ���øı�          
                //           
                VDir.CommitChanges();

                //����aspnet_iis.exe���� 
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

        #region Install  �����￪ʼ������װ Install  �����￪ʼ������װ

        public override void Install(IDictionary stateSaver)
        {

            base.Install(stateSaver);

            physicaldir = Context.Parameters["targetdir"] + @"web\";
            virtualdir = Context.Parameters["virtualdir"];

            //dbname = this.Context.Parameters["dbname"].ToString();

            //dbserver = this.Context.Parameters["dbserver"].ToString();

            //user = this.Context.Parameters["user"].ToString();

            //pwd = this.Context.Parameters["pwd"].ToString();

            iis = Context.Parameters["iis"];

            // �����վ
            CreateVirtualDir();

            // �޸�web.config
            //WriteWebConfig();     

        }

        #endregion

        #region  Uninstall ɾ�� Uninstall ɾ��

        public override void Uninstall(IDictionary savedState)
        {
           //����Զ����ж�ش���
            if (savedState == null)
            {
                throw new ApplicationException("δ��ж�أ�");
            }

            else
            {
                base.Uninstall(savedState);
            }

        }

        #endregion

    }
} 