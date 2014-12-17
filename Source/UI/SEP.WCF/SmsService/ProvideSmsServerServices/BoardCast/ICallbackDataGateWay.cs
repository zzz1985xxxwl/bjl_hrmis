//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ICallbackDataGateWay.cs
// 创建者: 倪豪
// 创建日期: 2008-12-2
// 概述:  短信机回送数据的关口,该接口用于解除短信机与地址管理的耦合
// ----------------------------------------------------------------
using System.Collections.Generic;
using SmsDataContract;

namespace ProvideSmsServerServices.BoardCast
{
    public interface ICallbackDataGateWay
    {
        /// <summary>
        /// 回送接收到的数据
        /// </summary>
        /// <param name="messagesTobeSended"></param>
        void OnReceivedMessages(List<ReceiveMessageDataModel> messagesTobeSended);
        /// <summary>
        /// 回送发送失败的数据
        /// </summary>
        void OnSendFailedMessages(SendMessageDataModel failedMessage);
        /// <summary>
        /// 回送短信服务即将关闭的数据
        /// </summary>
        void OnStopServer();
    }
}