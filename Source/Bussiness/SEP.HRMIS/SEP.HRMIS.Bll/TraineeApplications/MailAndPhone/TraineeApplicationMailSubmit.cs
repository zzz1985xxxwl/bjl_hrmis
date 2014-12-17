
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
    public class TraineeApplicationMailSubmit
    {
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly TraineeApplication _TraineeApplication;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="traineeApplication"></param>
        public TraineeApplicationMailSubmit(TraineeApplication traineeApplication)
        {
            _TraineeApplication = traineeApplication;
            _TraineeApplication.Applicant = _AccountBll.GetAccountById(_TraineeApplication.Applicant.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SendMail()
        {
            if (_TraineeApplication.TraineeApplicationStatuss.Id == TraineeApplicationStatus.Submit.Id)
            {
                SendSubmitToMail(_TraineeApplication);
                SendSubmitCCMail(_TraineeApplication, _TraineeApplication.CurrentStep.MailAccount);
            }
        }

        private static void SendSubmitCCMail(TraineeApplication traineeApplication, IEnumerable<Account> cclist)
        {
            List<string> mailToList = new List<string>();
            foreach (Account account in cclist)
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);

                mailToList.AddRange(TraineeApplicationUtility.GetMail(innaccount));
            }
            if (mailToList.Count > 0)
            {
                MailBody mailBody = new MailBody();
                BuildSubmitMailBody(traineeApplication, mailBody, null, false);
                mailBody.MailTo = mailToList;
                mailBody.Subject = string.Format("≥≠ÀÕ£∫{0}Ã·Ωª≈‡—µ…Í«Î", traineeApplication.Applicant.Name);
                _MailGateWay.Send(mailBody);
            }
        }
        private static void SendSubmitToMail(TraineeApplication traineeApplication)
        {
            Account mailToAccount = new TAMailAndPhoneUtility().
                GetMailToAccount(traineeApplication, traineeApplication.NextStep);
            MailBody mailBody = new MailBody();
            BuildSubmitMailBody(traineeApplication, mailBody, mailToAccount, true);

            mailBody.MailTo = TraineeApplicationUtility.GetMail(mailToAccount);
            _MailGateWay.Send(mailBody);
        }

        private static void BuildSubmitMailBody(TraineeApplication traineeApplication, 
            MailBody mailBody, Account to, bool addConfirmAddress)
        {
            string subject = string.Format("{0}Ã·Ωª≈‡—µ…Í«Î£¨«Î…Û≈˙", traineeApplication.Applicant.Name);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append(TraineeApplicationMail.BuildBody(traineeApplication));
            if (addConfirmAddress)
            {
                TraineeApplicationMail.BulidConfirmAddress(mailContent, to, traineeApplication.PKID);
            }
            mailBody.Body = mailContent.ToString();
            mailBody.Subject = subject;
            mailBody.IsHtmlBody = true;
        }
    }
}
