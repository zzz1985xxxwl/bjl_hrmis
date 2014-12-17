using System;
using System.Collections.Generic;
using SEP.IBll;
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Bll.WorkTasks
{
    internal class WorkTaskBll : IWorkTaskBll
    {
        public void CreateWorkTask(WorkTask workTask, bool ifEmail)
        {
            AddWorkTask addWorkTask = new AddWorkTask(workTask, ifEmail);
            addWorkTask.Excute();
        }

        public void UpdateWorkTask(WorkTask workTask, bool ifEmail)
        {
            UpdateWorkTask updateWorkTask = new UpdateWorkTask(workTask, ifEmail);
            updateWorkTask.Excute();
        }

        public void DeleteWorkTask(int workTaskID)
        {
            DeleteWorkTask deleteWorkTask = new DeleteWorkTask(workTaskID);
            deleteWorkTask.Excute();
        }

        public WorkTask GetWorkTask(int workTaskID)
        {
            return DalInstance.WorkTaskDalInstance.GetWorkTaskByPKID(workTaskID);
        }

        public List<WorkTask> GetMyWorkTaskByCondition(string title, DateTime from, DateTime to, int priority, bool ifNotStarted, bool ifOngoing, bool ifFailure, bool ifFinish, int accountID)
        {
            List<WorkTask> workTasks = DalInstance.WorkTaskDalInstance.GetMyWorkTaskByCondition(title, from, to, priority, ifNotStarted, ifOngoing, ifFailure, ifFinish, accountID);
            for (int i = 0; i < workTasks.Count; i++)
            {
                workTasks[i] = DalInstance.WorkTaskDalInstance.GetWorkTaskByPKID(workTasks[i].Pkid);
            }
            return workTasks;
        }

        public List<WorkTask> GetResponsibleWorkTaskByCondition(string title, DateTime from, DateTime to, int priority, bool ifNotStarted, bool ifOngoing, bool ifFailure, bool ifFinish, int accountID)
        {
            List<WorkTask> workTasks = DalInstance.WorkTaskDalInstance.GetResponsibleWorkTaskByCondition(title, from, to, priority, ifNotStarted, ifOngoing, ifFailure, ifFinish, accountID);
            for (int i = 0; i < workTasks.Count; i++)
            {
                workTasks[i] = DalInstance.WorkTaskDalInstance.GetWorkTaskByPKID(workTasks[i].Pkid);
            }
            return workTasks;
        }

        public void QuestionWorkTask(WorkTaskQA workTaskQA, bool ifEmail)
        {
            QuestionWorkTask questionWorkTask = new QuestionWorkTask(workTaskQA, ifEmail);
            questionWorkTask.Excute();
        }

        public void AnswerWorkTask(WorkTaskQA workTaskQA, bool ifEmail)
        {
            AnswerWorkTask answerWorkTask = new AnswerWorkTask(workTaskQA, ifEmail);
            answerWorkTask.Excute();
        }

        public void DeleteWorkTaskQA(int pkid)
        {
            DeleteWorkTaskQA answerWorkTask = new DeleteWorkTaskQA(pkid);
            answerWorkTask.Excute();
        }

        public WorkTaskQA GetWorkTaskQA(int pkid)
        {
            return DalInstance.WorkTaskDalInstance.GetWorkTaskQAByPKID(pkid);
        }
        public List<WorkTask> GetTeamWorkTaskByCondition(string creatorname, string deptname, string title, DateTime from, DateTime to,
    int priority, bool ifNotStarted, bool ifOngoing, bool ifFailure, bool ifFinish, int accountID)
        {
            List<WorkTask> workTasks = new List<WorkTask>();
            Account Leader = new AccountBll().GetAccountById(accountID);
            if (Leader == null)
            {
                return workTasks;
            }
            List<Account> accounts = new AccountBll().GetChargeAccountByNameAndDeptString(creatorname, deptname, Leader);
            for (int i = 0; i < accounts.Count; i++)
            {
                workTasks.AddRange(
                    DalInstance.WorkTaskDalInstance.GetMyWorkTaskByCondition(title, from, to, priority, ifNotStarted,
                                                                             ifOngoing, ifFailure, ifFinish,
                                                                             accounts[i].Id));
                workTasks.AddRange(
                    DalInstance.WorkTaskDalInstance.GetResponsibleWorkTaskByCondition(title, from, to, priority,
                                                                                      ifNotStarted,
                                                                                      ifOngoing, ifFailure, ifFinish,
                                                                                      accounts[i].Id));
            }
            for (int i = 0; i < workTasks.Count; i++)
            {
                for (int j = 0; j < workTasks.Count; j++)
                {
                    if (workTasks[i].Pkid == workTasks[j].Pkid && i != j)
                    {
                        workTasks.RemoveAt(j);
                        j--;
                    }
                }
                workTasks[i] = DalInstance.WorkTaskDalInstance.GetWorkTaskByPKID(workTasks[i].Pkid);
            }
            return workTasks;
        }

    }
}