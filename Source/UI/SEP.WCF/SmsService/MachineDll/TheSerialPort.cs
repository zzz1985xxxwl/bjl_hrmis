//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: TheSerialPort.cs
// ������: �ߺ�
// ��������: 2008-11-21
// ����: ����ͨ�ŵ���չ��
// ----------------------------------------------------------------
using System;
using System.Configuration;
using System.IO.Ports;
using System.Threading;

namespace MachineDll
{
    public class TheSerialPort
    {
        public string PortName = "COM2";
        public string BautRate = "19200";
        public int DataBits = 8;
        public Parity Parity = Parity.None;
        public StopBits StopBits = StopBits.One;
        private SerialPort _ItsSerialPort;

        private static readonly string _PortNameConfig = ConfigurationManager.AppSettings["PortNameConfig"];
        private static readonly string _BautRateConfig = ConfigurationManager.AppSettings["BautRateConfig"];


        internal TheSerialPort()
        {
            if(!string.IsNullOrEmpty(_PortNameConfig))
            {
                PortName = _PortNameConfig;
            }
            if(!string.IsNullOrEmpty(_BautRateConfig))
            {
                BautRate = _BautRateConfig;
            }
        }

        public void StartConnection()
        {
            if (!PortIsOpen())
            {
                TryConnect();
            }
        }

        public void CloseConnection()
        {
            if (_ItsSerialPort!=null && PortIsOpen())
            {
                TryCloseConnection();
            }
        }

        public bool PortIsOpen()
        {
            if (_ItsSerialPort != null)
            {
                return _ItsSerialPort.IsOpen;
            }
            return false;
        }

        private void TryConnect()
        {
            _ItsSerialPort = new SerialPort(PortName, int.Parse(BautRate), Parity, DataBits, StopBits);
            try
            {
                _ItsSerialPort.Open();
                Thread.Sleep(1000);
            }
            catch
            {
                throw new ApplicationException(_ItsSerialPort.PortName + "�˿��Ѿ�������������ռ��");
            }
        }

        private void TryCloseConnection()
        {
            try
            {
                _ItsSerialPort.Close();
                Thread.Sleep(1000);
            }
            catch
            {
                throw new ApplicationException("�ر�����ʧ��");
            }
        }

        public void SendString(string s)
        {
            _ItsSerialPort.Write(s);
        }

        public string ReadExisting()
        {
            return _ItsSerialPort.ReadExisting();
        }

        public string ReadTo(string value,int millionSeconds)
        {
            _ItsSerialPort.ReadTimeout = millionSeconds;
            return _ItsSerialPort.ReadTo(value);
        }
    }
}
