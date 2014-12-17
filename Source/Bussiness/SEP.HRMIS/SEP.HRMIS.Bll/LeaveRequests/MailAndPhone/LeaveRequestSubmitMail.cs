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
    public class LeaveRequestSubmitMail
    {
        private readonly ILeaveRequestDal _DalLeaveRequest = DalFactory.DataAccess.CreateLeaveRequest();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly LeaveRequest _LeaveRequest;
        private readonly List<Account> _CCList;
        private readonly List<Account> _DiyProcesslist;
        private readonly DiyStep _NextStep;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="cclist"></param>
        /// <param name="diyProcesslist"></param>
        /// <param name="nextStep"></param>
        public LeaveRequestSubmitMail(int leaveRequestID, List<Account> cclist, List<Account> diyProcesslist,
                                      DiyStep nextStep)
        {
            _LeaveRequest = _DalLeaveRequest.GetLeaveRequestByPKID(leaveRequestID);
            _LeaveRequest.Account = _AccountBll.GetAccountById(_LeaveRequest.Account.Id);
            _CCList = cclist;
            _DiyProcesslist = diyProcesslist;
            _NextStep = nextStep;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SendMail()
        {
            //foreach (LeaveRequestItem item in _LeaveRequest.LeaveRequestItems)
            //{
            //if (item.Status.Id == RequestStatus.Submit.Id)
            //{
            SendSubmitToMail();
            SendSubmitCCMail(_CCList);
            //}
            //}
        }

        private void SendSubmitToMail()
        {
            Account mailToAccount = new MailAndPhoneUtility().GetMailToAccount(_LeaveRequest, _NextStep);
            MailBody mailBody = new MailBody();
            BuildSubmitMailBody(mailBody, mailToAccount, true);
            mailBody.MailTo = RequestUtility.GetMail(mailToAccount);
            _MailGateWay.Send(mailBody);
        }

        private void SendSubmitCCMail(IEnumerable<Account> cclist)
        {
            List<string> mailToList = new List<string>();
            foreach (Account account in cclist)
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);
                mailToList.AddRange(RequestUtility.GetMail(innaccount));
            }
            foreach (Account account in _DiyProcesslist)
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);
                mailToList.AddRange(RequestUtility.GetMail(innaccount));
            }

            if (mailToList.Count > 0)
            {
                MailBody mailBody = new MailBody();
                BuildSubmitMailBody(mailBody, null, false);
                mailBody.MailTo = mailToList;
                mailBody.Subject = string.Format("≥≠ÀÕ£∫{0}Ã·Ωª«ÎºŸ…Í«Î", _LeaveRequest.Account.Name);
                _MailGateWay.Send(mailBody);
            }
        }

        private void BuildSubmitMailBody(MailBody mailBody, Account to, bool addConfirmAddress)
        {
            string subject = string.Format("{0}Ã·Ωª«ÎºŸ…Í«Î£¨«Î…Û≈˙", _LeaveRequest.Account.Name);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append(LeaveRequestMail.BuildBody(_LeaveRequest));
            if (addConfirmAddress)
            {
                LeaveRequestMail.BulidConfirmAddress(mailContent, to, _LeaveRequest.PKID);
            }
            mailBody.Body = mailContent.ToString();
            mailBody.Subject = subject;
            mailBody.IsHtmlBody = true;
        }
    }
}