//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IMessageDal.cs
// 创建者: 倪豪
// 创建日期: 2008-11-24
// 概述: 该类描述了如何存取短信机的信息
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