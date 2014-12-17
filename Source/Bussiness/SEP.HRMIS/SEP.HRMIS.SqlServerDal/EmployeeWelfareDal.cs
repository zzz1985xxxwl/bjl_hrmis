//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: EmployeeWelfare.cs
// Creater:  Xue.wenlong
// Date:  2008-12-23
// Resume:2009-07-06 liudan add supply account
// ----------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.SqlServerDal
{
    public class EmployeeWelfareDal : IEmployeeWelfare
    {
        private const string _PKID = "@PKID";
        private const string _AccountID = "@AccountID";
        private const string _SocialSecurityType = "@SocialSecurityType";
        private const string _SocialSecurityBase = "@SocialSecurityBase";
        private const string _YangLaoBase = "@YangLaoBase";
        private const string _ShiYeBase = "@ShiYeBase";
        private const string _YiLiaoBase = "@YiLiaoBase";
        private const string _SocialSecurityEffectiveYearMonth = "@SocialSecurityEffectiveYearMonth";
        private const string _AccumulationFundAccount = "@AccumulationFundAccount";
        private const string _AccumulationFundSupplyAccount = "@AccumulationFundSupplyAccount";
        private const string _AccumulationFundSupplyBase = "@AccumulationFundSupplyBase";
        private const string _AccumulationFundBase = "@AccumulationFundBase";
        private const string _AccumulationFundEffectiveMonthYear = "@AccumulationFundEffectiveMonthYear";

        private const string _DbPKID = "PKID";
        private const string _DbSocialSecurityType = "SocialSecurityType";
        private const string _DbSocialSecurityBase = "SocialSecurityBase";
        private const string _DbYangLaoBase = "YangLaoBase";
        private const string _DbShiYeBase = "ShiYeBase";
        private const string _DbYiLiaoBase = "YiLiaoBase";
        private const string _DbSocialSecurityEffectiveYearMonth = "SocialSecurityEffectiveYearMonth";
        private const string _DbAccumulationFundAccount = "AccumulationFundAccount";
        private const string _DbAccumulationFundBase = "AccumulationFundBase";
        private const string _DbAccumulationFundEffectiveMonthYear = "AccumulationFundEffectiveMonthYear";
        private const string _DbAccumulationFundSupplyAccount = "AccumulationFundSupplyAccount";
        private const string _DbAccumulationFundSupplyBase = "AccumulationFundSupplyBase";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeWelfare"></param>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public int InsertEmployeeWelfareByAccountID(EmployeeWelfare employeeWelfare, int accountID)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            EditParameters(cmd, employeeWelfare, accountID);
            SqlHelper.ExecuteNonQueryReturnPKID("InsertEmployeeWelfareByAccountID", cmd, out pkid);
            return pkid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeWelfare"></param>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public int UpdateEmployeeWelfareByAccountID(EmployeeWelfare employeeWelfare, int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            EditParameters(cmd, employeeWelfare, accountID);
            return SqlHelper.ExecuteNonQuery("UpdateEmployeeWelfareByAccountID", cmd);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="employeeWelfare"></param>
        /// <param name="accountID"></param>
        public static void EditParameters(SqlCommand cmd, EmployeeWelfare employeeWelfare, int accountID)
        {
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_SocialSecurityType, SqlDbType.Int).Value = employeeWelfare.SocialSecurity.Type != null
                                                                               ? (object)
                                                                                 employeeWelfare.SocialSecurity.Type.Id
                                                                               : DBNull.Value;
            cmd.Parameters.Add(_SocialSecurityBase, SqlDbType.Decimal).Value =
                employeeWelfare.SocialSecurity.Base.HasValue
                    ? (object)employeeWelfare.SocialSecurity.Base
                    : DBNull.Value;
            cmd.Parameters.Add(_YangLaoBase, SqlDbType.Decimal).Value =
                employeeWelfare.SocialSecurity.YangLaoBase.HasValue
                    ? (object)employeeWelfare.SocialSecurity.YangLaoBase
                    : DBNull.Value;
            cmd.Parameters.Add(_YiLiaoBase, SqlDbType.Decimal).Value =
                employeeWelfare.SocialSecurity.YiLiaoBase.HasValue
                    ? (object)employeeWelfare.SocialSecurity.YiLiaoBase
                    : DBNull.Value;
            cmd.Parameters.Add(_ShiYeBase, SqlDbType.Decimal).Value =
                employeeWelfare.SocialSecurity.ShiYeBase.HasValue
                    ? (object)employeeWelfare.SocialSecurity.ShiYeBase
                    : DBNull.Value;
            cmd.Parameters.Add(_SocialSecurityEffectiveYearMonth, SqlDbType.DateTime).Value =
                employeeWelfare.SocialSecurity.EffectiveYearMonth.HasValue
                    ? (object) employeeWelfare.SocialSecurity.EffectiveYearMonth
                    : DBNull.Value;
            cmd.Parameters.Add(_AccumulationFundAccount, SqlDbType.NVarChar, 255).Value =
                employeeWelfare.AccumulationFund.Account != null
                    ? (object) employeeWelfare.AccumulationFund.Account
                    : DBNull.Value;
            cmd.Parameters.Add(_AccumulationFundSupplyAccount, SqlDbType.NVarChar, 255).Value =
                employeeWelfare.AccumulationFund.SupplyAccount != null
                    ? (object) employeeWelfare.AccumulationFund.SupplyAccount
                    : DBNull.Value;
            cmd.Parameters.Add(_AccumulationFundSupplyBase, SqlDbType.Decimal).Value =
               employeeWelfare.AccumulationFund.SupplyBase.HasValue
                   ? (object)employeeWelfare.AccumulationFund.SupplyBase
                   : DBNull.Value;
            cmd.Parameters.Add(_AccumulationFundBase, SqlDbType.Decimal).Value =
                employeeWelfare.AccumulationFund.Base.HasValue
                    ? (object) employeeWelfare.AccumulationFund.Base
                    : DBNull.Value;
            cmd.Parameters.Add(_AccumulationFundEffectiveMonthYear, SqlDbType.DateTime).Value =
                employeeWelfare.AccumulationFund.EffectiveYearMonth.HasValue
                    ? (object) employeeWelfare.AccumulationFund.EffectiveYearMonth
                    : DBNull.Value;
        }

        public int DeleteEmployeeWelfareByAccountID(int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            return SqlHelper.ExecuteNonQuery("DeleteEmployeeWelfareByAccountID", cmd);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public EmployeeWelfare GetEmployeeWelfareByAccountID(int accountID)
        {
            EmployeeWelfare employeeWelfare = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeWelfareByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    EmployeeSocialSecurity employeeSocialSecurity =
                        new EmployeeSocialSecurity(
                            SocialSecurityTypeEnum.GetById(
                                Convert.ToInt32(sdr[_DbSocialSecurityType] ?? 0)),
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
                    employeeWelfare =
                        new EmployeeWelfare(Convert.ToInt32(sdr[_DbPKID]), employeeSocialSecurity,
                                            employeeAccumulationFund);
                }
            }
            return employeeWelfare;
        }
    }
}