using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.TraineeApplications.MailAndPhone
{
    ///<summary>
    ///</summary>
    public class TraineeApplicationMailAndPhoneDelegate
    {
        private readonly TraineeApplicationMail _TraineeApplicationMail = new TraineeApplicationMail();
        //private readonly TraineeApplicationPhone _TraineeApplicationPhone = new TraineeApplicationPhone();

        /// <summary>
        /// �����ύ�ʼ�����
        /// </summary>
        public void SubmitOperation(TraineeApplication traineeApplication)
        {
            _TraineeApplicationMail.SendSubmitMail(traineeApplication);
            //_TraineeApplicationPhone.SendSubmitPhone(leaveRequestID);
        }


        /// <summary>
        /// ���
        /// </summary>
        public void ConfirmOperation(TraineeApplication traineeApplication, List<Account> hrAccount,
            int currentAccountID)
        {
            Account mailToAccount = new TAMailAndPhoneUtility().
                GetMailToAccount(traineeApplication, traineeApplication.NextStep);
            if (traineeApplication.NextStep.DiyStepID == 0 || traineeApplication.NextStep.Status == "ȡ��")
            {
                _TraineeApplicationMail.SendConfirmOverMail(traineeApplication,  hrAccount,currentAccountID);
                //_TraineeApplicationPhone.SendConfirmOverPhone(traineeApplication.PKID,   currentAccountID);
            }
            else if (mailToAccount != null)
            {
                _TraineeApplicationMail.SendMailToNextOperator(traineeApplication, mailToAccount,currentAccountID);
                //_TraineeApplicationPhone.SendPhoneToNextOperator(traineeApplication.PKID,  mailToAccount.Id,
                //                                           currentAccountID);
            }
        }

    }
}
