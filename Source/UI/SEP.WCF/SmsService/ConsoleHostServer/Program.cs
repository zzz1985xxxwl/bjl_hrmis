//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: Program.cs
// 创建者: 倪豪
// 创建日期: 2008-11-21
// 概述: 使用Console来承载短信服务
//       用于调试，发布出来承载在WindowsServer
// ----------------------------------------------------------------
using System;
using System.ServiceModel;
using ProvideSmsServerServices;

namespace ConsoleHostSmsServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SmsControllerServiceType controlType = new SmsControllerServiceType();
                controlType.BeforeHostStart();

                ServiceHost _SmsServiceTypeHost = new ServiceHost(typeof (SmsServerServiceType));
                _SmsServiceTypeHost.Open();

                ServiceHost _SmsControllerServiceType = new ServiceHost(typeof (SmsControllerServiceType));
                _SmsControllerServiceType.Open();

                Console.ReadKey(true);

                _SmsServiceTypeHost.Close();
                _SmsControllerServiceType.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}