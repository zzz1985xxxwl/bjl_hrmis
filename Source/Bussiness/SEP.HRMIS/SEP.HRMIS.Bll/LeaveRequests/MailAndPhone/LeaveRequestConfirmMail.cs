using System.Text;
using Mail.Model;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.LeaveRequests.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class LeaveRequestConfirmMail
    {
        private readonly ILeaveRequestDal _DalLeaveRequest = DalFactory.DataAccess.CreateLeaveRequest();
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly LeaveRequest _LeaveRequest;

        /// <summary>
        /// 
        /// </summary>
        public LeaveRequestConfirmMail(int leaveRequestID)
        {
            //_LeaveRequestItem = item;
            _LeaveRequest = _DalLeaveRequest.GetLeaveRequestByPKID(leaveRequestID);
            _LeaveRequest.Account = _AccountBll.GetAccountById(_LeaveRequest.Account.Id);
        }

        /// <summary>
        /// 给下一步操作人发邮件
        /// </summary>
        /// <param name="nextOperator"></param>
        public void SendMailToNextOperator(Account nextOperator)
        {
            foreach (LeaveRequestItem item in _LeaveRequest.LeaveRequestItems)
            {
                if (item.Status.Id == RequestStatus.Approving.Id ||
                    item.Status.Id == RequestStatus.CancelApproving.Id)
                {
                    MailBody mailBody = new MailBody();
                    nextOperator = _AccountBll.GetAccountById(nextOperator.Id);
                    BuildSubmitMailBody(mailBody, nextOperator, true);
                    _MailGateWay.Send(mailBody);
                    break;
                }
            }
        }

        private void BuildSubmitMailBody(MailBody mailBody, Account to, bool addConfirmAddress)
        {
            string subject = string.Format("请审批{0}的请假申请", _LeaveRequest.Account.Name);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append(LeaveRequestMail.BuildBody(_LeaveRequest));
            if (addConfirmAddress)
            {
                LeaveRequestMail.BulidConfirmAddress(mailContent, to, _LeaveRequest.PKID);
            }
            mailBody.MailTo = RequestUtility.GetMail(to);
            mailBody.Body = mailContent.ToString();
            mailBody.Subject = subject;
            mailBody.IsHtmlBody = true;
        }
    }
}