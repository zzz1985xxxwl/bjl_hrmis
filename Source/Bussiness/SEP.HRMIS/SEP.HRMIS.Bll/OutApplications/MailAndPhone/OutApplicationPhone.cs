//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutApplicationPhone.cs
// Creater:  Xue.wenlong
// Date:  2009-05-25
// Resume:
// ---------------------------------------------------------------

using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OutApplications.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OutApplicationPhone
    {
        private delegate void DelSendSubmitPhone(int outApplicationId);

        private delegate void DelSendPhoneUseID(int outApplicationID,int itemid);

        private delegate void DelSendPhoneToNextOperator(
           int outApplicationId,int itemid,Account nextOperator, Account nowAccount);

        /// <summary>
        /// 发送提交短信
        /// </summary>
        public void SendSubmitPhone(int outApplicationId)
        {
            DelSendSubmitPhone sendPhoneDelegate = SendSubmitPhoneF;
            sendPhoneDelegate.BeginInvoke(outApplicationId, null, null);
        }

        /// <summary>
        /// 发送取消短信
        /// </summary>
        public void SendCancelPhone(int outApplicationId,int itemID)
        {
            DelSendPhoneUseID sendPhoneDelegate = SendCancelPhoneF;
            sendPhoneDelegate.BeginInvoke(outApplicationId,itemID, null, null);
        }

        /// <summary>
        /// 发送短信给下一步处理人
        /// </summary>
        public void SendPhoneToNextOperator(int outApplicationId,int itemid,Account nextOperator, Account nowAccount)
        {
            DelSendPhoneToNextOperator sendPhoneDelegate = SendPhoneToNextOperatorF;
            sendPhoneDelegate.BeginInvoke(outApplicationId, itemid, nextOperator, nowAccount, null, null);
        }

        /// <summary>
        /// 发送审核结束短信
        /// </summary>
        public void SendConfirmOverPhone(int outApplicationID,int itemid)
        {
            DelSendPhoneUseID sendPhoneDelegate = SendConfirmOverPhoneF;
            sendPhoneDelegate.BeginInvoke(outApplicationID,itemid, null, null);
        }


        private static void SendSubmitPhoneF(int outApplicationId)
        {
            new OutSubmitPhone(outApplicationId).SendPhone();
        }

        private static void SendCancelPhoneF(int outApplicationID,int itemid)
        {
            new OutCancelPhone(outApplicationID, itemid).SendPhone();
        }

        private static void SendPhoneToNextOperatorF(int outApplicationID,int itemid, Account nextOperator,
                                                     Account nowAccount)
        {
            OutConfirmPhone confirmphone = new OutConfirmPhone(outApplicationID,itemid);
            confirmphone.SendPhoneToNextOperator(nextOperator, nowAccount);
        }

        private static void SendConfirmOverPhoneF(int outApplicationID,int itemid)
        {
            new OutOverPhone(outApplicationID, itemid).ConfirmOverPhone();
        }
    }
}