//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ISmsControllerContract.cs
// 创建者: 倪豪
// 创建日期: 2008-11-21
// 概述: 服务端提供的控制功能
// ----------------------------------------------------------------
using System.Collections.Generic;
using System.ServiceModel;
using SmsControlContract.ClientAddressModels;
using SmsDataContract;

namespace SmsControlContract
{
    [ServiceContract]
    public interface ISmsControllerContract
    {
        /// <summary>
        /// 投递短信(加入到发送队列)
        /// </summary>
        [OperationContract]
        void DelieveAMessage(SendMessageDataModel aMessage);

        //--------------------------------------
        //  串口命令
        //--------------------------------------

        /// <summary>
        /// 串口状态
        /// </summary>
        [OperationContract]
        bool GetPortStatus();
        /// <summary>
        /// 打开串口
        /// </summary>
        [OperationContract]
        void StartConnection();
        /// <summary>
        /// 停止串口
        /// </summary>
        [OperationContract]
        void StopConnection();

        //--------------------------------------
        //  机器命令
        //--------------------------------------

        /// <summary>
        /// 短信收发线程状态
        /// </summary>
        [OperationContract]
        bool GetWorkThreadStatus();
        /// <summary>
        /// 打开收发短信线程
        /// </summary>
        [OperationContract]
        void StartTheSmsThread();
        /// <summary>
        /// 关闭收发短信线程
        /// </summary>
        [OperationContract]
        void StopTheSmsThread();
        /// <summary>
        /// 广播信息状态
        /// </summary>
        [OperationContract]
        bool GetTheBoardStatus();
        /// <summary>
        /// 设置是否要开始广播信息
        /// </summary>
        [OperationContract]
        void SetTheBoardStatus(bool status);
        /// <summary>
        /// 测试机器，并设置机器为PDU编码(可发中文短信方式)工作，会停止短信线程
        /// </summary>
        [OperationContract]
        bool TestMachine();
        /// <summary>
        /// at命令
        /// </summary>
        /// <param name="commandText">命令的asc2码</param>
        /// <param name="waitReplayMillionSeconds">读取等待时间，考虑机器特性，最好等待5000以上时间</param>
        [OperationContract]
        string SendCommand(string commandText, int waitReplayMillionSeconds);

        //--------------------------------------
        //  短信命令
        //--------------------------------------

        /// <summary>
        /// 同步发送短信
        /// </summary>
        [OperationContract]
        bool SendAMessage(SendMessageDataModel aMessage);
        /// <summary>
        /// 同步接收所有短信
        /// </summary>
        [OperationContract]
        void ReceiveAllMessage();
        /// <summary>
        /// 发送余额查询短信
        /// </summary>
        [OperationContract]
        void SendSearchMoneyMessage();

        //--------------------------------------
        //  消息源历史
        //--------------------------------------

        /// <summary>
        /// 收到的消息队列
        /// </summary>
        [OperationContract]
        List<ReceiveMessageDataModel> GetLogsForReceiveMessages();
        /// <summary>
        /// 等待发送的消息队列
        /// </summary>
        [OperationContract]
        List<SendMessageDataModel> GetLogsForWaitSendMessages();
        /// <summary>
        ///  发送成功的消息
        /// </summary>
        [OperationContract]
        List<SendMessageDataModel> GetLogsForSuccesssSendMessages();
        /// <summary>
        ///   发送失败的消息
        /// </summary>
        [OperationContract]
        List<SendMessageDataModel> GetLogsForFailedSendMessages();
        /// <summary>
        /// 删除所有接受到的短信，包括未回送的，慎用
        /// </summary>
        [OperationContract]
        void ClearAllReceivedMessages();
        /// <summary>
        /// 清空所有发送的短信，包括发送成功/发送失败/等待发送的短信，慎用
        /// </summary>
        [OperationContract]
        void ClearAllSendMessages();

        //--------------------------------------
        //  注册中心
        //--------------------------------------

        /// <summary>
        /// 通过Id获取客户信息
        /// </summary>
        [OperationContract]
        ClientInformationModel GetClientAddressModelById(int id);
        /// <summary>
        /// 通过客户信息标示获取地址信息列表
        /// </summary>
        [OperationContract]
        List<ListenAddressModel> GetListenAddressModelsByClientId(int clientInformationId);
        /// <summary>
        /// 获取所有的客户信息
        /// </summary>
        [OperationContract]
        List<ClientInformationModel> GetAllClientAddressModel();
        /// <summary>
        /// 激活客户信息的通道
        /// </summary>
        [OperationContract]
        void ActiveTheClientInformation(int clientInformationId);
        /// <summary>
        /// 封闭客户信息的通道
        /// </summary>
        [OperationContract]
        void DisableTheClientInformation(int clientInformationId);
        /// <summary>
        /// 激活监听地址的通道
        /// </summary>
        [OperationContract]
        void ActiveTheListenAddress(int clientInformationid, int listenAddressId);
        /// <summary>
        /// 封闭监听地址的通道
        /// </summary>
        [OperationContract]
        void DisableTheListenAddress(int clientInformationid, int listenAddressId);
        /// <summary>
        /// 增加一个激活的客户信息
        /// </summary>
        [OperationContract]
        void AddActivedClientInformation(string hrmisId, string companyDescription);
        /// <summary>
        /// 描述一个客户信息
        /// </summary>
        [OperationContract]
        void DescriptClientInformation(int clientInformationId, string description);
        /// <summary>
        /// 联系每一个客户，察看该客户是否依然激活
        /// </summary>
        [OperationContract]
        void ClearBlockMessages();
    }
}
