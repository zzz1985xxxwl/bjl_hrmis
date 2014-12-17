//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ParameterDal.cs
// 创建者: 杨俞彬
// 创建日期: 2008-05-23
// 概述: 参数的数据库访问类
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 参数
    /// </summary>
    public class ParameterDal : IParameter
    {
        private const string _AtParameterID = "@PKID";
        private const string _AtName = "@Name";
        private const string _AtType = "@Type";
        private const string _AtDescription = "@Description";
        private const string _DbCount = "counts";
        private const string _ParameterID = "PKID";
        private const string _Name = "Name";
        private const string _Description = "Description";

        #region Parameter
        private static int InsertParameter(Parameter parameter, ParameterTypeEnum type)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AtParameterID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_AtName, SqlDbType.NVarChar, 50).Value = parameter.Name;
            cmd.Parameters.Add(_AtType, SqlDbType.Int).Value = (Int32)type;
            cmd.Parameters.Add(_AtDescription, SqlDbType.Text).Value = parameter.Description;

            SqlHelper.ExecuteNonQueryReturnPKID("ParameterInsert", cmd, out pkid);
            return pkid;
        }

        private static int UpdateParameter(Parameter parameter)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AtParameterID, SqlDbType.Int).Value = parameter.ParameterID;
            cmd.Parameters.Add(_AtName, SqlDbType.NVarChar, 50).Value = parameter.Name;
            cmd.Parameters.Add(_AtDescription, SqlDbType.Text).Value = parameter.Description;
            return SqlHelper.ExecuteNonQuery("ParameterUpdate", cmd);
        }

        private static int DeleteParameter(int parameterID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AtParameterID, SqlDbType.Int).Value = parameterID;
            return SqlHelper.ExecuteNonQuery("ParameterDelete", cmd);
        }

        private static int CountParameterByName(string name, ParameterTypeEnum type)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AtName, SqlDbType.NVarChar, 50).Value = name;
            cmd.Parameters.Add(_AtType, SqlDbType.Int).Value = (Int32)type;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountParameterByName", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return -1;
        }

        private static int CountParameterByNameDiffPKID(int PKID, string name, ParameterTypeEnum type)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AtParameterID, SqlDbType.Int).Value = PKID;
            cmd.Parameters.Add(_AtName, SqlDbType.NVarChar, 50).Value = name;
            cmd.Parameters.Add(_AtType, SqlDbType.Int).Value = (Int32)type;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountParameterByNameDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return -1;
        }

        private static Parameter GetParameterByPkid(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AtParameterID, SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetParameterByPkid", cmd))
            {
                while (sdr.Read())
                {
                    return new Parameter((Int32)sdr[_ParameterID], sdr[_Name].ToString(), sdr[_Description].ToString());
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Parameter> GetParameterByCondition(int pkid, string name, ParameterTypeEnum type)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AtParameterID, SqlDbType.Int).Value = pkid;
            cmd.Parameters.Add(_AtName, SqlDbType.NVarChar, 50).Value = name;
            cmd.Parameters.Add(_AtType, SqlDbType.Int).Value = (Int32)type;

            List<Parameter> parameters = new List<Parameter>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetParameterByCondition", cmd))
            {
                while (sdr.Read())
                {
                    parameters.Add(new Parameter((Int32)sdr[_ParameterID], sdr[_Name].ToString(), sdr[_Description].ToString()));
                }
            }
            return parameters;
        }
        #endregion

        #region SkillType
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertSkillType(SkillType obj)
        {
            return InsertParameter(obj, ParameterTypeEnum.SkillType);
        }

        public int UpdateSkillType(SkillType obj)
        {
            return UpdateParameter(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skillId"></param>
        /// <returns></returns>
        public int DeleteSkillType(int skillId)
        {
            return DeleteParameter(skillId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SkillTypeName"></param>
        /// <returns></returns>
        public int CountSkillTypeByName(string SkillTypeName)
        {
            return CountParameterByName(SkillTypeName, ParameterTypeEnum.SkillType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int CountSkillTypeByNameDiffPKID(int pkid, string Name)
        {
            return CountParameterByNameDiffPKID(pkid, Name, ParameterTypeEnum.SkillType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public SkillType GetSkillTypeByPkid(int pkid)
        {
            Parameter parameter = GetParameterByPkid(pkid);
            if (parameter != null)
            {
                return new SkillType(parameter.ParameterID, parameter.Name);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<SkillType> GetSkillTypeByCondition(int pkid, string name)
        {
            List<SkillType> skillTypes = new List<SkillType>();
            List<Parameter> parameters = GetParameterByCondition(pkid, name, ParameterTypeEnum.SkillType);
            foreach (Parameter parameter in parameters)
            {
                skillTypes.Add(new SkillType(parameter.ParameterID, parameter.Name));
            }

            return skillTypes;
        }


        #endregion

        #region FBQuesType
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertFBQuesType(TrainFBQuesType obj)
        {
            return InsertParameter(obj, ParameterTypeEnum.TrainFBQuesType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateFBQuesType(TrainFBQuesType obj)
        {
            return UpdateParameter(obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public int DeleteFBQuesType(int pkid)
        {
            return DeleteParameter(pkid);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int CountFBQuesTypeByName(string Name)
        {
            return CountParameterByName(Name, ParameterTypeEnum.TrainFBQuesType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int CountFBQuesTypeByNameDiffPKID(int pkid, string Name)
        {
            return CountParameterByNameDiffPKID(pkid, Name, ParameterTypeEnum.TrainFBQuesType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public TrainFBQuesType GetTrainFBQuesTypeByPKID(int pkid)
        {
            Parameter parameter = GetParameterByPkid(pkid);
            if (parameter != null)
            {
                return new TrainFBQuesType(parameter.ParameterID, parameter.Name);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<TrainFBQuesType> GetTrainFBQuesTypeByCondition(int pkid, string name)
        {
            List<TrainFBQuesType> FBQueTypes = new List<TrainFBQuesType>();
            List<Parameter> parameters = GetParameterByCondition(pkid, name, ParameterTypeEnum.TrainFBQuesType);
            foreach (Parameter parameter in parameters)
            {
                FBQueTypes.Add(new TrainFBQuesType(parameter.ParameterID, parameter.Name));
            }

            return FBQueTypes;
        }
        #endregion

        #region Nationality
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertNationality(Nationality obj)
        {
            return InsertParameter(obj, ParameterTypeEnum.Nationality);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateNationality(Nationality obj)
        {
            return UpdateParameter(obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public int DeleteNationality(int pkid)
        {
            return DeleteParameter(pkid);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int CountNationalityByName(string Name)
        {
            return CountParameterByName(Name, ParameterTypeEnum.Nationality);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int CountNationalityByNameDiffPKID(int pkid, string Name)
        {
            return CountParameterByNameDiffPKID(pkid, Name, ParameterTypeEnum.Nationality);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public Nationality GetNationalityByPKID(int pkid)
        {
            Parameter parameter = GetParameterByPkid(pkid);
            if (parameter != null)
            {
                return new Nationality(parameter.ParameterID, parameter.Name, parameter.Description);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Nationality> GetNationalityByCondition(int pkid, string name)
        {
            List<Nationality> nationalitys = new List<Nationality>();
            List<Parameter> parameters = GetParameterByCondition(pkid, name, ParameterTypeEnum.Nationality);
            foreach (Parameter parameter in parameters)
            {
                nationalitys.Add(new Nationality(parameter.ParameterID, parameter.Name, parameter.Description));
            }

            return nationalitys;
        }

        #endregion

    }
}
