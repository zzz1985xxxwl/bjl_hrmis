using System;
using System.IO.Ports;
using System.Threading;
using Framework.Common;

namespace Sms.Bll
{
    public class TheSerialPort
    {
        private static readonly string _PortNameConfig = ConfigReader.GetConfig("app", "PortNameConfig");
        private static readonly string _BautRateConfig = ConfigReader.GetConfig("app", "BautRateConfig");
        public string BautRate = "19200";
        public int DataBits = 8;
        public Parity Parity = Parity.None;
        public string PortName = "COM2";
        public StopBits StopBits = StopBits.One;
        private SerialPort _ItsSerialPort;

        private static TheSerialPort _TheSerialPort;
        public static TheSerialPort GetInstance
        {
            get
            {
                if (_TheSerialPort == null)
                {
                    _TheSerialPort = new TheSerialPort();
                    return _TheSerialPort;
                }
                return _TheSerialPort;
            }
        }

        internal TheSerialPort()
        {
            if (!string.IsNullOrEmpty(_PortNameConfig))
            {
                PortName = _PortNameConfig;
            }
            if (!string.IsNullOrEmpty(_BautRateConfig))
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
            if (_ItsSerialPort != null && PortIsOpen())
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
                throw new ApplicationException(_ItsSerialPort.PortName + "端口已经被其他程序所占用");
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
                throw new ApplicationException("关闭连接失败");
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

        public string ReadTo(string value, int millionSeconds)
        {
            _ItsSerialPort.ReadTimeout = millionSeconds;
            return _ItsSerialPort.ReadTo(value);
        }
    }
}