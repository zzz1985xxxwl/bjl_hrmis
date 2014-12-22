//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkCancelMail.cs
// Creater:  Xue.wenlong
// Date:  2009-05-19
// Resume:
// ---------------------------------------------------------------
using System.Text;
using Mail.Model;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OverWorks.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OverWorkCancelMail
    {
        private static readonly IOverWork _OverWorkDal = new OverWorkDal();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly OverWork _OverWork;
        private readonly OverWorkDiyProcessUtility OverWorkDiyProcessUtility = new OverWorkDiyProcessUtility();

        /// <summary>
        /// </summary>
        public OverWorkCancelMail(int overWorkId)
        {
            _OverWork = _OverWorkDal.GetOverWorkByOverWorkID(overWorkId);
            _OverWork.Account = _AccountBll.GetAccountById(_OverWork.Account.Id);
        }


        /// <summary>
        /// 
        /// </summary>
        public void SendMail()
        {
            SendSubmitToMail();
        }

        private void SendSubmitToMail()
        {
            Account mailToAccount = GetMailToAccount();
            MailBody mailBody = new MailBody();
            BuildSubmitMailBody(mailBody, mailToAccount);
            mailBody.MailTo = RequestUtility.GetMail(mailToAccount);
            _MailGateWay.Send(mailBody);
        }

        private void BuildSubmitMailBody(MailBody mailBody, Account to)
        {
            string subject = string.Format("{0}取消加班申请，请审批", _OverWork.Account.Name);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append(OverWorkMail.BuildBody(_OverWork));
            OverWorkMail.BulidConfirmAddress(mailContent, to, _OverWork.PKID);
            mailBody.Body = mailContent.ToString();
            mailBody.Subject = subject;
            mailBody.IsHtmlBody = true;
        }


        private Account GetMailToAccount()
        {
            Account account =
                OverWorkDiyProcessUtility.GetNextOperator(_OverWork.DiyProcess, 1, _OverWork.Account.Id);
            account = _AccountBll.GetAccountById(account.Id);
            return account;
        }
    }
}