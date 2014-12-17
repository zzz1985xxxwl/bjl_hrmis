using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.SMS;
using SmsDataContract;

namespace SEP.HRMIS.Bll.TraineeApplications.MailAndPhone
{
    ///<summary>
    ///</summary>
    public class TraineeApplicationPhoneOver
    {
        private static readonly ITraineeApplication _DalTraineeApplication = DataAccess.CreateTraineeApplication();
        private readonly TraineeApplication _TraineeApplication;
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly ISendSMSBll _Sms = BllInstance.SendSMSBllInstance;
        private readonly int _NowAccount;

        /// <summary>
        /// 
        /// </summary>
        public TraineeApplicationPhoneOver(int traineeApplicationID, int nowAccountID)
        {
            _TraineeApplication = _DalTraineeApplication.GetTraineeApplicationByTraineeApplicationID(traineeApplicationID);
            _TraineeApplication.Applicant = _AccountBll.GetAccountById(_TraineeApplication.Applicant.Id);
            _NowAccount = nowAccountID;
        }

        /// <summary>
        /// ∑¢ÀÕ…Û∫ÀΩ· ¯” º˛
        /// </summary>
        public void ConfirmOverPhone()
        {
            ConfirmMessage confirmmessage = new ConfirmMessage();
            confirmmessage.FinishPhoneMessageOperationByAssessorID(
                new PhoneMessageType(PhoneMessageEnumType.LeaveRequest,
                                     _TraineeApplication.PKID), _NowAccount);
            if (_TraineeApplication.TraineeApplicationStatuss == TraineeApplicationStatus.ApproveFail ||
                _TraineeApplication.TraineeApplicationStatuss == TraineeApplicationStatus.ApprovePass)
            {
                string contant = "";
                if (_TraineeApplication.TraineeApplicationStatuss == TraineeApplicationStatus.ApproveFail)
                {
                    contant = "ƒ„µƒ≈‡—µ…Í«Î“—…Û∫Àæ‹æ¯";
                }
                else if (_TraineeApplication.TraineeApplicationStatuss == TraineeApplicationStatus.ApprovePass )
                {
                    contant = "ƒ„µƒ≈‡—µ…Í«Î“—…Û∫ÀÕ®π˝";
                }
                _Sms.SendOneMessage(
                    new SendMessageDataModel(-1, _TraineeApplication.Applicant.MobileNum, contant,
                                             SmsClientProcessCenter._HrmisId));
            }
        }

    }
}
