//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ISmsClientContract.cs
// ������: �ߺ�
// ��������: 2008-11-21
// ����: �ͻ����ṩ�ķ���
// ----------------------------------------------------------------
using System.Collections.Generic;
using System.ServiceModel;

namespace SmsDataContract
{
    [ServiceContract]
    public interface ISmsClientContract
    {
        /// <summary>
        /// �ͻ����Ƿ���Ч
        /// </summary>
        [OperationContract]
        void ClientIsAvailable();
        /// <summary>
        /// ������״̬�ı�
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void TheServiceStatusChanged(bool theStatus);
        /// <summary>
        /// �ͻ��˽�����Ϣ
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void ReceiveTheMessages(List<ReceiveMessageDataModel> theMessages);
        /// <summary>
        /// ��Ϣ����ʧ��
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void SendFailedMessages(SendMessageDataModel theFaildMessage);
        /// <summary>
        /// �ɷ���������һ���첽���߳�ִ�������ס����Ϣ������
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void ClearBlockMessage();
    }
}