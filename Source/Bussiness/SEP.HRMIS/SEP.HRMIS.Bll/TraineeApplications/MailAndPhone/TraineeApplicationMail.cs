using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.HRMIS.Bll.TraineeApplications.MailAndPhone
{
    ///<summary>
    ///</summary>
    public class TraineeApplicationMail
    {
        private delegate void DelSendSubmitMail(TraineeApplication traineeApplication);

        private delegate void DelSendMailUseID(TraineeApplication traineeApplication,
            List<Account> diyProcessAccountlist, int currentAccountID);

        private delegate void DelSendMailToNextOperator(TraineeApplication traineeApplication,
             Account nextOperator, int currentAccountID);

        /// <summary>
        /// 发送提交邮件
        /// </summary>
        public void SendSubmitMail(TraineeApplication traineeApplication)
        {
            DelSendSubmitMail sendMailDelegate = SendSubmitMailF;
            sendMailDelegate.BeginInvoke(traineeApplication,null, null);
        }

        private static void SendSubmitMailF(TraineeApplication traineeApplication)
        {
            new TraineeApplicationMailSubmit(traineeApplication).SendMail();
        }

        /// <summary>
        /// 
        /// </summary>
        public static string BuildBody(TraineeApplication traineeApplication)
        {
            StringBuilder mailContent = new StringBuilder();
            mailContent.AppendFormat("{0}", traineeApplication.Applicant.Name);
            mailContent.AppendFormat("申请{1}:{0}，", traineeApplication.CourseName,
                traineeApplication.TrainType.Name);
            mailContent.AppendFormat("计划时间范围：从{0}到{1}，", traineeApplication.StratTime, traineeApplication.EndTime);
            mailContent.AppendFormat("培训机构为{0},培训师为{1},",
                traineeApplication.TrainOrgnatiaon, traineeApplication.Trainer);
            mailContent.AppendFormat("费用为{0},培训课时为{1}。", 
                traineeApplication.TrainCost,traineeApplication.TrainHour);
            if(traineeApplication.EduSpuCost!=null)
            {
                mailContent.AppendFormat("教育补助金额为{0}", traineeApplication.EduSpuCost);
            }
            mailContent.Append("<br/>");
            return mailContent.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void BulidConfirmAddress(StringBuilder mailContent, Account to,
            int traineeApplicationID)
        {
            string url =
                string.Format("{0}?accountId={1}&Id={2}", TraineeApplicationUtility.TraineeApplicationMailConfirmAddress(),
                              SecurityUtil.DECEncrypt(to.Id.ToString()),
                              SecurityUtil.DECEncrypt(traineeApplicationID.ToString()));
            mailContent.Append(
                "您可点击 <a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>同意</a> 快速审批<br/>");
            mailContent.Append("您也可以点击以下链接快速审批通过：<br/>");
            mailContent.Append("<a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>" + url +
                               "</a><br/>");
            mailContent.Append("如果您不通过此申请，可登录以下网址进行审批<br/>");
        }


        /// <summary>
        /// 发送邮件给下一步处理人
        /// </summary>
        public void SendMailToNextOperator(TraineeApplication traineeApplication, Account nextOperator,
            int currentAccountID)
        {
            DelSendMailToNextOperator sendMailDelegate = SendMailToNextOperatorF;
            sendMailDelegate.BeginInvoke(traineeApplication, nextOperator, currentAccountID,  null, null);
        }

        private static void SendMailToNextOperatorF(TraineeApplication traineeApplication,
            Account nextOperator, int currentAccountID)
        {
            new TraineeApplicationMailConfirm(traineeApplication, currentAccountID).SendMailToNextOperator(nextOperator);
        }

        /// <summary>
        /// 发送审核结束邮件
        /// </summary>
        /// <param name="traineeApplication"></param>
        /// <param name="hrAccountlist"></param>
        /// <param name="currentAccountID"></param>
        public void SendConfirmOverMail(TraineeApplication traineeApplication, List<Account> hrAccountlist, int currentAccountID)
        {
            DelSendMailUseID sendMailDelegate = SendConfirmOverMailF;
            sendMailDelegate.BeginInvoke(traineeApplication, hrAccountlist, currentAccountID,  null, null);
        }

        private static void SendConfirmOverMailF(TraineeApplication traineeApplication,
            List<Account> hrAccountlist, int currentAccountID)
        {
            new TraineeApplicationMailOver(traineeApplication, hrAccountlist,currentAccountID).ConfirmOverMail();
        }

    }
}
