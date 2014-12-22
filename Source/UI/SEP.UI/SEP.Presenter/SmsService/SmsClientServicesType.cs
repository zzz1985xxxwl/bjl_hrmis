//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: SmsClientServicesType.cs
// ������: xwl
// ��������: 2009-6-4
// ����: �˲��ִ�����Ҫ�޸ģ�������ϵͳ�յ���Ϣ����δ�������ʱ��������
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
        /// �ͻ����Ƿ���Ч
        /// </summary>
        public void ClientIsAvailable()
        {
           
        }
        /// <summary>
        /// ������״̬�ı�
        /// </summary>
        public void TheServiceStatusChanged(bool theStatus)
        {
            SmsClientProcessCenter.ReActiveTheService();
        }
        /// <summary>
        /// �ͻ��˽�����Ϣ
        /// </summary>
        public void ReceiveTheMessages(List<ReceiveMessageDataModel> theMessages)
        {
            foreach (ReceiveMessageDataModel aMessage in theMessages)
            {
                _ConfirmMesageFacade.ReceiveMessage(aMessage);
            }
            
        }
        /// <summary>
        /// ��Ϣ����ʧ��
        /// </summary>
        public void SendFailedMessages(SendMessageDataModel theFaildMessage)
        {
            _ConfirmMesageFacade.FailedSendMessageProcess(theFaildMessage);
        }

        /// <summary>
        /// �ɷ���������һ���첽���̴߳������¼�
        /// </summary>
        public void ClearBlockMessage()
        {
             _ConfirmMesageFacade.ReSendBlockMessage();
        }
    }
}