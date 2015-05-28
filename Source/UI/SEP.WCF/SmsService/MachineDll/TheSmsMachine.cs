//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TheSmsMachine.cs
// 创建者: 倪豪
// 创建日期: 2008-11-21
// 概述: 短信发送接收的核心类
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using Logs;
using MachineDll.Codings;
using SmsDataContract;

namespace MachineDll
{
    public class TheSmsMachine
    {
        //收发短信线程，是否打开
        public bool _WorkNow;
        //定义失败短信重发次数
        public int _TryTimes = 3;
        //定义短信的最大切割条数，大于此数的短信将默认不发送
        public int _CutCount = 3;
        //收到短信提示
        public event EventHandler ReceivedMessage;
        //短信发送失败提示
        public event EventHandler SendMessageFailed;
        //短信片，将一条大短信切割成小短信置于此
        public List<SendMessageDataModel> _SendPieceMessages = new List<SendMessageDataModel>();

        private static  Thread _WorkThread;                                
        private readonly TheSerialPort _TheSerialPort;

        internal TheSmsMachine()
        {
            _TheSerialPort = ObjectSource.GetSerialPort;
        }

        public bool TestMachine()
        {
            //保证串口单线程通信
            StopWorkNow();

            //测试串口并且清空数据串口缓存数据
            if (!_TheSerialPort.PortIsOpen())
            {
                throw new ApplicationException("请确认端口已经连接并且打开，否则无法操作");
            }
            _TheSerialPort.ReadExisting();

            //测试基本命令
            if (!CommandTest("AT\r"))
            {
                return false;
            }
            //测试信号
            if (!CommandTest("AT+CSQ\r"))
            {
                return false;
            }
            //设置短消息发送格式为PDU方式
            if (!CommandTest("AT+CMGF=0\r"))
            {
                return false;
            }
            return true;
        }

        public bool SendSMS(SendMessageDataModel messageToSend)
        {
            //判断短信的字数是否符合规范
            int theLength = messageToSend.Content.Length;
            if (theLength == 0 || theLength > _CutCount*70)
            {
                return false;
            }
            //计算需要发送的短信条数
            int theCount = theLength/70;
            int theYuShu = theLength%70;
            int theAdditionalCount = theYuShu == 0 ? 0 : 1;
            int realCount = theCount + theAdditionalCount;
            //切割短信并发送，其中有任意一小条短信发送不成功将视为整个短信发送不成功
            _SendPieceMessages.Clear();
            for (int index = 0; index < realCount; index++)
            {
                //最后一条与之前的短信应该分别处理
                if (index < realCount - 1)
                {
                    _SendPieceMessages.Add(new SendMessageDataModel(messageToSend.SystemSmsId, messageToSend.SendNumber,
                                                           messageToSend.Content.Substring(70*index, 70),null));
                }
                else
                {
                    _SendPieceMessages.Add(new SendMessageDataModel(messageToSend.SystemSmsId, messageToSend.SendNumber,
                                                           messageToSend.Content.Substring(70 * index), null));
                }
            }

            foreach (SendMessageDataModel aStandMessage in _SendPieceMessages)
            {
                if (!SendStandardSms(aStandMessage))
                {
                    return false;
                }
                //应为多条短信留有间隔发送的缓冲，否则可能发送不成功
                if(_SendPieceMessages.Count >1)
                {
                    Thread.Sleep(2000);
                }
            }
            return true;
        }

        /// <summary>
        /// 发送标准的字符不超过70的短信，若超过70，则无法发送成功
        /// </summary>
        private bool SendStandardSms(SendMessageDataModel standradMessageToSend)
        {
            try
            {
                PduEncoding thePdu = new PduEncoding();
                string decodedSMS = thePdu.smsDecodedsms(standradMessageToSend.SystemNumber, standradMessageToSend.SendNumber, standradMessageToSend.Content);
                //发送第一步 字节数
                _TheSerialPort.SendString(String.Format("AT+CMGS={0}\r", thePdu.nLength));
                _TheSerialPort.ReadTo("> ", 10000);
                //发送第二步 内容
                _TheSerialPort.SendString(String.Format("{0}\x01a", decodedSMS));
                _TheSerialPort.ReadTo("+CMGS:", 12000);
                _TheSerialPort.ReadTo("OK", 2000);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ReceiveAllMessage()
        {
            //_TheSerialPort.ReadExisting();
            //获取所有Sim卡中的短信
            _TheSerialPort.SendString("AT+CMGL=4\r");
            string theResponse;
            try
            {
                theResponse = _TheSerialPort.ReadTo("OK", 20000);
            }
            catch (TimeoutException)
            {
                ReceivedFailedHandler();
                return;
            }
            //一条一条解析短信
            Regex readReg = new Regex("(?:CMGL: (?<index>\\d+),\\d+,,\\d+\r\n(?<sms>\\S+)\r\n)");
            MatchCollection allMaches = readReg.Matches(theResponse);

            int successCount = 0;
            foreach (Match m in allMaches)
            {
                int id;
                string senderNumber;
                string content;
                DateTime senderTime;
                if (!int.TryParse(m.Groups["index"].Value, out id))
                {
                    continue;
                }
                if (!PduDecoding.DecodingMsg(m.Groups["sms"].Value, out senderNumber, out content, out senderTime))
                {
                    DecodingSmsFailHandler(m.Groups["index"].Value, m.Groups["sms"].Value);
                    continue;
                }
                ReceiveMessageDataModel theMessage = new ReceiveMessageDataModel(id, senderNumber, content, senderTime);
                successCount++;
                //删除Sim卡里面的信息
                //AT+CMGL="ALL"
                _TheSerialPort.SendString("AT+CMGD=" + theMessage.Id + "\r");
                try
                {
                    _TheSerialPort.ReadTo("OK", 10000);
                    theMessage.IsCleanMessage = true;
                }
                catch (TimeoutException)
                {
                    DeleteMessageFailedHandler(theMessage);
                }
                finally
                {
                    theMessage.MoveNumber86();
                    ObjectSource.GetMessageBox.EnqueueReceiveMessage(theMessage);
                }
            }
            //若是收到信息，引发异步事件
            if (successCount > 0 && ReceivedMessage != null)
            {
                ReceivedMessage.BeginInvoke(this, new EventArgs(), null, null);
            }
        }

        public string SendCommand(string command, int waitReplayMillionSeconds)
        {
            if (!_TheSerialPort.PortIsOpen())
            {
                throw new ApplicationException("请确认端口已经连接并且打开，否则无法操作");
            }
            if (_WorkThread != null && _WorkThread.IsAlive)
            {
                throw new ApplicationException("请确保已经关闭短信收发线程，保证串口通信始终只有一个线程");
            }
            _TheSerialPort.SendString(command);
            Thread.Sleep(waitReplayMillionSeconds);
            return _TheSerialPort.ReadExisting();
        }

        private bool CommandTest(string command)
        {
            _TheSerialPort.SendString(command);
            try
            {
                _TheSerialPort.ReadTo("OK", 5000);
                return true;
            }
            catch(TimeoutException)
            {
                return false;
            }
        }

        #region 短信收发线程

        public void StartWorkNow()
        {
            if (_WorkThread == null || !_WorkThread.IsAlive)
            {
                _WorkThread = new Thread(WorkWork);
                _WorkThread.IsBackground = true;
                _WorkThread.Start();
                _WorkNow = true;
            }
        }

        public void StopWorkNow()
        {
            if (_WorkThread != null && _WorkThread.IsAlive)
            {
                _WorkNow = false;
                _WorkThread.Join(20000);
            }
        }

        private void WorkWork()
        {
            while (true)
            {
                SendOneMessage();
                ReceiveAllMessage();
                Thread.Sleep(60000);
                if (!_WorkNow)
                {
                    break;
                }
            }
        }

        private void SendOneMessage()
        {
            if (ObjectSource.GetMessageBox._WaitSendMessages.Count.Equals(0))
            {
                return;
            }

            SendMessageDataModel aMessageToSend = ObjectSource.GetMessageBox._WaitSendMessages[0];
            if (aMessageToSend != null)
            {
                if (aMessageToSend.TriedCount >= _TryTimes)
                {
                    //aMessageToSend.IsSuccessed = false;
                    ObjectSource.GetMessageBox.EnqueueFailedMessage(aMessageToSend);
                    SendFailedHandler(aMessageToSend);
                    return;
                }
                if (!SendSMS(aMessageToSend))
                {
                    aMessageToSend.TriedCount++;
                    aMessageToSend.SendTime = DateTime.Now;
                    ObjectSource.GetMessageBox.EnqueueWaitMessage(aMessageToSend);
                }
                else
                {
                    aMessageToSend.SendTime = DateTime.Now;
                    //aMessageToSend.IsSuccessed = true;
                    ObjectSource.GetMessageBox.EnqueueSuccessMessage(aMessageToSend);
                }
            }
        }

        #endregion

        public bool SendSearchMoneyMessage()
        {
            try
            {
                //设置英文短信格式
                _TheSerialPort.SendString("AT+CMGF=1\r");
                _TheSerialPort.ReadTo("OK", 2000);
                //发送第一步 10086
                _TheSerialPort.SendString("AT+CMGS=10086\r");
                _TheSerialPort.ReadTo("> ", 10000);
                //发送第二步 内容
                _TheSerialPort.SendString(String.Format("{0}\x01a", "YECX"));
                _TheSerialPort.ReadTo("+CMGS:", 12000);
                _TheSerialPort.ReadTo("OK", 2000);
                //设置回中文短信格式
                _TheSerialPort.SendString("AT+CMGF=0\r");
                _TheSerialPort.ReadTo("OK", 2000);

                return true;
            }
            catch(TimeoutException)
            {
                return false;
            }
        }

        public bool TheEventHasHandler
        {
            get
            {
                if (ReceivedMessage == null || SendMessageFailed == null)
                {
                    return false;
                }
                return true;
            }
        }

        public void ClearEventHandler()
        {
            ReceivedMessage = null;
            SendMessageFailed = null;
        }

        #region 错误处理

        private void SendFailedHandler(SendMessageDataModel aMessageToSend)
        {
            //异步调用事件
            if (SendMessageFailed != null)
            {
                SendMessageFailed.BeginInvoke(aMessageToSend, new EventArgs(), null, null);
            }
            WriteLine(string.Format("发短信失败：发送给的号码是：{0},内容是{1}", aMessageToSend.SendNumber, aMessageToSend.Content));
        }

        private void ReceivedFailedHandler()
        {
            WriteLine("收短信失败");
        }

        private void DecodingSmsFailHandler(string id, string unDecodingConent)
        {
            WriteLine(string.Format("解码短信失败，在短信机器中的编号如下{0}编码内容如下{1}",id, unDecodingConent));
        }

        private void DeleteMessageFailedHandler(ReceiveMessageDataModel aMessage)
        {
            WriteLine(string.Format("删除Sim卡中的短信失败,短信在机器中的编号为{0},收到的时间为{1},内容是{2}", aMessage.Id, aMessage.ReceivedTime, aMessage.Content));
        }

        private static void WriteLine(string s)
        {
            GetLogInstance.GetInstance.DoWriteEventLog(s,EventType.Warning);
        }

        #endregion
    }
}