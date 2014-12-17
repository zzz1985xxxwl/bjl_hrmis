using System.ComponentModel;
using System.Configuration.Install;

namespace SEP.ReadExternalAttendanceData
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