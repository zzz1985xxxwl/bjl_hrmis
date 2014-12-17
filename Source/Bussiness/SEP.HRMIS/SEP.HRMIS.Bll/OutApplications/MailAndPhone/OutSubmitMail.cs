//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SubmitMail.cs
// Creater:  Xue.wenlong
// Date:  2009-05-18
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OutApplications.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OutSubmitMail
    {
        private static readonly IOutApplication _OutApplicationDal = DalFactory.DataAccess.CreateOutApplication();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly OutApplication _OutApplication;
        private readonly OutDiyProcessUtility _OutDiyProcessUtility = new OutDiyProcessUtility();
        private readonly List<Account> _CCList;

        /// <summary>
        /// </summary>
        public OutSubmitMail(int outApplicationId, List<Account> cclist)
        {
            _OutApplication = _OutApplicationDal.GetOutApplicationByOutApplicationID(outApplicationId);
            _OutApplication.Account = _AccountBll.GetAccountById(_OutApplication.Account.Id);
            _CCList = cclist;
        }


        /// <summary>
        /// 
        /// </summary>
        public void SendMail()
        {
            foreach (OutApplicationItem item in _OutApplication.Item)
            {
                if (item.Status == RequestStatus.Submit)
                {
                    SendSubmitToMail();
                    SendSubmitCCMail(_CCList);
                    break;
                }
            }
        }

        private void SendSubmitToMail()
        {
            Account mailToAccount = GetMailToAccount();
            MailBody mailBody = new MailBody();
            BuildSubmitMailBody(mailBody,mailToAccount, true);
            mailBody.MailTo = RequestUtility.GetMail(mailToAccount);
            _MailGateWay.Send(mailBody);
        }

        private void SendSubmitCCMail(IEnumerable<Account> cclist)
        {
            List<string> mailToList = new List<string>();
            foreach (Account account in cclist)
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);
                mailToList.AddRange(RequestUtility.GetMail(innaccount));
            }
            foreach (
                Account account in
                    _OutDiyProcessUtility.GetMailCC(_OutApplication.Item[0].OutApplicationFlow,
                                                    _OutApplication.DiyProcess))
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);
                mailToList.AddRange(RequestUtility.GetMail(innaccount));
            }

            if (mailToList.Count > 0)
            {
                MailBody mailBody = new MailBody();
                BuildSubmitMailBody(mailBody, null, false);
                mailBody.MailTo = mailToList;
                mailBody.Subject = string.Format("抄送：{0}提交外出申请", _OutApplication.Account.Name);
                _MailGateWay.Send(mailBody);
            }
        }

        private void BuildSubmitMailBody(MailBody mailBody, Account to, bool addConfirmAddress)
        {
            string subject = string.Format("{0}提交外出申请，请审批", _OutApplication.Account.Name);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append(OutApplicationMail.BuildBody(_OutApplication));
            if (addConfirmAddress)
            {
                OutApplicationMail.BulidConfirmAddress(mailContent, to, _OutApplication.PKID);
            }
            mailBody.Body = mailContent.ToString();
            mailBody.Subject = subject;
            mailBody.IsHtmlBody = true;
        }


        private Account GetMailToAccount()
        {
            Account account =
                _OutDiyProcessUtility.GetNextOperator(_OutApplication.DiyProcess, _OutApplication.Item[0],
                                                      _OutApplication.Account.Id);
            account = _AccountBll.GetAccountById(account.Id);
            return account;
        }
    }
}