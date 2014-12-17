using System;
using Sms.Entity;

namespace Sms.Bll
{
    public class TheMachineController
    {
        public static void StartConnection()
        {
            TheSerialPort.GetInstance.StartConnection();
        }

        public static void StopConnection()
        {
            if (SmsMachineBll.GetInstance.WorkNow)
            {
                throw new ApplicationException("短信收发线程工作中，无法停止端口连接");
            }
            TheSerialPort.GetInstance.CloseConnection();
        }

        public static void StartTheSmsThread()
        {
            if (!TheSerialPort.GetInstance.PortIsOpen())
            {
                throw new ApplicationException("端口未打开，无法开始短信线程工作");
            }
            SmsMachineBll.GetInstance.StartWorkNow();
        }

        public static void StopTheSmsThread()
        {
            SmsMachineBll.GetInstance.StopWorkNow();
        }

        public static bool TestMachine()
        {
            if (!TheSerialPort.GetInstance.PortIsOpen())
            {
                throw new ApplicationException("端口未打开，无法向端口发送数据");
            }
            return SmsMachineBll.GetInstance.TestMachine();
        }

        public static string SendCommand(string commandText, int waitReplayMillionSeconds)
        {
            if (!TheSerialPort.GetInstance.PortIsOpen())
            {
                throw new ApplicationException("端口未打开!");
            }
            if (SmsMachineBll.GetInstance.WorkNow)
            {
                throw new ApplicationException("短信收发线程工作中，无法向端口发送数据");
            }
            return SmsMachineBll.GetInstance.SendCommand(commandText, waitReplayMillionSeconds);
        }

        public static bool GetPortStatus()
        {
            return TheSerialPort.GetInstance.PortIsOpen();
        }

        public static bool GetWorkThreadStatus()
        {
            return SmsMachineBll.GetInstance.WorkNow;
        }

        public static bool SendAMessage(SendMessagesEntity aMessage)
        {
            if (!TheSerialPort.GetInstance.PortIsOpen())
            {
                throw new ApplicationException("端口未打开!");
            }
            if (SmsMachineBll.GetInstance.WorkNow)
            {
                throw new ApplicationException("短信收发线程工作中，无法向端口发送数据");
            }
            return SmsMachineBll.GetInstance.SendSMS(aMessage);
        }

        public static void ReceiveAllMessage()
        {
            if (!TheSerialPort.GetInstance.PortIsOpen())
            {
                throw new ApplicationException("端口未打开!");
            }
            if (SmsMachineBll.GetInstance.WorkNow)
            {
                throw new ApplicationException("短信收发线程工作中，无法向端口发送数据");
            }
            SmsMachineBll.GetInstance.ReceiveAllMessage();
        }

        public static void SendSearchMoneyMessage()
        {
            if (!TheSerialPort.GetInstance.PortIsOpen())
            {
                throw new ApplicationException("端口未打开，无法开始短信线程工作");
            }
            if (SmsMachineBll.GetInstance.WorkNow)
            {
                throw new ApplicationException("短信收发线程工作中，无法向端口发送数据");
            }
            SmsMachineBll.GetInstance.SendSearchMoneyMessage();
        }
    }
}