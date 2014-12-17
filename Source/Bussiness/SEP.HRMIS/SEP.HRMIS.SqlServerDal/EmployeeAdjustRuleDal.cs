using System;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Adjusts;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeAdjustRuleDal : IEmployeeAdjustRule
    {
        private const string _PKID = "@PKID";
        private const string _AccountID = "@AccountID";
        private const string _AdjustRuleID = "@AdjustRuleID";
        private const string _DbPKID = "PKID";
        private const string _DbName = "Name";
        private const string _DbOverWorkPuTongRate = "OverWorkPuTongRate";
        private const string _DbOverWorkJieRiRate = "OverWorkJieRiRate";
        private const string _DbOverWorkShuangXiuRate = "OverWorkShuangXiuRate";
        private const string _DbOutCityPuTongRate = "OutCityPuTongRate";
        private const string _DbOutCityJieRiRate = "OutCityJieRiRate";
        private const string _DbOutCityShuangXiuRate = "OutCityShuangXiuRate";

        public AdjustRule GetAdjustRuleByAccountID(int accoutid)
        {
            AdjustRule adjustRule = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accoutid;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAdjustRuleByAccountID", cmd))
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
        public int Insert(int accountid, int adjustRuleID)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountid;
            cmd.Parameters.Add(_AdjustRuleID, SqlDbType.Int).Value = adjustRuleID;
            SqlHelper.ExecuteNonQueryReturnPKID("EmployeeAdjustRuleInsert", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 
        /// </summary>
        public int UpdateEmployeeAdjustRuleByAccountID(int accountID, int adjustRuleID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_AdjustRuleID, SqlDbType.Int).Value = adjustRuleID;
            return SqlHelper.ExecuteNonQuery("UpdateEmployeeAdjustRuleByAccountID", cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        public int DeleteEmployeeAdjustRuleByAccountID(int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            return SqlHelper.ExecuteNonQuery("DeleteEmployeeAdjustRuleByAccountID", cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        public int CountAdjustRuleUsedByAdjustRuleID(int ruleID)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AdjustRuleID, SqlDbType.Int).Value = ruleID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeAdjustRuleByAdjustRuleID", cmd))
            {
                while (sdr.Read())
                {
                    count++;
                }
            }
            return count;
        }
    }
}