//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkPhone.cs
// Creater:  Xue.wenlong
// Date:  2009-05-26
// Resume:
// ---------------------------------------------------------------

using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OverWorks.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OverWorkPhone
    {
        private delegate void DelSendSubmitPhone(int overWorkId);

        private delegate void DelSendPhoneUseID(int overWorkID,int itemID);

        private delegate void DelSendPhoneToNextOperator(
            int overWorkId,int itemID, Account nextOperator, Account nowOperator);

        /// <summary>
        /// 发送提交短信
        /// </summary>
        public void SendSubmitPhone(int overWorkId)
        {
            DelSendSubmitPhone sendPhoneDelegate = SendSubmitPhoneF;
            sendPhoneDelegate.BeginInvoke(overWorkId, null, null);
        }

        /// <summary>
        /// 发送取消短信
        /// </summary>
        public void SendCancelPhone(int overWorkId,int itemID)
        {
            DelSendPhoneUseID sendPhoneDelegate = SendCancelPhoneF;
            sendPhoneDelegate.BeginInvoke(overWorkId,itemID, null, null);
        }

        /// <summary>
        /// 发送短信给下一步处理人
        /// </summary>
        public void SendPhoneToNextOperator(int overWorkId,int itemID, Account nextOperators, Account nowOperator)
        {
            DelSendPhoneToNextOperator sendPhoneDelegate = SendPhoneToNextOperatorF;
            sendPhoneDelegate.BeginInvoke(overWorkId,itemID, nextOperators, nowOperator, null, null);
        }

        /// <summary>
        /// 发送审核结束短信
        /// </summary>
        public void SendConfirmOverPhone(int overWorkID,int itemID)
        {
            DelSendPhoneUseID sendPhoneDelegate = SendConfirmOverPhoneF;
            sendPhoneDelegate.BeginInvoke(overWorkID,itemID, null, null);
        }


        private static void SendSubmitPhoneF(int overWorkId)
        {
            new OverWorkSubmitPhone(overWorkId).SendPhone();
        }

        private static void SendCancelPhoneF(int overWorkID,int itemID)
        {
            new OverWorkCancelPhone(overWorkID,itemID).SendPhone();
        }

        private static void SendPhoneToNextOperatorF(int overWorkID,int itemID, Account nextOperator, Account nowOperator)
        {
            OverWorkConfirmPhone overWorkConfirmPhone = new OverWorkConfirmPhone(overWorkID,itemID);
            overWorkConfirmPhone.SendPhoneToNextOperator(nextOperator, nowOperator);     
        }

        private static void SendConfirmOverPhoneF(int overWorkID,int itemID)
        {
            new OverWorkOverPhone(overWorkID,itemID).ConfirmOverPhone();
        }
    }
}