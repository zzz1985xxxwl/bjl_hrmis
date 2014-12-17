//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ContractBookMarkDal.cs
// 创建者: xue.wenlong
// 创建日期: 2008-11-19
// 概述: 记录员工对应某个合同的书签和书签内容
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
    public class EmployeeContractBookMarkDal:IEmployeeContractBookMark
    {
        private const string _PKID = "@PKID";
        private const string _EmployeeContractID = "@EmployeeContractID";
        private const string _BookMarkName = "@BookMarkName";
        private const string _BookMarkValue = "@BookMarkValue";
         
        private const string _DBPKID = "PKID";
        private const string _DBEmployeeContractID = "EmployeeContractID";
        private const string _DBBookMarkName = "BookMarkName";
        private const string _DBBookMarkValue = "BookMarkValue";


        public int InsertEmployeeContractBookMark(EmployeeContractBookMark employeecontractBookMark)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_BookMarkName, SqlDbType.NVarChar, 50).Value = employeecontractBookMark.BookMarkName;
            cmd.Parameters.Add(_EmployeeContractID, SqlDbType.Int).Value = employeecontractBookMark.EmployeeContractID;
            cmd.Parameters.Add(_BookMarkValue, SqlDbType.Text).Value = employeecontractBookMark.BookMarkValue;
            SqlHelper.ExecuteNonQueryReturnPKID("EmployeeContractBookMarkInsert", cmd, out pkid);
            return pkid;
        }

        public int DeleteEmployeeContractBookMarkByContractID(int contractID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_EmployeeContractID, SqlDbType.Int).Value = contractID;
            return SqlHelper.ExecuteNonQuery("DeleteEmployeeContractBookMarkByEmployeeContractID", cmd);
        }

        public List<EmployeeContractBookMark> GetEmployeeContractBookMarkByContractID(int contractID)
        {
            List<EmployeeContractBookMark> employeeContractBookMarkList = new List<EmployeeContractBookMark>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_EmployeeContractID, SqlDbType.Int).Value = contractID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeContractBookMarkByContractID", cmd))
            {
                while (sdr.Read())
                {
                    employeeContractBookMarkList.Add(new EmployeeContractBookMark(Convert.ToInt32(sdr[_DBPKID]),Convert.ToInt32(sdr[_DBEmployeeContractID]),sdr[_DBBookMarkName].ToString(),sdr[_DBBookMarkValue].ToString()));
                }
            }
            return employeeContractBookMarkList;
        }
    }
}
