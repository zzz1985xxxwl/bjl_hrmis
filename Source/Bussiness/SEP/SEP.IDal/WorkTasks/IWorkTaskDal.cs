using System;
using System.Collections.Generic;
using SEP.Model;

namespace SEP.IDal.WorkTasks
{
    public interface IWorkTaskDal
    {
        void Add(WorkTask model);
        void Update(WorkTask model);
        void Delete(int PKID);
        WorkTask GetWorkTaskByPKID(int PKID);
        List<WorkTask> GetMyWorkTaskByCondition(string title, DateTime from, DateTime to, int priority, bool ifNotStarted, bool ifOngoing, bool ifFailure, bool ifFinish, int accountID);
        List<WorkTask> GetResponsibleWorkTaskByCondition(string title, DateTime from, DateTime to, int priority, bool ifNotStarted, bool ifOngoing, bool ifFailure, bool ifFinish, int accountID);

        void AddWorkTaskQA(WorkTaskQA workTaskQA);
        void UpdateWorkTaskQA(WorkTaskQA workTaskQA);
        void DeleteWorkTaskQA(int PKID);
        WorkTaskQA GetWorkTaskQAByPKID(int PKID);
    }
}
