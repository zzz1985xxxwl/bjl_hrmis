using System.Collections.Generic;
using Mail.Model;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AutoRemindServer
{
    /// <summary>
    /// �Զ����ѹ��ܹ�������
    /// </summary>
    public class AutoRemindServerUtility
    {
        readonly GetDiyProcess _GetDiyProcess = new GetDiyProcess();
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="getDiyProcess"></param>
        public AutoRemindServerUtility(GetDiyProcess getDiyProcess)
        {
            _GetDiyProcess = getDiyProcess;
        }

        ///<summary>
        /// ����mailBodyListToHR�����е�email
        ///</summary>
        ///<param name="mailBodyListToHR"></param>
        ///<param name="email"></param>
        ///<returns></returns>
        private static MailBody GetMailBodyByEmail(List<MailBody> mailBodyListToHR, string email)
        {
            foreach (MailBody mailBody in mailBodyListToHR)
            {
                if (mailBody.MailTo == null)
                {
                    mailBody.MailTo = new List<string>();
                }
                foreach (string mailstring in mailBody.MailTo)
                {
                    if (mailstring == email)
                    {
                        return mailBody;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// �������������ʼ�������email��Ϣ��������µ��ʼ��Ѿ���mailBodyListToHR�У���ô׷���ʼ�body���ݣ���������һ��MailBody
        /// </summary>
        /// <param name="accountid"></param>
        /// <param name="mailBodyListToHR"></param>
        /// <param name="body"></param>
        /// <param name="distributeString"></param>
        public void CreateHREmail(int accountid, List<MailBody> mailBodyListToHR, string body, string distributeString)
        {
            if (mailBodyListToHR == null)
            {
                mailBodyListToHR = new List<MailBody>();
            }
            List<Account> accountList = _GetDiyProcess.GetHRPrincipalByAccountID(accountid);
            foreach (Account account in accountList)
            {
                GenerateEmailInfo(mailBodyListToHR, body, distributeString, account.Email1);
                GenerateEmailInfo(mailBodyListToHR, body, distributeString, account.Email2);
            }
        }
        /// <summary>
        /// ����email��Ϣ�����mailBodyListToHR������ͬ��ַ����׷���ʼ�������Ϣ�����������ʼ�
        /// </summary>
        /// <param name="mailBodyListToHR"></param>
        /// <param name="body"></param>
        /// <param name="distributeString"></param>
        /// <param name="email"></param>
        private static void GenerateEmailInfo(List<MailBody> mailBodyListToHR, string body, string distributeString, string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return;
            }
            MailBody mailBody = GetMailBodyByEmail(mailBodyListToHR, email);
            if (mailBody == null)
            {
                mailBody = new MailBody();
                mailBody.Body = body;
                List<string> mailAddress = new List<string>();
                mailAddress.Add(email);
                mailBody.MailTo = mailAddress;
                mailBodyListToHR.Add(mailBody);
            }
            else
            {
                //׷����Ϣ
                if (string.IsNullOrEmpty(mailBody.Body))
                {
                    mailBody.Body = body;
                }
                else
                {
                    if (!mailBody.Body.Contains(body))
                    {
                        mailBody.Body += distributeString + body;
                    }
                }
            }
        }
    }
}
