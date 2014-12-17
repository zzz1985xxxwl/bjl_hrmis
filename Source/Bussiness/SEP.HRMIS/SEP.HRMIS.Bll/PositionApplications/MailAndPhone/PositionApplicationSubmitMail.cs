using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.PositionApp;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.PositionApplications.MailAndPhone
{
    public class PositionApplicationSubmitMail
    {
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly PositionApplication _PositionApplication;
        private readonly List<Account> _CCList;
        private readonly List<string> _DiyProcesslist;
        private readonly DiyStep _NextStep;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionApplicationID"></param>
        /// <param name="cclist"></param>
        /// <param name="diyProcesslist"></param>
        /// <param name="nextStep"></param>
        public PositionApplicationSubmitMail(int positionApplicationID, List<Account> cclist, List<string> diyProcesslist,
                                      DiyStep nextStep)
        {
            _PositionApplication = new GetPositionApplication().GetPositionApplicationByPKID(positionApplicationID);
            _PositionApplication.Account = _AccountBll.GetAccountById(_PositionApplication.Account.Id);
            _CCList = cclist;
            _DiyProcesslist = diyProcesslist;
            _NextStep = nextStep;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SendMail()
        {
            SendSubmitToMail();
            SendSubmitCCMail(_CCList);
        }

        private void SendSubmitToMail()
        {
            Account mailToAccount = new MailAndPhoneUtility().GetMailToAccount(_PositionApplication, _NextStep);
            MailBody mailBody = new MailBody();
            BuildSubmitMailBody(mailBody, mailToAccount);
            mailBody.MailTo = HrmisUtility.GetMail(mailToAccount);
            _MailGateWay.Send(mailBody);
        }

        private void SendSubmitCCMail(IEnumerable<Account> cclist)
        {
            List<string> mailToList = new List<string>();
            foreach (Account account in cclist)
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);
                mailToList.AddRange(HrmisUtility.GetMail(innaccount));
            }
            mailToList.AddRange(_DiyProcesslist);

            if (mailToList.Count > 0)
            {
                MailBody mailBody = new MailBody();
                BuildSubmitMailBody(mailBody, null);
                mailBody.MailTo = mailToList;
                mailBody.Subject = string.Format("抄送：{0}提交职位申请", _PositionApplication.Account.Name);
                _MailGateWay.Send(mailBody);
            }
        }

        private void BuildSubmitMailBody(MailBody mailBody, Account to)
        {
            string subject = string.Format("{0}提交职位申请，请审批", _PositionApplication.Account.Name);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append(PositionApplicationMail.BuildBody(_PositionApplication));
            if (to != null)
            {
                PositionApplicationMail.BulidConfirmAddress(mailContent, to, _PositionApplication.PKID);
            }
            mailBody.Body = mailContent.ToString();
            mailBody.Subject = subject;
            mailBody.IsHtmlBody = true;
        }
    }
}