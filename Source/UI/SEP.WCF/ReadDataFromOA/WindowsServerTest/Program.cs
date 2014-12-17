//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights ReadIODataFromAccess.
// �ļ���: WindowsServerTest.cs
// ������: ����
// ��������: 2008-12-01
// ����: ����windows����
// ----------------------------------------------------------------

using System;
using System.ServiceModel;
using ReadDataFromAccessService;

namespace WindowsServerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Type serviceType = typeof(ReadIODataFromAccess);

            using (ServiceHost host = new ServiceHost(serviceType))
            {
                host.Open();

                Console.WriteLine("The service is aviliable");
                Console.WriteLine(host.BaseAddresses[0]);
                Console.ReadKey(true);

                host.Close();
            }
        }
    }
}
