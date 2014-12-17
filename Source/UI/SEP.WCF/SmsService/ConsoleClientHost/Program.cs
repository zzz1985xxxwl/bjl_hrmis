using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SmsClientServices;
using SmsDataContract;

namespace ConsoleClientHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost _SmsClientTypeHost = new ServiceHost(typeof(SmsClientServicesType));
            _SmsClientTypeHost.Open();

            ISmsServiceContract proxy = new ChannelFactory<ISmsServiceContract>("BasicHttpBinding_IDerivativesCalculator1").CreateChannel();
            proxy.RegisterSmsClient(_SmsClientTypeHost.BaseAddresses[0].ToString(), "nihaoIsPermitted");
            proxy.SendOneMessage(new SendMessageDataModel(-1, "13816428383", "hello world", "nihaoIsPermitted"));
            ((IChannel)proxy).Close();

            Console.ReadKey(true);
            _SmsClientTypeHost.Close();
        }
    }
}
