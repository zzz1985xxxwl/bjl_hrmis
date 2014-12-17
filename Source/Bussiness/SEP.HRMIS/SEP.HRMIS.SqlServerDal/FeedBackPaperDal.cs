using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.SqlServerDal
{

    ///<summary>
    ///</summary>
    public class FeedBackPaperDal : IFeedBackPaper
    {
        private readonly FBQuestionDal _QuestionDal = new FBQuestionDal();

        private const string _ParmPaperName = "@PaperName";
        private const string _ParmPKID = "@PKID";
        private const string _ParmCount = "@count";
        private const string _DbPaperName = "PaperName";
        private const string _DbPKID = "PKID";
        private const string _ParmPaperID = "@PaperID";
        private const string _ParmItemID = "@ItemID";
        private const string _DbItemID = "ItemID";
        private const string _DbError = "数据库访问错误!";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FeedBackPaper GetFeedBackPaperById(int id)
        {

            FeedBackPaper templatePaper = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = id;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetFeedBackPaperByPaperId", cmd))
            {
                while (sdr.Read())
                {
                    templatePaper = new FeedBackPaper();
                    templatePaper.FeedBackPaperId = Convert.ToInt32(sdr[_DbPKID]);
                    templatePaper.FeedBackPaperName = sdr[_DbPaperName].ToString();
                    templatePaper.FBQuestions = GetFeedBackPaperItemsById(templatePaper.FeedBackPaperId);
                }
                return templatePaper;
            }
        }

        /// <summary>
        /// 获取反馈问题
        /// </summary>
        /// <param name="paperId"></param>
        /// <returns></returns>
        private List<TrainFBQuestion> GetFeedBackPaperItemsById(int paperId)
        {
            try
            {
                List<TrainFBQuestion> items = new List<TrainFBQuestion>();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = paperId;
                using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetQustionItemByPaperId", cmd))
                {
                    while (sdr.Read())
                    {
                        TrainFBQuestion item = _QuestionDal.GetFBQuestinByPKID(Convert.ToInt32(sdr[_DbItemID]));
                        items.Add(item);
                    }
                }
                return items;
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        public int CountFeedBackPaperByPaperName(string paperName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPaperName, SqlDbType.NVarChar, 50).Value = paperName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountFeedBackPaperByPaperName", cmd))
            {
                sdr.Read();
                return sdr.GetInt32(0);
            }
        }

        public int CountFeedBackPaperByPaperNameDiffPKID(int id, string paperName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPaperName, SqlDbType.NVarChar, 50).Value = paperName;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = id;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountFeedBackPaperByPaperNameDiffPKID", cmd))
            {
                sdr.Read();
                return sdr.GetInt32(0);
            }
        }

        public int InsertFeedBackPaper(FeedBackPaper feedBackPaper)
        {
            try
            {
                int pkid;
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmPaperName, SqlDbType.NVarChar, 50).Value = feedBackPaper.FeedBackPaperName;
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQueryReturnPKID("FeedBackPaperInsert", cmd, out pkid);
                if (feedBackPaper.FBQuestions != null)
                {
                    foreach (TrainFBQuestion item in feedBackPaper.FBQuestions)
                    {
                        ManagePaperItems(pkid, item.FBQuestioniD);
                    }
                }
                return pkid;
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        public void UpdateFeedBackPaper(FeedBackPaper feedBackPaper)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmCount, SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = feedBackPaper.FeedBackPaperId;
                cmd.Parameters.Add(_ParmPaperName, SqlDbType.NVarChar, 50).Value = feedBackPaper.FeedBackPaperName;
                SqlHelper.ExecuteNonQuery("FeedBackPaperUpdate", cmd);
                DeleteAllItemsInPaper(feedBackPaper.FeedBackPaperId);
                if (feedBackPaper.FBQuestions != null)
                {
                    foreach (TrainFBQuestion item in feedBackPaper.FBQuestions)
                    {
                        ManagePaperItems(feedBackPaper.FeedBackPaperId, item.FBQuestioniD);
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        public int DeleteFeedBackPaperByID(int id)
        {
            try
            {
                DeleteAllItemsInPaper(id);
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = id;
                cmd.Parameters.Add(_ParmCount, SqlDbType.Int).Direction = ParameterDirection.Output;
                return SqlHelper.ExecuteNonQuery("DeleteFeedBackPaperByID", cmd);
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        /// <summary>
        /// 删除考评表与考评项的关系
        /// </summary>
        /// <param name="paperId"></param>
        /// <returns></returns>
        private static void DeleteAllItemsInPaper(int paperId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPaperID, SqlDbType.Int).Value = paperId;
            SqlHelper.ExecuteNonQuery("DeleteFeedBackRelation", cmd);
        }

        /// <summary>
        /// 添加反馈表与反馈问题的关系
        /// </summary>
        /// <param name="paperId"></param>
        /// <param name="itemId"></param>
        private static void ManagePaperItems(int paperId, int itemId)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_ParmPaperID, SqlDbType.Int).Value = paperId;
            cmd.Parameters.Add(_ParmItemID, SqlDbType.Int).Value = itemId;
            SqlHelper.ExecuteNonQueryReturnPKID("FeedBackPIShipInsert", cmd, out pkid);
        }

        public List<FeedBackPaper> GetFeedBackPaperByPaperName(string paperName)
        {
            List<FeedBackPaper> papers = new List<FeedBackPaper>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPaperName, SqlDbType.NVarChar, 50).Value = paperName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetFeedBackPaperByPaperName", cmd))
            {
                while (sdr.Read())
                {
                    FeedBackPaper paper = new FeedBackPaper();
                    paper.FeedBackPaperId = Convert.ToInt32(sdr[_DbPKID]);
                    paper.FeedBackPaperName = sdr[_DbPaperName].ToString();
                    papers.Add(paper);
                }
                return papers;
            }
        }
    }
}
