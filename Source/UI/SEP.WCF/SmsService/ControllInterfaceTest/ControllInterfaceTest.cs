//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ControllInterfaceTest.cs
// 创建者: 倪豪
// 创建日期: 2008-12-2
// 概述: 测试系统级接口ISmsControllerContract中控制短信机的部分
//       运行该测试需要将 SmsService运行起来，并将此测试的config
//       文件配置完毕才可
//       如果看到
//         由于目标机器积极拒绝，无法连接。 127.0.0.1:8888. 
//         ----> System.Net.WebException : 无法连接到远程服务器
//       就是没有运行 SmsService
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
        /// 测试机器连接是否正常
        /// 如果测试失败，请检查config配置的PortStatusConfig与BautRateConfig的配置
        /// 默认为COM2口，波特率19200
        /// </summary>
        [Test]
        public void Test1()
        {
            theController.StartConnection();
            Assert.IsTrue(theController.GetPortStatus());
            theController.StopConnection();
            Assert.IsFalse(theController.GetPortStatus());
        }

        [Test, Description("测试机器是否正常，包括基本AT命令，机器信号，设置机器中文短信发送方式")]
        public void Test2()
        {
            theController.StartConnection();
            Assert.IsTrue(theController.TestMachine());
            theController.StopConnection();
        }

        [Test, Description("测试At命令")]
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

        [Test, Description("手动发送与接受短信")]
        public void Test4()
        {
            theController.StartConnection();
            //将Sim所有短信读取到内存中
            theController.ReceiveAllMessage();
            //清空所有接受到的短信
            theController.ClearAllReceivedMessages();
            //发送短信
            theController.SendAMessage(new SendMessageDataModel(-1, "10086", "YECX","testDll"));
            Thread.Sleep(15000);
            theController.ReceiveAllMessage();
            theController.StopConnection();
            //应该收到10086的1条回复短信
            Assert.AreEqual(1, theController.GetLogsForReceiveMessages().Count);
        }

        [Test, Description("查询手机余额")]
        public void Test5()
        {
            theController.StartConnection();
            theController.ReceiveAllMessage();
            theController.ClearAllReceivedMessages();
            //发送查询余额的短信
            theController.SendSearchMoneyMessage();
            Thread.Sleep(15000);
            theController.ReceiveAllMessage();
            theController.StopConnection();
            //输出内容到控制台
            Assert.AreEqual(1,theController.GetLogsForReceiveMessages().Count);
            Console.WriteLine(theController.GetLogsForReceiveMessages()[0].Content);
        }

        /// <summary>
        /// 如果需要测试内部关口,请查看ClientBroadcast类，替换真实实现
        /// </summary>
        [Test, Description("测试自动短信收发")]
        public void Test6()
        {
            //清空Log数据
            theController.ClearAllReceivedMessages();
            theController.ClearAllSendMessages();

            //该短信无法发送成功
            theController.DelieveAMessage(new SendMessageDataModel(-1,"10086","余额查询","testDll"));
            //打开端口，开始收发短信线程
            theController.StartConnection();
            theController.StartTheSmsThread();
            Assert.IsTrue(theController.GetWorkThreadStatus());
            //在中途加入可以发送成功的一条短信
            Thread.Sleep(3000);
            theController.DelieveAMessage(new SendMessageDataModel(-1, "10086", "YECX", "testDll"));
            Thread.Sleep(60000);
            theController.StopTheSmsThread();
            theController.StopConnection();
            //-----验证短信Logs
            Assert.AreEqual(1, theController.GetLogsForSuccesssSendMessages().Count);
            Assert.AreEqual(2, theController.GetLogsForWaitSendMessages().Count);
            Assert.AreEqual(1, theController.GetLogsForReceiveMessages().Count);
            Assert.AreEqual(1, theController.GetLogsForFailedSendMessages().Count);
        }

        [Test, Description("测试发送长短信会分割成多条短信发送,该测试偶尔会失败，主要是10086连续发送命令会有不定因素产生，具体情况咨询10086")]
        public void Test7()
        {
            theController.StartConnection();
            //将Sim所有短信读取到内存中
            theController.ReceiveAllMessage();
            //清空内存保留的所有短信
            theController.ClearAllReceivedMessages();
            //发送短信
            //共计140字符，应该会分割成为2条短信发送
            Assert.IsTrue(theController.SendAMessage(new SendMessageDataModel(-1, "10086", "YECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXAYECXA","testDll")));
            Thread.Sleep(40000);
            theController.ReceiveAllMessage();
            theController.StopConnection();
            //将收到2条回复
            Assert.AreEqual(2, theController.GetLogsForReceiveMessages().Count);
        }
    }
}
