using System.Collections.Generic;
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Bll.WorkTasks
{
    internal class AddWorkTask : Transaction
    {
        private readonly WorkTask _WorkTask;
        private readonly bool _IfEmail;

        public AddWorkTask(WorkTask workTask, bool ifEmail)
        {
            _WorkTask = workTask;
            _IfEmail = ifEmail;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.WorkTaskDalInstance.Add(_WorkTask);

                if(_IfEmail)
                {
                    string subject = _WorkTask.Account.Name + "新增了一个工作计划";
                    List<string> to = new List<string>();
                    AccountBll accountBll = new AccountBll();
                    Account account = accountBll.GetLeaderByAccountId(_WorkTask.Account.Id);
                    account = DalInstance.AccountDalInstance.GetAccountById(account.Id);
                    if (account != null && account.Id > 0)
                    {
                        to.Add(account.Email1);
                        if(!string.IsNullOrEmpty(account.Email2))
                            to.Add(account.Email2);
                    }

                    for (int i = 0; i < _WorkTask.Responsibles.Count;i++ )
                    {
                        Account responsible =
                            DalInstance.AccountDalInstance.GetAccountById(_WorkTask.Responsibles[i].Id);
                        if (responsible != null && responsible.Id > 0)
                        {
                            to.Add(responsible.Email1);
                            if (!string.IsNullOrEmpty(responsible.Email2))
                                to.Add(responsible.Email2);
                        }
                    }
                    new WorkTaskEmail(subject, WorkTaskEmail.BuildWorkTaskMailBody(_WorkTask).ToString(), to).SendMail();
                }
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        protected override void Validation()
        {
            _WorkTask.Account = DalInstance.AccountDalInstance.GetAccountById(_WorkTask.Account.Id);
            if (_WorkTask.Account == null)
            {
                throw MessageKeys.AppException(MessageKeys._WorkTask_IsNot_Exist);
            }
            for (int i = _WorkTask.Responsibles.Count - 1; i >= 0; i--)
            {
                if (_WorkTask.Responsibles[i].Id == _WorkTask.Account.Id)
                {
                    _WorkTask.Responsibles.RemoveAt(i);
                }
            }
        }
    }
}