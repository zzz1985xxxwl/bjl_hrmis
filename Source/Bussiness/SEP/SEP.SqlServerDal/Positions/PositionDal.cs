//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: PositionDal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 职位持久层实现
// ----------------------------------------------------------------
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.IDal.Positions;
using SEP.Model.Positions;
using System;
using SEP.Model.Departments;
using System.Transactions;

namespace SEP.SqlServerDal
{
    public class PositionDal : IPositionDal
    {
        #region

        private const string _PositionId = "@PKID";
        private const string _PositionName = "@PositionName";
        private const string _LevelId = "@LevelId";
        private const string _PositionSequence = "@Sequence";
        private const string _PositionDescription = "@PositionDescription";

        private const string _DbPositionId = "PKID";
        private const string _DbPositionName = "PositionName";
        private const string _DbLevelId = "LevelId";
        private const string _DbPositionSequence = "Sequence";
        private const string _DbPositionDescription = "PositionDescription";


        private const string _PositionGradeId = "@PKID";
        private const string _PositionGradeName = "@PositionGradeName";
        private const string _PositionGradeDescription = "@PositionGradeDescription";

        private const string _DbPositionGradeId = "PKID";
        private const string _DbPositionGradeName = "PositionGradeName";
        private const string _DbPositionGradeDescription = "PositionGradeDescription";


        #endregion

        private Position CreatePositionFromDB(IDataRecord dr)
        {
            Position position = null;

            if (dr == null)
                return position;

            position = new Position();

            position.Id = Convert.ToInt32(dr[_DbPositionId]);
            position.Name = dr[_DbPositionName].ToString();
            position.Description = dr[_DbPositionDescription].ToString();

            //if (dr[_DbLevelId] != DBNull.Value)
            //{
            //    position.Level = new PositionGrade();
            //    position.Level.Id = Convert.ToInt32(dr[_DbLevelId]);
            //}

            return position;
        }
        private PositionGrade CreatePositionGradeFromDB(IDataRecord dr)
        {
            PositionGrade positionGrade = null;

            if (dr == null)
                return positionGrade;

            positionGrade = new PositionGrade();
            positionGrade.Id = Convert.ToInt32(dr[_DbPositionGradeId]);
            positionGrade.Name = dr[_DbPositionGradeName].ToString();
            positionGrade.Description = dr[_DbPositionGradeDescription].ToString();
            positionGrade.Sequence = Convert.ToInt32(dr[_DbPositionSequence]);

            return positionGrade;
        }

        #region IPositionDal 成员

        //public void InsertPosition(Position obj)
        //{
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.Parameters.Add(_PositionId, SqlDbType.Int).Direction = ParameterDirection.Output;

        //    cmd.Parameters.Add(_PositionName, SqlDbType.NVarChar, 50).Value = obj.Name;
        //    cmd.Parameters.Add(_PositionDescription, SqlDbType.Text).Value = obj.Description;
        //    if (obj.Level != null)
        //        cmd.Parameters.Add(_LevelId, SqlDbType.Int).Value = obj.Level.Id;


        //    int pkid;
        //    SqlHelper.ExecuteNonQueryReturnPKID("InsertPosition", cmd, out pkid);
        //    obj.Id = pkid;
        //}

        //public void UpdatePosition(Position obj)
        //{
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.Parameters.Add(_PositionId, SqlDbType.Int).Value = obj.Id;
        //    cmd.Parameters.Add(_PositionName, SqlDbType.NVarChar, 50).Value = obj.Name;
        //    cmd.Parameters.Add(_PositionDescription, SqlDbType.Text).Value = obj.Description;
        //    if (obj.Level != null)
        //        cmd.Parameters.Add(_LevelId, SqlDbType.Int).Value = obj.Level.Id;
        //    else
        //        cmd.Parameters.Add(_LevelId, SqlDbType.Int).Value = DBNull.Value;

        //    SqlHelper.ExecuteNonQuery("UpdatePosition", cmd);
        //}

        //public void DeletePosition(int id)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Parameters.Add(_PositionId, SqlDbType.Int).Value = id;
        //    SqlHelper.ExecuteNonQuery("DeletePosition", cmd);
        //}

        //public List<Position> GetAllPosition()
        //{
        //    List<Position> positions = new List<Position>();

        //    SqlCommand cmd = new SqlCommand();

        //    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPosition", cmd))
        //    {
        //        while (sdr.Read())
        //        {
        //            Position temp = CreatePositionFromDB(sdr);
        //            if (temp != null)
        //                positions.Add(temp);
        //        }
        //    }
        //    return positions;
        //}

        //public Position GetPositionById(int id)
        //{
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.Parameters.Add(_PositionId, SqlDbType.Int).Value = id;

        //    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPosition", cmd))
        //    {
        //        while (sdr.Read())
        //        {
        //            return CreatePositionFromDB(sdr);
        //        }
        //    }
        //    return null;
        //}

        //public bool IsExistPosition(int id)
        //{
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.Parameters.Add(_PositionId, SqlDbType.Int).Value = id;

        //    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPosition", cmd))
        //    {
        //        return sdr.HasRows;
        //    }
        //}

        //public Position GetPositionByName(string name)
        //{
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.Parameters.Add(_PositionName, SqlDbType.NVarChar, 50).Value = name;

        //    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPosition", cmd))
        //    {
        //        while (sdr.Read())
        //        {
        //            return CreatePositionFromDB(sdr);
        //        }
        //    }
        //    return null;
        //}





        public void InsertPositionGrade(PositionGrade obj)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PositionGradeId, SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.Parameters.Add(_PositionGradeName, SqlDbType.NVarChar, 50).Value = obj.Name;
            cmd.Parameters.Add(_PositionSequence, SqlDbType.Int).Value = obj.Sequence;
            cmd.Parameters.Add(_PositionGradeDescription, SqlDbType.Text).Value = obj.Description;

            int pkid;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertPositionGrade", cmd, out pkid);
            obj.Id = pkid;
        }

        public void UpdatePositionGrade(PositionGrade obj)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PositionGradeId, SqlDbType.Int).Value = obj.Id;
            cmd.Parameters.Add(_PositionGradeName, SqlDbType.NVarChar, 50).Value = obj.Name;
            cmd.Parameters.Add(_PositionSequence, SqlDbType.Int).Value = obj.Sequence;
            cmd.Parameters.Add(_PositionGradeDescription, SqlDbType.Text).Value = obj.Description;

            SqlHelper.ExecuteNonQuery("UpdatePositionGrade", cmd);
        }

        public void DeletePositionGrade(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PositionGradeId, SqlDbType.Int).Value = id;
            SqlHelper.ExecuteNonQuery("DeletePositionGrade", cmd);
        }

        public List<PositionGrade> GetAllPositionGrade()
        {
            List<PositionGrade> positionGrades = new List<PositionGrade>();
            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionGrade", cmd))
            {
                while (sdr.Read())
                {
                    PositionGrade temp = CreatePositionGradeFromDB(sdr);
                    if(temp != null)
                        positionGrades.Add(temp);
                }
            }
            return positionGrades;
        }

        public PositionGrade GetPositionGradeById(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PositionGradeId, SqlDbType.Int).Value = id;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionGrade", cmd))
            {
                while (sdr.Read())
                {
                    return CreatePositionGradeFromDB(sdr);
                }
            }
            return null;
        }

        public PositionGrade GetPositionGradeByName(string name)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PositionGradeName, SqlDbType.NVarChar, 50).Value = name;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionGrade", cmd))
            {
                while (sdr.Read())
                {
                    if (sdr[_DbPositionGradeName].ToString() != name)
                        continue;
                    return CreatePositionGradeFromDB(sdr);
                }
            }
            return null;
        }

        public List<Position> GetPositionByGradeId(int positionGradeId)
        {
            List<Position> positions = new List<Position>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_LevelId, SqlDbType.Int).Value = positionGradeId;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPosition", cmd))
            {
                while (sdr.Read())
                {
                    Position temp = CreatePositionFromDB(sdr);
                    if (temp != null)
                        positions.Add(temp);
                }
            }
            return positions;
        }

        public bool HasUsing(int positionGradeId)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_LevelId, SqlDbType.Int).Value = positionGradeId;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPosition", cmd))
            {
                return sdr.HasRows;
            }
        }

        //public List<Position> GetPositionByCondition(string nameLike, int levelId)
        //{
        //    List<Position> positions = new List<Position>();
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.Parameters.Add(_PositionName, SqlDbType.NVarChar, 50).Value = nameLike;
        //    cmd.Parameters.Add(_LevelId, SqlDbType.Int).Value = levelId;

        //    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionByCondition", cmd))
        //    {
        //        while (sdr.Read())
        //        {
        //            Position temp = CreatePositionFromDB(sdr);
        //            if (temp != null)
        //            { 
        //                if(temp.Level!=null)
        //                {
        //                    temp.Level = GetPositionGradeById(temp.Level.Id);
        //                }
        //                positions.Add(temp);
        //            }
        //        }
        //    }
        //    return positions;
        //}

        #endregion

        #region Position

        private static Position FetchPosition(IDataRecord dr)
        {
            if (dr == null)
                return null;

            Position position = new Position();
            position.Id = Convert.ToInt32(dr["PKID"]);
            position.Name = dr["PositionName"].ToString();
            position.Description = dr["PositionDescription"].ToString();
            if (dr["LevelId"] != DBNull.Value)
            {
                position.Grade.Id = Convert.ToInt32(dr["LevelId"]);
            }
            position.Number = dr["Number"].ToString();
            position.Number = dr["Number"].ToString();
            if (dr["Reviewer"] != DBNull.Value)
            {
                position.Reviewer.Id = Convert.ToInt32(dr["Reviewer"]);
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

        public void InsertPosition(Position obj)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cm = new SqlCommand();
                AddParameters(obj, cm);
                cm.Parameters.AddWithValue("@PKID", 0);
                cm.Parameters["@PKID"].Direction = ParameterDirection.Output;
                int pkid;
                SqlHelper.ExecuteNonQueryReturnPKID("InsertPosition", cm, out pkid);
                obj.Id = pkid;

                UpdateChildren(obj);
                ts.Complete();
            }
        }

        public void UpdatePosition(Position obj)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cm = new SqlCommand();
                cm.Parameters.AddWithValue("@PKID", obj.Id);
                AddParameters(obj, cm);
                UpdateChildren(obj);
                SqlHelper.ExecuteNonQuery("UpdatePosition", cm);
                ts.Complete();
            }
        }

        private static void AddParameters(Position obj, SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@PositionName", obj.Name);
            if (obj.Grade != null && obj.Grade.Id != 0)
                cm.Parameters.AddWithValue("@LevelId", obj.Grade.Id);
            else
                cm.Parameters.AddWithValue("@LevelId", DBNull.Value);
            cm.Parameters.AddWithValue("@PositionDescription", obj.Description);
            cm.Parameters.AddWithValue("@Number", obj.Number);
            if (obj.Reviewer != null && obj.Reviewer.Id != 0)
                cm.Parameters.AddWithValue("@Reviewer", obj.Reviewer.Id);
            else
                cm.Parameters.AddWithValue("@Reviewer", DBNull.Value);
            cm.Parameters.AddWithValue("@PositionStatus", obj.PositionStatus.Id);
            cm.Parameters.AddWithValue("@Version", obj.Version);
            if (obj.Commencement != DateTime.MinValue)
                cm.Parameters.AddWithValue("@Commencement", obj.Commencement);
            else
                cm.Parameters.AddWithValue("@Commencement", DBNull.Value);
            cm.Parameters.AddWithValue("@Summary", obj.Summary);
            cm.Parameters.AddWithValue("@MainDuties", obj.MainDuties);
            cm.Parameters.AddWithValue("@ReportScope", obj.ReportScope);
            cm.Parameters.AddWithValue("@ControlScope", obj.ControlScope);
            cm.Parameters.AddWithValue("@Coordination", obj.Coordination);
            cm.Parameters.AddWithValue("@Authority", obj.Authority);
            cm.Parameters.AddWithValue("@Education", obj.Education);
            cm.Parameters.AddWithValue("@ProfessionalBackground", obj.ProfessionalBackground);
            cm.Parameters.AddWithValue("@WorkExperience", obj.WorkExperience);
            cm.Parameters.AddWithValue("@Qualification", obj.Qualification);
            cm.Parameters.AddWithValue("@Competence", obj.Competence);
            cm.Parameters.AddWithValue("@OtherRequirements", obj.OtherRequirements);
            cm.Parameters.AddWithValue("@KnowledgeAndSkills", obj.KnowledgeAndSkills);
            cm.Parameters.AddWithValue("@RelatedProcesses", obj.RelatedProcesses);
            cm.Parameters.AddWithValue("@ManagementSkills", obj.ManagementSkills);
            cm.Parameters.AddWithValue("@AuxiliarySkills", obj.AuxiliarySkills);
        }

        private static void UpdateChildren(Position obj)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Parameters.AddWithValue("@PositionID", obj.Id);
            SqlHelper.ExecuteNonQuery("DeletePositionNatureRelationship", cmd1);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Parameters.AddWithValue("@PositionID", obj.Id);
            SqlHelper.ExecuteNonQuery("DeletePositionDeptRelationship", cmd2);

            foreach (PositionNature nature in obj.Nature)
            {
                SqlCommand cm = new SqlCommand();
                cm.Parameters.AddWithValue("@PositionID", obj.Id);
                cm.Parameters.AddWithValue("@PositionNatureID", nature.Pkid);
                cm.Parameters.AddWithValue("@PKID", 0);
                cm.Parameters["@PKID"].Direction = ParameterDirection.Output;
                int pkid;
                SqlHelper.ExecuteNonQueryReturnPKID("InsertPositionNatureRelationship", cm, out pkid);
            }

            foreach (Department d in obj.Departments)
            {
                SqlCommand cm = new SqlCommand();
                cm.Parameters.AddWithValue("@PositionID", obj.Id);
                cm.Parameters.AddWithValue("@DeptID", d.Id);
                cm.Parameters.AddWithValue("@PKID", 0);
                cm.Parameters["@PKID"].Direction = ParameterDirection.Output;
                int pkid;
                SqlHelper.ExecuteNonQueryReturnPKID("InsertPositionDeptRelationship", cm, out pkid);
            }
        }

        public void DeletePosition(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("PKID", SqlDbType.Int).Value = id;
            SqlHelper.ExecuteNonQuery("DeletePosition", cmd);
        }

        public List<Position> GetAllPosition()
        {
            List<Position> positions = new List<Position>();

            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPosition", cmd))
            {
                while (sdr.Read())
                {
                    Position temp = FetchPosition(sdr);
                    if (temp != null)
                        positions.Add(temp);
                }
            }
            return positions;
        }

        public Position GetPositionById(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add("PKID", SqlDbType.Int).Value = id;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPosition", cmd))
            {
                while (sdr.Read())
                {
                    Position temp = FetchPosition(sdr);
                    if (temp != null)
                    {
                        if (temp.Grade != null)
                        {
                            temp.Grade = GetPositionGradeById(temp.Grade.Id);
                        }
                        if (temp.Reviewer != null)
                        {
                            temp.Reviewer = new AccountDal().GetAccountById(temp.Reviewer.Id);
                        }
                    }
                    return temp;
                }
            }
            return null;
        }

        public bool IsExistPosition(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add("PKID", SqlDbType.Int).Value = id;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPosition", cmd))
            {
                return sdr.HasRows;
            }
        }

        public Position GetPositionByName(string name)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add("@PositionName", SqlDbType.NVarChar, 50).Value = name;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPosition", cmd))
            {
                while (sdr.Read())
                {
                    return FetchPosition(sdr);
                }
            }
            return null;
        }

        public List<Position> GetPositionByCondition(string nameLike, int levelId)
        {
            List<Position> positions = new List<Position>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add("@PositionName", SqlDbType.NVarChar, 50).Value = nameLike;
            cmd.Parameters.Add("@LevelId", SqlDbType.Int).Value = levelId;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionByCondition", cmd))
            {
                while (sdr.Read())
                {
                    Position temp = FetchPosition(sdr);
                    if (temp != null)
                    {
                        if (temp.Grade != null)
                        {
                            temp.Grade = GetPositionGradeById(temp.Grade.Id);
                        }
                        positions.Add(temp);
                    }
                }
            }
            return positions;
        }

        public List<Position> GetPositionByCondition(string sql)
        {
            List<Position> positions = new List<Position>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader(cmd))
            {
                while (sdr.Read())
                {
                    Position temp = GetPositionById(Convert.ToInt32(sdr["Pkid"]));
                    if (temp != null)
                    {
                        positions.Add(temp);
                    }
                }
            }
            return positions;
        }

        #endregion


        #region PositionNature

        public void InsertPositionNature(PositionNature obj)
        {
            SqlCommand cm = new SqlCommand();
            cm.Parameters.AddWithValue("@Name", obj.Name);
            cm.Parameters.AddWithValue("@Description", obj.Description);
            cm.Parameters.AddWithValue("@PKID", obj.Pkid);
            cm.Parameters["@PKID"].Direction = ParameterDirection.Output;
            int pkid;
            SqlHelper.ExecuteNonQueryReturnPKID("AddPositionNature", cm, out pkid);
            obj.Pkid = pkid;
        }

        public void UpdatePositionNature(PositionNature obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@PKID", obj.Pkid);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Description", obj.Description);
            SqlHelper.ExecuteNonQuery("UpdatePositionNature", cmd);
        }

        public void DeletePositionNature(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@PKID", SqlDbType.Int).Value = id;
            SqlHelper.ExecuteNonQuery("DeletePositionNature", cmd);
        }

        public List<PositionNature> GetAllPositionNature()
        {
            List<PositionNature> positionNatures = new List<PositionNature>();

            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllPositionNature", cmd))
            {
                while (sdr.Read())
                {
                    positionNatures.Add(FetchPositionNature(sdr));
                }
            }
            return positionNatures;
        }

        public List<PositionNature> GetPositionNatureByPositionID(int id)
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

        public List<Department> GetPositionDeptByPositionID(int id)
        {
            List<Department> departments = new List<Department>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@PositionID", id);

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionDeptByPositionID", cmd))
            {
                while (sdr.Read())
                {
                    departments.Add(new DepartmentDal().CreateDeptFromDB(sdr));
                }
            }
            return departments;
        }

        public List<PositionNature> GetPositionNatureListByName(string name)
        {
            List<PositionNature> positionNatures = new List<PositionNature>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add("Name", SqlDbType.NVarChar, 50).Value = name;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionNatureListByName", cmd))
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

        public PositionNature GetPositionNatureById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@PKID", id);
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionNature", cmd))
            {
                while (sdr.Read())
                {
                    return FetchPositionNature(sdr);
                }
            }
            return null;
        }

        public int CountPositionByNatureId(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@PositionNatureId", id);
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountPositionByNatureId", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr["counts"]);
                }
            }
            return 0;
        }

        public int CountPositionNatureByNameDiffPKID(int pkid, string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@PKID", pkid);
            cmd.Parameters.AddWithValue("@Name", name);

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountPositionNatureByNameDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr["counts"]);
                }
            }
            return 0;
        }

        #endregion
    }
}
