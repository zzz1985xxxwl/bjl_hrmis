//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeAccountSetDal.cs
// 创建者: 刘丹
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
using SEP.HRMIS.IDal.PayModule;
//using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.SqlServerDal.PayModule
{
    ///<summary>
    ///</summary>
    public class EmployeeSalaryDal : IEmployeeSalary
    {
        private const string _DirtyData = "该记录已被更新";
        private readonly object LockObj = new object();

        private const string _ParmPKID = "@PKID";
        private const string _ParmEmployeeID = "@EmployeeID";
        private const string _ParmAccountSetID = "@AccountSetID";
        private const string _ParmAccountSetName = "@AccountSetName";
        private const string _ParmEmployeeAccountSetItems = "@EmployeeAccountSetItems";
        private const string _ParmVersionNumber = "@VersionNumber";
        private const string _ParmStatus = "@Status";
        private const string _ParmSalaryDateTime = "@SalaryDateTime";
        private const string _ParmAccountsBackName = "@AccountsBackName";
        private const string _ParmDescpriton= "@Descpriton";
        //private const string _ParmName = "@Name";
        //private const string _ParmpositionID = "@positionID";
        //private const string _ParmDepartmentID = "@DepartmentID";
        //private const string _ParmEmployeeType = "@EmployeeType";

        private const string _DBPKID = "PKID";
        private const string _DBAccountSetID = "AccountSetID";
        private const string _DBAccountSetName = "AccountSetName";
        private const string _DBEmployeeAccountSetItems = "EmployeeAccountSetItems";
        private const string _DBVersionNumber = "VersionNumber";
        private const string _DBStatus = "Status";
        private const string _DBSalaryDateTime = "SalaryDateTime";
        private const string _DBAccountsBackName = "AccountsBackName";
        private const string _DBDescpriton = "Descpriton";
        private const string _DBEmployeeId = "EmployeeID";
        private const string _DBEmployeeName = "EmployeeName";


        /// <summary>
        /// 发薪
        /// </summary>
        public int InsertEmployeeSalaryHistory(int employeeID, EmployeeSalaryHistory salary)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_ParmEmployeeID, SqlDbType.Int).Value = employeeID;
            cmd.Parameters.Add(_ParmAccountSetID, SqlDbType.Int).Value =
                salary.EmployeeAccountSet.AccountSetID;
            cmd.Parameters.Add(_ParmAccountSetName, SqlDbType.NVarChar, 255).Value =
                salary.EmployeeAccountSet.AccountSetName;
            if (salary.EmployeeAccountSet.Items != null)
            {
                cmd.Parameters.Add(_ParmEmployeeAccountSetItems, SqlDbType.Image).Value =
                    SerializeAccountSetItemList(salary.EmployeeAccountSet.Items);
            }
            else
            {
                cmd.Parameters.Add(_ParmEmployeeAccountSetItems, SqlDbType.Image).Value = DBNull.Value; 
            }
            cmd.Parameters.Add(_ParmStatus, SqlDbType.Int).Value = salary.EmployeeSalaryStatus.Id;
            cmd.Parameters.Add(_ParmSalaryDateTime, SqlDbType.DateTime).Value = salary.SalaryDateTime;
            cmd.Parameters.Add(_ParmAccountsBackName, SqlDbType.NVarChar, 255).Value = salary.AccountsBackName;
            cmd.Parameters.Add(_ParmDescpriton, SqlDbType.NVarChar, 255).Value = salary.Description;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertEmployeeSalaryHistory", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 更新薪水
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="salary"></param>
        /// <returns></returns>
        public int UpdateEmployeeSalaryHistory(int employeeID, EmployeeSalaryHistory salary)
        {
            //注释掉该代码可以模拟测试,锁定是为了单线程访问
            lock (LockObj)
            {
                //判断是否是脏数据
                int updateVersion = GetEmployeeSalaryHistoryByPKID(salary.HistoryId).VersionNumber;
                if (updateVersion != salary.VersionNumber)
                {
                    throw new ApplicationException(_DirtyData);
                }

                return InnerUpdateEmployeeSalaryHistory(employeeID, salary);
            }
        }

        private static int InnerUpdateEmployeeSalaryHistory(int employeeID, EmployeeSalaryHistory salary)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = salary.HistoryId;
            cmd.Parameters.Add(_ParmEmployeeID, SqlDbType.Int).Value = employeeID;
            cmd.Parameters.Add(_ParmAccountSetID, SqlDbType.Int).Value =
                salary.EmployeeAccountSet.AccountSetID;
            cmd.Parameters.Add(_ParmAccountSetName, SqlDbType.NVarChar, 255).Value =
                salary.EmployeeAccountSet.AccountSetName;
            if (salary.EmployeeAccountSet.Items != null)
            {
                cmd.Parameters.Add(_ParmEmployeeAccountSetItems, SqlDbType.Image).Value =
                    SerializeAccountSetItemList(salary.EmployeeAccountSet.Items);
            }
            else
            {
                cmd.Parameters.Add(_ParmEmployeeAccountSetItems, SqlDbType.Image).Value = DBNull.Value;
            }
            cmd.Parameters.Add(_ParmStatus, SqlDbType.Int).Value = salary.EmployeeSalaryStatus.Id;
            cmd.Parameters.Add(_ParmSalaryDateTime, SqlDbType.DateTime).Value = salary.SalaryDateTime;
            cmd.Parameters.Add(_ParmAccountsBackName, SqlDbType.NVarChar, 255).Value = salary.AccountsBackName;
            cmd.Parameters.Add(_ParmDescpriton, SqlDbType.NVarChar, 255).Value = salary.Description;
            cmd.Parameters.Add(_ParmVersionNumber, SqlDbType.Int).Value = ++salary.VersionNumber;
            return SqlHelper.ExecuteNonQuery("UpdateEmployeeSalaryHistory", cmd);
        }

        public int ImportEmployeeSalaryHistory(int employeeID,EmployeeSalaryHistory salary)
        {
            return InnerUpdateEmployeeSalaryHistory(employeeID, salary);
        }

        public EmployeeSalary GetEmployeeSalaryByEmployeeID(int employeeId)
        {
            EmployeeSalary employeeSalary = new EmployeeSalary(employeeId);
            employeeSalary.EmployeeSalaryHistoryList = new List<EmployeeSalaryHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeID, SqlDbType.Int).Value = employeeId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeSalaryByEmployeeID", cmd))
            {
                while (sdr.Read())
                {
                    EmployeeSalaryHistory salaryHistory = new EmployeeSalaryHistory();
                    salaryHistory.HistoryId = (int) sdr[_DBPKID];
                    salaryHistory.EmployeeAccountSet = new AccountSet((int)sdr[_DBAccountSetID], sdr[_DBAccountSetName].ToString());

                    byte[] employeeAccountSetItems = sdr[_DBEmployeeAccountSetItems] as byte[];
                    if (employeeAccountSetItems != null)
                    {
                        salaryHistory.EmployeeAccountSet.Items = DeserializeAccountSetItems(employeeAccountSetItems);
                    }
                    salaryHistory.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.GetEmployeeSalaryStatusEnum((int)sdr[_DBStatus]);
                    salaryHistory.AccountsBackName = sdr[_DBAccountsBackName].ToString();
                    salaryHistory.VersionNumber = (int)sdr[_DBVersionNumber];
                    salaryHistory.SalaryDateTime = Convert.ToDateTime(sdr[_DBSalaryDateTime]);
                    salaryHistory.Description = sdr[_DBDescpriton].ToString();
                    employeeSalary.EmployeeSalaryHistoryList.Add(salaryHistory);
                }
            }
            return employeeSalary;
        }

        public EmployeeSalaryHistory GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(int employeeID, DateTime dt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeID, SqlDbType.Int).Value = employeeID;
            cmd.Parameters.Add(_ParmSalaryDateTime, SqlDbType.DateTime).Value = dt;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeSalaryHistoryByEmployeeIdAndDateTime", cmd))
            {
                while (sdr.Read())
                {
                    EmployeeSalaryHistory salaryHistory = new EmployeeSalaryHistory();
                    salaryHistory.EmployeeAccountSet = new AccountSet((int)sdr[_DBAccountSetID], sdr[_DBAccountSetName].ToString());
                    salaryHistory.HistoryId = (int)sdr[_DBPKID];
                    byte[] employeeAccountSetItems = sdr[_DBEmployeeAccountSetItems] as byte[];
                    if (employeeAccountSetItems != null)
                    {
                        salaryHistory.EmployeeAccountSet.Items = DeserializeAccountSetItems(employeeAccountSetItems);
                    }
                    salaryHistory.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.GetEmployeeSalaryStatusEnum((int)sdr[_DBStatus]);
                    salaryHistory.AccountsBackName = sdr[_DBAccountsBackName].ToString();
                    salaryHistory.VersionNumber =(int)sdr[_DBVersionNumber];
                    salaryHistory.SalaryDateTime = Convert.ToDateTime(sdr[_DBSalaryDateTime]);
                    salaryHistory.Description = sdr[_DBDescpriton].ToString();
                    return salaryHistory;
                }
            }
            return null;
        }

        public List<EmployeeSalaryHistory> GetEmployeeSalaryHistoryByEmployeeId(int employeeID)
        {
            List<EmployeeSalaryHistory> iRet= new List<EmployeeSalaryHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeID, SqlDbType.Int).Value = employeeID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeSalaryHistoryByEmployeeId", cmd))
            {
                while (sdr.Read())
                {
                    EmployeeSalaryHistory salaryHistory = new EmployeeSalaryHistory();
                    salaryHistory.EmployeeAccountSet = new AccountSet((int)sdr[_DBAccountSetID], sdr[_DBAccountSetName].ToString());
                    salaryHistory.HistoryId = (int)sdr[_DBPKID];
                    byte[] employeeAccountSetItems = sdr[_DBEmployeeAccountSetItems] as byte[];
                    if (employeeAccountSetItems != null)
                    {
                        salaryHistory.EmployeeAccountSet.Items = DeserializeAccountSetItems(employeeAccountSetItems);
                    }
                    salaryHistory.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.GetEmployeeSalaryStatusEnum((int)sdr[_DBStatus]);
                    salaryHistory.AccountsBackName = sdr[_DBAccountsBackName].ToString();
                    salaryHistory.VersionNumber = (int)sdr[_DBVersionNumber];
                    salaryHistory.SalaryDateTime = Convert.ToDateTime(sdr[_DBSalaryDateTime]);
                    salaryHistory.Description = sdr[_DBDescpriton].ToString();
                    iRet.Add(salaryHistory);
                }
            }
            return iRet;
        }

        public EmployeeSalary GetEmployeeSalaryByEmployeeSalaryHistoryID(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeSalaryHistoryByPKID", cmd))
            {
                while (sdr.Read())
                {
                    EmployeeSalary employeeSalary = new EmployeeSalary((int)sdr[_DBEmployeeId]);
                    employeeSalary.EmployeeSalaryHistoryList = new List<EmployeeSalaryHistory>();
                    EmployeeSalaryHistory salaryHistory = new EmployeeSalaryHistory();
                    salaryHistory.EmployeeAccountSet = new AccountSet((int)sdr[_DBAccountSetID], sdr[_DBAccountSetName].ToString());
                    salaryHistory.HistoryId = (int)sdr[_DBPKID];
                    byte[] employeeAccountSetItems = sdr[_DBEmployeeAccountSetItems] as byte[];
                    if (employeeAccountSetItems != null)
                    {
                        salaryHistory.EmployeeAccountSet.Items = DeserializeAccountSetItems(employeeAccountSetItems);
                    }
                    salaryHistory.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.GetEmployeeSalaryStatusEnum((int)sdr[_DBStatus]);
                    salaryHistory.AccountsBackName = sdr[_DBAccountsBackName].ToString();
                    salaryHistory.VersionNumber = (int)sdr[_DBVersionNumber];
                    salaryHistory.SalaryDateTime = Convert.ToDateTime(sdr[_DBSalaryDateTime]);
                    salaryHistory.Description = sdr[_DBDescpriton].ToString();
                    employeeSalary.EmployeeSalaryHistoryList.Add(salaryHistory);
                    return employeeSalary;
                }
            }
            return null;
        }

        public EmployeeSalaryHistory GetEmployeeSalaryHistoryByPKID(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeSalaryHistoryByPKID", cmd))
            {
                while (sdr.Read())
                {
                    EmployeeSalaryHistory salaryHistory = new EmployeeSalaryHistory();
                    salaryHistory.EmployeeAccountSet = new AccountSet((int)sdr[_DBAccountSetID], sdr[_DBAccountSetName].ToString());
                    salaryHistory.HistoryId = (int)sdr[_DBPKID];
                    byte[] employeeAccountSetItems = sdr[_DBEmployeeAccountSetItems] as byte[];
                    if (employeeAccountSetItems != null)
                    {
                        salaryHistory.EmployeeAccountSet.Items = DeserializeAccountSetItems(employeeAccountSetItems);
                    }
                    salaryHistory.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.GetEmployeeSalaryStatusEnum((int)sdr[_DBStatus]);
                    salaryHistory.AccountsBackName = sdr[_DBAccountsBackName].ToString();
                    salaryHistory.VersionNumber = (int)sdr[_DBVersionNumber];
                    salaryHistory.SalaryDateTime = Convert.ToDateTime(sdr[_DBSalaryDateTime]);
                    salaryHistory.Description = sdr[_DBDescpriton].ToString();
                    return salaryHistory;
                }
            }
            return null;
        }

        public List<EmployeeSalary> GetEmployeeSalaryByCondition(DateTime salaryTime, int accountSetId)
        {
   
            List<EmployeeSalary> employeeSalarys=new List<EmployeeSalary>();
            SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.Add(_ParmName, SqlDbType.NVarChar,50).Value = name;
            cmd.Parameters.Add(_ParmSalaryDateTime, SqlDbType.DateTime).Value = salaryTime;
            //cmd.Parameters.Add(_ParmDepartmentID, SqlDbType.Int).Value = departmentId;
            //cmd.Parameters.Add(_ParmpositionID, SqlDbType.Int).Value = positionId;
            cmd.Parameters.Add(_ParmAccountSetID, SqlDbType.Int).Value = accountSetId;
            //cmd.Parameters.Add(_ParmEmployeeType, SqlDbType.Int).Value = employeeType;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeSalaryByCondition", cmd))
            {
                while (sdr.Read())
                {
                    EmployeeSalary salary = new EmployeeSalary((int)sdr[_DBEmployeeId]);
                    //salary.EmployeeName = sdr[_DBEmployeeName].ToString();
                    salary.EmployeeSalaryHistoryList = new List<EmployeeSalaryHistory>();
                    EmployeeSalaryHistory salaryHistory = new EmployeeSalaryHistory();
                    salaryHistory.HistoryId = (int)sdr[_DBPKID];
                    salaryHistory.EmployeeAccountSet = new AccountSet((int)sdr[_DBAccountSetID], sdr[_DBAccountSetName].ToString());

                    byte[] employeeAccountSetItems = sdr[_DBEmployeeAccountSetItems] as byte[];
                    if (employeeAccountSetItems != null)
                    {
                        salaryHistory.EmployeeAccountSet.Items = DeserializeAccountSetItems(employeeAccountSetItems);
                    }
                    salaryHistory.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.GetEmployeeSalaryStatusEnum((int)sdr[_DBStatus]);
                    salaryHistory.AccountsBackName = sdr[_DBAccountsBackName].ToString();
                    salaryHistory.VersionNumber = (int)sdr[_DBVersionNumber];
                    salaryHistory.SalaryDateTime = Convert.ToDateTime(sdr[_DBSalaryDateTime]);
                    salaryHistory.Description = sdr[_DBDescpriton].ToString();
                    salary.EmployeeSalaryHistoryList.Add(salaryHistory);
                    employeeSalarys.Add(salary);
                }
            }
            return employeeSalarys;
        }

        private static List<AccountSetItem> DeserializeAccountSetItems(byte[] accountSetItems)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(accountSetItems, 0, accountSetItems.Length);
            return formatter.Deserialize(ms) as List<AccountSetItem>;
        }

        private static byte[] SerializeAccountSetItemList(List<AccountSetItem> accountSetItemList)
        {
            MemoryStream ms = new MemoryStream();
            new BinaryFormatter().Serialize(ms, accountSetItemList);
            byte[] bt = ms.ToArray();
            ms.Close();
            return bt;
        }
    }
}