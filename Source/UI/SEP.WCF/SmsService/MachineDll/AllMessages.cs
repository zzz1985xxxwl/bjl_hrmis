//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AllMessages.cs
// ������: �ߺ�
// ��������: 2008-11-21
// ����: ��Ϣ���ӣ����������Ϣ����ʷ
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
        /// �յ����㲥����Ϣ
        /// </summary>
        public List<ReceiveMessageDataModel> _ReceiveMessages
        {
            get
            {
                return _TheDal.GetReceiveMessageByStatus(false);
            }
        }
        /// <summary>
        /// �����͵Ķ���
        /// </summary>
        public List<SendMessageDataModel> _WaitSendMessages
        {
            get
            {
                return _TheDal.GetSendMessageByStatus(SendStatusEnum.ToBeSend);
            }
        }
        /// <summary>
        /// �����͵ķ���ʧ�ܵ���Ϣ
        /// </summary>
        public List<SendMessageDataModel> _FailedSendMessages
        {
            get
            {
                return _TheDal.GetSendMessageByStatus(SendStatusEnum.FailSendedToBeCallback);
            }
        }

        //��¼�����յ�����Ϣ
        public List<ReceiveMessageDataModel> _LogsForReceiveMessages
        {
            get
            {
                return _TheDal.GetAllReceiveMessages();
            }
        }
        //��¼���з��͹�����Ϣ
        public List<SendMessageDataModel> _LogsForWaitSendMessages
        {
            get
            {
                return _TheDal.GetAllSendMessages();
            }
        }
        //��¼���з��ͳɹ�����Ϣ
        public List<SendMessageDataModel> _LogsForSuccesssSendMessages
        {
            get
            {
                return _TheDal.GetSendMessageByStatus(SendStatusEnum.SuccessSended);
            }
        }
        //��¼���з���ʧ�ܵ���Ϣ
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
        /// ������н��ܵ��Ķ��ţ�����δ�ط��ģ�����
        /// </summary>
        public void ClearAllReceivedMessages()
        {
            _TheDal.DeleteAllReceiveMessage();
        }

        /// <summary>
        /// ������з��͵Ķ��ţ��������ͳɹ�/����ʧ��/�ȴ����͵Ķ��ţ�����
        /// </summary>
        public void ClearAllSendMessages()
        {
            _TheDal.DeleteAllSendMessage();
        }
    }
}