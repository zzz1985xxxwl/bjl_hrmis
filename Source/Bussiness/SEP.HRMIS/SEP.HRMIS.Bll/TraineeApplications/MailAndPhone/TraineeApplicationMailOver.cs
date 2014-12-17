
using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.TraineeApplications.MailAndPhone
{
    ///<summary>
    ///</summary>
    public class TraineeApplicationMailOver
    {
        private readonly TraineeApplication _TraineeApplication;
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly List<Account> _HRAccount;
        private readonly Account _CurrentAccount;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="traineeApplication"></param>
        /// <param name="hrAccount"></param>
        /// <param name="currentAccountID"></param>
        public TraineeApplicationMailOver(TraineeApplication traineeApplication,
            List<Account> hrAccount, int currentAccountID)
        {
            _TraineeApplication = traineeApplication;
            _TraineeApplication.Applicant = _AccountBll.GetAccountById(_TraineeApplication.Applicant.Id);
            _CurrentAccount = _AccountBll.GetAccountById(currentAccountID);
            _HRAccount = hrAccount;
        }

        /// <summary>
        /// ������˽����ʼ�
        /// </summary>
        public void ConfirmOverMail()
        {
            if (_TraineeApplication.TraineeApplicationStatuss.Id == TraineeApplicationStatus.ApproveFail.Id ||
                _TraineeApplication.TraineeApplicationStatuss.Id == TraineeApplicationStatus.ApprovePass.Id)
            {
                MailBody mailBody = new MailBody();
                mailBody.Subject =
                    string.Format("{2}{1}{0}����ѵ���뵥", _TraineeApplication.Applicant.Name,
                                  TraineeApplicationUtility.TraineeApplicationStatusDisplay(_TraineeApplication.TraineeApplicationStatuss),
                                  _CurrentAccount.Name);
                StringBuilder body = new StringBuilder();
                body.AppendFormat(TraineeApplicationMail.BuildBody(_TraineeApplication));
                mailBody.Body = body.ToString();
                mailBody.IsHtmlBody = true;
                mailBody.MailTo = TraineeApplicationUtility.GetMail(_TraineeApplication.Applicant);
                mailBody.MailCc = SendMailToMailCC();
                if (_TraineeApplication.TraineeApplicationStatuss.Id == TraineeApplicationStatus.ApprovePass.Id)
                {
                    mailBody.MailCc.AddRange(SendMailToHRMailCC());
                }
                _MailGateWay.Send(mailBody);
            }
        }

        /// <summary>
        /// ��Ҫ���͵��˷��ʼ�,��Ҫ�����£����ԣ��������������˽�������
        /// </summary>
        private List<string> SendMailToMailCC()
        {
            DiyProcess diyProcess = _TraineeApplication.TraineeApplicationDiyProcess;
            List<string> mailToList = new List<string>();
            foreach (Account account in diyProcess.DiySteps[diyProcess.DiySteps.Count - 1].MailAccount)
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);
                mailToList.AddRange(TraineeApplicationUtility.GetMail(innaccount));
            }
            foreach (Account account in _TraineeApplication.CurrentStep.MailAccount)
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);
                mailToList.AddRange(TraineeApplicationUtility.GetMail(innaccount));
            }
            return mailToList;
        }

        /// <summary>
        /// ��Ҫ���͵��˷��ʼ�,��Ҫ�����£����ԣ��������������˽�������
        /// </summary>
        private List<string> SendMailToHRMailCC()
        {
            List<string> mailToList = new List<string>();
            foreach (Account account in _HRAccount)
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);
                mailToList.AddRange(TraineeApplicationUtility.GetMail(innaccount));
            }
            return mailToList;
        }

    }
}
