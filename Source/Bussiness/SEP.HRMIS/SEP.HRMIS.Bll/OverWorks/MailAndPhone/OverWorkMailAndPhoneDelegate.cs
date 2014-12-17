//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkMailAndPhoneDelegate.cs
// Creater:  Xue.wenlong
// Date:  2009-05-26
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OverWorks.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OverWorkMailAndPhoneDelegate
    {
        private readonly OverWorkMail _OverWorkMail = new OverWorkMail();
        private readonly OverWorkPhone _OverWorkPhone = new OverWorkPhone();

        /// <summary>
        /// 发送提交邮件短信
        /// </summary>
        public void SubmitOperation(int overWorkId, List<Account> cclist)
        {
            _OverWorkMail.SendSubmitMail(overWorkId, cclist);
            _OverWorkPhone.SendSubmitPhone(overWorkId);
        }

        /// <summary>
        /// 发送取消短信
        /// </summary>
        public void CancelOperation(int overWorkId,int itemID)
        {
           
            _OverWorkPhone.SendCancelPhone(overWorkId,itemID);
        }
        /// <summary>
        /// 发送取消邮件
        /// </summary>
        public void CancelOperationMail(int overWorkId)
        {
            _OverWorkMail.SendCancelMail(overWorkId);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ConfirmOperation(int overWorkID,int itemID,Account nextOperators,Account nowOperator)
        {

            _OverWorkPhone.SendPhoneToNextOperator(overWorkID,itemID, nextOperators, nowOperator);
            if (nextOperators == null)
            {
                _OverWorkPhone.SendConfirmOverPhone(overWorkID,itemID);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ConfirmOperationMail(int overWorkID,  Account nextOperators, Account nowOperator)
        {
            _OverWorkMail.SendMailToNextOperator(overWorkID, nextOperators);
            if (nextOperators == null)
            {
                _OverWorkMail.SendConfirmOverMail(overWorkID);
            }
        }
    }
}