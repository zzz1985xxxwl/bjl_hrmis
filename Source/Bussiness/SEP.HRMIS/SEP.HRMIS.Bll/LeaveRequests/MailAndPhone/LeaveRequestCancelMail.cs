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
    public class LeaveRequestCancelMail
    {
        private readonly ILeaveRequestDal _DalLeaveRequest = DalFactory.DataAccess.CreateLeaveRequest();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly LeaveRequest _LeaveRequest;
        private readonly DiyStep _NextStep;
        private readonly List<Account> _DiyProcessAccountlist;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="diyProcessAccountlist"></param>
        /// <param name="nextStep"></param>
        public LeaveRequestCancelMail(int leaveRequestID, List<Account> diyProcessAccountlist, DiyStep nextStep)
        {
            _LeaveRequest = _DalLeaveRequest.GetLeaveRequestByPKID(leaveRequestID);
            _LeaveRequest.Account = _AccountBll.GetAccountById(_LeaveRequest.Account.Id);
            _NextStep = nextStep;
            _DiyProcessAccountlist = diyProcessAccountlist;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SendMail()
        {
            SendCancelToMail();
            SendCancelCCMail();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SendCancelToMail()
        {
            Account mailToAccount = new MailAndPhoneUtility().GetMailToAccount(_LeaveRequest, _NextStep);
            MailBody mailBody = new MailBody();
            BuildSubmitMailBody(mailBody, mailToAccount);
            mailBody.MailTo = RequestUtility.GetMail(mailToAccount);
            _MailGateWay.Send(mailBody);
        }

        private void SendCancelCCMail()
        {
            List<string> mailToList = new List<string>();
            foreach (Account account in _DiyProcessAccountlist)
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);
                mailToList.AddRange(RequestUtility.GetMail(innaccount));
            }

            if (mailToList.Count > 0)
            {
                MailBody mailBody = new MailBody();
                BuildSubmitMailBody(mailBody, null);
                mailBody.MailTo = mailToList;
                mailBody.Subject = string.Format("≥≠ÀÕ£∫{0}Ã·Ωª«ÎºŸ…Í«Î", _LeaveRequest.Account.Name);
                _MailGateWay.Send(mailBody);
            }
        }

        private void BuildSubmitMailBody(MailBody mailBody, Account to)
        {
            string subject = string.Format("{0}»°œ˚«ÎºŸ…Í«Î£¨«Î…Û≈˙", _LeaveRequest.Account.Name);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append(LeaveRequestMail.BuildBody(_LeaveRequest));
            LeaveRequestMail.BulidConfirmAddress(mailContent, to, _LeaveRequest.PKID);
            mailBody.Body = mailContent.ToString();
            mailBody.Subject = subject;
            mailBody.IsHtmlBody = true;
        }
    }
}