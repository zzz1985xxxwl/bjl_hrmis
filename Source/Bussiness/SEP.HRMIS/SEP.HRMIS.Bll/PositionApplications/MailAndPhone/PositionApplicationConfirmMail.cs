using System.Text;
using Mail.Model;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PositionApp;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.PositionApplications.MailAndPhone
{
    public class PositionApplicationConfirmMail
    {
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly PositionApplication _PositionApplication;

        public PositionApplicationConfirmMail(int positionApplicationID)
        {
            _PositionApplication = new GetPositionApplication().GetPositionApplicationByPKID(positionApplicationID);
            _PositionApplication.Account = _AccountBll.GetAccountById(_PositionApplication.Account.Id);
        }

        /// <summary>
        /// ����һ�������˷��ʼ�
        /// </summary>
        /// <param name="nextOperator"></param>
        public void SendMailToNextOperator(Account nextOperator)
        {
            if (_PositionApplication.Status.Id == RequestStatus.Approving.Id ||
                _PositionApplication.Status.Id == RequestStatus.CancelApproving.Id)
            {
                MailBody mailBody = new MailBody();
                nextOperator = _AccountBll.GetAccountById(nextOperator.Id);
                BuildSubmitMailBody(mailBody, nextOperator, true);
                _MailGateWay.Send(mailBody);
            }
        }

        private void BuildSubmitMailBody(MailBody mailBody, Account to, bool addConfirmAddress)
        {
            string subject = string.Format("������{0}��ְλ����", _PositionApplication.Account.Name);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append(PositionApplicationMail.BuildBody(_PositionApplication));
            if (addConfirmAddress)
            {
                PositionApplicationMail.BulidConfirmAddress(mailContent, to, _PositionApplication.PKID);
            }
            mailBody.MailTo = HrmisUtility.GetMail(to);
            mailBody.Body = mailContent.ToString();
            mailBody.Subject = subject;
            mailBody.IsHtmlBody = true;
        }
    }
}