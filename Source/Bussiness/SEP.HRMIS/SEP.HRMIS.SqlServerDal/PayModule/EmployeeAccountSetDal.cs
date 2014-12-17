//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeAccountSetDal.cs
// 创建者: yyb
// 创建日期: 2008-12-24
// 概述: 实现IEmployeeAccountSetDal接口中的方法
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SEP.HRMIS.Model.PayModule;
//using SEP.HRMIS.Model;
using SEP.HRMIS.IDal.PayModule;

namespace SEP.HRMIS.SqlServerDal.PayModule
{
    ///<summary>
    ///</summary>
    public class EmployeeAccountSetDal : IEmployeeAccountSet
    {
        #region const string
        private const string _ParmPKID = "@PKID";
        private const string _ParmEmployeeID = "@EmployeeID";
        //private const string _ParmEmployeeName = "@EmployeeName";
        private const string _ParmAccountSetID = "@AccountSetID";
        private const string _ParmAccountSetName = "@AccountSetName";
        private const string _ParmEmployeeAccountSetItems = "@EmployeeAccountSetItems";
        private const string _ParmChangeDate = "@ChangeDate";
        private const string _ParmAccountsBackName = "@AccountsBackName";
        private const string _ParmDescription = "@Description";
        //private const string _ParmDepartmentID = "@DepartmentID";
        //private const string _ParmEmployeeType = "@EmployeeType";
        //private const string _ParmPositionID = "@PositionID";
        private const string _ParmAccountSetParaID = "@AccountSetParaID";

        private const string _DBPKID = "PKID";
        private const string _DBAccountSetID = "AccountSetID";
        private const string _DBAccountSetName = "AccountSetName";
        private const string _DBEmployeeAccountSetItems = "EmployeeAccountSetItems";
        private const string _DBEmployeeID = "EmployeeID";
        private const string _DBEmployeeName = "EmployeeName";
        private const string _DBChangeDate = "ChangeDate";
        private const string _DBAccountsBackName = "AccountsBackName";
        private const string _DBDescription = "Description";
        private const string _DBCount = "Count";

        #endregion

        private static List<AccountSetItem> DeserializeAccountSetItems(SqlDataReader sdr)
        {
            byte[] employeeAccountSetItems = sdr[_DBEmployeeAccountSetItems] as byte[];
            if (employeeAccountSetItems != null)
            {
                IFormatter formatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(employeeAccountSetItems, 0, employeeAccountSetItems.Length);
                return formatter.Deserialize(ms) as List<AccountSetItem>;
            }
            return null;
        }

        private static byte[] SerializeAccountSetItemList(List<AccountSetItem> accountSetItemList)
        {
            MemoryStream ms = new MemoryStream();
            new BinaryFormatter().Serialize(ms, accountSetItemList);
            byte[] bt = ms.ToArray();
            ms.Close();
            return bt;
        }

        #region EmployeeAccountSet

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="accountSet"></param>
        ///<returns></returns>
        public int InsertEmployeeAccountSet(int employeeID, AccountSet accountSet)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeID, SqlDbType.Int).Value = employeeID;
            cmd.Parameters.Add(_ParmAccountSetID, SqlDbType.Int).Value = accountSet.AccountSetID;
            cmd.Parameters.Add(_ParmAccountSetName, SqlDbType.NVarChar, 255).Value = accountSet.AccountSetName;
            cmd.Parameters.Add(_ParmEmployeeAccountSetItems, SqlDbType.Image).Value = SerializeAccountSetItemList(accountSet.Items);
            cmd.Parameters.Add(_ParmDescription, SqlDbType.NVarChar, 255).Value = accountSet.Description;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertEmployeeAccountSet", cmd, out pkid);
            return pkid;
        }

        public int UpdateEmployeeAccountSet(int employeeID, AccountSet accountSet)
        {
            SqlCommand cmd = new SqlCommand(); 
            cmd.Parameters.Add(_ParmEmployeeID, SqlDbType.Int).Value = employeeID;
            cmd.Parameters.Add(_ParmAccountSetID, SqlDbType.Int).Value = accountSet.AccountSetID;
            cmd.Parameters.Add(_ParmAccountSetName, SqlDbType.NVarChar, 255).Value = accountSet.AccountSetName;
            cmd.Parameters.Add(_ParmEmployeeAccountSetItems, SqlDbType.Image).Value = SerializeAccountSetItemList(accountSet.Items);
            cmd.Parameters.Add(_ParmDescription, SqlDbType.NVarChar, 255).Value = accountSet.Description;
            return SqlHelper.ExecuteNonQuery("UpdateEmployeeAccountSet", cmd);
        }

        public EmployeeSalary GetEmployeeAccountSetByEmployeeID(int employeeID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeID, SqlDbType.Int).Value = employeeID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeAccountSetByEmployeeID", cmd))
            {
                while (sdr.Read())
                {
                    EmployeeSalary employeeSalary = new EmployeeSalary(employeeID);
                    employeeSalary.AccountSet = new AccountSet((int)sdr[_DBAccountSetID], sdr[_DBAccountSetName].ToString());
                    employeeSalary.AccountSet.Items = DeserializeAccountSetItems(sdr);
                    employeeSalary.AccountSet.Description = sdr[_DBDescription].ToString();
                    
                    return employeeSalary;
                }
                return null;
            }
        }

        public int CountEmployeeAccountSetByAccountSetID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountSetID, SqlDbType.Int).Value = id;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountEmployeeAccountSetByAccountSetID", cmd))
            {
                while (sdr.Read())
                {
                    return (int)sdr[_DBCount];
                }
                return 0;
            }
        }

        public List<EmployeeSalary> GetEmployeeAccountSetByAccountSetID(int id)
        {
            List<EmployeeSalary> iRet = new List<EmployeeSalary>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountSetID, SqlDbType.Int).Value = id;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeAccountSetByAccountSetID", cmd))
            {
                while (sdr.Read())
                {
                    EmployeeSalary employeeSalary = new EmployeeSalary((int) sdr[_DBEmployeeID]);
                    employeeSalary.AccountSet = new AccountSet(id, sdr[_DBAccountSetName].ToString());
                    employeeSalary.AccountSet.Items = DeserializeAccountSetItems(sdr);
                    employeeSalary.AccountSet.Description = sdr[_DBDescription].ToString();
                    iRet.Add(employeeSalary);
                }
            }
            return iRet;
        }

        public List<EmployeeSalary> GetAllEmployeeAccountSet()
        {
            List<EmployeeSalary> iRet = new List<EmployeeSalary>();
            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllEmployeeAccountSet", cmd))
            {
                while (sdr.Read())
                {
                    EmployeeSalary employeeSalary = new EmployeeSalary((int)sdr[_DBEmployeeID]);
                    employeeSalary.AccountSet = new AccountSet((int)sdr[_DBAccountSetID], sdr[_DBAccountSetName].ToString());
                    employeeSalary.AccountSet.Items = DeserializeAccountSetItems(sdr);
                    employeeSalary.AccountSet.Description = sdr[_DBDescription].ToString();
                    iRet.Add(employeeSalary);
                }
            }
            return iRet;
        }

        public List<EmployeeSalary> GetEmployeeAccountSetByAccountSetParaID(int accountSetParaID)
        {
            List<EmployeeSalary> iRet = new List<EmployeeSalary>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountSetParaID, SqlDbType.Int).Value = accountSetParaID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeAccountSetByAccountSetParaID", cmd))
            {
                while (sdr.Read())
                {
                    EmployeeSalary employeeSalary = new EmployeeSalary((int)sdr[_DBEmployeeID]);
                    employeeSalary.AccountSet = new AccountSet((int)sdr[_DBAccountSetID], sdr[_DBAccountSetName].ToString());
                    employeeSalary.AccountSet.Items = DeserializeAccountSetItems(sdr);
                    employeeSalary.AccountSet.Description = sdr[_DBDescription].ToString();
                    iRet.Add(employeeSalary);
                }
            }
            return iRet;
        }

        #endregion

        #region AdjustSalaryHistory

        public void InsertAdjustSalaryHistory(int employeeID, AdjustSalaryHistory adjustSalaryHistory)
        {
            int pkid; 
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeID, SqlDbType.Int).Value = employeeID;
            cmd.Parameters.Add(_ParmAccountSetName, SqlDbType.NVarChar, 255).Value = adjustSalaryHistory.AccountSet.AccountSetName;
            cmd.Parameters.Add(_ParmEmployeeAccountSetItems, SqlDbType.Image).Value = SerializeAccountSetItemList(adjustSalaryHistory.AccountSet.Items);
            cmd.Parameters.Add(_ParmChangeDate, SqlDbType.DateTime).Value = adjustSalaryHistory.ChangeDate;
            cmd.Parameters.Add(_ParmAccountsBackName, SqlDbType.NVarChar, 255).Value = adjustSalaryHistory.AccountsBackName;
            cmd.Parameters.Add(_ParmDescription, SqlDbType.NVarChar, 255).Value = adjustSalaryHistory.Description;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertAdjustSalaryHistory", cmd, out pkid);
        }

        public void UpdateAdjustSalaryHistory(int employeeID, AdjustSalaryHistory adjustSalaryHistory)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeID, SqlDbType.Int).Value = employeeID;
            cmd.Parameters.Add(_ParmAccountSetName, SqlDbType.NVarChar, 255).Value = adjustSalaryHistory.AccountSet.AccountSetName;
            cmd.Parameters.Add(_ParmEmployeeAccountSetItems, SqlDbType.Image).Value = SerializeAccountSetItemList(adjustSalaryHistory.AccountSet.Items);
            cmd.Parameters.Add(_ParmChangeDate, SqlDbType.DateTime).Value = adjustSalaryHistory.ChangeDate;
            cmd.Parameters.Add(_ParmAccountsBackName, SqlDbType.NVarChar, 255).Value = adjustSalaryHistory.AccountsBackName;
            cmd.Parameters.Add(_ParmDescription, SqlDbType.NVarChar, 255).Value = adjustSalaryHistory.Description;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = adjustSalaryHistory.AdjustSalaryHistoryID;
            SqlHelper.ExecuteNonQuery("UpdateAdjustSalaryHistory", cmd);
        }

        public EmployeeSalary GetAdjustSalaryHistoryByPKID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = id;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAdjustSalaryHistoryByPKID", cmd))
            {
                while (sdr.Read())
                {
                    EmployeeSalary iRet = new EmployeeSalary((int)sdr[_DBEmployeeID]);
                    AdjustSalaryHistory adjustSalaryHistory = new AdjustSalaryHistory();
                    adjustSalaryHistory.AdjustSalaryHistoryID = id;
                    adjustSalaryHistory.AccountsBackName = sdr[_DBAccountsBackName].ToString();
                    adjustSalaryHistory.Description = sdr[_DBDescription].ToString();
                    adjustSalaryHistory.ChangeDate = (DateTime)sdr[_DBChangeDate];
                    adjustSalaryHistory.AccountSet = new AccountSet(0, sdr[_DBAccountSetName].ToString());
                    adjustSalaryHistory.AccountSet.Items = DeserializeAccountSetItems(sdr);
                    adjustSalaryHistory.AccountSet.Description = sdr[_DBDescription].ToString();
                    iRet.AdjustSalaryHistoryList = new List<AdjustSalaryHistory>();
                    iRet.AdjustSalaryHistoryList.Add(adjustSalaryHistory);
                    return iRet;
                }
            }
            return null;
        }

        public List<AdjustSalaryHistory> GetAdjustSalaryHistoryByEmployeeID(int employeeID)
        {
            List<AdjustSalaryHistory> iRet = new List<AdjustSalaryHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeID, SqlDbType.Int).Value = employeeID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAdjustSalaryHistoryByEmployeeID", cmd))
            {
                while (sdr.Read())
                {
                    AdjustSalaryHistory adjustSalaryHistory = new AdjustSalaryHistory();
                    adjustSalaryHistory.AdjustSalaryHistoryID = (int)sdr[_DBPKID];
                    adjustSalaryHistory.AccountsBackName = sdr[_DBAccountsBackName].ToString();
                    adjustSalaryHistory.Description = sdr[_DBDescription].ToString();
                    adjustSalaryHistory.ChangeDate = (DateTime)sdr[_DBChangeDate];
                    adjustSalaryHistory.AccountSet = new AccountSet(0, sdr[_DBAccountSetName].ToString());
                    adjustSalaryHistory.AccountSet.Items = DeserializeAccountSetItems(sdr);
                    iRet.Add(adjustSalaryHistory);
                }
            }
            return iRet;
        }

        public List<AdjustSalaryHistory> GetAdjustSalaryHistoryByEmployeeIDAndDateTime(int employeeID, DateTime dt)
        {
            List<AdjustSalaryHistory> iRet = new List<AdjustSalaryHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeID, SqlDbType.Int).Value = employeeID;
            cmd.Parameters.Add(_ParmChangeDate, SqlDbType.DateTime).Value = dt;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAdjustSalaryHistoryByEmployeeIDAndDateTime", cmd))
            {
                while (sdr.Read())
                {
                    AdjustSalaryHistory adjustSalaryHistory = new AdjustSalaryHistory();
                    adjustSalaryHistory.AccountsBackName = sdr[_DBAccountsBackName].ToString();
                    adjustSalaryHistory.Description = sdr[_DBDescription].ToString();
                    adjustSalaryHistory.ChangeDate = (DateTime)sdr[_DBChangeDate];
                    adjustSalaryHistory.AccountSet = new AccountSet(0, sdr[_DBAccountSetName].ToString());
                    adjustSalaryHistory.AccountSet.Items = DeserializeAccountSetItems(sdr);
                    iRet.Add(adjustSalaryHistory);
                }
            }
            return iRet;
        }

        #endregion

    }
}