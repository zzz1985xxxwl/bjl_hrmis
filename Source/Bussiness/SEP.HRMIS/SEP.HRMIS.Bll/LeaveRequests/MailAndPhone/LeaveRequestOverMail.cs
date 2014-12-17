using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.LeaveRequests.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class LeaveRequestOverMail
    {
        private readonly ILeaveRequestDal _DalLeaveRequest = DalFactory.DataAccess.CreateLeaveRequest();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly LeaveRequest _LeaveRequest;
        private readonly List<Account> _HRAccount;
        private readonly DiyStep _CurrentStep;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="hrAccount"></param>
        /// <param name="currentStep"></param>
        public LeaveRequestOverMail(int leaveRequestID, List<Account> hrAccount, DiyStep currentStep)
        {
            _LeaveRequest = _DalLeaveRequest.GetLeaveRequestByPKID(leaveRequestID);
            _LeaveRequest.Account = _AccountBll.GetAccountById(_LeaveRequest.Account.Id);
            _HRAccount = hrAccount;
            _CurrentStep = currentStep;
        }

        /// <summary>
        /// 发送审核结束邮件
        /// </summary>
        public void ConfirmOverMail()
        {
            //MailBody mailBody = new MailBody();
            //mailBody.Subject = string.Format("{0}的请假单审核结束，请查看审核结果", _LeaveRequest.Account.Name);
            //StringBuilder body = new StringBuilder();
            //body.AppendFormat(LeaveRequestMail.BuildBody(_LeaveRequest, _LeaveRequestItem));
            //mailBody.Body = body.ToString();
            //mailBody.IsHtmlBody = true;
            //mailBody.MailTo = RequestUtility.GetMail(_LeaveRequest.Account);
            //List<string> mailToList = new List<string>();
            //foreach (Account account in _DiyProcessAccountlist)
            //{
            //    Account innaccount = _AccountBll.GetAccountById(account.Id);
            //    mailToList.AddRange(RequestUtility.GetMail(innaccount));
            //}
            //mailBody.MailCc = mailToList;
            //_MailGateWay.Send(mailBody);
            bool over = true;
            foreach (LeaveRequestItem item in _LeaveRequest.LeaveRequestItems)
            {
                over &= item.Status.Id == RequestStatus.ApproveCancelFail.Id ||
                        item.Status.Id == RequestStatus.ApproveCancelPass.Id ||
                        item.Status.Id == RequestStatus.ApproveFail.Id ||
                        item.Status.Id == RequestStatus.ApprovePass.Id;
            }
            if (over)
            {
                MailBody mailBody = new MailBody();
                mailBody.Subject =
                    string.Format("审核完毕{0}的请假单", _LeaveRequest.Account.Name);
                StringBuilder body = new StringBuilder();
                body.AppendFormat(LeaveRequestMail.BuildBody(_LeaveRequest));
                mailBody.Body = body.ToString();
                mailBody.IsHtmlBody = true;
                mailBody.MailTo = RequestUtility.GetMail(_LeaveRequest.Account);
                mailBody.MailCc = SendMailToMailCC();
                foreach (LeaveRequestItem item in _LeaveRequest.LeaveRequestItems)
                {
                    if (item.Status.Id == RequestStatus.ApprovePass.Id ||
                        item.Status.Id == RequestStatus.ApproveCancelFail.Id)
                    {
                        mailBody.MailCc.AddRange(SendMailToHRMailCC());
                        break;
                    }
                }
                _MailGateWay.Send(mailBody);
            }
        }

        /// <summary>
        /// 给要抄送的人发邮件,主要是人事，所以，在整个外出单审核结束后发送
        /// </summary>
        private List<string> SendMailToMailCC()
        {
            List<string> mailToList = new List<string>();
            foreach (Account account in _CurrentStep.MailAccount)
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);
                mailToList.AddRange(RequestUtility.GetMail(innaccount));
            }
            return mailToList;
        }

        /// <summary>
        /// 给要抄送的人发邮件,主要是人事，所以，在整个外出单审核结束后发送
        /// </summary>
        private List<string> SendMailToHRMailCC()
        {
            List<string> mailToList = new List<string>();
            foreach (Account account in _HRAccount)
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);
                mailToList.AddRange(RequestUtility.GetMail(innaccount));
            }
            return mailToList;
        }
    }
}