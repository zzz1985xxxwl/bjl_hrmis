//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkOverMail.cs
// Creater:  Xue.wenlong
// Date:  2009-05-19
// Resume:
// ---------------------------------------------------------------
using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.HRMIS.Bll.DiyProcesses;

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
    public class OverWorkOverMail
    {
        private static readonly IOverWork _OverWorkDal = new OverWorkDal();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly OverWork _OverWork;
        private readonly OverWorkDiyProcessUtility _OverWorkDiyProcessUtility = new OverWorkDiyProcessUtility();
        private readonly GetDiyProcess _GetDiyProcess = new GetDiyProcess();
        /// <summary>
        /// 
        /// </summary>
        public OverWorkOverMail(int overWorkId)
        {
            _OverWork = _OverWorkDal.GetOverWorkByOverWorkID(overWorkId);
            _OverWork.Account = _AccountBll.GetAccountById(_OverWork.Account.Id);
        }

        /// <summary>
        /// 发送审核结束邮件
        /// </summary>
        public void ConfirmOverMail()
        {
            bool val = true;
            foreach (OverWorkItem item in _OverWork.Item)
            {
                val &= item.Status == RequestStatus.ApproveCancelFail ||
                       item.Status == RequestStatus.ApproveCancelPass ||
                       item.Status == RequestStatus.ApproveFail ||
                       item.Status == RequestStatus.ApprovePass;
            }
            if (val)
            {
                MailBody mailBody = new MailBody();
                mailBody.Subject = string.Format("审核完毕{0}的加班单", _OverWork.Account.Name);
                StringBuilder body = new StringBuilder();
                body.AppendFormat(OverWorkMail.BuildBody(_OverWork));
                mailBody.Body = body.ToString();
                mailBody.IsHtmlBody = true;
                mailBody.MailTo = RequestUtility.GetMail(_OverWork.Account);
                foreach (OverWorkItem item in _OverWork.Item)
                {
                    if (item.Status == RequestStatus.ApprovePass || item.Status == RequestStatus.ApproveCancelFail)
                    {
                        mailBody.MailCc = SendMailToMailCC();
                        break;
                    }
                }
               
                _MailGateWay.Send(mailBody);
            }
        }

        /// <summary>
        /// 给要抄送的人发邮件,主要是人事，所以，在整个加班单审核结束后发送
        /// </summary>
        private List<string> SendMailToMailCC()
        {
            List<string> mailToList = new List<string>();
            foreach (
                Account account in
                    _OverWorkDiyProcessUtility.GetLastMailCC(_OverWork.DiyProcess))
            {
                Account innaccount = _AccountBll.GetAccountById(account.Id);
                mailToList.AddRange(RequestUtility.GetMail(innaccount));
            }
            List<Account> accounts = _GetDiyProcess.GetHRPrincipalByAccountID(_OverWork.Account.Id);
            foreach (Account acc in accounts)
            {
                mailToList.AddRange(RequestUtility.GetMail(acc));
            }
            return RequestUtility.CleanMailAddress(mailToList);
        }
    }
}