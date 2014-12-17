using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 实现ILeaveRequestDal接口中的方法
    /// </summary>
    public class LeaveRequestDal : ILeaveRequestDal
    {
        #region 私有变量

        private const string _ParmPKID = "@PKID";
        private const string _ParmLeaveRequestID = "@LeaveRequestID";
        private const string _ParmAccountID = "@AccountID";
        private const string _ParmSubmitDate = "@SubmitDate";
        private const string _ParmFromDate = "@AbsentFrom";
        private const string _ParmToDate = "@AbsentTo";
        private const string _ParmAbsentHours = "@AbsentHours";
        private const string _ParmReason = "@Reason";
        private const string _ParmDiyProcess = "@DiyProcess";
        private const string _ParmLeaveRequestStatus = "@Status";
        private const string _ParmLeaveRequestTypeID = "@LeaveRequestTypeID";
        private const string _ParmFrom = "@From";
        private const string _ParmTo = "@To";
        private const string _ParmLeaveRequestItemID = "@LeaveRequestItemID";
        private const string _ParmOperatorID = "@OperatorID";
        private const string _ParmNextProcessID = "@NextProcessID";
        private const string _ParmDate = "@Date";
        private const string _ParmUseList = "@UseList";

        private const string _DBPKID = "PKID";
        private const string _DBAccountID = "AccountID";
        private const string _DBSubmitDate = "SubmitDate";
        private const string _DBFromDate = "AbsentFrom";
        private const string _DBToDate = "AbsentTo";
        private const string _DBAbsentHours = "AbsentHours";
        private const string _DBReason = "Reason";
        private const string _DBLeaveRequestTypeID = "LeaveRequestTypeID";
        private const string _DBLeaveRequestTypeName = "LeaveRequestTypeName";
        private const string _DBLeaveRequestTypeLeastHour = "LeaveRequestTypeLeastHour";
        private const string _DBLeaveRequestTypeDescription = "LeaveRequestTypeDescription";
        private const string _DBLeaveRequestTypeIncludeNationalHolidays = "LeaveRequestTypeIncludeNationalHolidays";
        private const string _DBLeaveRequestTypeIncludeRestDay = "LeaveRequestTypeIncludeRestDay";
        private const string _DBLeaveRequestStatus = "Status";
        private const string _DBAbsenceTypeName = "AbsenceTypeName";
        private const string _DBLeastHour = "LeastHour";
        private const string _DBCostTime = "AbsentHours";
        private const string _DBCount = "counts";
        private const string _DbTotalHout = "TotalHour";
        private const string _DbDiyProcess = "DiyProcess";
        private const string _DBNextProcessID = "NextProcessID";
        private const string _DBLeaveRequestID = "LeaveRequestID";
        private const string _DBUseList = "UseList";
        #endregion

        /// <summary>
        /// 新增请假
        /// </summary>
        /// <param name="leaveRequest"></param>
        /// <param name="nextStepID"></param>
        /// <returns></returns>
        public int InsertLeaveRequest(LeaveRequest leaveRequest, int nextStepID)
        {
            SqlConnection _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            SqlTransaction _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
            int pkid;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmAccountID, SqlDbType.NVarChar, 50).Value = leaveRequest.Account.Id;
                cmd.Parameters.Add(_ParmSubmitDate, SqlDbType.DateTime).Value = leaveRequest.SubmitDate;
                cmd.Parameters.Add(_ParmReason, SqlDbType.Text).Value = leaveRequest.Reason;
                cmd.Parameters.Add(_ParmAbsentHours, SqlDbType.Decimal).Value = leaveRequest.CostTime;
                cmd.Parameters.Add(_ParmFromDate, SqlDbType.DateTime).Value = leaveRequest.FromDate;
                cmd.Parameters.Add(_ParmToDate, SqlDbType.DateTime).Value = leaveRequest.ToDate;
                cmd.Parameters.Add(_ParmLeaveRequestTypeID, SqlDbType.Int).Value =
                    leaveRequest.LeaveRequestType.LeaveRequestTypeID;
                string diyProcess = "";
                if (leaveRequest.DiyProcess != null && leaveRequest.DiyProcess.DiySteps != null)
                {
                    foreach (DiyStep step in leaveRequest.DiyProcess.DiySteps)
                    {
                        diyProcess += step.DiyStepID + "|" + step.Status + "|" + step.OperatorType.Id + "|" +
                                      step.OperatorID + "|";

                        foreach (Account account in step.MailAccount)
                        {
                            diyProcess += account.Id + ",";
                        }

                        diyProcess += ";";
                    }
                }
                if (diyProcess.Length > 0)
                {
                    diyProcess = diyProcess.Substring(0, diyProcess.Length - 1);
                }
                cmd.Parameters.Add(_ParmDiyProcess, SqlDbType.Text).Value = diyProcess;
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQueryReturnPKID("InsertLeaveRequest", cmd, out pkid);
                //循环新增每一个项
                for (int i = 0; i < leaveRequest.LeaveRequestItems.Count; i++)
                {
                    InsertLeaveRequestItem(pkid, leaveRequest.LeaveRequestItems[i], nextStepID, _Conn, _Trans);
                }
                _Trans.Commit();
            }
            catch
            {
                _Trans.Rollback();
                throw;
            }
            finally
            {
                _Conn.Close();
            }

            return pkid;
        }

        /// <summary>
        /// 新增请假项
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="item"></param>
        /// <param name="nextProcessID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        private static void InsertLeaveRequestItem(int leaveRequestID, LeaveRequestItem item, int nextProcessID, SqlConnection conn,
                                                   SqlTransaction trans)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmLeaveRequestID, SqlDbType.Int).Value = leaveRequestID;
            cmd.Parameters.Add(_ParmFromDate, SqlDbType.DateTime).Value = item.FromDate;
            cmd.Parameters.Add(_ParmToDate, SqlDbType.DateTime).Value = item.ToDate;
            cmd.Parameters.Add(_ParmAbsentHours, SqlDbType.Decimal).Value = item.CostTime;
            cmd.Parameters.Add(_ParmLeaveRequestStatus, SqlDbType.Int).Value = item.Status.Id;
            cmd.Parameters.Add(_ParmNextProcessID, SqlDbType.Int).Value = nextProcessID;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlHelper.TransExecuteNonQueryReturnPKID("InsertLeaveRequestItem", cmd, conn, trans, out pkid);
        }

        /// <summary>
        /// 修改请假
        /// </summary>
        /// <param name="leaveRequest"></param>
        /// <param name="nextStepID"></param>
        /// <returns></returns>
        public int UpdateLeaveRequest(LeaveRequest leaveRequest, int nextStepID)
        {
            int iRet;
            SqlConnection _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            SqlTransaction _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmLeaveRequestID, SqlDbType.Int).Value = leaveRequest.PKID;
                SqlHelper.ExecuteNonQuery("DeleteLeaveRequestItemByLeaveRequestID", cmd);

                cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmPKID, SqlDbType.NVarChar, 50).Value = leaveRequest.PKID;
                cmd.Parameters.Add(_ParmAccountID, SqlDbType.NVarChar, 50).Value = leaveRequest.Account.Id;
                cmd.Parameters.Add(_ParmSubmitDate, SqlDbType.DateTime).Value = leaveRequest.SubmitDate;
                cmd.Parameters.Add(_ParmReason, SqlDbType.Text).Value = leaveRequest.Reason;
                cmd.Parameters.Add(_ParmAbsentHours, SqlDbType.Decimal).Value = leaveRequest.CostTime;
                cmd.Parameters.Add(_ParmFromDate, SqlDbType.DateTime).Value = leaveRequest.FromDate;
                cmd.Parameters.Add(_ParmToDate, SqlDbType.DateTime).Value = leaveRequest.ToDate;
                cmd.Parameters.Add(_ParmLeaveRequestTypeID, SqlDbType.Int).Value =
                    leaveRequest.LeaveRequestType.LeaveRequestTypeID;
                
                iRet = SqlHelper.ExecuteNonQuery("UpdateLeaveRequest", cmd);

                //循环修改每一个项
                for (int i = 0; i < leaveRequest.LeaveRequestItems.Count; i++)
                {
                    InsertLeaveRequestItem(leaveRequest.PKID, leaveRequest.LeaveRequestItems[i], nextStepID, _Conn, _Trans);
                }
                _Trans.Commit();
            }
            catch
            {
                _Trans.Rollback();
                throw;
            }
            finally
            {
                _Conn.Close();
            }

            return iRet;
        }

        ///// <summary>
        ///// 修改请假项
        ///// </summary>
        ///// <param name="item"></param>
        //private static void UpdateLeaveRequestItem(LeaveRequestItem item)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = item.LeaveRequestItemID;
        //    cmd.Parameters.Add(_ParmFromDate, SqlDbType.DateTime).Value = item.FromDate;
        //    cmd.Parameters.Add(_ParmToDate, SqlDbType.DateTime).Value = item.ToDate;
        //    cmd.Parameters.Add(_ParmAbsentHours, SqlDbType.Decimal).Value = item.CostTime;
        //    cmd.Parameters.Add(_ParmLeaveRequestStatus, SqlDbType.Int).Value = item.Status.Id;
        //    SqlHelper.ExecuteNonQuery("UpdateLeaveRequestItem", cmd);
        //}

        /// <summary>
        /// 删除请假
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        public int DeleteLeaveRequest(int leaveRequestID)
        {
            SqlConnection _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            SqlTransaction _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
            int iRet;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = leaveRequestID;
                iRet = SqlHelper.ExecuteNonQuery("DeleteLeaveRequest", cmd);

                cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmLeaveRequestID, SqlDbType.Int).Value = leaveRequestID;
                SqlHelper.ExecuteNonQuery("DeleteLeaveRequestItemByLeaveRequestID", cmd);
                _Trans.Commit();
            }
            catch
            {
                _Trans.Rollback();
                throw;
            }
            finally
            {
                _Conn.Close();
            }
            return iRet;
        }

        /// <summary>
        /// 根据ID获得请假
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        public LeaveRequest GetLeaveRequestByPKID(int leaveRequestID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = leaveRequestID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestByPKID", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequest leaveRequest = new LeaveRequest();
                    leaveRequest.PKID = leaveRequestID;
                    leaveRequest.Account = new Account((int)sdr[_DBAccountID], "", "");
                    leaveRequest.FromDate = (DateTime)sdr[_DBFromDate];
                    leaveRequest.ToDate = (DateTime)sdr[_DBToDate];
                    leaveRequest.CostTime = (decimal)sdr[_DBAbsentHours];
                    leaveRequest.LeaveRequestType =
                        new LeaveRequestType(Convert.ToInt32(sdr[_DBLeaveRequestTypeID]),
                                             sdr[_DBAbsenceTypeName].ToString(),
                                             sdr[_DBLeaveRequestTypeDescription].ToString(),
                                             ((LegalHoliday)sdr[_DBLeaveRequestTypeIncludeNationalHolidays]),
                                             ((RestDay)sdr[_DBLeaveRequestTypeIncludeRestDay]),
                                             Convert.ToInt32(sdr[_DBLeastHour]));
                    leaveRequest.SubmitDate = Convert.ToDateTime(sdr[_DBSubmitDate]);
                    leaveRequest.Reason = sdr[_DBReason].ToString();

                    List<DiyStep> diyStepList = new List<DiyStep>();
                    string diyProcess = sdr[_DbDiyProcess].ToString();
                    string[] diySteps = diyProcess.Split(';');
                    foreach (string diyStep in diySteps)
                    {
                        string[] steps = diyStep.Split('|');
                        if (steps.Length > 4)
                        {
                            DiyStep step =
                                new DiyStep(Convert.ToInt32(steps[0]), steps[1],
                                            new OperatorType(Convert.ToInt32(steps[2]),
                                                             OperatorType.FindOperatorTypeByID(Convert.ToInt32(steps[2]))),
                                            Convert.ToInt32(steps[3]));

                            string[] mailAccounts = steps[4].Split(',');
                            foreach (string mailAccount in mailAccounts)
                            {
                                if (!string.IsNullOrEmpty(mailAccount))
                                {
                                    step.MailAccount.Add(new Account(Convert.ToInt32(mailAccount), "", ""));
                                }
                            }

                            diyStepList.Add(step);
                        }
                    }

                    leaveRequest.DiyProcess = new DiyProcess();
                    leaveRequest.DiyProcess.DiySteps = diyStepList;
                    leaveRequest.LeaveRequestItems = GetLeaveRequestItemByLeaveRequestID(leaveRequestID, leaveRequest.DiyProcess);
                    return leaveRequest;
                }
                return null;
            }
        }

        /// <summary>
        /// 通过帐号ID查找相关的帐套项
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="diyProcess"></param>
        /// <returns></returns>
        private static List<LeaveRequestItem> GetLeaveRequestItemByLeaveRequestID(int leaveRequestID, DiyProcess diyProcess)
        {
            List<LeaveRequestItem> leaveRequestItemList = new List<LeaveRequestItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmLeaveRequestID, SqlDbType.Int).Value = leaveRequestID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestItemByLeaveRequestID", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequestItem leaveRequestItem =
                        new LeaveRequestItem((int)sdr[_DBPKID], Convert.ToDateTime(sdr[_DBFromDate]),
                                             Convert.ToDateTime(sdr[_DBToDate]), Convert.ToDecimal(sdr[_DBAbsentHours]),
                                             RequestStatus.FindRequestStatus((int)sdr[_DBLeaveRequestStatus]));
                    leaveRequestItem.UseList = sdr[_DBUseList].ToString();

                    if (diyProcess != null)
                    {
                        leaveRequestItem.CurrentStep = diyProcess.FindStep((int)sdr[_DBNextProcessID]);
                    }

                    leaveRequestItemList.Add(leaveRequestItem);
                }
            }
            return leaveRequestItemList;
        }

        /// <summary>
        /// 根据账号获得请假
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<LeaveRequest> GetLeaveRequestByAccountID(int accountID)
        {
            List<LeaveRequest> LeaveRequestList = new List<LeaveRequest>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequest leaveRequest = new LeaveRequest();
                    leaveRequest.PKID = Convert.ToInt32(sdr[_DBPKID]);
                    leaveRequest.Reason = sdr[_DBReason].ToString();
                    leaveRequest.SubmitDate = (DateTime)sdr[_DBSubmitDate];
                    leaveRequest.Account = new Account((int)sdr[_DBAccountID], "", "");
                    leaveRequest.FromDate = (DateTime)sdr[_DBFromDate];
                    leaveRequest.ToDate = (DateTime)sdr[_DBToDate];
                    leaveRequest.CostTime = Convert.ToDecimal(sdr[_DBCostTime]);
                    LegalHoliday legalHoliday;
                    if ((int)sdr[_DBLeaveRequestTypeIncludeNationalHolidays] == 0)
                    {
                        legalHoliday = LegalHoliday.UnInclude;
                    }
                    else
                    {
                        legalHoliday = LegalHoliday.Include;
                    }
                    RestDay restDay;
                    if ((int)sdr[_DBLeaveRequestTypeIncludeRestDay] == 0)
                    {
                        restDay = RestDay.UnInclude;
                    }
                    else
                    {
                        restDay = RestDay.Include;
                    }
                    leaveRequest.LeaveRequestType =
                        new LeaveRequestType((int)sdr[_DBLeaveRequestTypeID], sdr[_DBLeaveRequestTypeName].ToString(),
                                             sdr[_DBLeaveRequestTypeDescription].ToString(),
                                             legalHoliday,restDay,
                                             (decimal)sdr[_DBLeaveRequestTypeLeastHour]);
                    leaveRequest.LeaveRequestItems = GetLeaveRequestItemByLeaveRequestID(leaveRequest.PKID, null);
                    LeaveRequestList.Add(leaveRequest);
                }
            }
            return LeaveRequestList;
        }

        public int CountLeaveRequestByLeaveRequestTypeID(int leaveRequestTypeID)
        {
            int retVal = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmLeaveRequestTypeID, SqlDbType.Int).Value = leaveRequestTypeID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountLeaveRequestByLeaveRequestTypeID", cmd))
            {
                while (sdr.Read())
                {
                    retVal = Convert.ToInt32(sdr[_DBCount]);
                }
            }
            return retVal;
        }

        /// <summary>
        /// 查找重复时间内的其他请假
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="LeaveRequestID"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int CountLeaveRequestInRepeatDateDiffPKID(int AccountID, int? LeaveRequestID, DateTime from,
                                                                      DateTime to)
        {
            int retVal = 0;
            SqlCommand cmd = new SqlCommand();
            if (LeaveRequestID == null)
            {
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = LeaveRequestID;
            }
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = AccountID;
            cmd.Parameters.Add(_ParmFrom, SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add(_ParmTo, SqlDbType.DateTime).Value = to;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountLeaveRequestInRepeatDateDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    retVal = Convert.ToInt32(sdr[_DBCount]);
                }
            }
            return retVal;
        }

        /// <summary>
        /// 根据员工ID，请假类型，状态，累加请假小时
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="status"></param>
        /// <param name="leaveRequestTypeEnum"></param>
        /// <returns></returns>
        public decimal SumLeaveRequestCostTimeByEmployeeIDStatusApplyType(int accountID, RequestStatus status, LeaveRequestTypeEnum leaveRequestTypeEnum)
        {
            decimal count = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_DBAccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_ParmLeaveRequestStatus, SqlDbType.Int).Value = status.Id;
            cmd.Parameters.Add(_ParmLeaveRequestTypeID, SqlDbType.Int).Value = leaveRequestTypeEnum;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("SumLeaveRequestCostTimeByEmployeeIDAndStatus", cmd))
            {
                while (sdr.Read())
                {
                    try
                    {
                        count = (decimal)sdr[_DbTotalHout];
                    }
                    catch
                    {
                        count = 0;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="leaveRequestType"></param>
        /// <param name="requestStatus"></param>
        /// <returns></returns>
        public List<LeaveRequestItem> GetLeaveRequestItemByAccountIDAndRequestStatus(int accountID,
                                                            LeaveRequestTypeEnum leaveRequestType, RequestStatus requestStatus)
        {
            List<LeaveRequestItem> leaveRequestItemList = new List<LeaveRequestItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_ParmLeaveRequestTypeID, SqlDbType.Int).Value = (int)leaveRequestType;
            cmd.Parameters.Add(_ParmLeaveRequestStatus, SqlDbType.Int).Value = requestStatus.Id;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestItemByAccountIDAndRequestStatus", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequestItem leaveRequestItem =
                        new LeaveRequestItem((int)sdr[_DBPKID], Convert.ToDateTime(sdr[_DBFromDate]),
                                             Convert.ToDateTime(sdr[_DBToDate]), Convert.ToDecimal(sdr[_DBAbsentHours]),
                                             RequestStatus.FindRequestStatus((int)sdr[_DBLeaveRequestStatus]));

                    leaveRequestItemList.Add(leaveRequestItem);
                }
            }
            return leaveRequestItemList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<LeaveRequest> GetLeaveRequestByAccountIDForCalendar(int accountID)
        {
            List<LeaveRequest> leaveRequestList = new List<LeaveRequest>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestByAccountIDForCalendar", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequest leaveRequest = new LeaveRequest();
                    leaveRequest.PKID = Convert.ToInt32(sdr[_DBPKID]);
                    leaveRequest.Reason = sdr[_DBReason].ToString();
                    leaveRequest.SubmitDate = (DateTime)sdr[_DBSubmitDate];
                    leaveRequest.Account = new Account((int)sdr[_DBAccountID], "", "");
                    leaveRequest.FromDate = (DateTime)sdr[_DBFromDate];
                    leaveRequest.ToDate = (DateTime)sdr[_DBToDate];
                    leaveRequest.CostTime = Convert.ToDecimal(sdr[_DBCostTime]);
                    LegalHoliday legalHoliday;
                    if ((int)sdr[_DBLeaveRequestTypeIncludeNationalHolidays] == 0)
                    {
                        legalHoliday = LegalHoliday.UnInclude;
                    }
                    else
                    {
                        legalHoliday = LegalHoliday.Include;
                    }
                    RestDay restDay;
                    if ((int)sdr[_DBLeaveRequestTypeIncludeRestDay] == 0)
                    {
                        restDay = RestDay.UnInclude;
                    }
                    else
                    {
                        restDay = RestDay.Include;
                    }
                    leaveRequest.LeaveRequestType =
                        new LeaveRequestType((int)sdr[_DBLeaveRequestTypeID], sdr[_DBLeaveRequestTypeName].ToString(),
                                             sdr[_DBLeaveRequestTypeDescription].ToString(),
                                             legalHoliday,restDay,
                                             (decimal)sdr[_DBLeaveRequestTypeLeastHour]);
                    leaveRequest.LeaveRequestItems = GetLeaveRequestItemByLeaveRequestIDForCalendar(leaveRequest.PKID);
                    leaveRequestList.Add(leaveRequest);
                }
            }
            return leaveRequestList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<LeaveRequest> GetAllLeaveRequestByAccountIDForCalendar(int accountID)
        {
            List<LeaveRequest> leaveRequestList = new List<LeaveRequest>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllLeaveRequestByAccountIDForCalendar", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequest leaveRequest = new LeaveRequest();
                    leaveRequest.PKID = Convert.ToInt32(sdr[_DBPKID]);
                    leaveRequest.Reason = sdr[_DBReason].ToString();
                    leaveRequest.SubmitDate = (DateTime)sdr[_DBSubmitDate];
                    leaveRequest.Account = new Account((int)sdr[_DBAccountID], "", "");
                    leaveRequest.FromDate = (DateTime)sdr[_DBFromDate];
                    leaveRequest.ToDate = (DateTime)sdr[_DBToDate];
                    leaveRequest.CostTime = Convert.ToDecimal(sdr[_DBCostTime]);
                    LegalHoliday legalHoliday;
                    if ((int)sdr[_DBLeaveRequestTypeIncludeNationalHolidays] == 0)
                    {
                        legalHoliday = LegalHoliday.UnInclude;
                    }
                    else
                    {
                        legalHoliday = LegalHoliday.Include;
                    }
                    RestDay restDay;
                    if ((int)sdr[_DBLeaveRequestTypeIncludeRestDay] == 0)
                    {
                        restDay = RestDay.UnInclude;
                    }
                    else
                    {
                        restDay = RestDay.Include;
                    }
                    leaveRequest.LeaveRequestType =
                        new LeaveRequestType((int)sdr[_DBLeaveRequestTypeID], sdr[_DBLeaveRequestTypeName].ToString(),
                                             sdr[_DBLeaveRequestTypeDescription].ToString(),
                                             legalHoliday,restDay,
                                             (decimal)sdr[_DBLeaveRequestTypeLeastHour]);
                    leaveRequest.LeaveRequestItems = GetAllLeaveRequestItemByLeaveRequestIDForCalendar(leaveRequest.PKID);
                    leaveRequestList.Add(leaveRequest);
                }
            }
            return leaveRequestList;
        }
        /// <summary>
        /// 通过帐号ID查找相关的帐套项
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        private static List<LeaveRequestItem> GetLeaveRequestItemByLeaveRequestIDForCalendar(int leaveRequestID)
        {
            List<LeaveRequestItem> leaveRequestItemList = new List<LeaveRequestItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmLeaveRequestID, SqlDbType.Int).Value = leaveRequestID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestItemByLeaveRequestIDForCalendar", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequestItem leaveRequestItem =
                        new LeaveRequestItem((int)sdr[_DBPKID], Convert.ToDateTime(sdr[_DBFromDate]),
                                             Convert.ToDateTime(sdr[_DBToDate]), Convert.ToDecimal(sdr[_DBAbsentHours]),
                                             RequestStatus.FindRequestStatus((int)sdr[_DBLeaveRequestStatus]));

                    leaveRequestItemList.Add(leaveRequestItem);
                }
            }
            return leaveRequestItemList;
        }
        /// <summary>
        /// 通过帐号ID查找相关的帐套项
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        private static List<LeaveRequestItem> GetAllLeaveRequestItemByLeaveRequestIDForCalendar
            (int leaveRequestID)
        {
            List<LeaveRequestItem> leaveRequestItemList = new List<LeaveRequestItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmLeaveRequestID, SqlDbType.Int).Value = leaveRequestID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllLeaveRequestItemByLeaveRequestIDForCalendar", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequestItem leaveRequestItem =
                        new LeaveRequestItem((int)sdr[_DBPKID], Convert.ToDateTime(sdr[_DBFromDate]),
                                             Convert.ToDateTime(sdr[_DBToDate]), Convert.ToDecimal(sdr[_DBAbsentHours]),
                                             RequestStatus.FindRequestStatus((int)sdr[_DBLeaveRequestStatus]));

                    leaveRequestItemList.Add(leaveRequestItem);
                }
            }
            return leaveRequestItemList;
        }

        /// <summary>
        /// 更新Item的状态
        /// </summary>
        public int UpdateLeaveRequestItemStatusByLeaveRequestItemID(int leaveRequestItemID, RequestStatus status, 
            int nextStepID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmLeaveRequestItemID, SqlDbType.Int).Value = leaveRequestItemID;
            cmd.Parameters.Add(_ParmLeaveRequestStatus, SqlDbType.Int).Value = status.Id;
            cmd.Parameters.Add(_ParmNextProcessID, SqlDbType.Int).Value = nextStepID;
            return SqlHelper.ExecuteNonQuery("UpdateLeaveRequestStatusByLeaveRequestItemID", cmd);
        }
        /// <summary>
        /// 
        /// </summary>
        public int UpdateLeaveRequestItemUseDetail(LeaveRequestItem item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmLeaveRequestItemID, SqlDbType.Int).Value = item.LeaveRequestItemID;
            cmd.Parameters.Add(_ParmUseList, SqlDbType.NVarChar, 200).Value = item.UseList;
            return SqlHelper.ExecuteNonQuery("UpdateLeaveRequestItemUseDetail", cmd);
        }

        /// <summary>
        /// 获得所有待审核的请假单
        /// </summary>
        /// <returns></returns>
        public List<LeaveRequest> GetConfirmLeaveRequest()
        {
            List<LeaveRequest> LeaveRequestList = new List<LeaveRequest>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetConfirmLeaveRequest", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequest leaveRequest = new LeaveRequest();
                    leaveRequest.PKID = Convert.ToInt32(sdr[_DBPKID]);
                    leaveRequest.Reason = sdr[_DBReason].ToString();
                    leaveRequest.SubmitDate = (DateTime)sdr[_DBSubmitDate];
                    leaveRequest.Account = new Account((int)sdr[_DBAccountID], "", "");
                    leaveRequest.FromDate = (DateTime)sdr[_DBFromDate];
                    leaveRequest.ToDate = (DateTime)sdr[_DBToDate];
                    leaveRequest.CostTime = Convert.ToDecimal(sdr[_DBCostTime]);
                    LegalHoliday legalHoliday;
                    if ((int)sdr[_DBLeaveRequestTypeIncludeNationalHolidays] == 0)
                    {
                        legalHoliday = LegalHoliday.UnInclude;
                    }
                    else
                    {
                        legalHoliday = LegalHoliday.Include;
                    }
                    RestDay restDay;
                    if ((int)sdr[_DBLeaveRequestTypeIncludeRestDay] == 0)
                    {
                        restDay = RestDay.UnInclude;
                    }
                    else
                    {
                        restDay = RestDay.Include;
                    }
                    leaveRequest.LeaveRequestType =
                        new LeaveRequestType((int)sdr[_DBLeaveRequestTypeID], sdr[_DBLeaveRequestTypeName].ToString(),
                                             sdr[_DBLeaveRequestTypeDescription].ToString(),
                                             legalHoliday,restDay,
                                             (decimal)sdr[_DBLeaveRequestTypeLeastHour]);

                    List<DiyStep> diyStepList = new List<DiyStep>();
                    string diyProcess = sdr[_DbDiyProcess].ToString();
                    string[] diySteps = diyProcess.Split(';');
                    foreach (string diyStep in diySteps)
                    {
                        string[] steps = diyStep.Split('|');
                        if (steps.Length > 4)
                        {
                            DiyStep step =
                                new DiyStep(Convert.ToInt32(steps[0]), steps[1],
                                            new OperatorType(Convert.ToInt32(steps[2]),
                                                             OperatorType.FindOperatorTypeByID(Convert.ToInt32(steps[2]))),
                                            Convert.ToInt32(steps[3]));

                            string[] mailAccounts = steps[4].Split(',');
                            foreach (string mailAccount in mailAccounts)
                            {
                                if (!string.IsNullOrEmpty(mailAccount))
                                {
                                    step.MailAccount.Add(new Account(Convert.ToInt32(mailAccount), "", ""));
                                }
                            }

                            diyStepList.Add(step);
                        }
                    }

                    leaveRequest.DiyProcess = new DiyProcess();
                    leaveRequest.DiyProcess.DiySteps = diyStepList;

                    leaveRequest.LeaveRequestItems = GetLeaveRequestItemByLeaveRequestID(leaveRequest.PKID, leaveRequest.DiyProcess);
                    LeaveRequestList.Add(leaveRequest);
                }
            }
            return LeaveRequestList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operatorID"></param>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <returns></returns>
        public List<LeaveRequest> GetLeaveRequestConfirmHistoryByOperatorID(int operatorID, DateTime fromTime, DateTime toTime)
        {
            List<LeaveRequest> LeaveRequestList = new List<LeaveRequest>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmOperatorID, SqlDbType.Int).Value = operatorID;
            cmd.Parameters.Add(_ParmFrom, SqlDbType.DateTime).Value = fromTime;
            cmd.Parameters.Add(_ParmTo, SqlDbType.DateTime).Value = toTime;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestConfirmHistoryByOperatorID", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequest leaveRequest = new LeaveRequest();
                    leaveRequest.PKID = Convert.ToInt32(sdr[_DBPKID]);
                    leaveRequest.Reason = sdr[_DBReason].ToString();
                    leaveRequest.SubmitDate = (DateTime)sdr[_DBSubmitDate];
                    leaveRequest.Account = new Account((int)sdr[_DBAccountID], "", "");
                    leaveRequest.FromDate = (DateTime)sdr[_DBFromDate];
                    leaveRequest.ToDate = (DateTime)sdr[_DBToDate];
                    leaveRequest.CostTime = Convert.ToDecimal(sdr[_DBCostTime]);
                    LegalHoliday legalHoliday;
                    if ((int)sdr[_DBLeaveRequestTypeIncludeNationalHolidays] == 0)
                    {
                        legalHoliday = LegalHoliday.UnInclude;
                    }
                    else
                    {
                        legalHoliday = LegalHoliday.Include;
                    }
                    RestDay restDay;
                    if ((int)sdr[_DBLeaveRequestTypeIncludeRestDay] == 0)
                    {
                        restDay = RestDay.UnInclude;
                    }
                    else
                    {
                        restDay = RestDay.Include;
                    }
                    leaveRequest.LeaveRequestType =
                        new LeaveRequestType((int)sdr[_DBLeaveRequestTypeID], sdr[_DBLeaveRequestTypeName].ToString(),
                                             sdr[_DBLeaveRequestTypeDescription].ToString(),
                                             legalHoliday,restDay,
                                             (decimal)sdr[_DBLeaveRequestTypeLeastHour]);
                    leaveRequest.LeaveRequestItems = GetLeaveRequestItemByLeaveRequestID(leaveRequest.PKID, null);
                    LeaveRequestList.Add(leaveRequest);
                }
            }
            return LeaveRequestList;
        }

        /// <summary>
        /// 通过帐号ID查找相关的帐套项
        /// </summary>
        /// <param name="leaveRequestItemID"></param>
        /// <returns></returns>
        public LeaveRequestItem GetLeaveRequestItemByPKID(int leaveRequestItemID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = leaveRequestItemID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestItemByPKID", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequestItem leaveRequestItem =
                        new LeaveRequestItem((int)sdr[_DBPKID], Convert.ToDateTime(sdr[_DBFromDate]),
                                             Convert.ToDateTime(sdr[_DBToDate]), Convert.ToDecimal(sdr[_DBAbsentHours]),
                                             RequestStatus.FindRequestStatus((int)sdr[_DBLeaveRequestStatus]));
                    leaveRequestItem.LeaveRequestID = (int)sdr[_DBLeaveRequestID];
                    return leaveRequestItem;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<LeaveRequest> GetLeaveRequestDetailByAccountIDAndDate(int accountID, DateTime date)
        {
            List<LeaveRequest> LeaveRequestList = new List<LeaveRequest>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_ParmDate, SqlDbType.DateTime).Value = date;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestDetailByAccountIDAndDate", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequestList.Add(GetLeaveRequestByPKID(Convert.ToInt32(sdr[_DBPKID])));
                }
            }
            return LeaveRequestList;
        }

        ///<summary>
        /// 查询申请 
        ///</summary>
        ///<param name="employeeId"></param>
        ///<param name="theFrom"></param>
        ///<param name="theTo"></param>
        ///<param name="status"></param>
        ///<returns></returns>
        public List<LeaveRequest> GetLeaveRequestByCondition(int employeeId, DateTime theFrom, DateTime theTo,
                                                      RequestStatus status)
        {
            List<LeaveRequest> LeaveRequestList = new List<LeaveRequest>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = employeeId;
            cmd.Parameters.Add(_ParmFrom, SqlDbType.DateTime).Value = theFrom;
            cmd.Parameters.Add(_ParmTo, SqlDbType.DateTime).Value = theTo;
            cmd.Parameters.Add(_ParmLeaveRequestStatus, SqlDbType.Int).Value = status.Id;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestByCondition", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequest leaveRequest = new LeaveRequest();
                    leaveRequest.PKID = Convert.ToInt32(sdr[_DBPKID]);
                    leaveRequest.Reason = sdr[_DBReason].ToString();
                    leaveRequest.SubmitDate = (DateTime)sdr[_DBSubmitDate];
                    leaveRequest.Account = new Account((int)sdr[_DBAccountID], "", "");
                    leaveRequest.FromDate = (DateTime)sdr[_DBFromDate];
                    leaveRequest.ToDate = (DateTime)sdr[_DBToDate];
                    leaveRequest.CostTime = Convert.ToDecimal(sdr[_DBCostTime]);
                    LegalHoliday legalHoliday;
                    if ((int)sdr[_DBLeaveRequestTypeIncludeNationalHolidays] == 0)
                    {
                        legalHoliday = LegalHoliday.UnInclude;
                    }
                    else
                    {
                        legalHoliday = LegalHoliday.Include;
                    }
                    RestDay restDay;
                    if ((int)sdr[_DBLeaveRequestTypeIncludeRestDay] == 0)
                    {
                        restDay = RestDay.UnInclude;
                    }
                    else
                    {
                        restDay = RestDay.Include;
                    }
                    leaveRequest.LeaveRequestType =
                        new LeaveRequestType((int)sdr[_DBLeaveRequestTypeID], sdr[_DBLeaveRequestTypeName].ToString(),
                                             sdr[_DBLeaveRequestTypeDescription].ToString(),
                                             legalHoliday,restDay,
                                             (decimal)sdr[_DBLeaveRequestTypeLeastHour]);
                    leaveRequest.LeaveRequestItems = GetLeaveRequestItemByLeaveRequestID(leaveRequest.PKID, null);
                    LeaveRequestList.Add(leaveRequest);
                }
            }
            return LeaveRequestList;
        }


        /// <summary>
        /// 
        /// </summary>
        public List<LeaveRequestItem> GetVacationUsedDetailByAccountID(int accountID)
        {
            List<LeaveRequestItem> LeaveRequestItemList = new List<LeaveRequestItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetVacationUsedDetailByAccountID", cmd))
            {
                while (sdr.Read())
                {
                   LeaveRequestItem item= new LeaveRequestItem((int)sdr[_DBPKID], Convert.ToDateTime(sdr[_DBFromDate]),
                                            Convert.ToDateTime(sdr[_DBToDate]), Convert.ToDecimal(sdr[_DBAbsentHours]),
                                            RequestStatus.FindRequestStatus((int)sdr[_DBLeaveRequestStatus]));
                    item.Remark = sdr[_DBReason].ToString();
                    LeaveRequestItemList.Add(item);
                }
            }
            return LeaveRequestItemList;
        }
    }
}