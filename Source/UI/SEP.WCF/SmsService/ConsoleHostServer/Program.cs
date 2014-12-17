//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: Program.cs
// ������: �ߺ�
// ��������: 2008-11-21
// ����: ʹ��Console�����ض��ŷ���
//       ���ڵ��ԣ���������������WindowsServer
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