//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: CompanyRegulationDal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 公司规章持久层实现
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.IDal.CompanyRegulations;
using SEP.Model.CompanyRegulations;

namespace SEP.SqlServerDal
{
    public class CompanyRegulationDal : ICompanyRegulationDal
    {
        private const string _CompanyRegulationsID = "@PKID";
        private const string _ReguType             = "@CompanyReguType";
        private const string _Title                = "@Title";
        private const string _Content              = "@Content";

        private const string _DbCompanyRegulationsID = "PKID";
        private const string _DbReguType             = "CompanyReguType";
        private const string _DbTitle                = "Title";
        private const string _DbContent              = "Content";

        private const string _AppendixID    = "@PKID";
        private const string _CompanyReguID = "@CompanyReguID";
        private const string _FileName      = "@FileName";
        private const string _Directory     = "@Directory";
        private const string _UpLoadDate    = "@UpLoadDate";

        private const string _DbAppendixID    = "PKID";
        private const string _DbCompanyReguID = "CompanyReguID";
        private const string _DbFileName      = "FileName";
        private const string _DbDirectory     = "Directory";
        private const string _DbUpLoadDate    = "UpLoadDate";

        #region ICompanyRegulations 成员

        /// <summary>
        /// 插入公司规章制度
        /// </summary>
        /// <param name="obj">公司规章制度</param>
        /// <returns>pkid</returns>
        public int InsertCompanyRegulations(CompanyRegulation obj)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_CompanyRegulationsID, SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.Parameters.Add(_ReguType, SqlDbType.Int).Value = obj.CompanyReguType;
            cmd.Parameters.Add(_Title, SqlDbType.NVarChar, 100).Value = obj.Title;
            cmd.Parameters.Add(_Content, SqlDbType.Text).Value = obj.Content;

            SqlHelper.ExecuteNonQueryReturnPKID("CompanyRegulationsInsert", cmd, out pkid);
            obj.CompanyRegulationsID = pkid;
            return pkid;
        }

        /// <summary>
        /// 通过公司规章制度ID删除公司规章制度
        /// </summary>
        public void DeleteCompanyRegulationsByPKID(int pkId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_CompanyRegulationsID, SqlDbType.Int).Value = pkId;
            SqlHelper.ExecuteNonQuery("CompanyRegulationsDeleteByPKID", cmd);
        }

        /// <summary>
        /// 插入公司规章制度附件
        /// </summary>
        public int InsertCompanyReguAppendix(CompanyReguAppendix obj)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AppendixID, SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.Parameters.Add(_CompanyReguID, SqlDbType.Int).Value = obj.CompanyReguID;
            cmd.Parameters.Add(_FileName, SqlDbType.NVarChar, 100).Value = obj.FileName;
            cmd.Parameters.Add(_Directory, SqlDbType.NVarChar, 255).Value = obj.Directory;
            cmd.Parameters.Add(_UpLoadDate, SqlDbType.DateTime).Value = DateTime.Now.Date;

            SqlHelper.ExecuteNonQueryReturnPKID("CompanyReguAppendixInsert", cmd, out pkid);

            obj.AppendixID = pkid;

            return pkid;
        }

        /// <summary>
        /// 通过公司规章制度ID删除公司规章制度附件
        /// </summary>
        public void DeleteCompanyReguAppendixByPKID(int pkId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AppendixID, SqlDbType.Int).Value = pkId;
            SqlHelper.ExecuteNonQuery("CompanyReguAppendixDeleteByPKID", cmd);
        }

        /// <summary>
        /// 通过公司规章制度ID删除公司规章制度附件
        /// </summary>
        public void DeleteCompanyReguAppendixByCompanyRegulationsID(int companyRegulationsID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_CompanyReguID, SqlDbType.Int).Value = companyRegulationsID;
            SqlHelper.ExecuteNonQuery("CompanyReguAppendixDeleteByCompanyReguId", cmd);
        }

        public List<CompanyReguAppendix> GetCompanyReguAppendixByCompanyRegulationsID(int companyRegulationsID)
        {
            List<CompanyReguAppendix> companyReguAppendixList = new List<CompanyReguAppendix>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_CompanyReguID, SqlDbType.Int).Value = companyRegulationsID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetCompanyReguAppendixByCompanyReguID", cmd))
            {
                while (sdr.Read())
                {
                    CompanyReguAppendix appendix = new CompanyReguAppendix(
                        Convert.ToInt32(sdr[_DbAppendixID]), 
                        Convert.ToInt32(sdr[_DbCompanyReguID]),
                        sdr[_DbFileName].ToString(), 
                        sdr[_DbDirectory].ToString(),
                        Convert.ToDateTime(sdr[_DbUpLoadDate]));
                    companyReguAppendixList.Add(appendix);
                }
            }
            return companyReguAppendixList;
        }

        public CompanyRegulation GetCompanyRegulationsByType(ReguType type)
        {
            CompanyRegulation companyRegulations = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_ReguType, SqlDbType.Int).Value = type;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetCompanyRegulationsByType", cmd))
            {
                while (sdr.Read())
                {
                    string content = String.Empty;

                    if (sdr[_DbContent] != DBNull.Value)
                        content = sdr[_DbContent].ToString();

                    companyRegulations = new CompanyRegulation(
                        Convert.ToInt32(sdr[_DbCompanyRegulationsID]), 
                        (ReguType)sdr[_DbReguType], 
                        sdr[_DbTitle].ToString(),
                        content);

                    companyRegulations.AppendixList = GetCompanyReguAppendixByCompanyRegulationsID(companyRegulations.CompanyRegulationsID);
                }
            }

            if (companyRegulations == null)
                companyRegulations = new CompanyRegulation(type);
            return companyRegulations;
        }

        #endregion
    }
}


