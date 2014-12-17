using System;
using System.Collections.Generic;
using SEP.Model;

namespace SEP.IBll
{
    public interface IWorkTaskBll
    {
        void CreateWorkTask(WorkTask workTask, bool ifEmail);
        void UpdateWorkTask(WorkTask workTask, bool ifEmail);
        void DeleteWorkTask(int workTaskID);
        WorkTask GetWorkTask(int workTaskID);
        List<WorkTask> GetMyWorkTaskByCondition(string title, DateTime from, DateTime to, int priority, bool ifNotStarted, bool ifOngoing, bool ifFailure, bool ifFinish, int accountID);
        List<WorkTask> GetResponsibleWorkTaskByCondition(string title, DateTime from, DateTime to, int priority, bool ifNotStarted, bool ifOngoing, bool ifFailure, bool ifFinish, int accountID);

        List<WorkTask> GetTeamWorkTaskByCondition(string creatorname, string deptname, string title, DateTime from,
                                                  DateTime to,
                                                  int priority, bool ifNotStarted, bool ifOngoing, bool ifFailure,
                                                  bool ifFinish, int accountID);
        void QuestionWorkTask(WorkTaskQA workTaskQA, bool ifEmail);
        void AnswerWorkTask(WorkTaskQA workTaskQA, bool ifEmail);
        void DeleteWorkTaskQA(int pkid);
        WorkTaskQA GetWorkTaskQA(int pkid);
    }
}