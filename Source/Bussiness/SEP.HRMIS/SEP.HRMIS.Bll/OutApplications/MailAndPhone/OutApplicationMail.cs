//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutApplicationMail.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.HRMIS.Bll.OutApplications.MailAndPhone
{
    /// <summary>
    /// </summary>
    public class OutApplicationMail
    {
        private delegate void DelSendSubmitMail(int outApplicationId, List<Account> cclist);

        private delegate void DelSendCancelMail(int outApplicationID);

        private delegate void DelSendMailToNextOperator(int outApplicationID, Account nextOperator);

        private delegate void DelErrorMail(int applicationID);

        /// <summary>
        /// 发送提交邮件
        /// </summary>
        public void SendSubmitMail(int outApplicationId, List<Account> cclist)
        {
            DelSendSubmitMail sendMailDelegate = SendSubmitMailF;
            sendMailDelegate.BeginInvoke(outApplicationId, cclist, null, null);
        }

        /// <summary>
        /// 发送取消邮件
        /// </summary>
        public void SendCancelMail(int outApplicationId)
        {
            DelSendCancelMail sendMailDelegate = SendCancelMailF;
            sendMailDelegate.BeginInvoke(outApplicationId, null, null);
        }

        /// <summary>
        /// 发送邮件给下一步处理人
        /// </summary>
        public void SendMailToNextOperator(int outApplicationId, Account nextOperator)
        {

            DelSendMailToNextOperator sendMailDelegate = SendMailToNextOperatorF;
            sendMailDelegate.BeginInvoke(outApplicationId, nextOperator, null, null);
        }

        /// <summary>
        /// 发送审核结束邮件
        /// </summary>
        public void SendConfirmOverMail(int outApplicationID)
        {
            DelSendCancelMail sendMailDelegate = SendConfirmOverMailF;
            sendMailDelegate.BeginInvoke(outApplicationID,  null, null);
        }

        /// <summary>
        /// </summary>
        public void SendErrorMail(int applicationID)
        {
            DelErrorMail sendMailDelegate = SendErrorMailF;
            sendMailDelegate.BeginInvoke( applicationID,  null, null);
        }

        private static void SendSubmitMailF(int outApplicationId, List<Account> cclist)
        {
            new OutSubmitMail(outApplicationId, cclist).SendMail();
        }

        private static void SendCancelMailF(int outApplicationID)
        {
            new OutCancelMail(outApplicationID).SendMail();
        }

        private static void SendMailToNextOperatorF(int outApplicationID, Account nextOperator)
        {
            new OutConfirmMail(outApplicationID).SendMailToNextOperator(nextOperator);
        }

        private static void SendConfirmOverMailF(int outApplicationID)
        {
            new OutOverMail(outApplicationID).ConfirmOverMail();
        }
        private static void SendErrorMailF( int applicationID)
        {
            new OutErrorMail(applicationID).Send();
        }
        #region 邮件公共方法

        /// <summary>
        /// 
        /// </summary>
        public static string BuildBody(OutApplication outApplication)
        {
            StringBuilder mailContent = new StringBuilder();
            mailContent.AppendFormat("外出员工：{0}", outApplication.Account.Name);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("外出地点：{0}", outApplication.OutLocation);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("外出理由：{0}", outApplication.Reason);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("子项：");
            mailContent.Append("<br />");
            foreach (OutApplicationItem item in outApplication.Item)
            {
                mailContent.AppendFormat("从{0}到{1}，外出{2}小时，状态为{3}", item.FromDate, item.ToDate, item.CostTime, RequestStatus.FindRequestStatus(item.Status.Id).Name);
                mailContent.Append("<br />");
            }
            return mailContent.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void BulidConfirmAddress(StringBuilder mailContent, Account to, int outApplicationID)
        {
            string url =
                string.Format("{0}?accountId={1}&Id={2}", RequestUtility.OutMailConfirmAddress(),
                              SecurityUtil.DECEncrypt(to.Id.ToString()),
                              SecurityUtil.DECEncrypt(outApplicationID.ToString()));
            mailContent.Append(
                "您可点击 <a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>同意</a> 快速审批<br/>");
            mailContent.Append("您也可以点击以下链接快速审批通过：<br/>");
            mailContent.Append("<a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>" + url +
                               "</a><br/>");
            mailContent.Append("如果您不通过此申请，可登录以下网址进行审批<br/>");
        }

 

        #endregion

    }
}