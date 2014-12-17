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
        /// �����ύ�ʼ�����
        /// </summary>
        public void SubmitOperation(int positionApplicationID, List<string> diyProcesslist, DiyStep nextStep)
        {
            _PositionApplicationMail.SendSubmitMail(positionApplicationID, new List<Account>(), diyProcesslist, nextStep);
        }

        /// <summary>
        /// ����ȡ���ʼ�
        /// </summary>
        public void CancelMail(int positionApplicationID, List<string> currentStepAccountlist, DiyStep nextStep)
        {
            _PositionApplicationMail.SendCancelMail(positionApplicationID, currentStepAccountlist, nextStep);
        }

        /// <summary>
        /// ���
        /// </summary>
        public void ConfirmOperationMail(PositionApplication positionApplication, int currentAccountID, DiyStep currentStep, DiyStep nextStep)
        {
            Account mailToAccount = new MailAndPhoneUtility().GetMailToAccount(positionApplication, nextStep);
            if (nextStep.DiyStepID == 0 || nextStep.Status == "ȡ��")
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
