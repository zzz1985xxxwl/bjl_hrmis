using System.Collections.Generic;
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
    public class OverWorkErrorMail
    {
         private static readonly IOverWork _OverWorkDal = new OverWorkDal();
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly OverWork _OverWork;
        private readonly List<Account> _Accounts;
        private readonly GetDiyProcess _GetDiyProcess = new GetDiyProcess();
        /// <summary>
        /// 
        /// </summary>
        public OverWorkErrorMail(int applicationID)
        {
           
            _OverWork = _OverWorkDal.GetOverWorkByOverWorkID(applicationID);
            _OverWork.Account = _AccountBll.GetAccountById(_OverWork.Account.Id);
            _Accounts = _GetDiyProcess.GetHRPrincipalByAccountID(_OverWork.Account.Id); ;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Send()
        {
           
                MailBody mailBody = new MailBody();
                mailBody.Subject = string.Format("{0}的加班申请由于无法找到审批人而异常中断", _OverWork.Account.Name);
                mailBody.Body = OverWorkMail.BuildBody(_OverWork);
                mailBody.MailTo = SendMailTo();
                _MailGateWay.Send(mailBody);
           
        }

     
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