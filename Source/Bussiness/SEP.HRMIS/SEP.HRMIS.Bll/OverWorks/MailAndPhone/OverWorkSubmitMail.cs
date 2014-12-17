//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkSubmitMail.cs
// Creater:  Xue.wenlong
// Date:  2009-05-19
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OverWorks.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OverWorkSubmitMail
    {
        private static readonly IOverWork _OverWorkDal = DalFactory.DataAccess.CreateOverWork();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly OverWork _OverWork;
        private readonly OverWorkDiyProcessUtility _OverWorkDiyProcessUtility = new OverWorkDiyProcessUtility();
        private readonly List<Account> _CCList;

        /// <summary>
        /// </summary>
        public OverWorkSubmitMail(int overWorkId, List<Account> cclist)
        {
            _OverWork = _OverWorkDal.GetOverWorkByOverWorkID(overWorkId);
            _OverWork.Account = _AccountBll.GetAccountById(_OverWork.Account.Id);
            _CCList = cclist;
        }


        /// <summary>
        /// 
        /// </summary>
        public void SendMail()
        {
            foreach (OverWorkItem item in _OverWork.Item)
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
            BuildSubmitMailBody(mailBody,  mailToAccount, true);
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
                    _OverWorkDiyProcessUtility.GetMailCC(_OverWork.Item[0].OverWorkFlow,
                                                         _OverWork.DiyProcess))
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);
                mailToList.AddRange(RequestUtility.GetMail(innaccount));
            }

            if (mailToList.Count > 0)
            {
                MailBody mailBody = new MailBody();
                BuildSubmitMailBody(mailBody,  null, false);
                mailBody.MailTo = mailToList;
                mailBody.Subject = string.Format("抄送：{0}提交加班申请", _OverWork.Account.Name);
                _MailGateWay.Send(mailBody);
            }
        }

        private void BuildSubmitMailBody(MailBody mailBody, Account to, bool addConfirmAddress)
        {
            string subject = string.Format("{0}提交加班申请，请审批", _OverWork.Account.Name);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append(OverWorkMail.BuildBody(_OverWork));
            if (addConfirmAddress)
            {
                OverWorkMail.BulidConfirmAddress(mailContent, to, _OverWork.PKID);
            }
            mailBody.Body = mailContent.ToString();
            mailBody.Subject = subject;
            mailBody.IsHtmlBody = true;
        }


        private Account GetMailToAccount()
        {
            Account account =
                _OverWorkDiyProcessUtility.GetNextOperator(_OverWork.DiyProcess, _OverWork.Item[0],
                                                           _OverWork.Account.Id);
            account = _AccountBll.GetAccountById(account.Id);
            return account;
        }
    }
}