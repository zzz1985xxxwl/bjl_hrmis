//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AllMessages.cs
// 创建者: 倪豪
// 创建日期: 2008-11-21
// 概述: 消息箱子，存放所有消息与历史
// ----------------------------------------------------------------
using System.Collections.Generic;
using SmsDataContract;
using SqlServerDal.MessageDal;

namespace MachineDll
{
    public class AllMessages
    {
        private readonly IMessageDal _TheDal;

        public AllMessages(IMessageDal thDal)
        {
            _TheDal = thDal;
        }

        /// <summary>
        /// 收到待广播的消息
        /// </summary>
        public List<ReceiveMessageDataModel> _ReceiveMessages
        {
            get
            {
                return _TheDal.GetReceiveMessageByStatus(false);
            }
        }
        /// <summary>
        /// 待发送的队列
        /// </summary>
        public List<SendMessageDataModel> _WaitSendMessages
        {
            get
            {
                return _TheDal.GetSendMessageByStatus(SendStatusEnum.ToBeSend);
            }
        }
        /// <summary>
        /// 待回送的发送失败的消息
        /// </summary>
        public List<SendMessageDataModel> _FailedSendMessages
        {
            get
            {
                return _TheDal.GetSendMessageByStatus(SendStatusEnum.FailSendedToBeCallback);
            }
        }

        //记录所有收到的消息
        public List<ReceiveMessageDataModel> _LogsForReceiveMessages
        {
            get
            {
                return _TheDal.GetAllReceiveMessages();
            }
        }
        //记录所有发送过的消息
        public List<SendMessageDataModel> _LogsForWaitSendMessages
        {
            get
            {
                return _TheDal.GetAllSendMessages();
            }
        }
        //记录所有发送成功的消息
        public List<SendMessageDataModel> _LogsForSuccesssSendMessages
        {
            get
            {
                return _TheDal.GetSendMessageByStatus(SendStatusEnum.SuccessSended);
            }
        }
        //记录所有发送失败的消息
        public List<SendMessageDataModel> _LogsForFailedSendMessages
        {
            get
            {
                List<SendMessageDataModel> retVal = new List<SendMessageDataModel>();
                retVal.AddRange(_TheDal.GetSendMessageByStatus(SendStatusEnum.FailSendedCallbacked));
                retVal.AddRange(_TheDal.GetSendMessageByStatus(SendStatusEnum.FailSendedToBeCallback));

                return retVal;
            }
        }

        public void EnqueueReceiveMessage(ReceiveMessageDataModel aMessage)
        {
            _TheDal.SaveReceiveMessage(aMessage);
        }

        public void EnqueueWaitMessage(SendMessageDataModel aMessage)
        {
            aMessage.TheStatus = SendStatusEnum.ToBeSend;
            _TheDal.SaveSendMessage(aMessage);
        }

        public void EnqueueSuccessMessage(SendMessageDataModel aMessage)
        {
            aMessage.TheStatus = SendStatusEnum.SuccessSended;
            _TheDal.SaveSendMessage(aMessage);
        }

        public void EnqueueFailedMessage(SendMessageDataModel aMessage)
        {
            aMessage.TheStatus = SendStatusEnum.FailSendedToBeCallback;
            _TheDal.SaveSendMessage(aMessage);
        }

        public void EnqueueFaildMessageCallBacked(SendMessageDataModel aMessage)
        {
            aMessage.TheStatus = SendStatusEnum.FailSendedCallbacked;
            _TheDal.SaveSendMessage(aMessage);
        }

        /// <summary>
        /// 清空所有接受到的短信，包括未回发的，慎用
        /// </summary>
        public void ClearAllReceivedMessages()
        {
            _TheDal.DeleteAllReceiveMessage();
        }

        /// <summary>
        /// 清空所有发送的短信，包括发送成功/发送失败/等待发送的短信，慎用
        /// </summary>
        public void ClearAllSendMessages()
        {
            _TheDal.DeleteAllSendMessage();
        }
    }
}