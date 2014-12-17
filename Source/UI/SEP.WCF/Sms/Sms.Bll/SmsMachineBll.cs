using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using Sms.Bll.SmsCoding;
using Sms.Entity;

namespace Sms.Bll
{
    public class SmsMachineBll
    {
        //收发短信线程，是否打开
        //定义短信的最大切割条数，大于此数的短信将默认不发送
        private readonly TheSerialPort _theSerialPort;
        private int CutCount = 3;
        //收到短信提示
        private int TryTimes = 3;
        public bool WorkNow;

        private Thread _workThread;

        internal SmsMachineBll()
        {
            _theSerialPort = TheSerialPort.GetInstance;
        }

        private static SmsMachineBll _TheSmsMachine;
        public static SmsMachineBll GetInstance
        {
            get
            {
                if (_TheSmsMachine == null)
                {
                    _TheSmsMachine = new SmsMachineBll();
                    return _TheSmsMachine;
                }
                return _TheSmsMachine;
            }
        }

        #region 辅助短信操作
        public bool TestMachine()
        {
            //保证串口单线程通信
            StopWorkNow();

            //测试串口并且清空数据串口缓存数据
            if (!_theSerialPort.PortIsOpen())
            {
                throw new ApplicationException("请确认端口已经连接并且打开，否则无法操作");
            }
            _theSerialPort.ReadExisting();

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
     
        public string SendCommand(string command, int waitReplayMillionSeconds)
        {
            if (!_theSerialPort.PortIsOpen())
            {
                throw new ApplicationException("请确认端口已经连接并且打开，否则无法操作");
            }
            if (_workThread != null && _workThread.IsAlive)
            {
                throw new ApplicationException("请确保已经关闭短信收发线程，保证串口通信始终只有一个线程");
            }
            _theSerialPort.SendString(command);
            Thread.Sleep(waitReplayMillionSeconds);
            return _theSerialPort.ReadExisting();
        }

        private bool CommandTest(string command)
        {
            _theSerialPort.SendString(command);
            try
            {
                _theSerialPort.ReadTo("OK", 5000);
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }

        public bool SendSearchMoneyMessage()
        {
            try
            {
                //设置英文短信格式
                _theSerialPort.SendString("AT+CMGF=1\r");
                _theSerialPort.ReadTo("OK", 2000);
                //发送第一步 10086
                _theSerialPort.SendString("AT+CMGS=10086\r");
                _theSerialPort.ReadTo("> ", 10000);
                //发送第二步 内容
                _theSerialPort.SendString(String.Format("{0}\x01a", "YECX"));
                _theSerialPort.ReadTo("+CMGS:", 12000);
                _theSerialPort.ReadTo("OK", 2000);
                //设置回中文短信格式
                _theSerialPort.SendString("AT+CMGF=0\r");
                _theSerialPort.ReadTo("OK", 2000);

                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }

        #endregion
      
        #region 短信收发线程

        public void StartWorkNow()
        {
            if (_workThread == null || !_workThread.IsAlive)
            {
                _workThread = new Thread(WorkWork);
                _workThread.IsBackground = true;
                _workThread.Start();
                WorkNow = true;
            }
        }

        public void StopWorkNow()
        {
            if (_workThread != null && _workThread.IsAlive)
            {
                WorkNow = false;
                _workThread.Join(20000);
            }
        }

        private void WorkWork()
        {
            while (true)
            {
                SendOneMessage();
                ReceiveAllMessage();
                Thread.Sleep(3000);
                if (!WorkNow)
                {
                    break;
                }
            }
        }

      

        #endregion

        #region 发消息



        public bool SendSMS(SendMessagesEntity messageToSend)
        {
            //判断短信的字数是否符合规范
            int theLength = messageToSend.Content.Length;
            if (theLength == 0 || theLength > CutCount * 70)
            {
                return false;
            }
            //计算需要发送的短信条数
            int theCount = theLength / 70;
            int theYuShu = theLength % 70;
            int theAdditionalCount = theYuShu == 0 ? 0 : 1;
            int realCount = theCount + theAdditionalCount;
            //切割短信并发送，其中有任意一小条短信发送不成功将视为整个短信发送不成功
            //短信片，将一条大短信切割成小短信置于此
            var sendPieceMessages = new List<SendMessagesEntity>();
            for (int index = 0; index < realCount; index++)
            {
                var sendMessagesEntity = new SendMessagesEntity
                {
                    SystemSmsId = messageToSend.SystemSmsId,
                    SendToNumber = messageToSend.SendToNumber,
                    Content = ""
                };
                //最后一条与之前的短信应该分别处理
                if (index < realCount - 1)
                {
                    sendMessagesEntity.Content = messageToSend.Content.Substring(70 * index, 70);
                    sendPieceMessages.Add(sendMessagesEntity);
                }
                else
                {
                    sendMessagesEntity.Content = messageToSend.Content.Substring(70 * index);
                    sendPieceMessages.Add(sendMessagesEntity);
                }
            }

            foreach (SendMessagesEntity aStandMessage in sendPieceMessages)
            {
                if (!SendStandardSms(aStandMessage))
                {
                    return false;
                }
                //应为多条短信留有间隔发送的缓冲，否则可能发送不成功
                if (sendPieceMessages.Count > 1)
                {
                    Thread.Sleep(2000);
                }
            }
            return true;
        }

        /// <summary>
        ///     发送标准的字符不超过70的短信，若超过70，则无法发送成功
        /// </summary>
        private bool SendStandardSms(SendMessagesEntity standradMessageToSend)
        {
            try
            {
                var thePdu = new PduEncoding();
                string decodedSMS = thePdu.smsDecodedsms(standradMessageToSend.SystemNumber,
                    standradMessageToSend.SendToNumber, standradMessageToSend.Content);
                //发送第一步 字节数
                _theSerialPort.SendString(String.Format("AT+CMGS={0}\r", thePdu.nLength));
                _theSerialPort.ReadTo("> ", 10000);
                //发送第二步 内容
                _theSerialPort.SendString(String.Format("{0}\x01a", decodedSMS));
                _theSerialPort.ReadTo("+CMGS:", 12000);
                _theSerialPort.ReadTo("OK", 2000);
                return true;
            }
            catch
            {
                return false;
            }
        }


        private void SendOneMessage()
        {
            SendMessagesEntity aMessageToSend = SendMessagesBll.GetOneToSend();
            if (aMessageToSend == null)
            {
                return;
            }
            //发送
            bool ans = SendSMS(aMessageToSend);
            aMessageToSend.TriedCount++;
            aMessageToSend.LastestSendTime = DateTime.Now;
            if (!ans)
            {
                if (aMessageToSend.TriedCount >= TryTimes)
                {
                    aMessageToSend.SendStatusEnum = (int)SendStatusEnum.FailSendedToBeCallback;
                    SendFailedHandler(aMessageToSend);
                }
                else
                {
                    aMessageToSend.SendStatusEnum = (int)SendStatusEnum.ToBeSend;
                }
            }
            else
            {
                aMessageToSend.SendStatusEnum = (int)SendStatusEnum.SuccessSended;
            }
            SendMessagesBll.Update(aMessageToSend);
        }
        #endregion

        #region 收短信

        /// <summary>
        /// 获取所有Sim卡中的短信
        /// </summary>
        public void ReceiveAllMessage()
        {
            _theSerialPort.SendString("AT+CMGL=4\r");
            string theResponse;
            try
            {
                theResponse = _theSerialPort.ReadTo("OK", 20000);
            }
            catch (TimeoutException)
            {
                ReceivedFailedHandler();
                return;
            }
            //一条一条解析短信
            var readReg = new Regex("(?:CMGL: (?<index>\\d+),\\d+,,\\d+\r\n(?<sms>\\S+)\r\n)");
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
                var theMessage = new ReceiveMessagesEntity
                {
                    Id = id,
                    TheNumber = senderNumber,
                    Content = content,
                    ReceivedTime = senderTime,
                    BoradCasted = 0
                };
                successCount++;
                //删除Sim卡里面的信息
                _theSerialPort.SendString("AT+CMGD=" + theMessage.Id + "\r");
                try
                {
                    _theSerialPort.ReadTo("OK", 10000);
                    theMessage.IsCleanMessage = 1;
                }
                catch (TimeoutException)
                {
                    DeleteMessageFailedHandler(theMessage);
                }
                finally
                {
                    theMessage.TheNumber = theMessage.TheNumber.Replace("+86", "");
                    ReceiveMessagesBll.Insert(theMessage);
                }
            }
        }

        #endregion

        #region 错误处理

        private void SendFailedHandler(SendMessagesEntity aMessageToSend)
        {
            Log.Write(string.Format("发短信失败：发送给的号码是：{0},内容是{1}", aMessageToSend.SendToNumber, aMessageToSend.Content));
        }

        private void ReceivedFailedHandler()
        {
            Log.Write("收短信失败");
        }

        private void DecodingSmsFailHandler(string id, string unDecodingConent)
        {
            Log.Write(string.Format("解码短信失败，在短信机器中的编号如下{0}编码内容如下{1}", id, unDecodingConent));
        }

        private void DeleteMessageFailedHandler(ReceiveMessagesEntity aMessage)
        {
            Log.Write(string.Format("删除Sim卡中的短信失败,短信在机器中的编号为{0},收到的时间为{1},内容是{2}", aMessage.Id, aMessage.ReceivedTime,
                aMessage.Content));
        }

        #endregion
    }
}