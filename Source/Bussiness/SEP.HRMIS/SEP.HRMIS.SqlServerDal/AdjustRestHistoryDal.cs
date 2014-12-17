using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Model.Enum;
using SEP.Model.Accounts;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 数据库交互
    /// </summary>
    public class AdjustRestHistoryDal : IAdjustRestHistory
    {
        #region 私有常量

        private const string _ParmPKID = "@PKID";
        private const string _ParmOccurTime = "@OccurTime";
        private const string _ParmOperatorId = "@OperatorId";
        private const string _ParmChangeHours = "@ChangeHours";
        //private const string _ParmResultAdjustRestHours = "@ResultAdjustRestHours";
        private const string _ParmAdjustRestHistoryType = "@AdjustRestHistoryType";
        private const string _ParmRelevantID = "@RelevantID";
        private const string _ParmRemark = "@Remark";
        private const string _ParmAccountID = "@AccountID";

        private const string _DBPKID = "PKID"; 
        private const string _DBOccurTime = "OccurTime";
        private const string _DBOperatorId = "OperatorId";
        private const string _DBChangeHours = "ChangeHours";
        //private const string _DBResultAdjustRestHours = "ResultAdjustRestHours";
        private const string _DBAdjustRestHistoryType = "AdjustRestHistoryType";
        private const string _DBRelevantID = "RelevantID";
        private const string _DBRemark = "Remark";

        private const string _DBError = "数据库访问错误!";

        #endregion

        public int InsertAdjustRestHistory(int accountid, AdjustRestHistory adjustRestHistory)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_ParmAdjustRestHistoryType, SqlDbType.Int).Value =
                (Int32)adjustRestHistory.AdjustRestHistoryTypeEnum;
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountid;
            cmd.Parameters.Add(_ParmChangeHours, SqlDbType.Decimal).Value = adjustRestHistory.ChangeHours;
            cmd.Parameters.Add(_ParmOccurTime, SqlDbType.DateTime).Value = adjustRestHistory.OccurTime;
            cmd.Parameters.Add(_ParmOperatorId, SqlDbType.Int).Value = adjustRestHistory.Operator.Id;
            cmd.Parameters.Add(_ParmRelevantID, SqlDbType.Int).Value = adjustRestHistory.RelevantID;
            cmd.Parameters.Add(_ParmRemark, SqlDbType.NVarChar, 255).Value = adjustRestHistory.Remark;
           // cmd.Parameters.Add(_ParmResultAdjustRestHours, SqlDbType.Decimal).Value = adjustRestHistory.ResultAdjustRestHours;

            SqlHelper.ExecuteNonQueryReturnPKID("AdjustRestHistoryInsert", cmd, out pkid);
            adjustRestHistory.AdjustRestHistoryID = pkid;
            return pkid;
        }

        public List<AdjustRestHistory> GetAdjustRestHistoryByAccountID(int accountID)
        {
            List<AdjustRestHistory> adjustRestHistoryList = new List<AdjustRestHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            try
            {
                using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAdjustRestHistoryByAccountID", cmd))
                {
                    while (sdr.Read())
                    {
                        AdjustRestHistory adjustRestHistory = new AdjustRestHistory();
                        GetFieldFromParm(sdr, adjustRestHistory);
                        adjustRestHistoryList.Add(adjustRestHistory);
                    }
                    return adjustRestHistoryList;
                }
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
        }

        public int DeleteAdjustRestHistory(int adjustRestHistoryID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = adjustRestHistoryID;
            return SqlHelper.ExecuteNonQuery("AdjustRestHistoryDelete", cmd);
        }

        /// <summary>
        /// 所有GET数据绑定
        /// </summary>
        /// <param name="sdr"></param>
        /// <param name="adjustRestHistory"></param>
        private static void GetFieldFromParm(SqlDataReader sdr, AdjustRestHistory adjustRestHistory)
        {
            if (adjustRestHistory==null)
            {
                adjustRestHistory = new AdjustRestHistory();
            }
            for (int i = 0; i < sdr.FieldCount; i++)
            {
                DateTime tryDateTimeParse;
                int tryIntParse;
                decimal tryDecimalParse;
                switch (sdr.GetName(i))
                {
                    case _DBPKID:
                        if (sdr[_DBPKID] != null && int.TryParse(sdr[_DBPKID].ToString(), out tryIntParse))
                        {
                            adjustRestHistory.AdjustRestHistoryID = (int) sdr[_DBPKID];
                        }
                        break;
                    case _DBAdjustRestHistoryType:
                        if (sdr[_DBAdjustRestHistoryType] != null && int.TryParse(sdr[_DBAdjustRestHistoryType].ToString(), out tryIntParse))
                        {
                            adjustRestHistory.AdjustRestHistoryTypeEnum =
                                (AdjustRestHistoryTypeEnum)sdr[_DBAdjustRestHistoryType];
                        }
                        break;
                    case _DBChangeHours:
                        if (sdr[_DBChangeHours] != null &&
                            decimal.TryParse(sdr[_DBChangeHours].ToString(), out tryDecimalParse))
                        {
                            adjustRestHistory.ChangeHours = (decimal)sdr[_DBChangeHours];
                        }
                        break;
                    case _DBOccurTime:
                        if (sdr[_DBOccurTime] != null &&
                            DateTime.TryParse(sdr[_DBOccurTime].ToString(), out tryDateTimeParse))
                        {
                            adjustRestHistory.OccurTime = (DateTime)sdr[_DBOccurTime];
                        }
                        break;
                    case _DBOperatorId:
                        if (sdr[_DBOperatorId] != null &&
                            int.TryParse(sdr[_DBOperatorId].ToString(), out tryIntParse))
                        {
                            adjustRestHistory.Operator = adjustRestHistory.Operator ?? new Account();
                            adjustRestHistory.Operator.Id = (int) sdr[_DBOperatorId];
                        }
                        break;
                    case _DBRelevantID:
                        if (sdr[_DBRelevantID] != null &&
                            int.TryParse(sdr[_DBRelevantID].ToString(), out tryIntParse))
                        {
                            adjustRestHistory.RelevantID = (int)sdr[_DBRelevantID];
                        }
                        break;
                    case _DBRemark:
                        if (sdr[_DBRemark] != null )
                        {
                            adjustRestHistory.Remark = sdr[_DBRemark].ToString();
                        }
                        break;
                    //case _DBResultAdjustRestHours:
                    //    if (sdr[_DBResultAdjustRestHours] != null &&
                    //        decimal.TryParse(sdr[_DBResultAdjustRestHours].ToString(), out tryDecimalParse))
                    //    {
                    //        adjustRestHistory.ResultAdjustRestHours = (decimal)sdr[_DBResultAdjustRestHours];
                    //    }
                    //    break;
                    default:
                        break;
                }
            }
        }

    }
}
