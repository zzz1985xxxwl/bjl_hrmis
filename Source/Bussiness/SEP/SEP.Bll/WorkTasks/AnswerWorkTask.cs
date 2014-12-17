using System.Collections.Generic;
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Bll.WorkTasks
{
    internal class AnswerWorkTask : Transaction
    {
        private readonly WorkTaskQA _WorkTaskQA;
        private readonly bool _IfEmail;

        public AnswerWorkTask(WorkTaskQA workTaskQA, bool ifEmail)
        {
            _WorkTaskQA = workTaskQA;
            _IfEmail = ifEmail;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.WorkTaskDalInstance.UpdateWorkTaskQA(_WorkTaskQA);

                if (_IfEmail)
                {
                    string subject = _WorkTaskQA.AAccount.Name + "给你的工作计划留言";
                    List<string> to = new List<string>();
                    Account account = DalInstance.AccountDalInstance.GetAccountById(_WorkTaskQA.QAccount.Id);
                    if (account != null && account.Id > 0)
                    {
                        to.Add(account.Email1);
                    }
                    new WorkTaskEmail(subject, WorkTaskEmail.BuildAnswerWorkTaskMailBody(_WorkTaskQA), to).SendMail();
                }
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        protected override void Validation()
        {
            _WorkTaskQA.WorkTask = DalInstance.WorkTaskDalInstance.GetWorkTaskByPKID(_WorkTaskQA.WorkTask.Pkid);
            if (_WorkTaskQA.WorkTask == null)
            {
                throw MessageKeys.AppException(MessageKeys._WorkTask_IsNot_Exist);
            }
            _WorkTaskQA.WorkTask.Account = DalInstance.AccountDalInstance.GetAccountById(_WorkTaskQA.WorkTask.Account.Id);
            if (_WorkTaskQA.WorkTask.Account == null)
            {
                throw MessageKeys.AppException(MessageKeys._Account_IsNot_Exist);
            }
        }
    }
}