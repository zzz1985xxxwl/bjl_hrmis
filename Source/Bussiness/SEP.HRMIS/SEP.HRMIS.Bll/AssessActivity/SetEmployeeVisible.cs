using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class SetEmployeeVisible : Transaction
    {
        private readonly int _AssessActivityID;
        private readonly bool _IfEmployeeVisible;
        private Model.AssessActivity _AssessActivity;

        private readonly IAssessActivity _IAssessActivity = new AssessActivityDal();

        /// <summary>
        /// 
        /// </summary>
        public SetEmployeeVisible(int assessActivityID, bool ifEmployeeVisible)
        {
            _AssessActivityID = assessActivityID;
            _IfEmployeeVisible = ifEmployeeVisible;
        }

        protected override void Validation()
        {
            _AssessActivity = _IAssessActivity.GetAssessActivityById(_AssessActivityID);
            if (_AssessActivity == null)
            {
                BllUtility.ThrowException(BllExceptionConst._InvalidActivityId);
            }
        }

        protected override void ExcuteSelf()
        {
            _AssessActivity.IfEmployeeVisible = _IfEmployeeVisible;
            _IAssessActivity.UpdateAssessActivityEmployeeVisible(_AssessActivity.AssessActivityID,
                                                                 _AssessActivity.IfEmployeeVisible);
            if (_IfEmployeeVisible)
            {
                try
                {
                    MailBody mailBody = CreateMailBody();
                    if ((mailBody.MailTo.Count != 0 || mailBody.MailCc.Count != 0))
                    {
                        BllInstance.MailGateWayBllInstance.Send(mailBody);
                    }
                }
                catch
                {
                }
            }
        }

        private MailBody CreateMailBody()
        {
            MailBody mailBody = new MailBody();
            mailBody.Subject = "您的【" +
                               AssessActivityUtility.GetCharacterNameByType(_AssessActivity.AssessCharacterType) +" "+
                               _AssessActivity.ScopeFrom.ToShortDateString() + "至" +
                               _AssessActivity.ScopeTo.ToShortDateString() + "】已经结束，请登录系统查看评估表。";

            StringBuilder sbMailBody = new StringBuilder(mailBody.Subject);
            mailBody.Body = sbMailBody.ToString();

            Account account = BllInstance.AccountBllInstance.GetAccountById(_AssessActivity.ItsEmployee.Account.Id);
            List<Account> accounts = new List<Account>();
            accounts.Add(account);
            List<List<string>> emails;
            emails = BllUtility.GetEmailsByAccountIds(accounts);

            mailBody.MailTo = emails[0];
            mailBody.MailCc = emails[1];

            return mailBody;
        }

    }
}
