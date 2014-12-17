using System;
using ReadDataFromAccessService;
using System.ServiceProcess;
using System.ServiceModel;

namespace ReadDataFromAccessWindowsService
{
    partial class ReadDataHostService : ServiceBase
    {
        private ServiceHost host;

        public ReadDataHostService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Type serviceType = typeof (ReadIODataFromAccess);
            host=new ServiceHost(serviceType);
            host.Open();
        }

        protected override void OnStop()
        {
            host.Close();
        }
    }
}
