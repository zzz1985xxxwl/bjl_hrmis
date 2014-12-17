//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights ReadIODataFromAccess.
// 文件名: WindowsServerTest.cs
// 创建者: 刘丹
// 创建日期: 2008-12-01
// 概述: 测试windows服务
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
