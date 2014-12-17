//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkDal.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// </summary>
    public class OverWorkDal : IOverWork
    {
        private const string _PKID = "@PKID";
        private const string _AccountID = "@AccountID";
        private const string _SubmitDate = "@SubmitDate";
        private const string _From = "@From";
        private const string _To = "@To";
        private const string _CostTime = "@CostTime";
        private const string _Status = "@Status";
        private const string _Reason = "@Reason";
        private const string _ProjectName = "@ProjectName";
        private const string _DbPKID = "PKID";
        private const string _DbAccountID = "AccountID";
        private const string _DbSubmitDate = "SubmitDate";
        private const string _DbFrom = "From";
        private const string _DbTo = "To";
        private const string _DbCostTime = "CostTime";
        private const string _DbStatus = "Status";
        private const string _DbReason = "Reason";
        private const string _DbProjectName = "ProjectName";
        private const string _OverWorkID = "@OverWorkID";
        private const string _Step = "@Step";
        private const string _OperatorID = "@OperatorID";
        private const string _OperationTime = "@OperationTime";
        private const string _OverWorkItemID = "@OverWorkItemID";
        private const string _Operation = "@Operation";
        private const string _Remark = "@Remark";
        private const string _Adjust = "@Adjust";
        private const string _AdjustHour = "@AdjustHour";
        private const string _OverWorkType = "@OverWorkType";
        private const string _DbOverWorkType = "OverWorkType";
        private const string _DbAdjust = "Adjust";
        private const string _DbAdjustHour = "AdjustHour";
        private const string _DbOperatorID = "OperatorID";
        private const string _DbOperationTime = "OperationTime";
        private const string _DbRemark = "Remark";
        private const string _DbOperation = "Operation";
        private const string _DbStep = "Step";
        private const string _DiyProcess = "@DiyProcess";
        private const string _DbDiyProcess = "DiyProcess";
        private const string _DbCount = "counts";
        private const string _Date = "@Date";
        private const string _DbOverWorkID = "OverWorkID";
        private const string _DbTOverWorkItemPKID = "TOverWorkItemPKID";
        private const string _DbTOverWorkItemOverWorkID = "TOverWorkItemOverWorkID";
        private const string _DbTOverWorkItemStatus = "TOverWorkItemStatus";
        private const string _DbTOverWorkItemFrom = "TOverWorkItemFrom";
        private const string _DbTOverWorkItemTo = "TOverWorkItemTo";
        private const string _DbTOverWorkItemCostTime = "TOverWorkItemCostTime";
        private const string _DbTOverWorkItemOverWorkType = "TOverWorkItemOverWorkType";
        private const string _DbTOverWorkItemAdjust = "TOverWorkItemAdjust";
        private const string _DbTOverWorkItemAdjustHour = "TOverWorkItemAdjustHour";
        #region overwork

        /// <summary>
        /// </summary>
        public int InsertOverWork(OverWork overWork)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = overWork.Account.Id;
            cmd.Parameters.Add(_SubmitDate, SqlDbType.DateTime).Value = overWork.SubmitDate;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = overWork.FromDate;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = overWork.ToDate;
            cmd.Parameters.Add(_CostTime, SqlDbType.Decimal).Value = overWork.CostTime;
            cmd.Parameters.Add(_Reason, SqlDbType.Text).Value = overWork.Reason;
            cmd.Parameters.Add(_ProjectName, SqlDbType.NVarChar, 250).Value = overWork.ProjectName;
            cmd.Parameters.Add(_DiyProcess, SqlDbType.Text).Value =
                RequestUtility.DiyProcessToString(overWork.DiyProcess);
            SqlHelper.ExecuteNonQueryReturnPKID("OverWorkInsert", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// </summary>
        public int UpdateOverWork(OverWork overWork)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = overWork.PKID;
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = overWork.Account.Id;
            cmd.Parameters.Add(_SubmitDate, SqlDbType.DateTime).Value = overWork.SubmitDate;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = overWork.FromDate;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = overWork.ToDate;
            cmd.Parameters.Add(_CostTime, SqlDbType.Decimal).Value = overWork.CostTime;
            cmd.Parameters.Add(_Reason, SqlDbType.Text).Value = overWork.Reason;
            cmd.Parameters.Add(_ProjectName, SqlDbType.NVarChar, 250).Value = overWork.ProjectName;
            cmd.Parameters.Add(_DiyProcess, SqlDbType.Text).Value =
                RequestUtility.DiyProcessToString(overWork.DiyProcess);
            return SqlHelper.ExecuteNonQuery("OverWorkUpdate", cmd);
        }

        /// <summary>
        /// </summary>
        public OverWork GetOverWorkByOverWorkID(int pKID)
        {
            OverWork overwork = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pKID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOverWorkByOverWorkID", cmd))
            {
                while (sdr.Read())
                {
                    List<OverWorkItem> overWorkItem =
                        GetOverWorkItemByOverWorkID(Convert.ToInt32(sdr[_DbPKID]));
                    Account account = new Account();
                    account.Id = Convert.ToInt32(sdr[_DbAccountID]);
                    overwork =
                        new OverWork(pKID, account, Convert.ToDateTime(sdr[_DbSubmitDate]),
                                     sdr[_DbReason].ToString(), Convert.ToDateTime(sdr[_DbFrom]),
                                     Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                     overWorkItem, sdr[_DbProjectName].ToString());
                    overwork.DiyProcess = RequestUtility.GetDiyProcess(sdr[_DbDiyProcess].ToString());
                    break;
                }
            }
            return overwork;
        }

        /// <summary>
        /// </summary>
        public int DeleteOverWorkByPKID(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pkid;
            return SqlHelper.ExecuteNonQuery("OverWorkDelete", cmd);
        }

        /// <summary>
        /// </summary>
        public List<OverWork> GetAllOverWorkByAccountID(int accountID)
        {
            List<OverWork> overWorkList = new List<OverWork>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllOverWorkByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    Account account = new Account();
                    account.Id = Convert.ToInt32(sdr[_DbAccountID]);
                    OverWork overwork =
                        new OverWork(Convert.ToInt32(sdr[_DbPKID]), account,
                                     Convert.ToDateTime(sdr[_DbSubmitDate]),
                                     sdr[_DbReason].ToString(), Convert.ToDateTime(sdr[_DbFrom]),
                                     Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                     GetOverWorkItemByOverWorkID(Convert.ToInt32(sdr[_DbPKID])),
                                     sdr[_DbProjectName].ToString());
                    overWorkList.Add(overwork);
                }
            }
            return overWorkList;
        }

        /// <summary>
        /// </summary>
        public List<OverWork> GetNeedConfirmOverWork()
        {
            List<OverWork> iRet = new List<OverWork>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetNeedConfirmOverWork", cmd))
            {
                while (sdr.Read())
                {
                    Account account = new Account();
                    account.Id = Convert.ToInt32(sdr[_DbAccountID]);
                    OverWork overWork =
                        new OverWork(Convert.ToInt32(sdr[_DbPKID]), account,
                                     Convert.ToDateTime(sdr[_DbSubmitDate]),
                                     sdr[_DbReason].ToString(), Convert.ToDateTime(sdr[_DbFrom]),
                                     Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                     GetOverWorkItemByOverWorkID(Convert.ToInt32(sdr[_DbPKID])),
                                     sdr[_DbProjectName].ToString());
                    overWork.DiyProcess = RequestUtility.GetDiyProcess(sdr[_DbDiyProcess].ToString());
                    iRet.Add(overWork);
                }
                return iRet;
            }
        }

        /// <summary>
        /// </summary>
        public List<OverWork> GetConfirmHistroy(int accountID, DateTime fromTime, DateTime toTime)
        {
            List<OverWork> iRet = new List<OverWork>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_OperatorID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = fromTime;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = toTime;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOverWorkConfirmHistroy", cmd))
            {
                while (sdr.Read())
                {
                    Account account = new Account();
                    account.Id = Convert.ToInt32(sdr[_DbAccountID]);
                    OverWork overWork =
                        new OverWork(Convert.ToInt32(sdr[_DbPKID]), account,
                                     Convert.ToDateTime(sdr[_DbSubmitDate]),
                                     sdr[_DbReason].ToString(), Convert.ToDateTime(sdr[_DbFrom]),
                                     Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                     GetOverWorkItemByOverWorkID(Convert.ToInt32(sdr[_DbPKID])),
                                     sdr[_DbProjectName].ToString());
                    iRet.Add(overWork);
                }
                return iRet;
            }
        }

        #endregion

        #region item

        /// <summary>
        /// </summary>
        public int UpdateOverWorkItemStatusByItemID(int itemID, RequestStatus status)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = itemID;
            cmd.Parameters.Add(_Status, SqlDbType.Int).Value = status.Id;
            return SqlHelper.ExecuteNonQuery("UpdateOverWorkItemStatusByItemID", cmd);
        }

        /// <summary>
        /// </summary>
        public int UpdateOverWorkItemAdjustByItemID(int itemID, bool isAdjust,decimal adjustHour)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = itemID;
            cmd.Parameters.Add(_Adjust, SqlDbType.Int).Value = OverWorkItem.AdjustToInt(isAdjust);
            cmd.Parameters.Add(_AdjustHour, SqlDbType.Decimal).Value = adjustHour;
            return SqlHelper.ExecuteNonQuery("UpdateOverWorkItemAdjustByItemID", cmd);
        }

        /// <summary>
        /// </summary>
        public int InsertOverWorkItem(int overWorkID, OverWorkItem item)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_OverWorkID, SqlDbType.Int).Value = overWorkID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = item.FromDate;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = item.ToDate;
            cmd.Parameters.Add(_CostTime, SqlDbType.Decimal).Value = item.CostTime;
            cmd.Parameters.Add(_Status, SqlDbType.Int).Value = item.Status.Id;
            cmd.Parameters.Add(_Adjust, SqlDbType.Int).Value = OverWorkItem.AdjustToInt(item.Adjust);
            cmd.Parameters.Add(_AdjustHour, SqlDbType.Decimal).Value = item.AdjustHour;
            cmd.Parameters.Add(_OverWorkType, SqlDbType.Int).Value = item.OverWorkType;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertOverWorkItem", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// </summary>
        public List<OverWorkItem> GetOverWorkItemByOverWorkID(int overWorkID)
        {
            List<OverWorkItem> applicationList = new List<OverWorkItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_OverWorkID, SqlDbType.Int).Value = overWorkID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOverWorkItemByOverWorkID", cmd))
            {
                while (sdr.Read())
                {
                    OverWorkItem applicationItem =
                        new OverWorkItem(Convert.ToInt32(sdr[_DbPKID]), Convert.ToDateTime(sdr[_DbFrom]),
                                         Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                         RequestStatus.FindRequestStatus(Convert.ToInt32(sdr[_DbStatus])),
                                         (OverWorkType) sdr[_DbOverWorkType],
                                         OverWorkItem.IntToAdjust(Convert.ToInt32(sdr[_DbAdjust])), Convert.ToDecimal(sdr[_DbAdjustHour]));
                    applicationItem.OverWorkFlow = GetOverWorkFlowByItemID(Convert.ToInt32(sdr[_DbPKID]));
                    applicationList.Add(applicationItem);
                }
            }
            return applicationList;
        }

        /// <summary>
        /// </summary>
        public OverWorkItem GetOverWorkItemByItemID(int itemID)
        {
            OverWorkItem overworkItem = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = itemID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOverWorkItemByItemID", cmd))
            {
                while (sdr.Read())
                {
                    overworkItem =
                        new OverWorkItem(Convert.ToInt32(sdr[_DbPKID]), Convert.ToDateTime(sdr[_DbFrom]),
                                         Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                         RequestStatus.FindRequestStatus(Convert.ToInt32(sdr[_DbStatus])),
                                         (OverWorkType) sdr[_DbOverWorkType],
                                         OverWorkItem.IntToAdjust(Convert.ToInt32(sdr[_DbAdjust])), Convert.ToDecimal(sdr[_DbAdjustHour]));
                    overworkItem.OverWorkID = Convert.ToInt32(sdr[_DbOverWorkID]);
                    overworkItem.OverWorkFlow = GetOverWorkFlowByItemID(Convert.ToInt32(sdr[_DbPKID]));
                }
            }
            return overworkItem;
        }

        /// <summary>
        /// </summary>
        public int DeleteOverWorkItemByOverWorkID(int OverWorkID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_OverWorkID, SqlDbType.Int).Value = OverWorkID;
            return SqlHelper.ExecuteNonQuery("DeleteOverWorkItemByOverWorkID", cmd);
        }

        /// <summary>
        /// </summary>
        public int CountOverWorkInRepeatDateDiffPKID(int AccountID, int? OverWorkID, DateTime from, DateTime to)
        {
            int retVal = 0;
            SqlCommand cmd = new SqlCommand();
            if (OverWorkID == null)
            {
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = OverWorkID;
            }
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = AccountID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = to;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountOverWorkInRepeatDateDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    retVal = Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return retVal;
        }

        #endregion

        #region flow

        /// <summary>
        /// </summary>
        public int DeleteOverWorkFlowByItemID(int itemID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_OverWorkItemID, SqlDbType.Int).Value = itemID;
            return SqlHelper.ExecuteNonQuery("DeleteOverWorkFlowByItemID", cmd);
        }

        /// <summary>
        /// </summary>
        public int InsertOverWorkFlow(int OverWorkItemID, OverWorkFlow outFlow)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_OverWorkItemID, SqlDbType.Int).Value = OverWorkItemID;
            cmd.Parameters.Add(_OperatorID, SqlDbType.Int).Value = outFlow.Account.Id;
            cmd.Parameters.Add(_OperationTime, SqlDbType.DateTime).Value = outFlow.OperationTime;
            cmd.Parameters.Add(_Operation, SqlDbType.Int).Value = outFlow.Operation.Id;
            cmd.Parameters.Add(_Remark, SqlDbType.Text).Value = outFlow.Remark;
            cmd.Parameters.Add(_Step, SqlDbType.Int).Value = outFlow.Step;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertOverWorkFlow", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// </summary>
        private static List<OverWorkFlow> GetOverWorkFlowByItemID(int itemID)
        {
            List<OverWorkFlow> iRet = new List<OverWorkFlow>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_OverWorkItemID, SqlDbType.Int).Value = itemID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOverWorkFlowByItemID", cmd))
            {
                while (sdr.Read())
                {
                    Account account = new Account(Convert.ToInt32(sdr[_DbOperatorID]), "", "");
                    OverWorkFlow flow =
                        new OverWorkFlow(Convert.ToInt32(sdr[_DbPKID]), account,
                                         Convert.ToDateTime(sdr[_DbOperationTime]), sdr[_DbRemark].ToString(),
                                         RequestStatus.FindRequestStatus(Convert.ToInt32(sdr[_DbOperation])),
                                         Convert.ToInt32(sdr[_DbStep]));
                    iRet.Add(flow);
                }
                return iRet;
            }
        }

        #endregion

        #region  wyq 

        public List<OverWorkItem> GetOverWorkForCalendar(int accountID, DateTime from, DateTime to)
        {
            List<OverWorkItem> overWorkItemList = new List<OverWorkItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = to;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOverWorkForCalendar", cmd))
            {
                while (sdr.Read())
                {
                    OverWorkItem overworkItem =
                        new OverWorkItem(Convert.ToInt32(sdr[_DbPKID]), Convert.ToDateTime(sdr[_DbFrom]),
                                         Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                         RequestStatus.FindRequestStatus(Convert.ToInt32(sdr[_DbStatus])),
                                         (OverWorkType)sdr[_DbOverWorkType],
                                         OverWorkItem.IntToAdjust(Convert.ToInt32(sdr[_DbAdjust])), Convert.ToDecimal(sdr[_DbAdjustHour]));
                    overWorkItemList.Add(overworkItem);
                }
                return overWorkItemList;
            }
        }
        public List<OverWorkItem> GetAllOverWorkForCalendar(int accountID, DateTime from, DateTime to)
        {
            List<OverWorkItem> overWorkItemList = new List<OverWorkItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = to;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllOverWorkForCalendar", cmd))
            {
                while (sdr.Read())
                {
                    OverWorkItem overworkItem =
                        new OverWorkItem(Convert.ToInt32(sdr[_DbTOverWorkItemPKID]),
                                         Convert.ToDateTime(sdr[_DbTOverWorkItemFrom]),
                                         Convert.ToDateTime(sdr[_DbTOverWorkItemTo]),
                                         Convert.ToDecimal(sdr[_DbTOverWorkItemCostTime]),
                                         RequestStatus.FindRequestStatus(Convert.ToInt32(sdr[_DbTOverWorkItemStatus])),
                                         (OverWorkType)sdr[_DbTOverWorkItemOverWorkType],
                                         OverWorkItem.IntToAdjust(Convert.ToInt32(sdr[_DbTOverWorkItemAdjust])),
                                         Convert.ToDecimal(sdr[_DbTOverWorkItemAdjustHour]));
                    overworkItem.OverWorkID = Convert.ToInt32(sdr[_DbTOverWorkItemOverWorkID]); 
                    overWorkItemList.Add(overworkItem);
                }
                return overWorkItemList;
            }
        }
        public List<OverWork> GetOverWorkByAccountAndRelatedDate(int accountID, DateTime from, DateTime to)
        {
            List<OverWork> overWorkList = new List<OverWork>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = to;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllOverWorkForCalendar", cmd))
            {
                while (sdr.Read())
                {
                    OverWork overwork = OverWork.FindOverWorkByPKID(overWorkList, Convert.ToInt32(sdr[_DbPKID]));
                    if (overwork == null)
                    {
                        Account account = new Account();
                        account.Id = Convert.ToInt32(sdr[_DbAccountID]);
                        overwork =
                            new OverWork(Convert.ToInt32(sdr[_DbPKID]), account, Convert.ToDateTime(sdr[_DbSubmitDate]),
                                         sdr[_DbReason].ToString(), Convert.ToDateTime(sdr[_DbFrom]),
                                         Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                         new List<OverWorkItem>(), sdr[_DbProjectName].ToString());
                        overWorkList.Add(overwork);
                    }
                    OverWorkItem overworkItem =
                        new OverWorkItem(Convert.ToInt32(sdr[_DbTOverWorkItemPKID]),
                                         Convert.ToDateTime(sdr[_DbTOverWorkItemFrom]),
                                         Convert.ToDateTime(sdr[_DbTOverWorkItemTo]),
                                         Convert.ToDecimal(sdr[_DbTOverWorkItemCostTime]),
                                         RequestStatus.FindRequestStatus(Convert.ToInt32(sdr[_DbTOverWorkItemStatus])),
                                         (OverWorkType)sdr[_DbTOverWorkItemOverWorkType],
                                         OverWorkItem.IntToAdjust(Convert.ToInt32(sdr[_DbTOverWorkItemAdjust])),
                                         Convert.ToDecimal(sdr[_DbTOverWorkItemAdjustHour]));
                    overworkItem.OverWorkID = Convert.ToInt32(sdr[_DbTOverWorkItemOverWorkID]);
                    overwork.Item.Add(overworkItem);
                }
                return overWorkList;
            }
        }
        public List<OverWork> GetOverWorkDetailByEmployee(int accountID, DateTime date)
        {
            List<OverWork> overworkList=new List<OverWork>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_Date, SqlDbType.DateTime).Value = date;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOverWorkDetailByEmployee", cmd))
            {
                while (sdr.Read())
                {
                    OverWork overwork = GetOverWorkByOverWorkID(Convert.ToInt32(sdr[_DbPKID]));
                    overworkList.Add(overwork);
                }
            }
            return overworkList;
        }

        ///<summary>
        /// ≤È—Ø…Í«Î
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="formTime"></param>
        ///<param name="toTime"></param>
        ///<param name="status"></param>
        ///<returns></returns>
        public List<OverWork> GetOverWorkByCondition(int employeeID, DateTime formTime, DateTime toTime,
            RequestStatus status)
        {
            List<OverWork> overworkList = new List<OverWork>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = employeeID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = formTime;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = toTime;
            cmd.Parameters.Add(_Status, SqlDbType.Int).Value = status.Id;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOverWorkByCondition", cmd))
            {
                while (sdr.Read())
                {
                    OverWork overwork = GetOverWorkByOverWorkID(Convert.ToInt32(sdr[_DbPKID]));
                    overworkList.Add(overwork);
                }
            }
            return overworkList;
        }

        #endregion
    }
}