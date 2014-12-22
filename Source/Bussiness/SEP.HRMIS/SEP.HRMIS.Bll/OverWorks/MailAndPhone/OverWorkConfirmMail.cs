//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkConfirmMail.cs
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
    public class OverWorkConfirmMail
    {
        private static readonly IOverWork _OverWorkDal = new OverWorkDal();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly OverWork _OverWork;
        /// <summary>
        /// 
        /// </summary>
        public OverWorkConfirmMail(int overWorkId)
        {
            _OverWork = _OverWorkDal.GetOverWorkByOverWorkID(overWorkId);
            _OverWork.Account = _AccountBll.GetAccountById(_OverWork.Account.Id);
        }


        /// <summary>
        /// 给下一步操作人发邮件
        /// </summary>
        /// <param name="nextOperator"></param>
        public void SendMailToNextOperator(Account nextOperator)
        {
            if(nextOperator!=null)
            {
                MailBody mailBody = new MailBody();
                nextOperator = _AccountBll.GetAccountById(nextOperator.Id);
                BuildSubmitMailBody(mailBody, nextOperator, true);
                _MailGateWay.Send(mailBody);
            }
        }

        private void BuildSubmitMailBody(MailBody mailBody, Account to, bool addConfirmAddress)
        {
            string subject = string.Format("请审批的{0}加班申请，", _OverWork.Account.Name);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append(OverWorkMail.BuildBody(_OverWork));
            if (addConfirmAddress)
            {
                OverWorkMail.BulidConfirmAddress(mailContent, to, _OverWork.PKID);
            }
            mailBody.MailTo = RequestUtility.GetMail(to);
            mailBody.Body = mailContent.ToString();
            mailBody.Subject = subject;
            mailBody.IsHtmlBody = true;
        }
    }
}