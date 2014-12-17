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
    public class PositionApplicationCancelMail
    {
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly PositionApplication _PositionApplication;
        private readonly DiyStep _NextStep;
        private readonly List<string> _CurrentStepAccountlist;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionApplicationID"></param>
        /// <param name="currentStepAccountlist"></param>
        /// <param name="nextStep"></param>
        public PositionApplicationCancelMail(int positionApplicationID, List<string> currentStepAccountlist, DiyStep nextStep)
        {
            _PositionApplication = new GetPositionApplication().GetPositionApplicationByPKID(positionApplicationID);
            _PositionApplication.Account = _AccountBll.GetAccountById(_PositionApplication.Account.Id);
            _NextStep = nextStep;
            _CurrentStepAccountlist = currentStepAccountlist;
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
            Account mailToAccount = new MailAndPhoneUtility().GetMailToAccount(_PositionApplication, _NextStep);
            MailBody mailBody = new MailBody();
            BuildSubmitMailBody(mailBody, mailToAccount);
            mailBody.MailTo = HrmisUtility.GetMail(mailToAccount);
            _MailGateWay.Send(mailBody);
        }

        private void SendCancelCCMail()
        {
            if (_CurrentStepAccountlist.Count > 0)
            {
                MailBody mailBody = new MailBody();
                BuildSubmitMailBody(mailBody, null);
                mailBody.MailTo = _CurrentStepAccountlist;
                mailBody.Subject = string.Format("抄送：{0}取消职位申请", _PositionApplication.Account.Name);
                _MailGateWay.Send(mailBody);
            }
        }

        private void BuildSubmitMailBody(MailBody mailBody, Account to)
        {
            string subject = string.Format("{0}取消职位申请，请审批", _PositionApplication.Account.Name);
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