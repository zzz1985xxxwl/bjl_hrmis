//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TheMachineController.cs
// 创建者: 倪豪
// 创建日期: 2008-11-21
// 概述: 短信控制的外观类
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SmsDataContract;

namespace MachineDll
{
    public class TheMachineController
    {
        #region ISmsController 成员

        public void StartConnection()
        {
            ObjectSource.GetSerialPort.StartConnection();
        }

        public void StopConnection()
        {
            if (ObjectSource.GetSmsMachine._WorkNow)
            {
                throw new ApplicationException("短信收发线程工作中，无法停止端口连接");
            }
            ObjectSource.GetSerialPort.CloseConnection();
        }

        public void StartTheSmsThread()
        {
            if (!ObjectSource.GetSerialPort.PortIsOpen())
            {
                throw new ApplicationException("端口未打开，无法开始短信线程工作");
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
                throw new ApplicationException("端口未打开，无法向端口发送数据");
            }
            return ObjectSource.GetSmsMachine.TestMachine();
        }

        public string SendCommand(string commandText, int waitReplayMillionSeconds)
        {
            if (!ObjectSource.GetSerialPort.PortIsOpen())
            {
                throw new ApplicationException("端口未打开!");
            }
            if (ObjectSource.GetSmsMachine._WorkNow)
            {
                throw new ApplicationException("短信收发线程工作中，无法向端口发送数据");
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
                throw new ApplicationException("端口未打开!");
            }
            if (ObjectSource.GetSmsMachine._WorkNow)
            {
                throw new ApplicationException("短信收发线程工作中，无法向端口发送数据");
            }
            return ObjectSource.GetSmsMachine.SendSMS(aMessage);
        }

        public void ReceiveAllMessage()
        {
            if (!ObjectSource.GetSerialPort.PortIsOpen())
            {
                throw new ApplicationException("端口未打开!");
            }
            if (ObjectSource.GetSmsMachine._WorkNow)
            {
                throw new ApplicationException("短信收发线程工作中，无法向端口发送数据");
            }
            ObjectSource.GetSmsMachine.ReceiveAllMessage();
        }

        public void SendSearchMoneyMessage()
        {
            if (!ObjectSource.GetSerialPort.PortIsOpen())
            {
                throw new ApplicationException("端口未打开，无法开始短信线程工作");
            }
            if (ObjectSource.GetSmsMachine._WorkNow)
            {
                throw new ApplicationException("短信收发线程工作中，无法向端口发送数据");
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
                throw new ApplicationException("短信收发线程工作中，无法删除所有接收到短信");
            }
            ObjectSource.GetMessageBox.ClearAllReceivedMessages();
        }

        public void ClearAllSendMessages()
        {
            if (ObjectSource.GetSmsMachine._WorkNow)
            {
                throw new ApplicationException("短信收发线程工作中，无法删除所有发送短信");
            }
            ObjectSource.GetMessageBox.ClearAllSendMessages();
        }

        #endregion

    }
}
