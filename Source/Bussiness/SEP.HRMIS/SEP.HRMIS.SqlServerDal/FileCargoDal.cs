//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: FileCargoDal.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-09
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 
    /// </summary>
    public class FileCargoDal:IFileCargo
    {
        private const string _PKID = "@PKID";
        private const string _AccountID = "@AccountID";
        private const string _FileCargoName = "@FileCargoName";
        private const string _Remark = "@Remark";
        private const string _File = "@File";
        private const string _DbPKID = "PKID";
        private const string _DbAccountID = "AccountID";
        private const string _DbFileCargoName = "FileCargoName";
        private const string _DbRemark = "Remark";
        private const string _DbFile = "File";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileCargo"></param>
        /// <returns></returns>
        public int Insert(FileCargo fileCargo)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = fileCargo.Account.Id;
            cmd.Parameters.Add(_FileCargoName, SqlDbType.NVarChar, 50).Value = fileCargo.Name.Id;
            cmd.Parameters.Add(_Remark, SqlDbType.NVarChar, 2000).Value = fileCargo.Remark;
            cmd.Parameters.Add(_File, SqlDbType.NVarChar, 250).Value = fileCargo.File;
            SqlHelper.ExecuteNonQueryReturnPKID("FileCargoInsert", cmd, out pkid);
            return pkid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileCargo"></param>
        /// <returns></returns>
        public int Update(FileCargo fileCargo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = fileCargo.FileCargoID;
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = fileCargo.Account.Id;
            cmd.Parameters.Add(_FileCargoName, SqlDbType.NVarChar, 50).Value = fileCargo.Name.Id;
            cmd.Parameters.Add(_Remark, SqlDbType.NVarChar, 2000).Value = fileCargo.Remark;
            cmd.Parameters.Add(_File, SqlDbType.NVarChar, 250).Value = fileCargo.File;
            return SqlHelper.ExecuteNonQuery("FileCargoUpdate", cmd);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pKID"></param>
        /// <returns></returns>
        public int Delete(int pKID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pKID;
            return SqlHelper.ExecuteNonQuery("FileCargoDelete", cmd);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pKID"></param>
        /// <returns></returns>
        public FileCargo GetFileCargoByFileCargoID(int pKID)
        {
            FileCargo fileCargo = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pKID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetFileCargoByFileCargoID", cmd))
            {
                while (sdr.Read())
                {
                    fileCargo = new FileCargo(Convert.ToInt32(sdr[_DbPKID]),FileCargoName.FindFileCargoName(Convert.ToInt32(sdr[_DbFileCargoName])) , sdr[_DbRemark].ToString(), sdr[_DbFile].ToString(), new Account(Convert.ToInt32(sdr[_DbAccountID]), "", ""));
                }
            }
            return fileCargo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<FileCargo> GetFileCargoByAccountID(int accountID)
        {
            List<FileCargo> fileCargoList = new List<FileCargo>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetFileCargoByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    FileCargo fileCargo = new FileCargo(Convert.ToInt32(sdr[_DbPKID]), FileCargoName.FindFileCargoName(Convert.ToInt32(sdr[_DbFileCargoName])), sdr[_DbRemark].ToString(), sdr[_DbFile].ToString(), new Account(Convert.ToInt32(sdr[_DbAccountID]), "", ""));
                    fileCargoList.Add(fileCargo);
                }
            }
            return fileCargoList;
        }

    }
}