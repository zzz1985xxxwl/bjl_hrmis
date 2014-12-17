//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ICallbackDataGateWay.cs
// ������: �ߺ�
// ��������: 2008-12-2
// ����:  ���Ż��������ݵĹؿ�,�ýӿ����ڽ�����Ż����ַ��������
// ----------------------------------------------------------------
using System.Collections.Generic;
using SmsDataContract;

namespace ProvideSmsServerServices.BoardCast
{
    public interface ICallbackDataGateWay
    {
        /// <summary>
        /// ���ͽ��յ�������
        /// </summary>
        /// <param name="messagesTobeSended"></param>
        void OnReceivedMessages(List<ReceiveMessageDataModel> messagesTobeSended);
        /// <summary>
        /// ���ͷ���ʧ�ܵ�����
        /// </summary>
        void OnSendFailedMessages(SendMessageDataModel failedMessage);
        /// <summary>
        /// ���Ͷ��ŷ��񼴽��رյ�����
        /// </summary>
        void OnStopServer();
    }
}