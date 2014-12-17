//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkMail.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.HRMIS.Bll.OverWorks.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OverWorkMail
    {
        private delegate void DelSendSubmitMail(int overWorkId, List<Account> cclist);

        private delegate void DelSendMailUseID(int overWorkID);

        private delegate void DelSendMailToNextOperator(int overWorkID,Account nextOperator);

        private delegate void DelErrorMail(int applicationID);

        /// <summary>
        /// 发送提交邮件
        /// </summary>
        public void SendSubmitMail(int overWorkId, List<Account> cclist)
        {
            DelSendSubmitMail sendMailDelegate = SendSubmitMailF;
            sendMailDelegate.BeginInvoke(overWorkId, cclist, null, null);
        }

        /// <summary>
        /// 发送取消邮件
        /// </summary>
        public void SendCancelMail(int overWorkId)
        {
            DelSendMailUseID sendMailDelegate = SendCancelMailF;
            sendMailDelegate.BeginInvoke(overWorkId,  null, null);
        }

        /// <summary>
        /// 发送邮件给下一步处理人
        /// </summary>
        public void SendMailToNextOperator(int overWorkId,  Account nextOperator)
        {
            DelSendMailToNextOperator sendMailDelegate = SendMailToNextOperatorF;
            sendMailDelegate.BeginInvoke(overWorkId,  nextOperator, null, null);
        }

        /// <summary>
        /// 发送审核结束邮件
        /// </summary>
        public void SendConfirmOverMail(int overWorkID)
        {
            DelSendMailUseID sendMailDelegate = SendConfirmOverMailF;
            sendMailDelegate.BeginInvoke(overWorkID, null, null);
        }

        /// <summary>
        /// </summary>
        public void SendErrorMail(int applicationID)
        {
            DelErrorMail sendMailDelegate = SendErrorMailF;
            sendMailDelegate.BeginInvoke(applicationID, null, null);
        }


        private static void SendSubmitMailF(int overWorkId, List<Account> cclist)
        {
            new OverWorkSubmitMail(overWorkId, cclist).SendMail();
        }

        private static void SendCancelMailF(int overWorkID)
        {
            new OverWorkCancelMail(overWorkID).SendMail();
        }

        private static void SendMailToNextOperatorF(int overWorkID, Account nextOperator)
        {
            new OverWorkConfirmMail(overWorkID).SendMailToNextOperator(nextOperator);
        }

        private static void SendConfirmOverMailF(int overWorkID)
        {
            new OverWorkOverMail(overWorkID).ConfirmOverMail();
        }

        private static void SendErrorMailF(int applicationID)
        {
            new OverWorkErrorMail(applicationID).Send();
        }

        #region 邮件公共方法

        /// <summary>
        /// 
        /// </summary>
        public static string BuildBody(OverWork overWork)
        {
            StringBuilder mailContent = new StringBuilder();
            mailContent.AppendFormat("加班员工：{0}", overWork.Account.Name);
            mailContent.Append("<br />");
            mailContent.AppendFormat("加班项目：{0}", overWork.ProjectName);
            mailContent.Append("<br />");
            mailContent.AppendFormat("加班理由：{0}", overWork.Reason);
            mailContent.Append("<br />");
            mailContent.AppendFormat("子项：");
            mailContent.Append("<br />");
            foreach (OverWorkItem item in overWork.Item)
            {
                mailContent.AppendFormat("从{0}到{1}，加班类型为{2}，加班{3}小时，状态为{4}", item.FromDate, item.ToDate,
                                         OverWorkUtility.GetOverWorkTypeName(item.OverWorkType), item.CostTime, RequestStatus.FindRequestStatus(item.Status.Id).Name);
                mailContent.Append("<br />");
            }
            return mailContent.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void BulidConfirmAddress(StringBuilder mailContent, Account to, int overWorkID)
        {
            string url =
                string.Format("{0}?accountId={1}&Id={2}", RequestUtility.OverWorkMailConfirmAddress(),
                              SecurityUtil.DECEncrypt(to.Id.ToString()),
                              SecurityUtil.DECEncrypt(overWorkID.ToString()));
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