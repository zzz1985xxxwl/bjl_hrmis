//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IMessageDal.cs
// ������: �ߺ�
// ��������: 2008-11-24
// ����: ������������δ�ȡ���Ż�����Ϣ
// ----------------------------------------------------------------
using System.Collections.Generic;
using SmsDataContract;

namespace SqlServerDal.MessageDal
{
    public interface IMessageDal
    {
        void SaveSendMessage(SendMessageDataModel aMessage);
        void DeleteSendMessageByPkid(int pkid);
        List<SendMessageDataModel> GetSendMessageByStatus(SendStatusEnum theStatus);
        List<SendMessageDataModel> GetAllSendMessages();
        void DeleteAllSendMessage();

        void SaveReceiveMessage(ReceiveMessageDataModel aMessage);
        void DeleteReceiveMessageByPkid(int pkid);
        List<ReceiveMessageDataModel> GetReceiveMessageByStatus(bool broadCasted);
        List<ReceiveMessageDataModel> GetAllReceiveMessages();
        void DeleteAllReceiveMessage();
    }
}