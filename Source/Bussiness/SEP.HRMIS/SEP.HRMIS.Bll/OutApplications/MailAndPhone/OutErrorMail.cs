using System.Collections.Generic;
using Mail.Model;
using SEP.HRMIS.Bll.DiyProcesses;
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
    ///<summary>
    ///</summary>
    public class OutErrorMail
    {
        private static readonly IOutApplication _OutApplicationDal = DalFactory.DataAccess.CreateOutApplication();
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly OutApplication _OutApplication;
        private readonly List<Account> _Accounts;
        private readonly GetDiyProcess _GetDiyProcess = new GetDiyProcess();
        /// <summary>
        /// 
        /// </summary>
        public OutErrorMail(int applicationID)
        {
            
            _OutApplication = _OutApplicationDal.GetOutApplicationByOutApplicationID(applicationID);
            _OutApplication.Account = _AccountBll.GetAccountById(_OutApplication.Account.Id);
            _Accounts = _GetDiyProcess.GetHRPrincipalByAccountID(_OutApplication.Account.Id); 
        }

        /// <summary>
        /// 发送审核结束邮件
        /// </summary>
        public void Send()
        {
           
                MailBody mailBody = new MailBody();
                mailBody.Subject = string.Format("{0}的外出申请由于无法找到审批人而异常中断",_OutApplication.Account.Name);
                mailBody.Body = OutApplicationMail.BuildBody(_OutApplication);
                mailBody.MailTo = SendMailTo();
                _MailGateWay.Send(mailBody);
           
        }

        /// <summary>
        /// 给要抄送的人发邮件,主要是人事，所以，在整个外出单审核结束后发送
        /// </summary>
        private List<string> SendMailTo()
        {
            List<string> mailToList = new List<string>();
            foreach (Account account in _Accounts)
            {
                mailToList.AddRange(RequestUtility.GetMail(account));
            }
            return mailToList;
        }
    }
}