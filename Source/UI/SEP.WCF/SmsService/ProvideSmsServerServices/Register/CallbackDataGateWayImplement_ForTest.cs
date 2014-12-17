//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: CallbackDataGateWayImplement_ForTest.cs
// ������: �ߺ�
// ��������: 2008-12-2
// ����: �������Ѱ������ĳ��ֵ�ԭ�����£�
//       ���ڷ��������ڵ����Ľ����У��ڲ��Թ����У����ڲ��Խ�����
//       ��������໥�����������޷���ͨ���滻�ڲ��ӿ�ʵ�ֵķ�ʽ��
//       �����ԣ�ֻ�����޸Ĵ��뷽ʽ����ô���յ�ԭ�����ڣ��ⲿ����
//       ��Ҫ���Եģ���������ϵͳ���ӿھͲ�������ϣ������޷�����
//       ʵ�֣��ⲿ�ֵĲ��Կ���ѡ����Ϊ�ڲ������Բ��ԣ�������õ�
//       ��ʽ�Ƿ���ϵͳ���ӿڣ������Ź�����ע�Ṧ�ܷ���
// ----------------------------------------------------------------
using System;
using System.IO;
using ProvideSmsServerServices.BoardCast;
using SmsDataContract;

namespace ProvideSmsServerServices.Register
{
    public class CallbackDataGateWayImplement_ForTest : ICallbackDataGateWay
    {

        #region ICallbackDataGateWay ��Ա

        public void OnReceivedMessages(System.Collections.Generic.List<ReceiveMessageDataModel> messagesTobeSended)
        {
            foreach (ReceiveMessageDataModel aMessage in messagesTobeSended)
            {
                WriteMessage(string.Format("�յ���Ϣ��\r������:{0}\rʱ����:{1}\r������:{2}", aMessage.TheNumber, aMessage.ReceivedTime, aMessage.Content));
            }
        }

        public void OnSendFailedMessages(SendMessageDataModel failedMessage)
        {
            WriteMessage(string.Format("��Ϣ����ʧ��\r����:{0}\r������:{1}\r��ϵͳ�еı����:{2}", failedMessage.SendNumber, failedMessage.Content, failedMessage.SystemSmsId));
        }

        public void OnStopServer()
        {
            WriteMessage("TheServer need to Stop" + DateTime.Now);
        }

        private void WriteMessage(string message)
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"C:\SMS_Test.txt", true);
                sw.WriteLine(message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        #endregion
    }
}