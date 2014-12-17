using System.Text;
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
    public class TraineeApplicationPhoneSubmit
    {
        private static readonly ITraineeApplication _DalTraineeApplication = DataAccess.CreateTraineeApplication();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly TraineeApplication _TraineeApplication;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="traineeApplicationID"></param>
        public TraineeApplicationPhoneSubmit(int traineeApplicationID)
        {
            _TraineeApplication = _DalTraineeApplication.
                GetTraineeApplicationByTraineeApplicationID(traineeApplicationID);
            _TraineeApplication.Applicant = _AccountBll.GetAccountById(_TraineeApplication.Applicant.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SendPhone()
        {
            if (_TraineeApplication.TraineeApplicationStatuss.Id == 
                TraineeApplicationStatus.Submit.Id)
            {
                Account phoneToAccount = new TAMailAndPhoneUtility().GetMailToAccount(_TraineeApplication);
                string contant = BuildBody(_TraineeApplication);
                ConfirmMessage confirmmessage = new ConfirmMessage();
                confirmmessage.SendNewMessage(_TraineeApplication.Applicant, phoneToAccount, contant,
                                              new PhoneMessageType(PhoneMessageEnumType.TraineeApplication,
                                                                   _TraineeApplication.PKID));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static string BuildBody(TraineeApplication traineeApplication)
        {
            StringBuilder Content = new StringBuilder();
            Content.AppendFormat("请审批{0}提交的培训申请,申请课程:{1},时间范围:从{2}到{3},培训费用:{4}",
                                 traineeApplication.Applicant.Name,
                                 traineeApplication.CourseName,
                                 traineeApplication.StratTime,
                                 traineeApplication.EndTime,
                                 traineeApplication.TrainCost);
            return Content.ToString();
        }

    }
}
