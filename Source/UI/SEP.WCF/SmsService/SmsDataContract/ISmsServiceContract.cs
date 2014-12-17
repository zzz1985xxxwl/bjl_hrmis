//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ISmsServiceContract.cs
// 创建者: 倪豪
// 创建日期: 2008-11-21
// 概述: 服务端提供的服务
// ----------------------------------------------------------------
using System.ServiceModel;

namespace SmsDataContract
{
    [ServiceContract]
    public interface ISmsServiceContract
    {
        /// <summary>
        /// 投递一条信息，等待发送
        /// </summary>
        /// <param name="aMessage"></param>
        [OperationContract(IsOneWay=true)]
        void SendOneMessage(SendMessageDataModel aMessage);

        /// <summary>
        /// 注册客户端
        /// </summary>
        /// <param name="clientListenAddress">客户端监听地址</param>
        /// <param name="clientId">Hrmis标识</param>
        /// <returns>回复消息分成下面3种：
        ///         1、"Pass" 证明客户端通过了验证
        ///         2、"Deny" 客户端是未认证的，既：没有注册信息或该记录的是否被认证字段变为false
        ///         3、"Failed" 客户端通过了认证，但是开放的端口无法访问</returns>
        [OperationContract]
        void RegisterSmsClient(string clientListenAddress,string clientId);

        /// <summary>
        /// 注销客户端服务
        /// </summary>
        /// <param name="clientListenAddrss">客户端监听地址</param>
        /// <param name="clientId">Hrmis标识</param>
        [OperationContract(IsOneWay = true)]
        void UnRegisterSmsClient(string clientListenAddrss,string clientId);
    }
}