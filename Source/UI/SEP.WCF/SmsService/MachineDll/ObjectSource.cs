//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AllMessages.cs
// ������: �ߺ�
// ��������: 2008-11-21
// ����: ����machine��ʵ��ͨ�������ȡ��һʵ�����Է�δ֪����ķ���
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
