//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PositionHistoryDal.cs
// 创建者: xue.wenlong
// 创建日期: 2008-11-1
// 概述: 实现IPositionHistory
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Positions;
using SEP.Model.Accounts;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 职位历史数据交互
    /// </summary>
    public class PositionHistoryDal : IPositionHistory
    {
        private const string _PKID = "@PKID";
        private const string _PositionID = "@PositionID";
        private const string _PositionName = "@PositionName";
        private const string _PositionGradeName = "@PositionGradeName";
        private const string _OperatorName = "@OperatorName";
        private const string _OperationTime = "@OperationTime";
        private const string _PositionGradeSequence = "@PositionGradeSequence";

        private const string _DBPositionID = "PositionID";
        private const string _DBPositionName = "PositionName";
        private const string _DBPositionGradeName = "PositionGradeName";
        private const string _DBPositionGradeSequence = "PositionGradeSequence";

        #region IPositionHistory 成员
        /// <summary>
        /// 插入一条职位历史
        /// </summary>
        public int CreatePositionHistory(PositionHistory obj)
        {
            //int pkid;
            //SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(_PositionID, SqlDbType.Int).Value = positionHistory.Position.ParameterID;
            //cmd.Parameters.Add(_PositionName, SqlDbType.NVarChar, 50).Value = positionHistory.Position.Name;
            //cmd.Parameters.Add(_PositionGradeName, SqlDbType.NVarChar, 50).Value = positionHistory.Position.Grade.Name;
            //cmd.Parameters.Add(_OperatorName, SqlDbType.NVarChar, 50).Value = positionHistory.Operator.Name;
            //cmd.Parameters.Add(_OperationTime, SqlDbType.DateTime).Value = positionHistory.OperationTime;
            //cmd.Parameters.Add(_PositionGradeSequence, SqlDbType.Int).Value = positionHistory.Position.Grade.Sequence;
            //SqlHelper.ExecuteNonQueryReturnPKID("PositionHistoryInsert", cmd, out pkid);
            //return pkid;

            int pkid;
            SqlCommand cm = new SqlCommand();
            AddParameters(obj, cm);
            cm.Parameters.AddWithValue("@PKID", 0);
            cm.Parameters["@PKID"].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQueryReturnPKID("PositionHistoryInsert", cm, out pkid);
            obj.PKID = pkid;
            UpdateChildren(obj);
            return pkid;

        }


        private static void AddParameters(PositionHistory obj, SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@OperatorName", obj.Operator.Name);
            cm.Parameters.AddWithValue("@OperationTime", obj.OperationTime);
            cm.Parameters.AddWithValue("@PositionGradeName", obj.Position.Grade.Name);
            cm.Parameters.AddWithValue("@PositionGradeSequence", obj.Position.Grade.Sequence);

            cm.Parameters.AddWithValue("@PositionID", obj.Position.Id);
            cm.Parameters.AddWithValue("@PositionName", obj.Position.Name);
            cm.Parameters.AddWithValue("@PositionDescription", obj.Position.Description);
            cm.Parameters.AddWithValue("@Number", obj.Position.Number);
            if (obj.Position.Reviewer != null && obj.Position.Reviewer.Id != 0)
            {
                cm.Parameters.AddWithValue("@ReviewerID", obj.Position.Reviewer.Id);
                cm.Parameters.AddWithValue("@ReviewerName", obj.Position.Reviewer.Name);
            }
            else
            {
                cm.Parameters.AddWithValue("@ReviewerID", DBNull.Value);
                cm.Parameters.AddWithValue("@ReviewerName", DBNull.Value);
            }
            cm.Parameters.AddWithValue("@PositionStatus", obj.Position.PositionStatus.Id);
            cm.Parameters.AddWithValue("@Version", obj.Position.Version);
            if (obj.Position.Commencement != DateTime.MinValue)
                cm.Parameters.AddWithValue("@Commencement", obj.Position.Commencement);
            else
                cm.Parameters.AddWithValue("@Commencement", DBNull.Value);
            cm.Parameters.AddWithValue("@Summary", obj.Position.Summary);
            cm.Parameters.AddWithValue("@MainDuties", obj.Position.MainDuties);
            cm.Parameters.AddWithValue("@ReportScope", obj.Position.ReportScope);
            cm.Parameters.AddWithValue("@ControlScope", obj.Position.ControlScope);
            cm.Parameters.AddWithValue("@Coordination", obj.Position.Coordination);
            cm.Parameters.AddWithValue("@Authority", obj.Position.Authority);
            cm.Parameters.AddWithValue("@Education", obj.Position.Education);
            cm.Parameters.AddWithValue("@ProfessionalBackground", obj.Position.ProfessionalBackground);
            cm.Parameters.AddWithValue("@WorkExperience", obj.Position.WorkExperience);
            cm.Parameters.AddWithValue("@Qualification", obj.Position.Qualification);
            cm.Parameters.AddWithValue("@Competence", obj.Position.Competence);
            cm.Parameters.AddWithValue("@OtherRequirements", obj.Position.OtherRequirements);
            cm.Parameters.AddWithValue("@KnowledgeAndSkills", obj.Position.KnowledgeAndSkills);
            cm.Parameters.AddWithValue("@RelatedProcesses", obj.Position.RelatedProcesses);
            cm.Parameters.AddWithValue("@ManagementSkills", obj.Position.ManagementSkills);
            cm.Parameters.AddWithValue("@AuxiliarySkills", obj.Position.AuxiliarySkills);
        }

        private static void UpdateChildren(PositionHistory obj)
        {
            foreach (PositionNature nature in obj.Position.Nature)
            {
                SqlCommand cm1 = new SqlCommand();
                cm1.Parameters.AddWithValue("@Name", nature.Name);
                cm1.Parameters.AddWithValue("@Description", nature.Description);
                cm1.Parameters.AddWithValue("@PKID", 0);
                cm1.Parameters["@PKID"].Direction = ParameterDirection.Output;
                int pkid;
                SqlHelper.ExecuteNonQueryReturnPKID("AddPositionNature", cm1, out pkid);

                SqlCommand cm = new SqlCommand();
                cm.Parameters.AddWithValue("@PositionID", obj.PKID);
                cm.Parameters.AddWithValue("@PositionNatureID", pkid);
                cm.Parameters.AddWithValue("@PKID", 0);
                cm.Parameters["@PKID"].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQueryReturnPKID("InsertPositionNatureRelationship", cm, out pkid);
            }
        }


        /// <summary>
        /// 在职位历史中找到员工某一时间的职位
        /// </summary>
        public Position GetPositionByPositionIDAndDateTime(int positionID, DateTime dt)
        {
            Position position = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PositionID, SqlDbType.Int).Value = positionID;
            cmd.Parameters.Add(_OperationTime, SqlDbType.DateTime).Value = dt;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionByPositionIDAndDateTime", cmd))
            {
                while (sdr.Read())
                {
                    position = new Position(Convert.ToInt32(sdr[_DBPositionID]), sdr[_DBPositionName].ToString(), new PositionGrade(0, sdr[_DBPositionGradeName].ToString(), ""));
                    position.Grade.Sequence = Convert.ToInt32(sdr[_DBPositionGradeSequence]);
                }
            }
            return position;
        }
        /// <summary>
        /// 得到某一时间的职位情况
        /// </summary>
        public List<Position> GetPositionByDateTime(DateTime dt)
        {
            List<Position> positionList =new List<Position>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_OperationTime, SqlDbType.DateTime).Value = Convert.ToDateTime(dt.ToShortDateString()).AddDays(1);
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionByDateTime", cmd))
            {
                while (sdr.Read())
                {
                    Position position =
                        new Position(Convert.ToInt32(sdr[_DBPositionID]), sdr[_DBPositionName].ToString(),
                                     new PositionGrade(0, sdr[_DBPositionGradeName].ToString(), ""));
                    position.Grade.Sequence = Convert.ToInt32(sdr[_DBPositionGradeSequence]);
                    positionList.Add(position);
                }
            }
            return positionList;
        }
        /// <summary>
        /// 删除历史记录，暂时仅为测试 
        /// </summary>
        public int DeletePositionHistory(int pKID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pKID;
            return SqlHelper.ExecuteNonQuery("PositionHistoryDelete", cmd);
        }


        public PositionHistory GetPositionHistoryByPKID(int pkid)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add("@PKID", SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionHistoryByPKID", cmd))
            {
                while (sdr.Read())
                {
                    PositionHistory positionHistory = FetchPositionHistory(sdr);
                    return positionHistory;
                }
            }
            return null;
        }

        public List<PositionHistory> GetPositionHistoryByPositionID(int positionID)
        {
            List<PositionHistory> positionHistorys = new List<PositionHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@PositionID", positionID);
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionHistoryByPositionID", cmd))
            {
                while (sdr.Read())
                {
                    positionHistorys.Add(FetchPositionHistory(sdr));
                }
            }
            return positionHistorys;
        }

        private static PositionHistory FetchPositionHistory(IDataRecord dr)
        {
            if (dr == null)
                return null;

            PositionHistory positionHistory = new PositionHistory();
            positionHistory.PKID = Convert.ToInt32(dr["PKID"]);
            positionHistory.OperationTime = Convert.ToDateTime(dr["OperationTime"]);
            positionHistory.Operator = new Account(0, "", dr["OperatorName"].ToString());
            positionHistory.Position = FetchPosition(dr);
            positionHistory.Position.Nature = GetPositionNatureByPositionID(positionHistory.PKID);

            return positionHistory;
        }


        private static List<PositionNature> GetPositionNatureByPositionID(int id)
        {
            List<PositionNature> positionNatures = new List<PositionNature>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@PositionID", id);

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionNatureByPositionID", cmd))
            {
                while (sdr.Read())
                {
                    positionNatures.Add(FetchPositionNature(sdr));
                }
            }
            return positionNatures;
        }

        private static PositionNature FetchPositionNature(IDataRecord dr)
        {
            PositionNature positionNature = new PositionNature();
            positionNature.Pkid = Convert.ToInt32(dr["PKID"]);
            positionNature.Name = dr["Name"].ToString();
            positionNature.Description = dr["Description"].ToString();
            return positionNature;
        }

        private static Position FetchPosition(IDataRecord dr)
        {
            if (dr == null)
                return null;

            Position position = new Position();
            position.Id = Convert.ToInt32(dr["PositionID"]);
            position.Name = dr["PositionName"].ToString();
            position.Description = dr["PositionDescription"].ToString();
            position.Grade = new PositionGrade();
            position.Grade.Name = dr["PositionGradeName"].ToString();
            position.Grade.Sequence = Convert.ToInt32(dr["PositionGradeSequence"]);
            position.Number = dr["Number"].ToString();
            if (dr["ReviewerID"] != DBNull.Value)
            {
                position.Reviewer.Id = Convert.ToInt32(dr["ReviewerID"]);
                position.Reviewer.Name = dr["ReviewerName"].ToString();
            }
            position.PositionStatus = PositionStatus.GetById(Convert.ToInt32(dr["PositionStatus"]));
            position.Version = dr["Version"].ToString();
            if (dr["Commencement"] != DBNull.Value)
            {
                position.Commencement = Convert.ToDateTime(dr["Commencement"]);
            }
            position.Summary = dr["Summary"].ToString();
            position.MainDuties = dr["MainDuties"].ToString();
            position.ReportScope = dr["ReportScope"].ToString();
            position.ControlScope = dr["ControlScope"].ToString();
            position.Coordination = dr["Coordination"].ToString();
            position.Authority = dr["Authority"].ToString();
            position.Education = dr["Education"].ToString();
            position.ProfessionalBackground = dr["ProfessionalBackground"].ToString();
            position.WorkExperience = dr["WorkExperience"].ToString();
            position.Qualification = dr["Qualification"].ToString();
            position.Competence = dr["Competence"].ToString();
            position.OtherRequirements = dr["OtherRequirements"].ToString();
            position.KnowledgeAndSkills = dr["KnowledgeAndSkills"].ToString();
            position.RelatedProcesses = dr["RelatedProcesses"].ToString();
            position.ManagementSkills = dr["ManagementSkills"].ToString();
            position.AuxiliarySkills = dr["AuxiliarySkills"].ToString();

            return position;
        }



        #endregion
    }
}
