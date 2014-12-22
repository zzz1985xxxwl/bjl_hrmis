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
        //重法短信的设置时间间隔，默认为24小时
        private static readonly string _ReSendMessageTimeSpan =
            ConfigurationManager.AppSettings["ReSendMessageTimeSpan"];

        private readonly ISendSMSBll _Sms = BllInstance.SendSMSBllInstance;
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private const double _DefaultTimeSpan = 24;
        //静态变量
        private static readonly IPhoneMessage _PhoneMessageDal = new PhoneMessageDal();

        private readonly HandleConfirm _HandelConfirm = new HandleConfirm();
        private readonly string _Format = "，回复1代表同意，0代表不同意 空格后写备注";

        #region 发送消息

        /// <summary>
        /// 发送新的加班，外出，等业务
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
        /// 发送消息给下一个审核人
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
        /// 发送取消短消息
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
        /// 发送可被发送的消息
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
        /// 判断是否可以被发送
        /// </summary>
        private static bool CanSend(PhoneMessage phonemessage)
        {
            return _PhoneMessageDal.CountToBeConfirmMessageWithSameAssessor(phonemessage.Assessor.Id) < 1;
        }

        #endregion

        #region 当收到消息时的业务处理

        /// <summary>
        /// 当收到消息时的业务处理
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
                    //处理审核信息，并发送消息
                    if (phoneMessage.Assessor.Id == assessor.Id && phoneMessage.Status == PhoneMessageStatus.ToBeConfirm)
                    {
                        phoneMessage.Answer = message;
                        _PhoneMessageDal.UpdatePhoneMessage(phoneMessage);
                        HandleConfirmMessage(phoneMessage);
                        //删除处理的记录
                        _PhoneMessageDal.FinishPhoneMessageByPKID(phoneMessage.PKID);
                        //发送被暂停的消息
                        SendMessage();
                    }
                }
                else
                {
                    returnMessage = "没有要处理的记录";
                    _Sms.SendOneMessage(
                        new SendMessageDataModel(-1, assessor.MobileNum, returnMessage, SmsClientProcessCenter._HrmisId));
                }
            }
            else
            {
                returnMessage = "格式错误，请再发一次" + _Format;
                _Sms.SendOneMessage(
                    new SendMessageDataModel(-1, assessor.MobileNum, returnMessage, SmsClientProcessCenter._HrmisId));
            }
        }

        /// <summary>
        /// 验证格式
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

        #region 隔断时间重新发送被阻塞的短信，暂定为超过24小时未处理的短信被重发

        /// <summary>
        /// 隔断时间重新发送被阻塞的短信，暂定为超过24小时未处理的短信被重发
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
        ///// 通过类型和对应的id来删除message，针对网页审核后删除
        ///// </summary>
        //public void DeletePhoneMessageByPhoneMessageType(PhoneMessageType phoneMessageType)
        //{
        //    PhoneMessage phoneMessage = _PhoneMessageDal.GetPhoneMessageByType(phoneMessageType);
        //    if (phoneMessage != null)
        //    {
        //        _PhoneMessageDal.FinishPhoneMessageByType(phoneMessageType);
        //    }
        //    //发送被暂停的消息
        //    SendMessage();
        //}

        /// <summary>
        /// 通过类型和对应的id来查找phonemessage
        /// </summary>
        public PhoneMessage GetPhoneMessageByPhoneMessageType(PhoneMessageType phoneMessageType)
        {
            return _PhoneMessageDal.GetPhoneMessageByType(phoneMessageType);
        }
    }
}