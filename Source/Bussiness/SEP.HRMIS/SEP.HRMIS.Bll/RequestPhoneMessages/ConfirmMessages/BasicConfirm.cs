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
        private bool _IsSendAnswerMessage = false;//不发送成功消息给主管
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
        ///// 是否给申请人发送短消息
        ///// </summary>
        //public bool IsSendApplicantMessage
        //{
        //    get { return _IsSendApplicantMessage; }
        //    set { _IsSendApplicantMessage = value; }
        //}
        /// <summary>
        /// 是否发送短信给主管
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
                //发送处理失败短消息
                expection = ex.Message;
                _Sms.SendOneMessage(new SendMessageDataModel(-1, _PhoneMessage.Assessor.MobileNum, ex.Message, SmsClientProcessCenter._HrmisId));
            }
            //如果没有抛错信息，则认为成功，执行成功操作
            if (string.IsNullOrEmpty(expection))
            {
               
                //是否发送短信给主管
                if (IsSendAnswerMessage)
                {
                    try { SendManagerMessage(); }
                    catch { }
                }
                ////发送邮件
                //try{ SendMail();}
                //catch{}
            }
        }
        /// <summary>
        /// 对审核结果进行数据更新
        /// </summary>
        protected virtual void ExcuteSelf()
        {
        }
        /// <summary>
        /// 审核结果，同意或不同意
        /// </summary>
        public bool Operation
        {
            get
            {
                return _PhoneMessage.Answer.Split(' ')[0] == "1" ? true : false;
            }
        }
        /// <summary>
        /// 备注
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
        ///// 发送审核结果给申请人
        ///// </summary>
        //protected virtual void SendApplicantMessage()
        //{
        //}
        /// <summary>
        /// 发送审核成功短信给主管
        /// </summary>
        protected virtual void SendManagerMessage()
        {
        }
    }
}