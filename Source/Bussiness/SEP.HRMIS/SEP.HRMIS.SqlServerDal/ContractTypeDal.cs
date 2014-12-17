//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ContractTypeDal.cs
// 创建者: 薛文龙
// 创建日期: 2008-11-17
// 概述:  实现IContractType接口中的方法
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.SqlServerDal
{
    public class ContractTypeDal:IContractType
    {
        private const string _ContractID = "@PKID";
        private const string _ContractName = "@Name";
        private const string _ContractTemplate = "@Template";

        private const string _DBContractID = "PKID";
        private const string _DBContractName = "Name";
        private const string _DBContractTemplate = "Template";
        private const string _DBCount = "counts";

        public int InsertContractType(ContractType contractType)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ContractID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_ContractName, SqlDbType.NVarChar, 50).Value = contractType.ContractTypeName;
            if (contractType.ContractTemplate != null)
            {
                cmd.Parameters.Add(_ContractTemplate, SqlDbType.Image).Value = contractType.ContractTemplate;
            }
            else
            {
                cmd.Parameters.Add(_ContractTemplate, SqlDbType.Image).Value = DBNull.Value;
            }
            SqlHelper.ExecuteNonQueryReturnPKID("ContractTypeInsert", cmd, out pkid);
            return pkid;
        }

        public int UpdateContractType(ContractType contractType)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ContractID, SqlDbType.Int).Value = contractType.ContractTypeID;
            cmd.Parameters.Add(_ContractName, SqlDbType.NVarChar, 50).Value = contractType.ContractTypeName;
            if (contractType.ContractTemplate != null)
            {
                cmd.Parameters.Add(_ContractTemplate, SqlDbType.Image).Value = contractType.ContractTemplate;
            }
            else
            {
                cmd.Parameters.Add(_ContractTemplate, SqlDbType.Image).Value = DBNull.Value;
            }
            return SqlHelper.ExecuteNonQuery("ContractTypeUpdate", cmd);
        }

        public int DeleteContractType(int ContractTypeId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ContractID, SqlDbType.Int).Value = ContractTypeId;
            return SqlHelper.ExecuteNonQuery("ContractTypeDelete", cmd);
        }

        public int CountContractTypeByName(string contractTypeName)
        {
            int retVal = -1;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ContractName, SqlDbType.NVarChar, 50).Value = contractTypeName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountContractTypeByName", cmd))
            {
                while (sdr.Read())
                {
                    retVal= Convert.ToInt32(sdr[_DBCount]);
                }
            }
            return retVal;
        }

        public int CountContractTypeByNameDiffPKID(int PKID, string contractTypeName)
        {
            int retVal = -1;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ContractID, SqlDbType.Int).Value = PKID;
            cmd.Parameters.Add(_ContractName, SqlDbType.NVarChar, 50).Value = contractTypeName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountContractTypeByNameDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    retVal = Convert.ToInt32(sdr[_DBCount]);
                }
            }
            return retVal;
        }

        public ContractType GetContractTypeByPkid(int pkid)
        {
            ContractType contractType = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ContractID, SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetContractTypeByPkid", cmd))
            {
                while (sdr.Read())
                {
                    contractType = new ContractType((Int32)sdr[_DBContractID], sdr[_DBContractName].ToString(), sdr[_DBContractTemplate] as byte[]);
                }
            }
            return contractType;
        }

        public List<ContractType> GetContractTypeByCondition(int pkid, string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ContractID, SqlDbType.Int).Value = pkid;
            cmd.Parameters.Add(_ContractName, SqlDbType.NVarChar, 50).Value = name;
            List<ContractType> contractTypeList = new List<ContractType>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetContractTypeByCondition", cmd))
            {
                while (sdr.Read())
                {
                    contractTypeList.Add(new ContractType((Int32)sdr[_DBContractID], sdr[_DBContractName].ToString(), sdr[_DBContractTemplate] as byte[])); 
                }
            }
            return contractTypeList;
        }
    }
}
