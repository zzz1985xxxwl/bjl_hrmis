using System.Text;
using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.LeaveRequests.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class LeaveRequestSubmitPhone
    {
        private readonly ILeaveRequestDal _DalLeaveRequest = new LeaveRequestDal();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly LeaveRequest _LeaveRequest;
        private readonly DiyStep _NextStep;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="nextStep"></param>
        public LeaveRequestSubmitPhone(int leaveRequestID, DiyStep nextStep)
        {
            _LeaveRequest = _DalLeaveRequest.GetLeaveRequestByPKID(leaveRequestID);
            _LeaveRequest.Account = _AccountBll.GetAccountById(_LeaveRequest.Account.Id);
            _NextStep = nextStep;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SendPhone()
        {
            foreach (LeaveRequestItem item in _LeaveRequest.LeaveRequestItems)
            {
                if (item.Status.Id == RequestStatus.Submit.Id)
                {
                    Account phoneToAccount = new MailAndPhoneUtility().GetMailToAccount(_LeaveRequest, _NextStep);
                    string contant = BuildBody(item);
                    ConfirmMessage confirmmessage = new ConfirmMessage();
                    confirmmessage.SendNewMessage(_LeaveRequest.Account, phoneToAccount, contant,
                                                  new PhoneMessageType(PhoneMessageEnumType.LeaveRequest, item.LeaveRequestItemID));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string BuildBody(LeaveRequestItem item)
        {
            StringBuilder Content = new StringBuilder();
            Content.AppendFormat("请审批{0}提交的请假申请,从{2}到{3},请{1},共{4}小时,理由:{5}",
                                 _LeaveRequest.Account.Name, _LeaveRequest.LeaveRequestType.Name, item.FromDate,
                                 item.ToDate, item.CostTime, _LeaveRequest.Reason);
            return Content.ToString();
        }
    }
}
