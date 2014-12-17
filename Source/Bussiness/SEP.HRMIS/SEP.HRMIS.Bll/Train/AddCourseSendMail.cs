
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
            mailBody.Subject = string.Format("您已参加名为{0}的培训课程，请在培训结束后，填写反馈问题", course.CourseName);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append("请到时参加以下培训，并在培训结束后填写反馈，谢谢<br/>");
            mailContent.AppendFormat("培训课程：{0}", course.CourseName);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("培训地点：{0}", course.TrainPlace);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("培训师：{0}", course.Trainer);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("协调员：{0}", course.Coordinator.Name);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("计划开始时间：{0}", course.ExpectST);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("计划结束时间：{0}", course.ExpectET);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("计划课时：{0}", course.ExpectHour);
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