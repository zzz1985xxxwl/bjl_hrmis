//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ReceivedMessageFacade.cs
// Creater:  Xue.wenlong
// Date:  2009-05-25
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.Bll.LeaveRequestTypes;
using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;
using SEP.HRMIS.Bll.RequestPhoneMessages.RequestMessages;
using SEP.IBll;
using SEP.IBll.SMS;
using SEP.Model.Accounts;
using SmsDataContract;

namespace SEP.HRMIS.Bll.RequestPhoneMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class ReceivedMessageFacade
    {
        private readonly ISendSMSBll _Sms = BllInstance.SendSMSBllInstance;
        /// <summary>
        /// �յ��ύ�����Ϣ�󣬴������Ϣ
        /// </summary>
        public void LeaveRequestMessageExcute(Account employee, ReceiveMessageDataModel message)
        {
            new LeaveRequestMessage(employee, message).Excute();
        }

        /// <summary>
        /// �յ��ύ�����Ϣ�󣬴������Ϣ
        /// </summary>
        public void OutMessageExcute(Account employee, ReceiveMessageDataModel message)
        {
            new OutApplicationMessage(employee, message).Excute();
        }

        /// <summary>
        /// �յ��ύ��ѵ�����Ϣ�󣬴������Ϣ
        /// </summary>
        public void OutTrainMessageExcute(Account employee, ReceiveMessageDataModel message)
        {
           new OutTrainApplicationMessage(employee, message).Excute();
        }
        /// <summary>
        /// �յ��ύ������Ϣ�󣬴������Ϣ
        /// </summary>
        public void OutCityMessageExcute(Account employee, ReceiveMessageDataModel message)
        {
            new OutCityApplicationMessage(employee, message).Excute();
        }
        /// <summary>
        /// �յ��ύ�Ӱ���Ϣ�󣬴������Ϣ
        /// </summary>
        public void OverWorkMessageExcute(Account employee, ReceiveMessageDataModel message)
        {
            new OverWorkMessage(employee, message).Excute();
        }

        /// <summary>
        /// �յ������Ϣ�󣬴������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message">�ֻ�����</param>
        public void ConfirmMessageExcute(Account sender, string message)
        {
            new ConfirmMessage().ReceiveMessage(sender, message);
        }

        /// <summary>
        /// ������������ҵ�񣬷������еķ�����Ŀ
        /// </summary>
        /// <param name="number">�ֻ�����</param>
        public void SelfServiceExcute(string number)
        {
            _Sms.SendOneMessage(new SendMessageDataModel(-1, number,
                                                             "�����Է�������ָ��:��Ҫ��ٻ�wyqj;��Ҫ�Ӱ��wyjb;��Ҫ�����wywc;��Ҫ�����wycc;��Ҫ�����ѵ��wywcpx;������ͻ�qjlx",
                                                             SmsClientProcessCenter._HrmisId));
        }

        /// <summary>
        /// ������Ҫ���ҵ�񣬷�����ٸ�ʽ��ģ��
        /// </summary>
        /// <param name="number">�ֻ�����</param>
        public void LeaveRequestServiceExcute(string number)
        {
            _Sms.SendOneMessage(new SendMessageDataModel(-1, number, LeaveRequestMessage.TemplageAndExample,
                                                             SmsClientProcessCenter._HrmisId));
        }

        /// <summary>
        /// ������Ҫ���ҵ�񣬷��������ʽ��ģ��
        /// </summary>
        /// <param name="number">�ֻ�����</param>
        public void OutServiceExcute(string number)
        {
            _Sms.SendOneMessage(new SendMessageDataModel(-1, number, OutApplicationMessage.TemplageAndExample,
                                                             SmsClientProcessCenter._HrmisId));
        }

        /// <summary>
        /// ������Ҫ��ѵ���ҵ�񣬷��������ʽ��ģ��
        /// </summary>
        /// <param name="number">�ֻ�����</param>
        public void OutTrainServiceExcute(string number)
        {
            _Sms.SendOneMessage(new SendMessageDataModel(-1, number, OutTrainApplicationMessage.TemplageAndExample,
                                                             SmsClientProcessCenter._HrmisId));
        }

        /// <summary>
        /// ������Ҫ����ҵ�񣬷��������ʽ��ģ��
        /// </summary>
        /// <param name="number">�ֻ�����</param>
        public void OutCityServiceExcute(string number)
        {
            _Sms.SendOneMessage(new SendMessageDataModel(-1, number, OutCityApplicationMessage.TemplageAndExample,
                                                             SmsClientProcessCenter._HrmisId));
        }

        /// <summary>
        /// ������Ҫ�Ӱ�ҵ�񣬷��ؼӰ��ʽ��ģ��
        /// </summary>
        /// <param name="number">�ֻ�����</param>
        public void OverWorkServiceExcute(string number)
        {
            _Sms.SendOneMessage(new SendMessageDataModel(-1, number, OverWorkMessage.TemplageAndExample,
                                                             SmsClientProcessCenter._HrmisId));
        }

        /// <summary>
        /// �����������ҵ�񣬷������е��������
        /// </summary>
        /// <param name="number">�ֻ�����</param>
        public void LeaveRequestTypeServiceExcute(string number)
        {
            _Sms.SendOneMessage(new SendMessageDataModel(-1, number,new GetLeaveRequestType().GetAllLeaveTypeNames(),
                                                             SmsClientProcessCenter._HrmisId));
        }

    }
}