using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.PositionApp;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.PositionApplications.MailAndPhone
{
    public class PositionApplicationMailAndPhoneDelegate
    {
        private readonly PositionApplicationMail _PositionApplicationMail = new PositionApplicationMail();

        /// <summary>
        /// 发送提交邮件短信
        /// </summary>
        public void SubmitOperation(int positionApplicationID, List<string> diyProcesslist, DiyStep nextStep)
        {
            _PositionApplicationMail.SendSubmitMail(positionApplicationID, new List<Account>(), diyProcesslist, nextStep);
        }

        /// <summary>
        /// 发送取消邮件
        /// </summary>
        public void CancelMail(int positionApplicationID, List<string> currentStepAccountlist, DiyStep nextStep)
        {
            _PositionApplicationMail.SendCancelMail(positionApplicationID, currentStepAccountlist, nextStep);
        }

        /// <summary>
        /// 审核
        /// </summary>
        public void ConfirmOperationMail(PositionApplication positionApplication, int currentAccountID, DiyStep currentStep, DiyStep nextStep)
        {
            Account mailToAccount = new MailAndPhoneUtility().GetMailToAccount(positionApplication, nextStep);
            if (nextStep.DiyStepID == 0 || nextStep.Status == "取消")
            {
                _PositionApplicationMail.SendConfirmOverMail(positionApplication.PKID, currentStep);
            }
            else if (mailToAccount != null)
            {
                _PositionApplicationMail.SendMailToNextOperator(positionApplication.PKID, mailToAccount);
            }
        }
    }
}
