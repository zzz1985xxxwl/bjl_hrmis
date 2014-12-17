using System;
using System.Collections.Generic;
using System.Text;
using ComService.ServiceContracts.Impls;
using System.ServiceModel;

namespace ConsoleServer
{
    class Program
    {
        static void Main()
        {
            Type serviceType = typeof(ContactServices);

            using (ServiceHost host = new ServiceHost(serviceType))
            {
                host.Open();

                Console.WriteLine("Contact Services Star");
                Console.WriteLine(host.BaseAddresses[0]);
                Console.ReadKey(true);

                host.Close();
            }
        }
    }
}
