//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SmsClientServicesType.cs
// 创建者: xwl
// 创建日期: 2009-6-4
// 概述: 此部分代码需要修改，各个子系统收到消息后如何处理现暂时放在这里
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Facade;
using SEP.HRMIS.IFacede;
using SEP.IBll.SMS;
using SmsDataContract;

namespace SEP.Presenter.SmsService
{
    public class SmsClientServicesType : ISmsClientContract
    {
        private readonly IConfirmMessageFacade _ConfirmMesageFacade = new ConfirmMessageFacade();
        /// <summary>
        /// 客户端是否有效
        /// </summary>
        public void ClientIsAvailable()
        {
           
        }
        /// <summary>
        /// 服务器状态改变
        /// </summary>
        public void TheServiceStatusChanged(bool theStatus)
        {
            SmsClientProcessCenter.ReActiveTheService();
        }
        /// <summary>
        /// 客户端接收消息
        /// </summary>
        public void ReceiveTheMessages(List<ReceiveMessageDataModel> theMessages)
        {
            foreach (ReceiveMessageDataModel aMessage in theMessages)
            {
                _ConfirmMesageFacade.ReceiveMessage(aMessage);
            }
            
        }
        /// <summary>
        /// 消息发送失败
        /// </summary>
        public void SendFailedMessages(SendMessageDataModel theFaildMessage)
        {
            _ConfirmMesageFacade.FailedSendMessageProcess(theFaildMessage);
        }

        /// <summary>
        /// 由服务器产生一个异步的线程触发该事件
        /// </summary>
        public void ClearBlockMessage()
        {
             _ConfirmMesageFacade.ReSendBlockMessage();
        }
    }
}