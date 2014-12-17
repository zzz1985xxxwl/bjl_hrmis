//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AllMessages.cs
// 创建者: 倪豪
// 创建日期: 2008-11-21
// 概述: 访问machine的实例通过该类获取单一实例，以防未知错误的发生
// ----------------------------------------------------------------

using SqlServerDal.MessageDal;

namespace MachineDll
{
    public static class ObjectSource
    {
        private static TheSerialPort _TheSerialPort;
        private static TheSmsMachine _TheSmsMachine;
        private static AllMessages _AllMessages;

        public static TheSerialPort GetSerialPort
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

        public static TheSmsMachine GetSmsMachine
        {
            get
            {
                if(_TheSmsMachine == null)
                {
                    _TheSmsMachine = new TheSmsMachine();
                    return _TheSmsMachine;
                }
                return _TheSmsMachine;
            }
        }

        public static AllMessages GetMessageBox
        {
            get
            {
                if(_AllMessages ==null)
                {
                    _AllMessages = new AllMessages(new SqlServerImplMessage());
                }
                return _AllMessages;
            }
        }
    }
}
