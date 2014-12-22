//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ConfirmMessage.cs
// Creater:  Xue.wenlong
// Date:  2009-05-22
// Resume:
// ---------------------------------------------------------------

using System;
using System.Configuration;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.SMS;
using SEP.Model.Accounts;
using SmsDataContract;

namespace SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfirmMessage
    {
        //�ط����ŵ�����ʱ������Ĭ��Ϊ24Сʱ
        private static readonly string _ReSendMessageTimeSpan =
            ConfigurationManager.AppSettings["ReSendMessageTimeSpan"];

        private readonly ISendSMSBll _Sms = BllInstance.SendSMSBllInstance;
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private const double _DefaultTimeSpan = 24;
        //��̬����
        private static readonly IPhoneMessage _PhoneMessageDal = new PhoneMessageDal();

        private readonly HandleConfirm _HandelConfirm = new HandleConfirm();
        private readonly string _Format = "���ظ�1����ͬ�⣬0����ͬ�� �ո��д��ע";

        #region ������Ϣ

        /// <summary>
        /// �����µļӰ࣬�������ҵ��
        /// </summary>
        public void SendNewMessage(Account requester, Account assessor, string message,
                                   PhoneMessageType phoneMessageType)
        {
            assessor = _AccountBll.GetAccountById(assessor.Id);
            if (assessor.IsAcceptSMS)
            {
                PhoneMessage phoneMessage = new PhoneMessage();
                phoneMessage.Requester = requester;
                phoneMessage.Message = message;
                phoneMessage.PhoneMessageType = phoneMessageType;
                phoneMessage.Assessor = assessor;
                phoneMessage.Status = PhoneMessageStatus.ToBeSent;
                phoneMessage.Answer = "";
                phoneMessage.PKID = _PhoneMessageDal.InsertPhoneMessage(phoneMessage);
            }
            SendMessage();
        }

        /// <summary>
        /// ������Ϣ����һ�������
        /// </summary>
        public void SendConfirmMessage(Account nextassessor, PhoneMessageType phoneMessageType)
        {
            nextassessor = _AccountBll.GetAccountById(nextassessor.Id);
            if (nextassessor.IsAcceptSMS)
            {
                PhoneMessage phoneMessage = _PhoneMessageDal.GetPhoneMessageByType(phoneMessageType);
                phoneMessage.Assessor = nextassessor;
                phoneMessage.Status = PhoneMessageStatus.ToBeSent;
                _PhoneMessageDal.UpdatePhoneMessage(phoneMessage);
            }
            SendMessage();
        }

        /// <summary>
        /// ����ȡ������Ϣ
        /// </summary>
        public void SendCancelMessage(Account assessor, string message, PhoneMessageType phoneMessageType)
        {
            assessor = _AccountBll.GetAccountById(assessor.Id);
            if (assessor.IsAcceptSMS)
            {
                PhoneMessage phoneMessage = _PhoneMessageDal.GetPhoneMessageByType(phoneMessageType);
                phoneMessage.Assessor = assessor;
                phoneMessage.Message = message;
                phoneMessage.Status = PhoneMessageStatus.ToBeSent;
                _PhoneMessageDal.UpdatePhoneMessage(phoneMessage);
            }
            SendMessage();
        }


        private void SendMessage()
        {
            foreach (PhoneMessage phoneMessage in _PhoneMessageDal.GetNeedConfirmMessage())
            {
                SendCanSendMessage(phoneMessage);
            }
        }

        /// <summary>
        /// ���Ϳɱ����͵���Ϣ
        /// </summary>
        /// <param name="phoneMessage"></param>
        private void SendCanSendMessage(PhoneMessage phoneMessage)
        {
            if (CanSend(phoneMessage))
            {
                if (phoneMessage.Status == PhoneMessageStatus.ToBeSent)
                {
                    phoneMessage.Assessor = _AccountBll.GetAccountById(phoneMessage.Assessor.Id);
                    _Sms.SendOneMessage(
                        new SendMessageDataModel(phoneMessage.PKID, phoneMessage.Assessor.MobileNum,
                                                 phoneMessage.Message + _Format, SmsClientProcessCenter._HrmisId));
                    phoneMessage.Status = PhoneMessageStatus.ToBeConfirm;
                    phoneMessage.SendTime = DateTime.Now;
                    _PhoneMessageDal.UpdatePhoneMessage(phoneMessage);
                }
            }
        }

        /// <summary>
        /// �ж��Ƿ���Ա�����
        /// </summary>
        private static bool CanSend(PhoneMessage phonemessage)
        {
            return _PhoneMessageDal.CountToBeConfirmMessageWithSameAssessor(phonemessage.Assessor.Id) < 1;
        }

        #endregion

        #region ���յ���Ϣʱ��ҵ����

        /// <summary>
        /// ���յ���Ϣʱ��ҵ����
        /// </summary>
        public void ReceiveMessage(Account assessor, string message)
        {
            assessor = _AccountBll.GetAccountById(assessor.Id);
            string returnMessage;
            if (ValideMessage(message))
            {
                PhoneMessage phoneMessage =
                    _PhoneMessageDal.GetToBeConfirmPhoneMessageByAssessorID(assessor.Id);
                if (phoneMessage != null)
                {
                    //���������Ϣ����������Ϣ
                    if (phoneMessage.Assessor.Id == assessor.Id && phoneMessage.Status == PhoneMessageStatus.ToBeConfirm)
                    {
                        phoneMessage.Answer = message;
                        _PhoneMessageDal.UpdatePhoneMessage(phoneMessage);
                        HandleConfirmMessage(phoneMessage);
                        //ɾ������ļ�¼
                        _PhoneMessageDal.FinishPhoneMessageByPKID(phoneMessage.PKID);
                        //���ͱ���ͣ����Ϣ
                        SendMessage();
                    }
                }
                else
                {
                    returnMessage = "û��Ҫ����ļ�¼";
                    _Sms.SendOneMessage(
                        new SendMessageDataModel(-1, assessor.MobileNum, returnMessage, SmsClientProcessCenter._HrmisId));
                }
            }
            else
            {
                returnMessage = "��ʽ�������ٷ�һ��" + _Format;
                _Sms.SendOneMessage(
                    new SendMessageDataModel(-1, assessor.MobileNum, returnMessage, SmsClientProcessCenter._HrmisId));
            }
        }

        /// <summary>
        /// ��֤��ʽ
        /// </summary>
        private static bool ValideMessage(string message)
        {
            string operation = message.Split(' ')[0];
            if (operation == "1" || operation == "0")
            {
                return true;
            }
            return false;
        }

        private void HandleConfirmMessage(PhoneMessage phoneMessage)
        {
            _HandelConfirm.Excute(phoneMessage);
        }

        #endregion

        #region ����ʱ�����·��ͱ������Ķ��ţ��ݶ�Ϊ����24Сʱδ����Ķ��ű��ط�

        /// <summary>
        /// ����ʱ�����·��ͱ������Ķ��ţ��ݶ�Ϊ����24Сʱδ����Ķ��ű��ط�
        /// </summary>
        public void ReSendBlockMessage()
        {
            foreach (PhoneMessage phoneMessage in _PhoneMessageDal.GetToBeConfirmMessage())
            {
                if (phoneMessage.Status == PhoneMessageStatus.ToBeConfirm)
                {
                    DateTime sendTime;
                    sendTime = phoneMessage.SendTime == null
                                   ? Convert.ToDateTime("2008-11-1")
                                   : Convert.ToDateTime(phoneMessage.SendTime);
                    TimeSpan ts = DateTime.Now - sendTime;
                    if (ts.TotalHours >= GetReSendMessageTimeSpan())
                    {
                        _Sms.SendOneMessage(
                            new SendMessageDataModel(phoneMessage.PKID, phoneMessage.Assessor.MobileNum,
                                                     phoneMessage.Message + _Format, SmsClientProcessCenter._HrmisId));
                        phoneMessage.SendTime = DateTime.Now;
                        _PhoneMessageDal.UpdatePhoneMessage(phoneMessage);
                    }
                }
            }
        }

        private static double GetReSendMessageTimeSpan()
        {
            double retVal;
            if (!double.TryParse(_ReSendMessageTimeSpan, out retVal))
            {
                retVal = _DefaultTimeSpan;
            }
            return retVal;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void FinishPhoneMessageOperationByAssessorID(PhoneMessageType phoneMessageType, int assessorID)
        {
            PhoneMessage phoneMessage = _PhoneMessageDal.GetPhoneMessageByType(phoneMessageType);
            if (phoneMessage != null)
            {
                if (phoneMessage.Assessor.Id == assessorID)
                {
                    _PhoneMessageDal.FinishPhoneMessageByPKID(phoneMessage.PKID);
                }
            }

            SendMessage();
        }
        public void FinishPhoneMessageOperation(PhoneMessageType phoneMessageType)
        {
            PhoneMessage phoneMessage = _PhoneMessageDal.GetPhoneMessageByType(phoneMessageType);
            if (phoneMessage != null)
            {
              
              _PhoneMessageDal.FinishPhoneMessageByPKID(phoneMessage.PKID);
            }

            SendMessage();
        }

        ///// <summary>
        ///// ͨ�����ͺͶ�Ӧ��id��ɾ��message�������ҳ��˺�ɾ��
        ///// </summary>
        //public void DeletePhoneMessageByPhoneMessageType(PhoneMessageType phoneMessageType)
        //{
        //    PhoneMessage phoneMessage = _PhoneMessageDal.GetPhoneMessageByType(phoneMessageType);
        //    if (phoneMessage != null)
        //    {
        //        _PhoneMessageDal.FinishPhoneMessageByType(phoneMessageType);
        //    }
        //    //���ͱ���ͣ����Ϣ
        //    SendMessage();
        //}

        /// <summary>
        /// ͨ�����ͺͶ�Ӧ��id������phonemessage
        /// </summary>
        public PhoneMessage GetPhoneMessageByPhoneMessageType(PhoneMessageType phoneMessageType)
        {
            return _PhoneMessageDal.GetPhoneMessageByType(phoneMessageType);
        }
    }
}