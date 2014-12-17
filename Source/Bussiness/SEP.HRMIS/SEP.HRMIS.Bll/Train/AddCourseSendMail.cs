
using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 
    /// </summary>
    public class AddCourseSendMail : Transaction
    {
        private readonly List<Account> _Accounts;
        private readonly Course _Course;
        private static  IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private static  IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private delegate void DelSendMail(Account account, Course course);
        /// <summary>
        /// 
        /// </summary>
        public AddCourseSendMail(List<Account> accounts,Course course)
        {
            _Accounts = accounts;
            _Course = course;
        }
        /// <summary>
        /// 
        /// </summary>
        public AddCourseSendMail(List<Account> accounts, Course course,IMailGateWay mailGateWay,IAccountBll iAccountBll):this(accounts,course)
        {
            _MailGateWay = mailGateWay;
            _AccountBll = iAccountBll;
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            foreach (Account account in _Accounts)
            {
                SendMailAnsy(account, _Course);
            }
        }

        private static void SendMail(Account account,Course course)
        {
            Account temp = _AccountBll.GetAccountById(account.Id);
            MailBody mailBody = new MailBody();
            mailBody.MailTo = RequestUtility.GetMail(temp);
            mailBody.Subject = string.Format("���Ѳμ���Ϊ{0}����ѵ�γ̣�������ѵ��������д��������", course.CourseName);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append("�뵽ʱ�μ�������ѵ��������ѵ��������д������лл<br/>");
            mailContent.AppendFormat("��ѵ�γ̣�{0}", course.CourseName);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("��ѵ�ص㣺{0}", course.TrainPlace);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("��ѵʦ��{0}", course.Trainer);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("Э��Ա��{0}", course.Coordinator.Name);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("�ƻ���ʼʱ�䣺{0}", course.ExpectST);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("�ƻ�����ʱ�䣺{0}", course.ExpectET);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("�ƻ���ʱ��{0}", course.ExpectHour);
            mailContent.Append("<br/>");
            mailBody.Body = mailContent.ToString();
            mailBody.IsHtmlBody = true;
            _MailGateWay.Send(mailBody);
        }


        private static void SendMailAnsy(Account account, Course course)
        {
            DelSendMail sendMailDelegate = SendMail;
            sendMailDelegate.BeginInvoke(account, course, null, null);
        }
    }
}