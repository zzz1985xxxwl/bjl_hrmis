//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: BasicConfirm.cs
// Creater:  Xue.wenlong
// Date:  2009-05-25
// Resume:
// ---------------------------------------------------------------

using System;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.SMS;
using SmsDataContract;

namespace SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class BasicConfirm
    {
        protected static IAccountBll _AccountBll =BllInstance.AccountBllInstance;
        protected PhoneMessage _PhoneMessage;
       // private bool _IsSendApplicantMessage = true;
        private bool _IsSendAnswerMessage = false;//�����ͳɹ���Ϣ������
        protected readonly ISendSMSBll _Sms = BllInstance.SendSMSBllInstance;
        /// <summary>
        /// 
        /// </summary>
        public BasicConfirm(PhoneMessage phoneMessage)
        {
            _PhoneMessage = phoneMessage;
            _PhoneMessage.Assessor = _AccountBll.GetAccountById(_PhoneMessage.Assessor.Id);
        }


        ///// <summary>
        ///// �Ƿ�������˷��Ͷ���Ϣ
        ///// </summary>
        //public bool IsSendApplicantMessage
        //{
        //    get { return _IsSendApplicantMessage; }
        //    set { _IsSendApplicantMessage = value; }
        //}
        /// <summary>
        /// �Ƿ��Ͷ��Ÿ�����
        /// </summary>
        public bool IsSendAnswerMessage
        {
            get { return _IsSendAnswerMessage; }
            set { _IsSendAnswerMessage = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public PhoneMessage PhoneMessage
        {
            get { return _PhoneMessage; }
            set { _PhoneMessage = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Excute()
        {
            string expection = "";
            try
            {
                ExcuteSelf();
            }
            catch (ApplicationException ex)
            {
                //���ʹ���ʧ�ܶ���Ϣ
                expection = ex.Message;
                _Sms.SendOneMessage(new SendMessageDataModel(-1, _PhoneMessage.Assessor.MobileNum, ex.Message, SmsClientProcessCenter._HrmisId));
            }
            //���û���״���Ϣ������Ϊ�ɹ���ִ�гɹ�����
            if (string.IsNullOrEmpty(expection))
            {
               
                //�Ƿ��Ͷ��Ÿ�����
                if (IsSendAnswerMessage)
                {
                    try { SendManagerMessage(); }
                    catch { }
                }
                ////�����ʼ�
                //try{ SendMail();}
                //catch{}
            }
        }
        /// <summary>
        /// ����˽���������ݸ���
        /// </summary>
        protected virtual void ExcuteSelf()
        {
        }
        /// <summary>
        /// ��˽����ͬ���ͬ��
        /// </summary>
        public bool Operation
        {
            get
            {
                return _PhoneMessage.Answer.Split(' ')[0] == "1" ? true : false;
            }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        {
            get
            {
                try
                {
                    return _PhoneMessage.Answer.Replace(_PhoneMessage.Answer.Split(' ')[0], "").Trim();
                }
                catch
                {
                    return "";
                }
            }
        }


        ///// <summary>
        ///// ������˽����������
        ///// </summary>
        //protected virtual void SendApplicantMessage()
        //{
        //}
        /// <summary>
        /// ������˳ɹ����Ÿ�����
        /// </summary>
        protected virtual void SendManagerMessage()
        {
        }
    }
}