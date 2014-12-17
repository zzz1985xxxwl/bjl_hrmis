//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ISmsClientContract.cs
// 创建者: 倪豪
// 创建日期: 2008-11-21
// 概述: 客户端提供的服务
// ----------------------------------------------------------------
using System.Collections.Generic;
using System.ServiceModel;

namespace SmsDataContract
{
    [ServiceContract]
    public interface ISmsClientContract
    {
        /// <summary>
        /// 客户端是否有效
        /// </summary>
        [OperationContract]
        void ClientIsAvailable();
        /// <summary>
        /// 服务器状态改变
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void TheServiceStatusChanged(bool theStatus);
        /// <summary>
        /// 客户端接收消息
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void ReceiveTheMessages(List<ReceiveMessageDataModel> theMessages);
        /// <summary>
        /// 消息发送失败
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void SendFailedMessages(SendMessageDataModel theFaildMessage);
        /// <summary>
        /// 由服务器启动一个异步的线程执行清除卡住的消息的任务
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void ClearBlockMessage();
    }
}