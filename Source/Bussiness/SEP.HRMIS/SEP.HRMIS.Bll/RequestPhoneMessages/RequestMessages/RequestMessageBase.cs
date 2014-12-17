//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: RequestMessageBase.cs
// Creater:  Xue.wenlong
// Date:  2009-05-31
// Resume:
// ---------------------------------------------------------------

using System;
using SEP.IBll;
using SEP.IBll.SMS;
using SEP.Model.Accounts;
using SmsDataContract;

namespace SEP.HRMIS.Bll.RequestPhoneMessages.RequestMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestMessageBase
    {
        protected ISendSMSBll _Sms = BllInstance.SendSMSBllInstance;
        protected readonly ReceiveMessageDataModel _Message;
        protected readonly Account _Account;
        protected DateTime _From;
        protected DateTime _To;
        protected string _Reason;
        private SendMessageDataModel _SendMessageDataModel;

        protected virtual string GetTemplageAndExample()
        {
            return string.Empty;
        }

        protected RequestMessageBase(Account account, ReceiveMessageDataModel message)
        {
            _Account = account;
            _Message = message;
        }

        #region 判断短信格式并赋值

        protected virtual bool ValidationAndInit()
        {
            return true;
        }

        protected bool InitReason(string reason)
        {
            _Reason = reason;
            return true;
        }

        protected bool ValidateAndInitFromTo(string from, string to)
        {
            if (!(ValidateAndInitFrom(from) && ValidateAndInitTo(to)))
            {
                return false;
            }
            else if (_From > _To)
            {
                return false;
            }
            return true;
        }

        protected bool ValidateAndInitFrom(string from)
        {
            DateTime? dt = RequestMessageUtility.GetDateTime(from);
            if (dt == null)
            {
                return false;
            }
            else
            {
                _From = Convert.ToDateTime(dt);
                return true;
            }
        }

        protected bool ValidateAndInitTo(string to)
        {
            DateTime? dt = RequestMessageUtility.GetDateTime(to);
            if (dt == null)
            {
                return false;
            }
            else
            {
                _To = Convert.ToDateTime(dt);
                return true;
            }
        }

        #endregion

        protected virtual void ExcuteSelf()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public void Excute()
        {
            string returnmessage;
            if (ValidationAndInit())
            {
                try
                {
                    ExcuteSelf();
                    returnmessage = "提交成功，等待被审核";
                }
                catch (ApplicationException ex)
                {
                    returnmessage = ex.Message;
                }
                catch
                {
                    returnmessage = "提交失败，请联系管理员";
                }
            }
            else
            {
                returnmessage = string.Format("格式错误，{0}", GetTemplageAndExample());
            }
            _SendMessageDataModel =
                new SendMessageDataModel(-1, _Message.TheNumber, returnmessage, SmsClientProcessCenter._HrmisId);
            _Sms.SendOneMessage(_SendMessageDataModel);
        }
    }
}