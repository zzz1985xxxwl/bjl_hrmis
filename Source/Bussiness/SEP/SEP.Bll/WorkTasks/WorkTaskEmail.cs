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
            body.Append("任务名称：" + workTask.Title + "<br/>");
            body.Append("开始时间：" + workTask.StartDate + "<br/>");
            body.Append("结束时间：" + workTask.EndDate + "<br/>");
            body.Append("优先级：" + workTask.Priority.Name + "<br/>");
            body.Append("状态：" + workTask.Status.Name + "<br/>");
            if (workTask.Responsibles.Count > 0)
            {
                body.Append("负责人：");
            }
            for (int i = 0; i < workTask.Responsibles.Count;i++ )
            {
                body.Append(workTask.Responsibles[i].Name + "，");
            }
            if (workTask.Responsibles.Count > 0)
            {
                body.Remove(body.Length - 1, 1);
            }
            body.Append("内容：" + workTask.Content + "<br/>");
            body.Append("描述：" + workTask.Description + "<br/>");
            body.Append("备注：" + workTask.Remark + "<br/>");
            return body;
        }

        internal static string BuildAnswerWorkTaskMailBody(WorkTaskQA workTaskQA)
        {
            StringBuilder body = new StringBuilder();
            body.Append(workTaskQA.QAccount.Name + "回复了你对他的工作计划[" + workTaskQA.WorkTask.Title + "]的留言。<br/>");
            body.Append("留言内容：" + workTaskQA.Question);
            body.Append("<br/>回复内容：" + workTaskQA.Answer + "<br/>");
            return body.ToString();
        }

        internal static string BuildQuestionWorkTaskMailBody(WorkTaskQA workTaskQA)
        {
            StringBuilder body = new StringBuilder();
            body.Append(workTaskQA.AAccount.Name + "对你的工作计划[" + workTaskQA.WorkTask.Title + "]留言。<br/>");
            body.Append("留言内容：" + workTaskQA.Question + "<br/>");
            return body.ToString();
        }
    }
}