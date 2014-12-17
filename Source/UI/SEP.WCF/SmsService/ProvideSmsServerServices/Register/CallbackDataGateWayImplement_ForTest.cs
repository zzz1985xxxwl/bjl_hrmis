//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CallbackDataGateWayImplement_ForTest.cs
// 创建者: 倪豪
// 创建日期: 2008-12-2
// 概述: 这个不合寻常的类的出现的原因如下：
//       由于服务运行在单独的进程中，在测试过程中，由于测试进程与
//       服务进程相互独立，所以无法以通过替换内部接口实现的方式来
//       做测试，只能以修改代码方式，那么最终的原因在于，这部分是
//       需要测试的，但是由于系统级接口就产生了耦合，所以无法分离
//       实现，这部分的测试可以选择作为内部功能性测试，但是最好的
//       方式是分离系统级接口，将短信功能于注册功能分离
// ----------------------------------------------------------------
using System;
using System.IO;
using ProvideSmsServerServices.BoardCast;
using SmsDataContract;

namespace ProvideSmsServerServices.Register
{
    public class CallbackDataGateWayImplement_ForTest : ICallbackDataGateWay
    {

        #region ICallbackDataGateWay 成员

        public void OnReceivedMessages(System.Collections.Generic.List<ReceiveMessageDataModel> messagesTobeSended)
        {
            foreach (ReceiveMessageDataModel aMessage in messagesTobeSended)
            {
                WriteMessage(string.Format("收到消息！\r发送人:{0}\r时间是:{1}\r内容是:{2}", aMessage.TheNumber, aMessage.ReceivedTime, aMessage.Content));
            }
        }

        public void OnSendFailedMessages(SendMessageDataModel failedMessage)
        {
            WriteMessage(string.Format("消息发送失败\r发给:{0}\r内容是:{1}\r在系统中的编号是:{2}", failedMessage.SendNumber, failedMessage.Content, failedMessage.SystemSmsId));
        }

        public void OnStopServer()
        {
            WriteMessage("TheServer need to Stop" + DateTime.Now);
        }

        private void WriteMessage(string message)
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"C:\SMS_Test.txt", true);
                sw.WriteLine(message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        #endregion
    }
}