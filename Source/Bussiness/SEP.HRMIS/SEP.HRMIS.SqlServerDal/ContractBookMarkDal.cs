//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ContractBookMarkDal.cs
// 创建者: xue.wenlong
// 创建日期: 2008-11-19
// 概述: 实现IContractBookMark接口中的方法
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
    public class ContractBookMarkDal:IContractBookMark
    {
        private const string _PKID = "@PKID";
        private const string _ContractTypeID = "@ContractTypeID";
        private const string _BookMarkName = "@BookMarkName";

        private const string _DBPKID = "PKID";
        private const string _DBContractTypeID = "ContractTypeID";
        private const string _DBBookMarkName = "BookMarkName";

        public int InsertContractBookMark(ContractBookMark contractBookMark)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_BookMarkName, SqlDbType.NVarChar,50).Value = contractBookMark.BookMarkName;
            cmd.Parameters.Add(_ContractTypeID, SqlDbType.Int).Value = contractBookMark.ContractTypeID;
            SqlHelper.ExecuteNonQueryReturnPKID("ContractBookMarkInsert", cmd, out pkid);
            return pkid;
        }

        public int DeleteContractBookMarkByContractTypeID(int contractTypeID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ContractTypeID, SqlDbType.Int).Value = contractTypeID;
            return SqlHelper.ExecuteNonQuery("DeleteContractBookMarkByContractTypeID", cmd);
        }

        public List<ContractBookMark> GetContractBookMarkByContractTypeID(int contractTypeID)
        {

            List<ContractBookMark> contractBookMarkList=new List<ContractBookMark>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ContractTypeID, SqlDbType.Int).Value = contractTypeID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetContractBookMarkByContractTypeID", cmd))
            {
                while (sdr.Read())
                {
                    contractBookMarkList.Add(new ContractBookMark(Convert.ToInt32(sdr[_DBPKID]), Convert.ToInt32(sdr[_DBContractTypeID]), sdr[_DBBookMarkName].ToString()));
                }
            }
            return contractBookMarkList;
        }
    }
}
