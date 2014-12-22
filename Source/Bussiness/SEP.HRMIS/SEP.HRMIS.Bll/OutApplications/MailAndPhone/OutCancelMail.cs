//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutCancelMail.cs
// Creater:  Xue.wenlong
// Date:  2009-05-18
// Resume:
// ---------------------------------------------------------------

using System.Text;
using Mail.Model;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OutApplications.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OutCancelMail
    {
        private static readonly IOutApplication _OutApplicationDal = new OutApplicationDal();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly OutApplication _OutApplication;
        private readonly OutDiyProcessUtility _OutDiyProcessUtility = new OutDiyProcessUtility();

        /// <summary>
        /// </summary>
        public OutCancelMail(int outApplicationId)
        {
            _OutApplication = _OutApplicationDal.GetOutApplicationByOutApplicationID(outApplicationId);
            _OutApplication.Account = _AccountBll.GetAccountById(_OutApplication.Account.Id);
        }


        /// <summary>
        /// 
        /// </summary>
        public void SendMail()
        {
            SendCancelMail();
        }

        private void SendCancelMail()
        {
            Account mailToAccount = GetMailToAccount();
            MailBody mailBody = new MailBody();
            BuildSubmitMailBody(mailBody, mailToAccount);
            mailBody.MailTo = RequestUtility.GetMail(mailToAccount);
            _MailGateWay.Send(mailBody);
        }

        private void BuildSubmitMailBody(MailBody mailBody, Account to)
        {
            string subject = string.Format("{0}取消外出申请，请审批", _OutApplication.Account.Name);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append(OutApplicationMail.BuildBody(_OutApplication));
            OutApplicationMail.BulidConfirmAddress(mailContent, to, _OutApplication.PKID);
            mailBody.Body = mailContent.ToString();
            mailBody.Subject = subject;
            mailBody.IsHtmlBody = true;
        }


        private Account GetMailToAccount()
        {
            Account account =
                _OutDiyProcessUtility.GetNextOperator(_OutApplication.DiyProcess, 1,_OutApplication.Account.Id);
            account = _AccountBll.GetAccountById(account.Id);
            return account;
        }
    }
}