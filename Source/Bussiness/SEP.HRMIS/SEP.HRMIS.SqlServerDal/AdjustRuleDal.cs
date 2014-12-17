//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: AdjustRuleDal.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-31
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Adjusts;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 
    /// </summary>
    public class AdjustRuleDal : IAdjustRule
    {
        private const int _retVal = -1;
        private const string _PKID = "@PKID";
        private const string _Name = "@Name";
        private const string _OverWorkPuTongRate = "@OverWorkPuTongRate";
        private const string _OverWorkJieRiRate = "@OverWorkJieRiRate";
        private const string _OverWorkShuangXiuRate = "@OverWorkShuangXiuRate";
        private const string _OutCityPuTongRate = "@OutCityPuTongRate";
        private const string _OutCityJieRiRate = "@OutCityJieRiRate";
        private const string _OutCityShuangXiuRate = "@OutCityShuangXiuRate";
        private const string _DbPKID = "PKID";
        private const string _DbName = "Name";
        private const string _DbOverWorkPuTongRate = "OverWorkPuTongRate";
        private const string _DbOverWorkJieRiRate = "OverWorkJieRiRate";
        private const string _DbOverWorkShuangXiuRate = "OverWorkShuangXiuRate";
        private const string _DbOutCityPuTongRate = "OutCityPuTongRate";
        private const string _DbOutCityJieRiRate = "OutCityJieRiRate";
        private const string _DbOutCityShuangXiuRate = "OutCityShuangXiuRate";

        private const string _DbCount = "counts";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adjustRule"></param>
        /// <returns></returns>
        public int InsertAdjustRule(AdjustRule adjustRule)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 200).Value = adjustRule.AdjustRuleName;
            cmd.Parameters.Add(_OverWorkPuTongRate, SqlDbType.Decimal).Value = adjustRule.OverWorkPuTongRate;
            cmd.Parameters.Add(_OverWorkJieRiRate, SqlDbType.Decimal).Value = adjustRule.OverWorkJieRiRate;
            cmd.Parameters.Add(_OverWorkShuangXiuRate, SqlDbType.Decimal).Value = adjustRule.OverWorkShuangXiuRate;
            cmd.Parameters.Add(_OutCityPuTongRate, SqlDbType.Decimal).Value = adjustRule.OutCityPuTongRate;
            cmd.Parameters.Add(_OutCityJieRiRate, SqlDbType.Decimal).Value = adjustRule.OutCityJieRiRate;
            cmd.Parameters.Add(_OutCityShuangXiuRate, SqlDbType.Decimal).Value = adjustRule.OutCityShuangXiuRate;
            SqlHelper.ExecuteNonQueryReturnPKID("AdjustRuleInsert", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adjustRule"></param>
        /// <returns></returns>
        public int UpdateAdjustRule(AdjustRule adjustRule)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = adjustRule.AdjustRuleID;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 200).Value = adjustRule.AdjustRuleName;
            cmd.Parameters.Add(_OverWorkPuTongRate, SqlDbType.Decimal).Value = adjustRule.OverWorkPuTongRate;
            cmd.Parameters.Add(_OverWorkJieRiRate, SqlDbType.Decimal).Value = adjustRule.OverWorkJieRiRate;
            cmd.Parameters.Add(_OverWorkShuangXiuRate, SqlDbType.Decimal).Value = adjustRule.OverWorkShuangXiuRate;
            cmd.Parameters.Add(_OutCityPuTongRate, SqlDbType.Decimal).Value = adjustRule.OutCityPuTongRate;
            cmd.Parameters.Add(_OutCityJieRiRate, SqlDbType.Decimal).Value = adjustRule.OutCityJieRiRate;
            cmd.Parameters.Add(_OutCityShuangXiuRate, SqlDbType.Decimal).Value = adjustRule.OutCityShuangXiuRate;
            return SqlHelper.ExecuteNonQuery("AdjustRuleUpdate", cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pKID"></param>
        /// <returns></returns>
        public int DeleteAdjustRule(int pKID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pKID;
            return SqlHelper.ExecuteNonQuery("AdjustRuleDelete", cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pKID"></param>
        /// <returns></returns>
        public AdjustRule GetAdjustRuleByAdjustRuleID(int pKID)
        {
            AdjustRule adjustRule = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pKID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAdjustRuleByAdjustRuleID", cmd))
            {
                while (sdr.Read())
                {
                    adjustRule =
                        new AdjustRule(Convert.ToInt32(sdr[_DbPKID]), sdr[_DbName].ToString(),
                                       Convert.ToDecimal(sdr[_DbOverWorkPuTongRate]),
                                       Convert.ToDecimal(sdr[_DbOverWorkJieRiRate]),
                                       Convert.ToDecimal(sdr[_DbOverWorkShuangXiuRate]),
                                       Convert.ToDecimal(sdr[_DbOutCityPuTongRate]),
                                       Convert.ToDecimal(sdr[_DbOutCityJieRiRate]),
                                       Convert.ToDecimal(sdr[_DbOutCityShuangXiuRate]));
                }
            }
            return adjustRule;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<AdjustRule> GetAdjustRuleByNameLike(string name)
        {
            List<AdjustRule> adjustRuleList = new List<AdjustRule>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 200).Value = name;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAdjustRuleByNameLike", cmd))
            {
                while (sdr.Read())
                {
                    AdjustRule adjustRule =
                        new AdjustRule(Convert.ToInt32(sdr[_DbPKID]), sdr[_DbName].ToString(),
                                       Convert.ToDecimal(sdr[_DbOverWorkPuTongRate]),
                                       Convert.ToDecimal(sdr[_DbOverWorkJieRiRate]),
                                       Convert.ToDecimal(sdr[_DbOverWorkShuangXiuRate]),
                                       Convert.ToDecimal(sdr[_DbOutCityPuTongRate]),
                                       Convert.ToDecimal(sdr[_DbOutCityJieRiRate]),
                                       Convert.ToDecimal(sdr[_DbOutCityShuangXiuRate]));
                    adjustRuleList.Add(adjustRule);
                }
            }
            return adjustRuleList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public int CountAdjustRuleByNameDiffPKID(string name, int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pkid;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 200).Value = name;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountAdjustRuleByNameDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }
    }
}