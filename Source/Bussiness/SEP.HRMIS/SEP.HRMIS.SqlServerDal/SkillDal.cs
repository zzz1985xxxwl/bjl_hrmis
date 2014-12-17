//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SkillDal.cs
// 创建者: 刘丹
// 创建日期: 2008-10-17
// 概述: 实现ISkill
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.Model;
using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.SqlServerDal
{
    public class SkillDal :ISkill
    {
        #region const
        private const string _PKID = "@PKID";
        private const string _Name = "@Name";
        private const string _TypeID = "@TypeID";

        private const string _DBPKID = "PKID";
        private const string _DBName = "Name";
        private const string _DBTypeID = "TypeID";
        private const string _DBTypeName = "TypeName";
        private const string _DbCount = "Counts";
        private readonly int _retVal = -1;
        #endregion

        public int InsertSkill(Skill Skill)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 100).Value = Skill.SkillName;
            cmd.Parameters.Add(_TypeID, SqlDbType.Int).Value = Skill.SkillType.ParameterID;
            SqlHelper.ExecuteNonQueryReturnPKID("SkillInsert", cmd, out pkid);
            return pkid;
        }

        public int UpdateSkill(Skill Skill)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = Skill.SkillID;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 100).Value = Skill.SkillName;
            cmd.Parameters.Add(_TypeID, SqlDbType.Int).Value = Skill.SkillType.ParameterID;
            return SqlHelper.ExecuteNonQuery("SkillUpdate", cmd);
        }

        public int DeleteSkillByPKID(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pkid;
            return SqlHelper.ExecuteNonQuery("SkillDelete", cmd);
        }

        public Skill GetSkillByPKID(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pkid;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetSkillByPkid", cmd))
            {
                while (sdr.Read())
                {
                    int skillId = (Int32)sdr[_DBPKID];
                    int skillTypeID = (Int32)sdr[_DBTypeID];
                    string name = sdr[_DBName].ToString();
                    string typeName = sdr[_DBTypeName].ToString();
                    SkillType type = new SkillType(skillTypeID, typeName);
                    Skill skill = new Skill(skillId, name, type);
                    return skill;
                }
            }
            return null;
        }

        public int CountSkillByName(string Name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 100).Value = Name;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountSkillByName", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        public int CountSkillByNameDiffPKID(int pkid, string skillName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 100).Value = skillName;
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pkid;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountSkillByNameDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        public List<Skill> GetSkillByCondition(string skillname, int skillTypeId)
        {
            List<Skill> skills = new List<Skill>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 100).Value = skillname;
            cmd.Parameters.Add(_TypeID, SqlDbType.Int).Value = skillTypeId;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetSkillsByCondition", cmd))
            {
                while (sdr.Read())
                {
                    int skillId = (Int32)sdr[_DBPKID];
                    int skillTypeID = (Int32)sdr[_DBTypeID];
                    string name = sdr[_DBName].ToString();
                    string typeName = sdr[_DBTypeName].ToString();
                    SkillType type = new SkillType(skillTypeID, typeName);
                    Skill skill = new Skill(skillId, name, type);
                    skills.Add(skill);
                }
                return skills;
            }
        }
    }
}
