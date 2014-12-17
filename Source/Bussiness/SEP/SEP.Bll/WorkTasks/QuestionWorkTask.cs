using System.Collections.Generic;
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Bll.WorkTasks
{
    internal class QuestionWorkTask : Transaction
    {
        private readonly WorkTaskQA _WorkTaskQA;
        private readonly bool _IfEmail;

        public QuestionWorkTask(WorkTaskQA workTaskQA, bool ifEmail)
        {
            _WorkTaskQA = workTaskQA;
            _IfEmail = ifEmail;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                if (_WorkTaskQA.Pkid == 0)
                {
                    DalInstance.WorkTaskDalInstance.AddWorkTaskQA(_WorkTaskQA);
                }
                else
                {
                    DalInstance.WorkTaskDalInstance.UpdateWorkTaskQA(_WorkTaskQA);
                }

                if (_IfEmail)
                {
                    string subject = _WorkTaskQA.QAccount.Name + "´ð¸´ÁËÄãµÄÁôÑÔ";
                    List<string> to = new List<string>();
                    Account account = DalInstance.AccountDalInstance.GetAccountById(_WorkTaskQA.WorkTask.Account.Id);
                    if (account != null && account.Id > 0)
                    {
                        to.Add(account.Email1);
                    }
                    new WorkTaskEmail(subject, WorkTaskEmail.BuildQuestionWorkTaskMailBody(_WorkTaskQA), to).SendMail();
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