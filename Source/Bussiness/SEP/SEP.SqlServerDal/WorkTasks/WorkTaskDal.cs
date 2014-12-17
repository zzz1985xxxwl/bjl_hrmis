using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using SEP.IDal.WorkTasks;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.SqlServerDal.WorkTasks
{
    public class WorkTaskDal : IWorkTaskDal
    {
        #region WorkTask
        public void Add(WorkTask model)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cm = new SqlCommand();
                AddInsertParameters(cm, model);
                cm.Parameters["@PKID"].Direction = ParameterDirection.Output;
                int pkid;
                SqlHelper.ExecuteNonQueryReturnPKID("AddWorkTask", cm, out pkid);
                model.Pkid = pkid;

                UpdateChildren(model);
                ts.Complete();
            }
        }

        private static void UpdateChildren(WorkTask obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@WorkTaskID", obj.Pkid);
            SqlHelper.ExecuteNonQuery("DeleteWorkTaskResponsible", cmd);

            foreach (Account account in obj.Responsibles)
            {
                if (account.Id > 0)
                {
                    SqlCommand cm = new SqlCommand();
                    cm.Parameters.AddWithValue("@WorkTaskID", obj.Pkid);
                    cm.Parameters.AddWithValue("@AccountID", account.Id);
                    cm.Parameters.AddWithValue("@PKID", 0);
                    cm.Parameters["@PKID"].Direction = ParameterDirection.Output;
                    int pkid;
                    SqlHelper.ExecuteNonQueryReturnPKID("InsertWorkTaskResponsible", cm, out pkid);
                }
            }
        }

        private static void AddInsertParameters(SqlCommand cm, WorkTask model)
        {
            cm.Parameters.AddWithValue("@Account", model.Account.Id);
            cm.Parameters.AddWithValue("@Title", model.Title);
            cm.Parameters.AddWithValue("@Content", model.Content);
            cm.Parameters.AddWithValue("@Priority", model.Priority.Id);
            cm.Parameters.AddWithValue("@Status", model.Status.Id);
            cm.Parameters.AddWithValue("@StartDate", model.StartDate);
            cm.Parameters.AddWithValue("@EndDate", model.EndDate);
            cm.Parameters.AddWithValue("@Description", model.Description);
            cm.Parameters.AddWithValue("@Remark", model.Remark);
            cm.Parameters.AddWithValue("@PKID", model.Pkid);
        }

        public void Update(WorkTask model)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cm = new SqlCommand();
                AddInsertParameters(cm, model);
                UpdateChildren(model);
                SqlHelper.ExecuteNonQuery("UpdateWorkTask", cm);
                ts.Complete();
            }
        }

        public void Delete(int PKID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("PKID", SqlDbType.Int).Value = PKID;
            SqlHelper.ExecuteNonQuery("DeleteWorkTask", cmd);
        }

        public WorkTask GetWorkTaskByPKID(int PKID)
        {
            WorkTask workTask = new WorkTask();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("PKID", SqlDbType.Int).Value = PKID;
            using (SqlDataReader dr = SqlHelper.ExecuteReader("GetWorkTask", cmd))
            {
                while (dr.Read())
                {
                    FetchObject(dr, workTask);
                    FetchChildren(dr, workTask);
                }
            }
            return workTask;
        }

        private static void FetchObject(IDataRecord dr, WorkTask workTask)
        {
            workTask.Pkid = (int) dr["PKID"];
            workTask.Account = new Account((int)dr["Account"], "", dr["AccountName"].ToString());
            workTask.Title = dr["Title"].ToString();
            workTask.Content = dr["Content"].ToString();
            workTask.Priority = WTPriority.GetById((int) dr["Priority"]);
            workTask.Status = WTStatus.GetById((int)dr["Status"]);
            workTask.StartDate = (DateTime)dr["StartDate"];
            workTask.EndDate = (DateTime)dr["EndDate"];
            workTask.Description = dr["Description"].ToString();
            workTask.Remark = dr["Remark"].ToString();
        }

        private static void FetchChildren(IDataReader dr, WorkTask workTask)
        {
            dr.NextResult();
            while(dr.Read())
            {
                workTask.Responsibles.Add(new Account((int)dr["AccountID"], "", dr["AccountName"].ToString()));
            }
            dr.NextResult();
            while (dr.Read())
            {
                WorkTaskQA workTaskQA = new WorkTaskQA((int) dr["PKID"], dr["QAccountName"].ToString(),
                                                       dr["AAccountName"].ToString(), dr["Question"].ToString(),
                                                       dr["Answer"].ToString(), (DateTime) dr["QuestionDate"],
                                                       (DateTime) dr["AnswerDate"]);
                workTaskQA.WorkTask.Pkid = (int)dr["WorkTaskID"];
                workTaskQA.QAccount.Id = (int)dr["QAccount"];
                workTaskQA.AAccount.Id = (int)dr["AAccount"];
                workTask.WorkTaskQAs.Add(workTaskQA);
            }
        }

        public List<WorkTask> GetMyWorkTaskByCondition(string title, DateTime from, DateTime to, int priority, bool ifNotStarted, bool ifOngoing, bool ifFailure, bool ifFinish, int accountID)
        {
            List<WorkTask> workTasks = new List<WorkTask>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("Title", SqlDbType.NVarChar, 200).Value = title;
            cmd.Parameters.Add("From", SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add("To", SqlDbType.DateTime).Value = to;
            cmd.Parameters.Add("Priority", SqlDbType.Int).Value = priority;
            cmd.Parameters.Add("IfApprove", SqlDbType.Int).Value = ifNotStarted ? WTStatus.NotStarted.Id : -1;
            cmd.Parameters.Add("IfOngoing", SqlDbType.Int).Value = ifOngoing ? WTStatus.Ongoing.Id : -1;
            cmd.Parameters.Add("IfFinish", SqlDbType.Int).Value = ifFinish ? WTStatus.Finish.Id : -1;
            cmd.Parameters.Add("IfFailure", SqlDbType.Int).Value = ifFailure ? WTStatus.Failure.Id : -1;
            cmd.Parameters.Add("AccountID", SqlDbType.Int).Value = accountID;
            using (SqlDataReader dr = SqlHelper.ExecuteReader("GetMyWorkTaskByCondition", cmd))
            {
                while (dr.Read())
                {
                    WorkTask workTask = new WorkTask();
                    FetchObject(dr, workTask);
                    workTasks.Add(workTask);
                }
            }
            return workTasks;
        }

        public List<WorkTask> GetResponsibleWorkTaskByCondition(string title, DateTime from, DateTime to, int priority, bool ifNotStarted, bool ifOngoing, bool ifFailure, bool ifFinish, int accountID)
        {
            List<WorkTask> workTasks = new List<WorkTask>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("Title", SqlDbType.NVarChar, 200).Value = title;
            cmd.Parameters.Add("From", SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add("To", SqlDbType.DateTime).Value = to;
            cmd.Parameters.Add("Priority", SqlDbType.Int).Value = priority;
            cmd.Parameters.Add("IfApprove", SqlDbType.Int).Value = ifNotStarted ? WTStatus.NotStarted.Id : -1;
            cmd.Parameters.Add("IfOngoing", SqlDbType.Int).Value = ifOngoing ? WTStatus.Ongoing.Id : -1;
            cmd.Parameters.Add("IfFinish", SqlDbType.Int).Value = ifFinish ? WTStatus.Finish.Id : -1;
            cmd.Parameters.Add("IfFailure", SqlDbType.Int).Value = ifFailure ? WTStatus.Failure.Id : -1;
            cmd.Parameters.Add("AccountID", SqlDbType.Int).Value = accountID;
            using (SqlDataReader dr = SqlHelper.ExecuteReader("GetResponsibleWorkTaskByCondition", cmd))
            {
                while (dr.Read())
                {
                    WorkTask workTask = new WorkTask();
                    FetchObject(dr, workTask);
                    workTasks.Add(workTask);
                }
            }
            return workTasks;
        }

        #endregion

        #region WorkTaskQA

        public void AddWorkTaskQA(WorkTaskQA model)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cm = new SqlCommand();
                AddInsertParameters(cm, model);
                cm.Parameters["@PKID"].Direction = ParameterDirection.Output;
                int pkid;
                SqlHelper.ExecuteNonQueryReturnPKID("AddWorkTaskQA", cm, out pkid);
                model.Pkid = pkid;
                ts.Complete();
            }
        }

        public void UpdateWorkTaskQA(WorkTaskQA model)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cm = new SqlCommand();
                AddInsertParameters(cm, model);
                SqlHelper.ExecuteNonQuery("UpdateWorkTaskQA", cm);
                ts.Complete();
            }
        }

        private static void AddInsertParameters(SqlCommand cm, WorkTaskQA model)
        {
            cm.Parameters.AddWithValue("@WorkTaskID", model.WorkTask.Pkid);
            cm.Parameters.AddWithValue("@QAccount", model.QAccount.Id);
            cm.Parameters.AddWithValue("@AAccount", model.AAccount.Id);
            cm.Parameters.AddWithValue("@Question", model.Question);
            cm.Parameters.AddWithValue("@Answer", model.Answer);
            cm.Parameters.AddWithValue("@QuestionDate", model.QuestionDate);
            cm.Parameters.AddWithValue("@AnswerDate", model.AnswerDate);
            cm.Parameters.AddWithValue("@PKID", model.Pkid);
        }

        public void DeleteWorkTaskQA(int PKID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("PKID", SqlDbType.Int).Value = PKID;
            SqlHelper.ExecuteNonQuery("DeleteWorkTaskQA", cmd);
        }

        public WorkTaskQA GetWorkTaskQAByPKID(int PKID)
        {
            WorkTaskQA workTaskQA = new WorkTaskQA();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("PKID", SqlDbType.Int).Value = PKID;
            using (SqlDataReader dr = SqlHelper.ExecuteReader("GetWorkTaskQA", cmd))
            {
                while (dr.Read())
                {
                    FetchObject(dr, workTaskQA);
                }
            }
            return workTaskQA;
        }

        private static void FetchObject(IDataRecord dr, WorkTaskQA workTask)
        {
            workTask.Pkid = (int)dr["PKID"];
			workTask.WorkTask.Pkid = (int)dr["WorkTaskID"];
			workTask.QAccount = new Account((int)dr["QAccount"],"",dr["QAccountName"].ToString());
			workTask.Question = dr["Question"].ToString();
			workTask.QuestionDate = (DateTime)dr["QuestionDate"];
			workTask.AAccount = new Account((int)dr["AAccount"],"",dr["AAccountName"].ToString());
			workTask.Answer = dr["Answer"].ToString();
			workTask.AnswerDate = (DateTime)dr["AnswerDate"];
		}

        #endregion 
    }
}
