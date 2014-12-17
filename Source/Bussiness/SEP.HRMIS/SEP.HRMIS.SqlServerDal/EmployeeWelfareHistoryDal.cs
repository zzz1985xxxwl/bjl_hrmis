//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeWelfareHistoryDal.cs
// 创建者: Xue.wenlong
// 创建日期: 2008-12-23
// 概述: 数据库访问类
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.SqlServerDal
{
    public class EmployeeWelfareHistoryDal : IEmployeeWelfareHistory
    {
        private const string _PKID = "@PKID";
        private const string _AccountID = "@AccountID";
        private const string _OperationTime = "@OperationTime";
        private const string _AccountsBackName = "@AccountsBackName";
        private const string _DbPKID = "PKID";
        private const string _DbSocialSecurityType = "SocialSecurityType";
        private const string _DbSocialSecurityBase = "SocialSecurityBase";
        private const string _DbYangLaoBase = "YangLaoBase";
        private const string _DbShiYeBase = "ShiYeBase";
        private const string _DbYiLiaoBase = "YiLiaoBase";
        private const string _DbSocialSecurityEffectiveYearMonth = "SocialSecurityEffectiveYearMonth";
        private const string _DbAccumulationFundAccount = "AccumulationFundAccount";
        private const string _DbAccumulationFundSupplyAccount = "AccumulationFundSupplyAccount";
        private const string _DbAccumulationFundSupplyBase = "AccumulationFundSupplyBase";
        private const string _DbAccumulationFundBase = "AccumulationFundBase";
        private const string _DbAccumulationFundEffectiveMonthYear = "AccumulationFundEffectiveMonthYear";
        private const string _DbOperationTime = "OperationTime";
        private const string _DbAccountsBackName = "AccountsBackName";

        public List<EmployeeWelfareHistory> GetEmployeeWelfareHistoryByAccountID(int employeeID)
        {
            List<EmployeeWelfareHistory> employeeWelfareHistoryList = new List<EmployeeWelfareHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = employeeID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeWelfareHistoryByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    EmployeeSocialSecurity employeeSocialSecurity =
                        new EmployeeSocialSecurity(
                            SocialSecurityTypeEnum.GetById(Convert.ToInt32(sdr[_DbSocialSecurityType] ?? 0)),
                            EmployeeWelfare.ConvertToDecimal(sdr[_DbSocialSecurityBase]),
                            EmployeeWelfare.ConvertToDateTime(sdr[_DbSocialSecurityEffectiveYearMonth]),
                            EmployeeWelfare.ConvertToDecimal(sdr[_DbYangLaoBase]),
                            EmployeeWelfare.ConvertToDecimal(sdr[_DbShiYeBase]),
                            EmployeeWelfare.ConvertToDecimal(sdr[_DbYiLiaoBase]));
                    EmployeeAccumulationFund employeeAccumulationFund =
                        new EmployeeAccumulationFund(EmployeeWelfare.ConvertToString(sdr[_DbAccumulationFundAccount]),
                                                     EmployeeWelfare.ConvertToDecimal(sdr[_DbAccumulationFundBase]),
                                                     EmployeeWelfare.ConvertToDateTime(
                                                         sdr[_DbAccumulationFundEffectiveMonthYear]),
                                                     EmployeeWelfare.ConvertToString(
                                                         sdr[_DbAccumulationFundSupplyAccount]),
                                                     EmployeeWelfare.ConvertToDecimal(
                                                         sdr[_DbAccumulationFundSupplyBase]));
                   
                    EmployeeWelfare employeeWelfare =
                        new EmployeeWelfare(employeeSocialSecurity, employeeAccumulationFund);
                    EmployeeWelfareHistory employeeWelfareHistory =
                        new EmployeeWelfareHistory(Convert.ToInt32(sdr[_DbPKID]), employeeWelfare,
                                                   Convert.ToDateTime(sdr[_DbOperationTime]),
                                                   sdr[_DbAccountsBackName].ToString());
                    employeeWelfareHistoryList.Add(employeeWelfareHistory);
                }
            }
            return employeeWelfareHistoryList;
        }

        public int CreateEmployeeWelfareHistoryByAccountID(EmployeeWelfareHistory employeeWelfareHistory, int employeeID)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            EmployeeWelfareDal.EditParameters(cmd, employeeWelfareHistory.EmployeeWelfare, employeeID);
            cmd.Parameters.Add(_OperationTime, SqlDbType.DateTime).Value = employeeWelfareHistory.OperationTime;
            cmd.Parameters.Add(_AccountsBackName, SqlDbType.NVarChar, 255).Value =
                employeeWelfareHistory.AccountsBackName;
            SqlHelper.ExecuteNonQueryReturnPKID("CreateEmployeeWelfareHistoryByAccountID", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 测试
        /// </summary>
        public int DeleteEmployeeWelfareHistoryByAccountID(int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            return SqlHelper.ExecuteNonQuery("DeleteEmployeeWelfareHistoryByAccountID", cmd);
        }
    }
}