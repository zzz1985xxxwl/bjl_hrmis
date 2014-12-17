//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ControllInterfaceTest.cs
// ������: �ߺ�
// ��������: 2008-12-2
// ����: ����ϵͳ���ӿ�ISmsControllerContract�п��ƶ��Ż��Ĳ���
//       ���иò�����Ҫ�� SmsService���������������˲��Ե�config
//       �ļ�������ϲſ�
//       �������
//         ����Ŀ����������ܾ����޷����ӡ� 127.0.0.1:8888. 
//         ----> System.Net.WebException : �޷����ӵ�Զ�̷�����
//       ����û������ SmsService
// ----------------------------------------------------------------
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using NUnit.Framework;
using SmsControlContract;
using SmsDataContract;

namespace ControllInterfaceTest
{
    [TestFixture]
    public class ControllInterfaceTest
    {
        private ISmsControllerContract theController;

        [TestFixtureSetUp]
        public void SetUp()
        {
            theController = new ChannelFactory<ISmsControllerContract>("ISmsControllerContractService").CreateChannel();

            theController.StopTheSmsThread();
            theController.StopConnection();

        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            ((IChannel)theController).Close();
        }

        /// <summary>
        /// ���Ի��������Ƿ�����
        /// �������ʧ�ܣ�����config���õ�PortStatusConfig��BautRateConfig������
        /// Ĭ��ΪCOM2�ڣ�������19200
        /// </summary>
        [Test]
        public void Test1()
        {
            theController.StartConnection();
            Assert.IsTrue(theController.GetPortStatus());
            theController.StopConnection();
            Assert.IsFalse(theController.GetPortStatus());
        }

        [Test, Description("���Ի����Ƿ���������������AT��������źţ����û������Ķ��ŷ��ͷ�ʽ")]
        public void Test2()
        {
            theController.StartConnection();
            Assert.IsTrue(theController.TestMachine());
            theController.StopConnection();
        }

        [Test, Description("����At����")]
        public void Test3()
        {
            theController.StartConnection();
            try
            {
                Assert.AreEqual("AT\r\r\nOK\r\n", theController.SendCommand("AT\r", 5000));
                Assert.AreEqual("AT+CMGF?\r\r\n+CMGF: 0\r\n\r\nOK\r\n", theController.SendCommand("AT+CMGF?\r", 5000));
            }
            finally
            {
                theController.StopConnection();
            }
        }

        [Test, Description("�ֶ���������ܶ���")]
        public void Test4()
        {
            theController.StartConnection();
            //��Sim���ж��Ŷ�ȡ���ڴ���
            theController.ReceiveAllMessage();
            //������н��ܵ��Ķ���
            theController.ClearAllReceivedMessages();
            //���Ͷ���
            theController.SendAMessage(new SendMessageDataModel(-1, "10086", "YECX","testDll"));
            Thread.Sleep(15000);
            theController.ReceiveAllMessage();
            theController.StopConnection();
            //Ӧ���յ�10086��1���ظ�����
            Assert.AreEqual(1, theController.GetLogsForReceiveMessages().Count);
        }

        [Test, Description("��ѯ�ֻ����")]
        public void Test5()
        {
            theController.StartConnection();
            theController.ReceiveAllMessage();
            theController.ClearAllReceivedMessages();
            //���Ͳ�ѯ���Ķ���
            theController.SendSearchMoneyMessage();
            Thread.Sleep(15000);
            theController.ReceiveAllMessage();
            theController.StopConnection();
            //������ݵ�����̨
            Assert.AreEqual(1,theController.GetLogsForReceiveMessages().Count);
            Console.WriteLine(theController.GetLogsForReceiveMessages()[0].Content);
        }

        /// <summary>
        /// �����Ҫ�����ڲ��ؿ�,��鿴ClientBroadcast�࣬�滻��ʵʵ��
        /// </summary>
        [Test, Description("�����Զ������շ�")]
        public void Test6()
        {
            //���Log����
            theController.ClearAllReceivedMessages();
            theController.ClearAllSendMessages();

            //�ö����޷����ͳɹ�
            theController.DelieveAMessage(new SendMessageDataModel(-1,"10086","����ѯ","testDll"));
            //�򿪶˿ڣ���ʼ�շ������߳�
            theController.StartConnection();
            theController.StartTheSmsThread();
            Assert.IsTrue(theController.GetWorkThreadStatus());
            //����;������Է��ͳɹ���һ������
            Thread.Sleep(3000);
            theController.DelieveAMessage(new SendMessageDataModel(-1, "10086", "YECX", "testDll"));
            Thread.Sleep(60000);
            theController.StopTheSmsThread();
            theController.StopConnection();
            //-----��֤����Logs
            Assert.AreEqual(1, theController.GetLogsForSuccesssSendMessages().Count);
            Assert.AreEqual(2, theController.GetLogsForWaitSendMessages().Count);
            Assert.AreEqual(1, theController.GetLogsForReceiveMessages().Count);
            Assert.AreEqual(1, theController.GetLogsForFailedSendMessages().Count);
        }

        [Test, Description("���Է��ͳ����Ż�ָ�ɶ������ŷ���,�ò���ż����ʧ�ܣ���Ҫ��10086��������������в������ز��������������ѯ10086")]
        public void Test7()
        {
            theController.StartConnection();
            //��Sim���ж��Ŷ�ȡ���ڴ���
            theController.ReceiveAllMessage();
            //����ڴ汣�������ж���
            theController.ClearAllReceivedMessages();
            //���Ͷ���
            //����140�ַ���Ӧ�û�ָ��Ϊ2�����ŷ���
            Assert.IsTrue(theController.SendAMessage(new SendMessageDataModel(-1, "10086", "YECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXA","testDll")));
            Thread.Sleep(40000);
            theController.ReceiveAllMessage();
            theController.StopConnection();
            //���յ�2���ظ�
            Assert.AreEqual(2, theController.GetLogsForReceiveMessages().Count);
        }
    }
}
