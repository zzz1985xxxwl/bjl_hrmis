//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: TheMachineController.cs
// ������: �ߺ�
// ��������: 2008-11-21
// ����: ���ſ��Ƶ������
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SmsDataContract;

namespace MachineDll
{
    public class TheMachineController
    {
        #region ISmsController ��Ա

        public void StartConnection()
        {
            ObjectSource.GetSerialPort.StartConnection();
        }

        public void StopConnection()
        {
            if (ObjectSource.GetSmsMachine._WorkNow)
            {
                throw new ApplicationException("�����շ��̹߳����У��޷�ֹͣ�˿�����");
            }
            ObjectSource.GetSerialPort.CloseConnection();
        }

        public void StartTheSmsThread()
        {
            if (!ObjectSource.GetSerialPort.PortIsOpen())
            {
                throw new ApplicationException("�˿�δ�򿪣��޷���ʼ�����̹߳���");
            }
            ObjectSource.GetSmsMachine.StartWorkNow();
        }

        public void StopTheSmsThread()
        {
            ObjectSource.GetSmsMachine.StopWorkNow();
        }

        public bool TestMachine()
        {
            if (!ObjectSource.GetSerialPort.PortIsOpen())
            {
                throw new ApplicationException("�˿�δ�򿪣��޷���˿ڷ�������");
            }
            return ObjectSource.GetSmsMachine.TestMachine();
        }

        public string SendCommand(string commandText, int waitReplayMillionSeconds)
        {
            if (!ObjectSource.GetSerialPort.PortIsOpen())
            {
                throw new ApplicationException("�˿�δ��!");
            }
            if (ObjectSource.GetSmsMachine._WorkNow)
            {
                throw new ApplicationException("�����շ��̹߳����У��޷���˿ڷ�������");
            }
            return ObjectSource.GetSmsMachine.SendCommand(commandText, waitReplayMillionSeconds);
        }

        public bool GetPortStatus()
        {
            return ObjectSource.GetSerialPort.PortIsOpen();
        }

        public bool GetWorkThreadStatus()
        {
            return ObjectSource.GetSmsMachine._WorkNow;
        }

        public bool SendAMessage(SendMessageDataModel aMessage)
        {
            if (!ObjectSource.GetSerialPort.PortIsOpen())
            {
                throw new ApplicationException("�˿�δ��!");
            }
            if (ObjectSource.GetSmsMachine._WorkNow)
            {
                throw new ApplicationException("�����շ��̹߳����У��޷���˿ڷ�������");
            }
            return ObjectSource.GetSmsMachine.SendSMS(aMessage);
        }

        public void ReceiveAllMessage()
        {
            if (!ObjectSource.GetSerialPort.PortIsOpen())
            {
                throw new ApplicationException("�˿�δ��!");
            }
            if (ObjectSource.GetSmsMachine._WorkNow)
            {
                throw new ApplicationException("�����շ��̹߳����У��޷���˿ڷ�������");
            }
            ObjectSource.GetSmsMachine.ReceiveAllMessage();
        }

        public void SendSearchMoneyMessage()
        {
            if (!ObjectSource.GetSerialPort.PortIsOpen())
            {
                throw new ApplicationException("�˿�δ�򿪣��޷���ʼ�����̹߳���");
            }
            if (ObjectSource.GetSmsMachine._WorkNow)
            {
                throw new ApplicationException("�����շ��̹߳����У��޷���˿ڷ�������");
            }
            ObjectSource.GetSmsMachine.SendSearchMoneyMessage();
        }

        public List<ReceiveMessageDataModel> GetLogsForReceiveMessages()
        {
            return ObjectSource.GetMessageBox._LogsForReceiveMessages;
        }

        public List<SendMessageDataModel> GetLogsForWaitSendMessages()
        {
            return ObjectSource.GetMessageBox._LogsForWaitSendMessages;
        }

        public List<SendMessageDataModel> GetLogsForSuccesssSendMessages()
        {
            return ObjectSource.GetMessageBox._LogsForSuccesssSendMessages;
        }

        public List<SendMessageDataModel> GetLogsForFailedSendMessages()
        {
            return ObjectSource.GetMessageBox._LogsForFailedSendMessages;
        }

        public bool TheEventHasHandler
        {
            get
            {
                return ObjectSource.GetSmsMachine.TheEventHasHandler;
            }
        }

        public void ClearAllReceivedMessages()
        {
            if (ObjectSource.GetSmsMachine._WorkNow)
            {
                throw new ApplicationException("�����շ��̹߳����У��޷�ɾ�����н��յ�����");
            }
            ObjectSource.GetMessageBox.ClearAllReceivedMessages();
        }

        public void ClearAllSendMessages()
        {
            if (ObjectSource.GetSmsMachine._WorkNow)
            {
                throw new ApplicationException("�����շ��̹߳����У��޷�ɾ�����з��Ͷ���");
            }
            ObjectSource.GetMessageBox.ClearAllSendMessages();
        }

        #endregion

    }
}
