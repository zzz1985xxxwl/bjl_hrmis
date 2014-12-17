using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.LeaveRequests.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class LeaveRequestMailAndPhoneDelegate
    {
        private readonly LeaveRequestMail _LeaveRequestMail = new LeaveRequestMail();
        private readonly LeaveRequestPhone _LeaveRequestPhone = new LeaveRequestPhone();

        /// <summary>
        /// 发送提交邮件短信
        /// </summary>
        public void SubmitOperation(int leaveRequestID, List<Account> cclist, List<Account> diyProcesslist, DiyStep nextStep)
        {
            _LeaveRequestMail.SendSubmitMail(leaveRequestID, cclist, diyProcesslist, nextStep);
            _LeaveRequestPhone.SendSubmitPhone(leaveRequestID, nextStep);
        }

        /// <summary>
        /// 发送取消短信
        /// </summary>
        public void CancelOperation(int leaveRequestID, LeaveRequestItem item, List<Account> diyProcessAccountlist, DiyStep nextStep)
        {
            
            _LeaveRequestPhone.SendCancelPhone(leaveRequestID, item, nextStep);
        }
        /// <summary>
        /// 发送取消邮件
        /// </summary>
        public void CancelMail(int leaveRequestID,  List<Account> diyProcessAccountlist, DiyStep nextStep)
        {
            _LeaveRequestMail.SendCancelMail(leaveRequestID,  diyProcessAccountlist, nextStep);
        }

        /// <summary>
        /// 审核
        /// </summary>
        public void ConfirmOperation(LeaveRequest leaveRequest, LeaveRequestItem item, List<Account> hrAccount,
            int currentAccountID, DiyStep currentStep, DiyStep nextStep)
        {
            Account mailToAccount = new MailAndPhoneUtility().GetMailToAccount(leaveRequest, nextStep);
            if (nextStep.DiyStepID == 0 || nextStep.Status == "取消")
            {
                _LeaveRequestPhone.SendConfirmOverPhone(leaveRequest.PKID, item, currentStep, currentAccountID);
            }
            else if (mailToAccount != null)
            {
                _LeaveRequestPhone.SendPhoneToNextOperator(leaveRequest.PKID, item, mailToAccount.Id,
                                                           currentAccountID);
            }
        }
        /// <summary>
        /// 审核
        /// </summary>
        public void ConfirmOperationMail(LeaveRequest leaveRequest, List<Account> hrAccount,
            int currentAccountID, DiyStep currentStep, DiyStep nextStep)
        {
            Account mailToAccount = new MailAndPhoneUtility().GetMailToAccount(leaveRequest, nextStep);
            if (nextStep.DiyStepID == 0 || nextStep.Status == "取消")
            {
                _LeaveRequestMail.SendConfirmOverMail(leaveRequest.PKID,  hrAccount, currentStep);
            }
            else if (mailToAccount != null)
            {
                _LeaveRequestMail.SendMailToNextOperator(leaveRequest.PKID,  mailToAccount);
            }
        }
    }
}
