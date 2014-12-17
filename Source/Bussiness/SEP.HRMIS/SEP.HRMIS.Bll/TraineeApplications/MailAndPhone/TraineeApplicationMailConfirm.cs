using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.TraineeApplications.MailAndPhone
{
    ///<summary>
    ///</summary>
    public class TraineeApplicationMailConfirm
    {
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly TraineeApplication _TraineeApplication;
        private readonly Account _CurrentAccount;
        /// <summary>
        /// 
        /// </summary>
        public TraineeApplicationMailConfirm(TraineeApplication traineeApplication, int currentAccountID)
        {
            _TraineeApplication = traineeApplication;
            _TraineeApplication.Applicant = _AccountBll.GetAccountById(_TraineeApplication.Applicant.Id);
            _CurrentAccount = _AccountBll.GetAccountById(currentAccountID);
        }

        /// <summary>
        /// 给下一步操作人发邮件
        /// </summary>
        /// <param name="nextOperator"></param>
        public void SendMailToNextOperator(Account nextOperator)
        {
            if (_TraineeApplication.TraineeApplicationStatuss.Id == TraineeApplicationStatus.Approving.Id)
            {
                MailBody mailBody = new MailBody();
                nextOperator = _AccountBll.GetAccountById(nextOperator.Id);
                BuildSubmitMailBody(mailBody, nextOperator, true);
                _MailGateWay.Send(mailBody);
            }
            SendSubmitCCMail();
        }

        private void SendSubmitCCMail()
        {
            List<string> mailToList = new List<string>();
            foreach (Account account in _TraineeApplication.CurrentStep.MailAccount)
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);

                mailToList.AddRange(TraineeApplicationUtility.GetMail(innaccount));
            }
            if (mailToList.Count > 0)
            {
                MailBody mailBody = new MailBody();
                BuildSubmitMailBody(mailBody, null, false);
                mailBody.MailTo = mailToList;
                mailBody.Subject = string.Format("抄送：{0}审核通过{1}提交的培训申请", _CurrentAccount.Name, _TraineeApplication.Applicant.Name);
                _MailGateWay.Send(mailBody);
            }
        }
        private void BuildSubmitMailBody(MailBody mailBody, Account to, bool addConfirmAddress)
        {
            string subject = string.Format("请审批{0}的培训申请", _TraineeApplication.Applicant.Name);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append(TraineeApplicationMail.BuildBody(_TraineeApplication));
            if (addConfirmAddress)
            {
                TraineeApplicationMail.BulidConfirmAddress(mailContent, to,
                    _TraineeApplication.PKID);
                mailBody.MailTo = TraineeApplicationUtility.GetMail(to);
            }
            mailBody.Body = mailContent.ToString();
            mailBody.Subject = subject;
            mailBody.IsHtmlBody = true;
        }

    }
}
