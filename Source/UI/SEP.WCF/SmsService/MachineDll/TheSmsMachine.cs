//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: TheSmsMachine.cs
// ������: �ߺ�
// ��������: 2008-11-21
// ����: ���ŷ��ͽ��յĺ�����
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
        //�շ������̣߳��Ƿ��
        public bool _WorkNow;
        //����ʧ�ܶ����ط�����
        public int _TryTimes = 3;
        //������ŵ�����и����������ڴ����Ķ��Ž�Ĭ�ϲ�����
        public int _CutCount = 3;
        //�յ�������ʾ
        public event EventHandler ReceivedMessage;
        //���ŷ���ʧ����ʾ
        public event EventHandler SendMessageFailed;
        //����Ƭ����һ��������и��С�������ڴ�
        public List<SendMessageDataModel> _SendPieceMessages = new List<SendMessageDataModel>();

        private static  Thread _WorkThread;                                
        private readonly TheSerialPort _TheSerialPort;

        internal TheSmsMachine()
        {
            _TheSerialPort = ObjectSource.GetSerialPort;
        }

        public bool TestMachine()
        {
            //��֤���ڵ��߳�ͨ��
            StopWorkNow();

            //���Դ��ڲ���������ݴ��ڻ�������
            if (!_TheSerialPort.PortIsOpen())
            {
                throw new ApplicationException("��ȷ�϶˿��Ѿ����Ӳ��Ҵ򿪣������޷�����");
            }
            _TheSerialPort.ReadExisting();

            //���Ի�������
            if (!CommandTest("AT\r"))
            {
                return false;
            }
            //�����ź�
            if (!CommandTest("AT+CSQ\r"))
            {
                return false;
            }
            //���ö���Ϣ���͸�ʽΪPDU��ʽ
            if (!CommandTest("AT+CMGF=0\r"))
            {
                return false;
            }
            return true;
        }

        public bool SendSMS(SendMessageDataModel messageToSend)
        {
            //�ж϶��ŵ������Ƿ���Ϲ淶
            int theLength = messageToSend.Content.Length;
            if (theLength == 0 || theLength > _CutCount*70)
            {
                return false;
            }
            //������Ҫ���͵Ķ�������
            int theCount = theLength/70;
            int theYuShu = theLength%70;
            int theAdditionalCount = theYuShu == 0 ? 0 : 1;
            int realCount = theCount + theAdditionalCount;
            //�и���Ų����ͣ�����������һС�����ŷ��Ͳ��ɹ�����Ϊ�������ŷ��Ͳ��ɹ�
            _SendPieceMessages.Clear();
            for (int index = 0; index < realCount; index++)
            {
                //���һ����֮ǰ�Ķ���Ӧ�÷ֱ���
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
                //ӦΪ�����������м�����͵Ļ��壬������ܷ��Ͳ��ɹ�
                if(_SendPieceMessages.Count >1)
                {
                    Thread.Sleep(2000);
                }
            }
            return true;
        }

        /// <summary>
        /// ���ͱ�׼���ַ�������70�Ķ��ţ�������70�����޷����ͳɹ�
        /// </summary>
        private bool SendStandardSms(SendMessageDataModel standradMessageToSend)
        {
            try
            {
                PduEncoding thePdu = new PduEncoding();
                string decodedSMS = thePdu.smsDecodedsms(standradMessageToSend.SystemNumber, standradMessageToSend.SendNumber, standradMessageToSend.Content);
                //���͵�һ�� �ֽ���
                _TheSerialPort.SendString(String.Format("AT+CMGS={0}\r", thePdu.nLength));
                _TheSerialPort.ReadTo("> ", 10000);
                //���͵ڶ��� ����
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
            //��ȡ����Sim���еĶ���
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
            //һ��һ����������
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
                //ɾ��Sim���������Ϣ
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
            //�����յ���Ϣ�������첽�¼�
            if (successCount > 0 && ReceivedMessage != null)
            {
                ReceivedMessage.BeginInvoke(this, new EventArgs(), null, null);
            }
        }

        public string SendCommand(string command, int waitReplayMillionSeconds)
        {
            if (!_TheSerialPort.PortIsOpen())
            {
                throw new ApplicationException("��ȷ�϶˿��Ѿ����Ӳ��Ҵ򿪣������޷�����");
            }
            if (_WorkThread != null && _WorkThread.IsAlive)
            {
                throw new ApplicationException("��ȷ���Ѿ��رն����շ��̣߳���֤����ͨ��ʼ��ֻ��һ���߳�");
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

        #region �����շ��߳�

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
                //����Ӣ�Ķ��Ÿ�ʽ
                _TheSerialPort.SendString("AT+CMGF=1\r");
                _TheSerialPort.ReadTo("OK", 2000);
                //���͵�һ�� 10086
                _TheSerialPort.SendString("AT+CMGS=10086\r");
                _TheSerialPort.ReadTo("> ", 10000);
                //���͵ڶ��� ����
                _TheSerialPort.SendString(String.Format("{0}\x01a", "YECX"));
                _TheSerialPort.ReadTo("+CMGS:", 12000);
                _TheSerialPort.ReadTo("OK", 2000);
                //���û����Ķ��Ÿ�ʽ
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

        #region ������

        private void SendFailedHandler(SendMessageDataModel aMessageToSend)
        {
            //�첽�����¼�
            if (SendMessageFailed != null)
            {
                SendMessageFailed.BeginInvoke(aMessageToSend, new EventArgs(), null, null);
            }
            WriteLine(string.Format("������ʧ�ܣ����͸��ĺ����ǣ�{0},������{1}", aMessageToSend.SendNumber, aMessageToSend.Content));
        }

        private void ReceivedFailedHandler()
        {
            WriteLine("�ն���ʧ��");
        }

        private void DecodingSmsFailHandler(string id, string unDecodingConent)
        {
            WriteLine(string.Format("�������ʧ�ܣ��ڶ��Ż����еı������{0}������������{1}",id, unDecodingConent));
        }

        private void DeleteMessageFailedHandler(ReceiveMessageDataModel aMessage)
        {
            WriteLine(string.Format("ɾ��Sim���еĶ���ʧ��,�����ڻ����еı��Ϊ{0},�յ���ʱ��Ϊ{1},������{2}", aMessage.Id, aMessage.ReceivedTime, aMessage.Content));
        }

        private static void WriteLine(string s)
        {
            GetLogInstance.GetInstance.DoWriteEventLog(s,EventType.Warning);
        }

        #endregion
    }
}