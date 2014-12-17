
using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.TraineeApplications.MailAndPhone
{
    ///<summary>
    ///</summary>
    public class TraineeApplicationPhoneConfirm
    {
        private static readonly ITraineeApplication _DalTraineeApplication = DataAccess.CreateTraineeApplication();
        private readonly TraineeApplication _TraineeApplication;
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;

        /// <summary>
        /// 
        /// </summary>
        public TraineeApplicationPhoneConfirm(int traineeApplicationID)
        {
            _TraineeApplication = _DalTraineeApplication.
                GetTraineeApplicationByTraineeApplicationID(traineeApplicationID);
            _TraineeApplication.Applicant = _AccountBll.GetAccountById(_TraineeApplication.Applicant.Id);
        }

        /// <summary>
        /// 给下一步操作人发邮件
        /// </summary>
        public void SendPhoneToNextOperator(int nextOperator,  int nowAccount)
        {
            ConfirmMessage confirmmessage = new ConfirmMessage();
            confirmmessage.FinishPhoneMessageOperationByAssessorID(
                new PhoneMessageType(PhoneMessageEnumType.LeaveRequest,
                                     _TraineeApplication.PKID), nowAccount);
            Account phoneToAccount = _AccountBll.GetAccountById(nextOperator);
            confirmmessage.SendConfirmMessage(phoneToAccount,
                                              new PhoneMessageType(PhoneMessageEnumType.LeaveRequest,
                                                                   _TraineeApplication.PKID));
        }
    }
}
