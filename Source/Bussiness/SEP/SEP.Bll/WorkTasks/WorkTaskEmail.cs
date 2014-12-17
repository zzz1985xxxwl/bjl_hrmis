using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.Bll.Mail;
using SEP.IBll.Mail;
using SEP.Model;

namespace SEP.Bll.WorkTasks
{
    internal class WorkTaskEmail
    {
        private readonly IMailGateWay _MailGateWay = new MailGateWay();
        private readonly string _Subject;
        private readonly string _Body;
        private readonly List<string> _To;

        internal WorkTaskEmail(string subject, string body, List<string> to)
        {
            _Subject = subject;
            _Body = body;
            _To = to;
        }

        internal void SendMail()
        {
            MailBody mailBody = new MailBody();
            mailBody.IsHtmlBody = true;
            mailBody.MailTo = _To;
            mailBody.Subject = _Subject;
            mailBody.Body = _Body;
            _MailGateWay.Send(mailBody);
        }

        internal static StringBuilder BuildWorkTaskMailBody(WorkTask workTask)
        {
            StringBuilder body = new StringBuilder();
            body.Append("�������ƣ�" + workTask.Title + "<br/>");
            body.Append("��ʼʱ�䣺" + workTask.StartDate + "<br/>");
            body.Append("����ʱ�䣺" + workTask.EndDate + "<br/>");
            body.Append("���ȼ���" + workTask.Priority.Name + "<br/>");
            body.Append("״̬��" + workTask.Status.Name + "<br/>");
            if (workTask.Responsibles.Count > 0)
            {
                body.Append("�����ˣ�");
            }
            for (int i = 0; i < workTask.Responsibles.Count;i++ )
            {
                body.Append(workTask.Responsibles[i].Name + "��");
            }
            if (workTask.Responsibles.Count > 0)
            {
                body.Remove(body.Length - 1, 1);
            }
            body.Append("���ݣ�" + workTask.Content + "<br/>");
            body.Append("������" + workTask.Description + "<br/>");
            body.Append("��ע��" + workTask.Remark + "<br/>");
            return body;
        }

        internal static string BuildAnswerWorkTaskMailBody(WorkTaskQA workTaskQA)
        {
            StringBuilder body = new StringBuilder();
            body.Append(workTaskQA.QAccount.Name + "�ظ���������Ĺ����ƻ�[" + workTaskQA.WorkTask.Title + "]�����ԡ�<br/>");
            body.Append("�������ݣ�" + workTaskQA.Question);
            body.Append("<br/>�ظ����ݣ�" + workTaskQA.Answer + "<br/>");
            return body.ToString();
        }

        internal static string BuildQuestionWorkTaskMailBody(WorkTaskQA workTaskQA)
        {
            StringBuilder body = new StringBuilder();
            body.Append(workTaskQA.AAccount.Name + "����Ĺ����ƻ�[" + workTaskQA.WorkTask.Title + "]���ԡ�<br/>");
            body.Append("�������ݣ�" + workTaskQA.Question + "<br/>");
            return body.ToString();
        }
    }
}