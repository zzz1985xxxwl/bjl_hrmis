using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.HRMIS.Bll.LeaveRequests.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class LeaveRequestMail
    {
        private delegate void DelSendSubmitMail(int leaveRequestID, List<Account> cclist, List<Account> diyProcesslist, DiyStep nextStep);

        //private delegate void DelSendMailUseID(int leaveRequestID, LeaveRequestItem item, List<Account> diyProcessAccountlist, DiyStep nextStep);
        private delegate void DelSendCancelMailUseID(int leaveRequestID,  List<Account> diyProcessAccountlist, DiyStep nextStep);

        private delegate void DelSendMailToNextOperator(int leaveRequestID,  Account nextOperator);

        /// <summary>
        /// 发送提交邮件
        /// </summary>
        public void SendSubmitMail(int leaveRequestID, List<Account> cclist, List<Account> diyProcesslist, DiyStep nextStep)
        {
            DelSendSubmitMail sendMailDelegate = SendSubmitMailF;
            sendMailDelegate.BeginInvoke(leaveRequestID, cclist, diyProcesslist,nextStep, null, null);
        }

        private static void SendSubmitMailF(int leaveRequestID, List<Account> cclist, List<Account> diyProcesslist, DiyStep nextStep)
        {
            new LeaveRequestSubmitMail(leaveRequestID, cclist, diyProcesslist, nextStep).SendMail();
        }

        /// <summary>
        /// 发送取消邮件
        /// </summary>
        public void SendCancelMail(int leaveRequestID,  List<Account> diyProcessAccountlist, DiyStep nextStep)
        {
            DelSendCancelMailUseID sendMailDelegate = SendCancelMailF;
            sendMailDelegate.BeginInvoke(leaveRequestID, diyProcessAccountlist, nextStep, null, null);
        }

        private static void SendCancelMailF(int leaveRequestID,  List<Account> diyProcessAccountlist, DiyStep nextStep)
        {
            new LeaveRequestCancelMail(leaveRequestID,  diyProcessAccountlist, nextStep).SendMail();
        }

        /// <summary>
        /// 
        /// </summary>
        public static string BuildBody(LeaveRequest leaveRequest)
        {
            StringBuilder mailContent = new StringBuilder();
            mailContent.AppendFormat("{0}", leaveRequest.Account.Name);
            mailContent.AppendFormat("请{0}", leaveRequest.LeaveRequestType.Name);
            mailContent.AppendFormat("共{0}小时，", leaveRequest.CostTime);
            mailContent.AppendFormat("从{0}到{1}，", leaveRequest.FromDate, leaveRequest.ToDate);
            mailContent.AppendFormat("理由是{0}", leaveRequest.Reason);
            mailContent.Append("<br/>");
            mailContent.Append("子项：<br/>");
            foreach (LeaveRequestItem item in leaveRequest.LeaveRequestItems)
            {
                mailContent.AppendFormat("从{0}到{1}， 共{2}小时，状态为{3}", item.FromDate, item.ToDate,
                                    item.CostTime, RequestStatus.FindRequestStatus(item.Status.Id).Name);
                mailContent.Append("<br/>");
            }
            return mailContent.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void BulidConfirmAddress(StringBuilder mailContent, Account to, int leaveRequestID)
        {
            string url =
                string.Format("{0}?accountId={1}&Id={2}", RequestUtility.LeaveRequestMailConfirmAddress(),
                              SecurityUtil.DECEncrypt(to.Id.ToString()),
                              SecurityUtil.DECEncrypt(leaveRequestID.ToString()));
            mailContent.Append(
                "您可点击 <a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>同意</a> 快速审批<br/>");
            mailContent.Append("您也可以点击以下链接快速审批通过：<br/>");
            mailContent.Append("<a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>" + url +
                               "</a><br/>");
            mailContent.Append("如果您不通过此申请，可登录以下网址进行审批<br/>");
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public static void BulidConfirmCancelAddress(StringBuilder mailContent, Account to, int leaveRequestID)
        //{
        //    string url =
        //        string.Format("{0}?accountId={1}&Id={2}", RequestUtility.LeaveRequestMailConfirmCancelAddress(),
        //                      SecurityUtil.DECEncrypt(to.Id.ToString()),
        //                      SecurityUtil.DECEncrypt(leaveRequestID.ToString()));
        //    mailContent.Append(
        //        "您可点击 <a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>同意</a> 快速审批<br/>");
        //    mailContent.Append("您也可以点击以下链接快速审批通过：<br/>");
        //    mailContent.Append("<a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>" + url +
        //                       "</a><br/>");
        //    mailContent.Append("如果您不通过此申请，可登录以下网址进行审批<br/>");
        //}

        /// <summary>
        /// 发送邮件给下一步处理人
        /// </summary>
        public void SendMailToNextOperator(int leaveRequestID, Account nextOperator)
        {
            DelSendMailToNextOperator sendMailDelegate = SendMailToNextOperatorF;
            sendMailDelegate.BeginInvoke(leaveRequestID,  nextOperator, null, null);
        }

        private static void SendMailToNextOperatorF(int leaveRequestID, Account nextOperator)
        {
            new LeaveRequestConfirmMail(leaveRequestID).SendMailToNextOperator(nextOperator);
        }

        /// <summary>
        /// 发送审核结束邮件
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="hrAccountlist"></param>
        /// <param name="currentStep"></param>
        public void SendConfirmOverMail(int leaveRequestID,  List<Account> hrAccountlist, DiyStep currentStep)
        {
            DelSendCancelMailUseID sendMailDelegate = SendConfirmOverMailF;
            sendMailDelegate.BeginInvoke(leaveRequestID,  hrAccountlist, currentStep, null, null);
        }

        private static void SendConfirmOverMailF(int leaveRequestID,  List<Account> hrAccountlist, DiyStep currentStep)
        {
            new LeaveRequestOverMail(leaveRequestID, hrAccountlist, currentStep).ConfirmOverMail();
        }
    }
}
