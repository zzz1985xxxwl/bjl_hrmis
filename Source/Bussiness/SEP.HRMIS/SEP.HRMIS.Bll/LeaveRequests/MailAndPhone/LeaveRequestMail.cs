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
        /// �����ύ�ʼ�
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
        /// ����ȡ���ʼ�
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
            mailContent.AppendFormat("��{0}", leaveRequest.LeaveRequestType.Name);
            mailContent.AppendFormat("��{0}Сʱ��", leaveRequest.CostTime);
            mailContent.AppendFormat("��{0}��{1}��", leaveRequest.FromDate, leaveRequest.ToDate);
            mailContent.AppendFormat("������{0}", leaveRequest.Reason);
            mailContent.Append("<br/>");
            mailContent.Append("���<br/>");
            foreach (LeaveRequestItem item in leaveRequest.LeaveRequestItems)
            {
                mailContent.AppendFormat("��{0}��{1}�� ��{2}Сʱ��״̬Ϊ{3}", item.FromDate, item.ToDate,
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
                "���ɵ�� <a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>ͬ��</a> ��������<br/>");
            mailContent.Append("��Ҳ���Ե���������ӿ�������ͨ����<br/>");
            mailContent.Append("<a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>" + url +
                               "</a><br/>");
            mailContent.Append("�������ͨ�������룬�ɵ�¼������ַ��������<br/>");
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
        //        "���ɵ�� <a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>ͬ��</a> ��������<br/>");
        //    mailContent.Append("��Ҳ���Ե���������ӿ�������ͨ����<br/>");
        //    mailContent.Append("<a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>" + url +
        //                       "</a><br/>");
        //    mailContent.Append("�������ͨ�������룬�ɵ�¼������ַ��������<br/>");
        //}

        /// <summary>
        /// �����ʼ�����һ��������
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
        /// ������˽����ʼ�
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
