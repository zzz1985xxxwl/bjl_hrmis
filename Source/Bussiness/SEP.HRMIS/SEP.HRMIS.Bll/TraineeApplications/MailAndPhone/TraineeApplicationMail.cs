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
        /// �����ύ�ʼ�
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
            mailContent.AppendFormat("����{1}:{0}��", traineeApplication.CourseName,
                traineeApplication.TrainType.Name);
            mailContent.AppendFormat("�ƻ�ʱ�䷶Χ����{0}��{1}��", traineeApplication.StratTime, traineeApplication.EndTime);
            mailContent.AppendFormat("��ѵ����Ϊ{0},��ѵʦΪ{1},",
                traineeApplication.TrainOrgnatiaon, traineeApplication.Trainer);
            mailContent.AppendFormat("����Ϊ{0},��ѵ��ʱΪ{1}��", 
                traineeApplication.TrainCost,traineeApplication.TrainHour);
            if(traineeApplication.EduSpuCost!=null)
            {
                mailContent.AppendFormat("�����������Ϊ{0}", traineeApplication.EduSpuCost);
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
                "���ɵ�� <a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>ͬ��</a> ��������<br/>");
            mailContent.Append("��Ҳ���Ե���������ӿ�������ͨ����<br/>");
            mailContent.Append("<a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>" + url +
                               "</a><br/>");
            mailContent.Append("�������ͨ�������룬�ɵ�¼������ַ��������<br/>");
        }


        /// <summary>
        /// �����ʼ�����һ��������
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
        /// ������˽����ʼ�
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
