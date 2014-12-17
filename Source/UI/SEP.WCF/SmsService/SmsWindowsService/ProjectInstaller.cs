using System.ComponentModel;
using System.Configuration.Install;

namespace WindowsServerHostSmsServer
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}