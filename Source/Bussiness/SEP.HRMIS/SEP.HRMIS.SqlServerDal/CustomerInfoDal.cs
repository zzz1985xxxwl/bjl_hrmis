//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CustomerInfoDal.cs
// 创建者: 刘丹
// 创建日期: 2009-08-14
// 概述: 客户信息dal
// ----------------------------------------------------------------

using SEP.HRMIS.IDal;
using System.Collections.Generic;
using SEP.HRMIS.Model; 
using System;
using System.Data;
using System.Data.SqlClient;

namespace SEP.HRMIS.SqlServerDal
{
    ///<summary>
    ///</summary>
    public class CustomerInfoDal : ICustomerInfoDal
    {
        private const int _retVal = -1;
        private const string _PKID = "@PKID";
        private const string _Name = "@CompanyName";

        private const string _DbPKID = "PKID";
        private const string _DbName = "CompanyName";

        private const string _DbCount = "counts";

        public int InsertCustomerInfo(CustomerInfo customerInfo)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 200).Value = customerInfo.CompanyName;
            SqlHelper.ExecuteNonQueryReturnPKID("CustomerInfoInsert", cmd, out pkid);
            return pkid;
        }

        public int UpdateCustomerInfo(CustomerInfo customerInfo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = customerInfo.CustomerInfoId;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 200).Value = customerInfo.CompanyName;
            return SqlHelper.ExecuteNonQuery("CustomerInfoUpdate", cmd);
        }

        public int DeleteCustomerInfo(int pKID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pKID;
            return SqlHelper.ExecuteNonQuery("CustomerInfoDelete", cmd);
        }

        public CustomerInfo GetCustomerInfoByCustomerInfoID(int pKID)
        {
            CustomerInfo customerInfo = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pKID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetCustomerInfoByPKID", cmd))
            {
                while (sdr.Read())
                {
                    customerInfo =
                        new CustomerInfo(Convert.ToInt32(sdr[_DbPKID]), sdr[_DbName].ToString());
                }
            }
            return customerInfo;
        }

        public List<CustomerInfo> GetCustomerInfoByNameLike(string name)
        {
            List<CustomerInfo> customerInfoList = new List<CustomerInfo>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 200).Value = name;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetCustomerInfoByNameLike", cmd))
            {
                while (sdr.Read())
                {
                    CustomerInfo customerInfo =
                        new CustomerInfo(Convert.ToInt32(sdr[_DbPKID]), sdr[_DbName].ToString());
                    customerInfoList.Add(customerInfo);
                }
            }
            return customerInfoList;
        }

        public int CountCustomerInfoByNameDiffPKID(string name, int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pkid;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 200).Value = name;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountCustomerInfoByNameDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        public int CountCustomerInfoByCodeDiffPKID(string code, int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pkid;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 200).Value = code;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountCustomerInfoByCodeDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        public CustomerInfo GetCustomerIDInfoByName(string name)
        {
            CustomerInfo customerInfo = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 200).Value = name;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetCustomerIDInfoByName", cmd))
            {
                while (sdr.Read())
                {
                    customerInfo =
                        new CustomerInfo(Convert.ToInt32(sdr[_DbPKID]), sdr[_DbName].ToString());
                }
            }
            return customerInfo;
        }

    }
}
