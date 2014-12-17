//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FBQuestionDal.cs
// 创建者: 刘丹
// 创建日期: 2008-10-17
// 概述: 实现IFBQuestion
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.SqlServerDal
{
    public class FBQuestionDal:IFBQuestion
    {
        #region const
        private const string _PKID = "@PKID";
        private const string _Name = "@Name";
        private const string _TypeID = "@TypeID";
        private const string _Score = "@Score";
        private const string _QuesID = "@QuesID";

        private const string _DBPKID = "PKID";
        private const string _DBName = "Name";
        private const string _DBTypeID = "TypeID";
        private const string _DBTypeName = "TypeName";
        private const string _DBScore = "Score";
        private const string _DbError = "数据库访问错误!";
        private const string _DbCount = "Counts";
        private readonly int _retVal = -1;
        #endregion

        public void InsertFBQuestion(TrainFBQuestion obj)
        {
            try
            {
                int pkid;
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 100).Value = obj.Description;
                cmd.Parameters.Add(_TypeID, SqlDbType.Int).Value = obj.TrainFBQuesType.ParameterID;
                SqlHelper.ExecuteNonQueryReturnPKID("TrainFBQuesInsert", cmd, out pkid);
                obj.FBQuestioniD = pkid;
                if(obj.FBItems!=null)
                {
                    foreach(TrainFBItem item in obj.FBItems)
                    {
                        InsertFBItem(item, obj.FBQuestioniD);
                    }
                }

            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        public void UpdateFBQuestion(TrainFBQuestion obj)
        {
            try
            {
                UpdateFBQues(obj);
                if (obj.FBItems != null)
                {         
                    DeleteFBItem(obj.FBQuestioniD);
                    foreach (TrainFBItem item in obj.FBItems)
                    {
                        item.FBItemID = InsertFBItem(item, obj.FBQuestioniD);
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        public void DeleteFBQuestion(int FBQuestionID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = FBQuestionID;
            SqlHelper.ExecuteNonQuery("DeleteTrainFBQuesByQuesID", cmd);
            //删除和问题有关的项
            DeleteFBItem(FBQuestionID);
        }

        public TrainFBQuestion GetFBQuestinByPKID(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pkid;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetTrainFBQuesByQuesID", cmd))
            {
                while (sdr.Read())
                {
                    int queID = (Int32)sdr[_DBPKID];
                    int queTypeID = (Int32)sdr[_DBTypeID];
                    string quesDescription = sdr[_DBName].ToString();
                    string typeName = sdr[_DBTypeName].ToString();
                    TrainFBQuesType type = new TrainFBQuesType(queTypeID, typeName);
                    TrainFBQuestion questioon = new TrainFBQuestion(queID, quesDescription, type, null);
                    questioon.FBItems = new List<TrainFBItem>();
                    questioon.FBItems = GetFBItemsByQuesId(pkid);
                    return questioon;
                }
            }    
            return null;
        }

        public List<TrainFBQuestion> GetFBQuestionByConditon(string name, int type)
        {
            List<TrainFBQuestion> questions=new List<TrainFBQuestion>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar,100).Value = name;
            cmd.Parameters.Add(_TypeID, SqlDbType.Int).Value = type;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetTrainFBQuesByCondition", cmd))
            {
                while (sdr.Read())
                {
                    int queID = (Int32)sdr[_DBPKID];
                    int queTypeID = (Int32)sdr[_DBTypeID];
                    string quesDescription = sdr[_DBName].ToString();
                    string typeName = sdr[_DBTypeName].ToString();
                    TrainFBQuesType quesType = new TrainFBQuesType(queTypeID, typeName);
                    TrainFBQuestion questioon = new TrainFBQuestion(queID, quesDescription, quesType, null);
                    questioon.FBItems = GetFBItemsByQuesId(queID);
                    questions.Add(questioon);
                }
                return questions;
            }
        }

        public int CountFBQuestionByNameDiffPKID(int pkid, string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 100).Value = name;
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pkid;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountFBQuestionByNameDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        public int CountFBQuestionByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 100).Value = name;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountFBQuestionByName", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }


        /// <summary>
        /// 插入反馈问题选择项
        /// </summary>
        /// <param name="item"></param>
        /// <param name="quesId"></param>
        /// <returns></returns>
        private static int InsertFBItem(TrainFBItem item,int quesId)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 100).Value = item.Description;
            cmd.Parameters.Add(_QuesID, SqlDbType.Int).Value = quesId;
            cmd.Parameters.Add(_Score, SqlDbType.Int).Value = item.Worth;
            SqlHelper.ExecuteNonQueryReturnPKID("TrainFBItemInsert", cmd, out pkid);
            return pkid;
        }
        
        /// <summary>
        ///删除反馈问题选择项
        /// </summary>
        /// <param name="quesId"></param>
        private static void DeleteFBItem(int quesId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_QuesID, SqlDbType.Int).Value = quesId;
            SqlHelper.ExecuteNonQuery("DeleteTrainFBItemByQuesID", cmd);
        }

        /// <summary>
        /// 更新反馈问题
        /// </summary>
        /// <param name="obj"></param>
        private static void UpdateFBQues(TrainFBQuestion obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = obj.FBQuestioniD;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 100).Value = obj.Description;
            cmd.Parameters.Add(_TypeID, SqlDbType.Int).Value = obj.TrainFBQuesType.ParameterID;
            SqlHelper.ExecuteNonQuery("TrainFBQuesUpdate", cmd);
        }

        /// <summary>
        /// 得到反馈问题下的反馈选择项
        /// </summary>
        /// <param name="quesId"></param>
        /// <returns></returns>
        private static List<TrainFBItem> GetFBItemsByQuesId(int quesId)
        {
            List<TrainFBItem> items=new List<TrainFBItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_QuesID, SqlDbType.Int).Value = quesId;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetTrainFBItemByQuesID", cmd))
            {
                while (sdr.Read())
                {
                    int pkid = (Int32)sdr[_DBPKID];
                    string name = sdr[_DBName].ToString();
                    int score = (Int32)sdr[_DBScore];
                    TrainFBItem item = new TrainFBItem(pkid,name,score);
                    items.Add(item);
                }
                return items;
            }
        }
    }
}
