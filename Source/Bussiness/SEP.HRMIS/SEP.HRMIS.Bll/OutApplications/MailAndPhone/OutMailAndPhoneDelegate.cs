//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutMailAndPhoneDelegate.cs
// Creater:  Xue.wenlong
// Date:  2009-05-25
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OutApplications.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OutMailAndPhoneDelegate
    {
        private readonly OutApplicationMail _OutApplicationMail = new OutApplicationMail();
        private readonly OutApplicationPhone _OutApplicationPhone = new OutApplicationPhone();

        /// <summary>
        /// 发送提交邮件短信
        /// </summary>
        public void SubmitOperation(int outApplicationId, List<Account> cclist)
        {
            _OutApplicationMail.SendSubmitMail(outApplicationId, cclist);
            _OutApplicationPhone.SendSubmitPhone(outApplicationId);
        }

        /// <summary>
        /// 发送取消短信
        /// </summary>
        public void CancelOperation(int outApplicationId,int itemID)
        {
            _OutApplicationPhone.SendCancelPhone(outApplicationId, itemID);
        }
        /// <summary>
        ///  发送取消邮件
        /// </summary>
        /// <param name="outApplicationId"></param>
        public void CancelOperationMail(int outApplicationId)
        {
            _OutApplicationMail.SendCancelMail(outApplicationId);
        }
        /// <summary>
        /// 审核
        /// </summary>
        public void ConfirmOperation(int outApplicationID,int itemid, Account nextOperators, Account nowAccount)
        {
            _OutApplicationPhone.SendPhoneToNextOperator(outApplicationID,itemid, nextOperators, nowAccount);
            if(nextOperators==null)
            {
                _OutApplicationPhone.SendConfirmOverPhone(outApplicationID, itemid);
            }
        }

        /// <summary>
        /// 审核
        /// </summary>
        public void ConfirmOperationMail(int outApplicationID,  Account nextOperators, Account nowAccount)
        {
            _OutApplicationMail.SendMailToNextOperator(outApplicationID,  nextOperators);
            if (nextOperators == null)
            {
                _OutApplicationMail.SendConfirmOverMail(outApplicationID);
            }
        }
    }
}