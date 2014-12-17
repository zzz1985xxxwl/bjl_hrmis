using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 
    /// </summary>
    public class OutApplicationDal : IOutApplication
    {
        private const string _PKID = "@PKID";
        private const string _AccountID = "@AccountID";
        private const string _SubmitDate = "@SubmitDate";
        private const string _From = "@From";
        private const string _To = "@To";
        private const string _CostTime = "@CostTime";
        private const string _Status = "@Status";
        private const string _Reason = "@Reason";
        private const string _OutLocation = "@OutLocation";
        private const string _OutType = "@OutType";
        private const string _DbPKID = "PKID";
        private const string _DbAccountID = "AccountID";
        private const string _DbSubmitDate = "SubmitDate";
        private const string _DbFrom = "From";
        private const string _DbTo = "To";
        private const string _DbCostTime = "CostTime";
        private const string _DbStatus = "Status";
        private const string _DbReason = "Reason";
        private const string _DbOutLocation = "OutLocation";
        private const string _DbOutType = "OutType";
        private const string _OutApplicationID = "@OutApplicationID";
        private const string _Step = "@Step";
        private const string _OperatorID = "@OperatorID";
        private const string _OperationTime = "@OperationTime";
        private const string _OutApplicationItemID = "@OutApplicationItemID";
        private const string _Operation = "@Operation";
        private const string _Remark = "@Remark";
        private const string _DbOperatorID = "OperatorID";
        private const string _DbOperationTime = "OperationTime";
        private const string _DbRemark = "Remark";
        private const string _DbOperation = "Operation";
        private const string _DbStep = "Step";
        private const string _DiyProcess = "@DiyProcess";
        private const string _DbDiyProcess = "DiyProcess";
        private const string _DbCount = "counts";
        private const string _Date = "@Date";
        private const string _DbOutApplicationID = "OutApplicationID";
        private const string _DbTOutApplicationItemPKID = "TOutApplicationItemPKID";
        private const string _DbTOutApplicationItemOutApplicationID = "TOutApplicationItemOutApplicationID";
        private const string _DbTOutApplicationItemStatus = "TOutApplicationItemStatus";
        private const string _DbTOutApplicationItemFrom = "TOutApplicationItemFrom";
        private const string _DbTOutApplicationItemTo = "TOutApplicationItemTo";
        private const string _DbTOutApplicationItemCostTime = "TOutApplicationItemCostTime";

        private const string _Adjust = "@Adjust";
        private const string _AdjustHour = "@AdjustHour";
        private const string _DbAdjust = "Adjust";
        private const string _DbAdjustHour = "AdjustHour";

        private const string _DbTOutApplicationItemAdjust = "TOutApplicationItemAdjust";
        private const string _DbTOutApplicationItemAdjustHour = "TOutApplicationItemAdjustHour";
        #region OutApplication

        /// <summary>
        /// </summary>
        public int InsertOutApplication(OutApplication outapplication)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = outapplication.Account.Id;
            cmd.Parameters.Add(_SubmitDate, SqlDbType.DateTime).Value = outapplication.SubmitDate;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = outapplication.FromDate;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = outapplication.ToDate;
            cmd.Parameters.Add(_CostTime, SqlDbType.Decimal).Value = outapplication.CostTime;
            cmd.Parameters.Add(_Reason, SqlDbType.Text).Value = outapplication.Reason;
            cmd.Parameters.Add(_OutLocation, SqlDbType.NVarChar, 250).Value = outapplication.OutLocation;
            cmd.Parameters.Add(_OutType, SqlDbType.Int).Value = outapplication.OutType.ID;
            cmd.Parameters.Add(_DiyProcess, SqlDbType.Text).Value =
                RequestUtility.DiyProcessToString(outapplication.DiyProcess);
            SqlHelper.ExecuteNonQueryReturnPKID("OutApplicationInsert", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// </summary>
        public int UpdateOutApplication(OutApplication outapplication)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = outapplication.PKID;
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = outapplication.Account.Id;
            cmd.Parameters.Add(_SubmitDate, SqlDbType.DateTime).Value = outapplication.SubmitDate;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = outapplication.FromDate;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = outapplication.ToDate;
            cmd.Parameters.Add(_CostTime, SqlDbType.Decimal).Value = outapplication.CostTime;
            cmd.Parameters.Add(_Reason, SqlDbType.Text).Value = outapplication.Reason;
            cmd.Parameters.Add(_OutLocation, SqlDbType.NVarChar, 250).Value = outapplication.OutLocation;
            cmd.Parameters.Add(_OutType, SqlDbType.Int).Value = outapplication.OutType.ID;
            cmd.Parameters.Add(_DiyProcess, SqlDbType.Text).Value =
                RequestUtility.DiyProcessToString(outapplication.DiyProcess);
            return SqlHelper.ExecuteNonQuery("OutApplicationUpdate", cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        public OutApplication GetOutApplicationByOutApplicationID(int pKID)
        {
            OutApplication application = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pKID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOutApplicationByOutApplicationID", cmd))
            {
                while (sdr.Read())
                {
                    List<OutApplicationItem> applicationItem =
                        GetOutApplicationItemByOutApplicationID(Convert.ToInt32(sdr[_DbPKID]));
                    Account account = new Account();
                    account.Id = Convert.ToInt32(sdr[_DbAccountID]);
                    application =
                        new OutApplication(pKID, account, Convert.ToDateTime(sdr[_DbSubmitDate]),
                                           sdr[_DbReason].ToString(), Convert.ToDateTime(sdr[_DbFrom]),
                                           Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                           applicationItem, sdr[_DbOutLocation].ToString(),
                                           OutType.GetOutTypeByID(Convert.ToInt32(sdr[_DbOutType])));
                    application.DiyProcess = RequestUtility.GetDiyProcess(sdr[_DbDiyProcess].ToString());
                    break;
                }
            }
            return application;
        }

        /// <summary>
        /// </summary>
        public List<OutApplication> GetAllOutApplicationByAccountID(int accountID)
        {
            List<OutApplication> applicationList = new List<OutApplication>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllOutApplicationByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    Account account = new Account();
                    account.Id = Convert.ToInt32(sdr[_DbAccountID]);
                    OutApplication application =
                        new OutApplication(Convert.ToInt32(sdr[_DbPKID]), account,
                                           Convert.ToDateTime(sdr[_DbSubmitDate]),
                                           sdr[_DbReason].ToString(), Convert.ToDateTime(sdr[_DbFrom]),
                                           Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                           GetOutApplicationItemByOutApplicationID(Convert.ToInt32(sdr[_DbPKID])),
                                           sdr[_DbOutLocation].ToString(),
                                           OutType.GetOutTypeByID(Convert.ToInt32(sdr[_DbOutType])));
                    applicationList.Add(application);
                }
            }
            return applicationList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pKID"></param>
        /// <returns></returns>
        public int DeleteOutApplicationByPKID(int pKID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pKID;
            return SqlHelper.ExecuteNonQuery("OutApplicationDelete", cmd);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="outApplicationID"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int CountOutApplicationInRepeatDateDiffPKID(int AccountID, int? outApplicationID, DateTime from,
                                                           DateTime to)
        {
            int retVal = 0;
            SqlCommand cmd = new SqlCommand();
            if (outApplicationID == null)
            {
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = outApplicationID;
            }
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = AccountID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = to;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountOutApplicationInRepeatDateDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    retVal = Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return retVal;
        }

        /// <summary>
        /// 得到所有待审核的请假单
        /// </summary>
        /// <returns></returns>
        public List<OutApplication> GetNeedConfirmOutApplication()
        {
            List<OutApplication> iRet = new List<OutApplication>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetNeedConfirmOutApplication", cmd))
            {
                while (sdr.Read())
                {
                    Account account = new Account();
                    account.Id = Convert.ToInt32(sdr[_DbAccountID]);
                    OutApplication application =
                        new OutApplication(Convert.ToInt32(sdr[_DbPKID]), account,
                                           Convert.ToDateTime(sdr[_DbSubmitDate]),
                                           sdr[_DbReason].ToString(), Convert.ToDateTime(sdr[_DbFrom]),
                                           Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                           GetOutApplicationItemByOutApplicationID(Convert.ToInt32(sdr[_DbPKID])),
                                           sdr[_DbOutLocation].ToString(),
                                           OutType.GetOutTypeByID(Convert.ToInt32(sdr[_DbOutType])));
                    application.DiyProcess = RequestUtility.GetDiyProcess(sdr[_DbDiyProcess].ToString());
                    iRet.Add(application);
                }
                return iRet;
            }
        }

        public List<OutApplication> GetConfirmHistroy(int accountID, DateTime fromTime, DateTime toTime)
        {
            List<OutApplication> iRet = new List<OutApplication>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_OperatorID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = fromTime;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = toTime;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOutConfirmHistroy", cmd))
            {
                while (sdr.Read())
                {
                    Account account = new Account();
                    account.Id = Convert.ToInt32(sdr[_DbAccountID]);
                    OutApplication application =
                        new OutApplication(Convert.ToInt32(sdr[_DbPKID]), account,
                                           Convert.ToDateTime(sdr[_DbSubmitDate]),
                                           sdr[_DbReason].ToString(), Convert.ToDateTime(sdr[_DbFrom]),
                                           Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                           GetOutApplicationItemByOutApplicationID(Convert.ToInt32(sdr[_DbPKID])),
                                           sdr[_DbOutLocation].ToString(),
                                           OutType.GetOutTypeByID(Convert.ToInt32(sdr[_DbOutType])));
                    iRet.Add(application);
                }
                return iRet;
            }
        }

        public int UpdateOutApplicationItemAdjustByItemID(int itemID, bool isAdjust, decimal adjustHour)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = itemID;
            cmd.Parameters.Add(_Adjust, SqlDbType.Int).Value = OverWorkItem.AdjustToInt(isAdjust);
            cmd.Parameters.Add(_AdjustHour, SqlDbType.Decimal).Value = adjustHour;
            return SqlHelper.ExecuteNonQuery("UpdateOutApplicationItemAdjustByItemID", cmd);
        }

        ///<summary>
        /// 查询申请
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="formTime"></param>
        ///<param name="toTime"></param>
        ///<param name="status"></param>
        ///<returns></returns>

        #endregion

        #region item

        /// <summary>
        /// </summary>
        public int InsertOutApplicationItem(int applicationID, OutApplicationItem item)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_OutApplicationID, SqlDbType.Int).Value = applicationID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = item.FromDate;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = item.ToDate;
            cmd.Parameters.Add(_CostTime, SqlDbType.Decimal).Value = item.CostTime;
            cmd.Parameters.Add(_Status, SqlDbType.Int).Value = item.Status.Id;
            cmd.Parameters.Add(_Adjust, SqlDbType.Int).Value = OverWorkItem.AdjustToInt(item.Adjust);
            cmd.Parameters.Add(_AdjustHour, SqlDbType.Decimal).Value = item.AdjustHour;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertOutApplicationItem", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// </summary>
        public int UpdateOutApplicationItem(int applicationID, OutApplicationItem item)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = item.ItemID;
            cmd.Parameters.Add(_OutApplicationID, SqlDbType.Int).Value = applicationID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = item.FromDate;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = item.ToDate;
            cmd.Parameters.Add(_CostTime, SqlDbType.Decimal).Value = item.CostTime;
            cmd.Parameters.Add(_Status, SqlDbType.Int).Value = item.Status.Id;
            cmd.Parameters.Add(_Adjust, SqlDbType.Int).Value = OverWorkItem.AdjustToInt(item.Adjust);
            cmd.Parameters.Add(_AdjustHour, SqlDbType.Decimal).Value = item.AdjustHour;
            return SqlHelper.ExecuteNonQuery("UpdateOutApplicationItem", cmd);
        }

        /// <summary>
        /// </summary>
        public int DeleteOutApplicationItem(int outApplicationItemID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_OutApplicationItemID, SqlDbType.Int).Value = outApplicationItemID;
            return SqlHelper.ExecuteNonQuery("DeleteOutApplicationItem", cmd);
        }

        /// <summary>
        /// </summary>
        public int DeleteOutApplicationItemByOutApplicationID(int applicationID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_OutApplicationID, SqlDbType.Int).Value = applicationID;
            return SqlHelper.ExecuteNonQuery("DeleteOutApplicationItemByOutApplicationID", cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        public List<OutApplicationItem> GetOutApplicationItemByOutApplicationID(int applicationID)
        {
            List<OutApplicationItem> applicationList = new List<OutApplicationItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_OutApplicationID, SqlDbType.Int).Value = applicationID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOutApplicationItemByOutApplicationID", cmd))
            {
                while (sdr.Read())
                {
                    OutApplicationItem applicationItem =
                        new OutApplicationItem(Convert.ToInt32(sdr[_DbPKID]), Convert.ToDateTime(sdr[_DbFrom]),
                                               Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                               RequestStatus.FindRequestStatus(Convert.ToInt32(sdr[_DbStatus])),
                                               OverWorkItem.IntToAdjust(Convert.ToInt32(sdr[_DbAdjust])),
                                               Convert.ToDecimal(sdr[_DbAdjustHour]));
                    applicationItem.OutApplicationFlow = GetOutApplicationFlowByItemID(Convert.ToInt32(sdr[_DbPKID]));
                    applicationList.Add(applicationItem);
                }
            }
            return applicationList;
        }

        /// <summary>
        /// 
        /// </summary>
        public OutApplicationItem GetOutApplicationItemByItemID(int itemID)
        {
            OutApplicationItem applicationItem = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = itemID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOutApplicationItemByItemID", cmd))
            {
                while (sdr.Read())
                {
                    applicationItem =
                        new OutApplicationItem(Convert.ToInt32(sdr[_DbPKID]), Convert.ToDateTime(sdr[_DbFrom]),
                                               Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                               RequestStatus.FindRequestStatus(Convert.ToInt32(sdr[_DbStatus])),
                                               OverWorkItem.IntToAdjust(Convert.ToInt32(sdr[_DbAdjust])),
                                               Convert.ToDecimal(sdr[_DbAdjustHour]));
                    applicationItem.OutApplicationID = Convert.ToInt32(sdr[_DbOutApplicationID]);
                    applicationItem.OutApplicationFlow = GetOutApplicationFlowByItemID(Convert.ToInt32(sdr[_DbPKID]));
                }
            }
            return applicationItem;
        }

        /// <summary>
        /// </summary>
        public int UpdateOutApplicationItemStatusByItemID(int itemID, RequestStatus status)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = itemID;
            cmd.Parameters.Add(_Status, SqlDbType.Int).Value = status.Id;
            return SqlHelper.ExecuteNonQuery("UpdateOutApplicationItemStatusByItemID", cmd);
        }

        #endregion

        #region flow

        /// <summary>
        /// 
        /// </summary>
        public int InsertOutApplicationFlow(int outApplicationItemID, OutApplicationFlow outFlow)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_OutApplicationItemID, SqlDbType.Int).Value = outApplicationItemID;
            cmd.Parameters.Add(_OperatorID, SqlDbType.Int).Value = outFlow.Account.Id;
            cmd.Parameters.Add(_OperationTime, SqlDbType.DateTime).Value = outFlow.OperationTime;
            cmd.Parameters.Add(_Operation, SqlDbType.Int).Value = outFlow.Operation.Id;
            cmd.Parameters.Add(_Remark, SqlDbType.Text).Value = outFlow.Remark;
            cmd.Parameters.Add(_Step, SqlDbType.Int).Value = outFlow.Step;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertOutApplicationFlow", cmd, out pkid);
            return pkid;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static List<OutApplicationFlow> GetOutApplicationFlowByItemID(int itemID)
        {
            List<OutApplicationFlow> iRet = new List<OutApplicationFlow>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_OutApplicationItemID, SqlDbType.Int).Value = itemID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOutApplicationFlowByItemID", cmd))
            {
                while (sdr.Read())
                {
                    Account account = new Account(Convert.ToInt32(sdr[_DbOperatorID]), "", "");
                    OutApplicationFlow flow =
                        new OutApplicationFlow(Convert.ToInt32(sdr[_DbPKID]), account,
                                               Convert.ToDateTime(sdr[_DbOperationTime]), sdr[_DbRemark].ToString(),
                                               RequestStatus.FindRequestStatus(Convert.ToInt32(sdr[_DbOperation])),
                                               Convert.ToInt32(sdr[_DbStep]));
                    iRet.Add(flow);
                }
                return iRet;
            }
        }

        /// <summary>
        /// </summary>
        public int DeleteOutApplicationFlowByItemID(int itemID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_OutApplicationItemID, SqlDbType.Int).Value = itemID;
            return SqlHelper.ExecuteNonQuery("DeleteOutApplicationFlowByItemID", cmd);
        }

        #endregion

        #region  wyq 

        /// <summary>
        /// 
        /// </summary>
        public List<OutApplicationItem> GetOutApplicationForCalendar(int accountID, DateTime from, DateTime to)
        {
            List<OutApplicationItem> outApplicationItemList = new List<OutApplicationItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = to;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOutApplicationForCalendar", cmd))
            {
                while (sdr.Read())
                {
                    OutApplicationItem applicationItem =
                        new OutApplicationItem(Convert.ToInt32(sdr[_DbPKID]), Convert.ToDateTime(sdr[_DbFrom]),
                                               Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                               RequestStatus.FindRequestStatus(Convert.ToInt32(sdr[_DbStatus])),
                                               OverWorkItem.IntToAdjust(Convert.ToInt32(sdr[_DbAdjust])),
                                               Convert.ToDecimal(sdr[_DbAdjustHour]));
                    outApplicationItemList.Add(applicationItem);
                }
                return outApplicationItemList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<OutApplicationItem> GetAllOutApplicationForCalendar(int accountID, DateTime from, DateTime to)
        {
            List<OutApplicationItem> outApplicationItemList = new List<OutApplicationItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = to;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllOutApplicationForCalendar", cmd))
            {
                while (sdr.Read())
                {
                    OutApplicationItem applicationItem =
                        new OutApplicationItem(Convert.ToInt32(sdr[_DbTOutApplicationItemPKID]),
                                               Convert.ToDateTime(sdr[_DbTOutApplicationItemFrom]),
                                               Convert.ToDateTime(sdr[_DbTOutApplicationItemTo]),
                                               Convert.ToDecimal(sdr[_DbTOutApplicationItemCostTime]),
                                               RequestStatus.FindRequestStatus(
                                                   Convert.ToInt32(sdr[_DbTOutApplicationItemStatus])),
                                               OverWorkItem.IntToAdjust(Convert.ToInt32(sdr[_DbTOutApplicationItemAdjust])),
                                               Convert.ToDecimal(sdr[_DbTOutApplicationItemAdjustHour]));
                    applicationItem.OutApplicationID = Convert.ToInt32(sdr[_DbTOutApplicationItemOutApplicationID]);
                    outApplicationItemList.Add(applicationItem);
                }
                return outApplicationItemList;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public List<OutApplication> GetOutApplicationByAccountAndRelatedDate(int accountID, DateTime from, DateTime to)
        {
            List<OutApplication> outApplicationList = new List<OutApplication>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = to;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllOutApplicationForCalendar", cmd))
            {
                while (sdr.Read())
                {
                    OutApplication outApplication =
                        OutApplication.FindOverWorkByPKID(outApplicationList, Convert.ToInt32(sdr[_DbPKID]));
                    if (outApplication == null)
                    {
                        Account account = new Account();
                        account.Id = Convert.ToInt32(sdr[_DbAccountID]);
                        outApplication =
                            new OutApplication(Convert.ToInt32(sdr[_DbPKID]), account,
                                               Convert.ToDateTime(sdr[_DbSubmitDate]),
                                               sdr[_DbReason].ToString(), Convert.ToDateTime(sdr[_DbFrom]),
                                               Convert.ToDateTime(sdr[_DbTo]), Convert.ToDecimal(sdr[_DbCostTime]),
                                               new List<OutApplicationItem>(),
                                               sdr[_DbOutLocation].ToString(),
                                               OutType.GetOutTypeByID(Convert.ToInt32(sdr[_DbOutType])));
                        outApplicationList.Add(outApplication);
                    }

                    OutApplicationItem applicationItem =
                        new OutApplicationItem(Convert.ToInt32(sdr[_DbTOutApplicationItemPKID]),
                                               Convert.ToDateTime(sdr[_DbTOutApplicationItemFrom]),
                                               Convert.ToDateTime(sdr[_DbTOutApplicationItemTo]),
                                               Convert.ToDecimal(sdr[_DbTOutApplicationItemCostTime]),
                                               RequestStatus.FindRequestStatus(
                                                   Convert.ToInt32(sdr[_DbTOutApplicationItemStatus])),
                                               OverWorkItem.IntToAdjust(Convert.ToInt32(sdr[_DbTOutApplicationItemAdjust])),
                                               Convert.ToDecimal(sdr[_DbTOutApplicationItemAdjustHour]));
                    applicationItem.OutApplicationID = Convert.ToInt32(sdr[_DbTOutApplicationItemOutApplicationID]);
                    outApplication.Item.Add(applicationItem);
                }
                return outApplicationList;
            }
        }

        public List<OutApplication> GetOutApplicationDetailByEmployee(int accountID, DateTime date)
        {
            List<OutApplication> applicationList = new List<OutApplication>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_Date, SqlDbType.DateTime).Value = date;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOutApplicationDetailByEmployee", cmd))
            {
                while (sdr.Read())
                {
                    OutApplication application = GetOutApplicationByOutApplicationID(Convert.ToInt32(sdr[_DbPKID]));
                    applicationList.Add(application);
                }
            }
            return applicationList;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<OutApplication> GetOutApplicationByCondition(int employeeID, DateTime formTime, DateTime toTime,
                                                                 RequestStatus status, OutType type)
        {
            List<OutApplication> applicationList = new List<OutApplication>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = employeeID;
            cmd.Parameters.Add(_From, SqlDbType.DateTime).Value = formTime;
            cmd.Parameters.Add(_To, SqlDbType.DateTime).Value = toTime;
            cmd.Parameters.Add(_Status, SqlDbType.Int).Value = status.Id;
            cmd.Parameters.Add(_OutType, SqlDbType.Int).Value = type.ID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetOutApplicationByCondition", cmd))
            {
                while (sdr.Read())
                {
                    OutApplication application = GetOutApplicationByOutApplicationID(Convert.ToInt32(sdr[_DbPKID]));
                    applicationList.Add(application);
                }
            }
            return applicationList;
        }

        #endregion
    }
}