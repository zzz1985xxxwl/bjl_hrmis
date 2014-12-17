//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutConfirmMail.cs
// Creater:  Xue.wenlong
// Date:  2009-05-18
// Resume:
// ---------------------------------------------------------------

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
    public class OutConfirmMail
    {
        private static readonly IOutApplication _OutApplicationDal = DalFactory.DataAccess.CreateOutApplication();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly OutApplication _OutApplication;

        /// <summary>
        /// 
        /// </summary>
        public OutConfirmMail(int outApplicationId)
        {
            _OutApplication = _OutApplicationDal.GetOutApplicationByOutApplicationID(outApplicationId);
            _OutApplication.Account = _AccountBll.GetAccountById(_OutApplication.Account.Id);
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
            string subject = string.Format("请审批{0}的外出申请，", _OutApplication.Account.Name);
            StringBuilder mailContent = new StringBuilder();
            mailContent.Append(OutApplicationMail.BuildBody(_OutApplication));
            if (addConfirmAddress)
            {
                OutApplicationMail.BulidConfirmAddress(mailContent, to, _OutApplication.PKID);
            }
            mailBody.MailTo = RequestUtility.GetMail(to);
            mailBody.Body = mailContent.ToString();
            mailBody.Subject = subject;
            mailBody.IsHtmlBody = true;
        }
    }
}