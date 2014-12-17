//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SystemErrorDal.cs
// Creater:  Xue.wenlong
// Date:  2009-09-29
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.SystemError;
using SEP.Model.Accounts;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// </summary>
    public class SystemErrorDal : ISystemError
    {
        private const string _DBAccount = "AccountID";
        private const string _DBDoorCardNo = "DoorCardNo";
        private const string _DBPlanDutyTableID = "PlanDutyTableID";
        private const string _DBLeaveRequestDiyID = "LeaveRequestDiyID";
        private const string _DBOutDiyID = "OutDiyID";
        private const string _DBOverWorkDiyID = "OverWorkDiyID";
        private const string _DBAssessDiyID = "AssessDiyID";
        private const string _DBHRPrincipalDiyID = "HRPrincipalDiyID";
        private const string _DBReimburseDiyID = "ReimburseDiyID";
        private const string _DBTraineeDiyID = "TraineeDiyID";


        private const string _PKID = "@PKID";
        private const string _ErrorType = "@ErrorType";
        private const string _MarkID = "@MarkID";
        private const string _DbPKID = "PKID";
        private const string _DbErrorType = "ErrorType";
        private const string _DbMarkID = "MarkID";


        /// <summary>
        /// </summary>
        public int SystemErrorInsert(SystemError systemError)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_ErrorType, SqlDbType.Int).Value = systemError.ErrorType.ID;
            cmd.Parameters.Add(_MarkID, SqlDbType.Int).Value = systemError.MarkID;
            SqlHelper.ExecuteNonQueryReturnPKID("SystemErrorInsert", cmd, out pkid);
            return pkid;
        }


        /// <summary>
        /// 
        /// </summary>
        public int DeleteSystemErrorByTypeAndMarkID(ErrorType errorType, int markID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ErrorType, SqlDbType.Int).Value = errorType.ID;
            cmd.Parameters.Add(_MarkID, SqlDbType.Int).Value = markID;
            return SqlHelper.ExecuteNonQuery("DeleteSystemErrorByTypeAndMarkID", cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        public SystemError GetSystemErrorByTypeAndMarkID(ErrorType errorType, int markID)
        {
            SystemError systemError = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_ErrorType, SqlDbType.Int).Value = errorType.ID;
            cmd.Parameters.Add(_MarkID, SqlDbType.Int).Value = markID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetSystemErrorByTypeAndMarkID", cmd))
            {
                while (sdr.Read())
                {
                    systemError =
                        new SystemError(Convert.ToInt32(sdr[_DbPKID]), "",
                                        ErrorType.GetErrorTypeByID(Convert.ToInt32(sdr[_DbErrorType])),
                                        Convert.ToInt32(sdr[_DbMarkID]));
                }
            }
            return systemError;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SystemError> GetAllIgnoreSystemError()
        {
            List<SystemError> items = new List<SystemError>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllSystemError", cmd))
            {
                while (sdr.Read())
                {
                    items.Add(new SystemError(Convert.ToInt32(sdr[_DbPKID]), "",
                                              ErrorType.GetErrorTypeByID(Convert.ToInt32(sdr[_DbErrorType])),
                                              Convert.ToInt32(sdr[_DbMarkID])));
                }
            }
            return items;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<SystemError> GetAcBaseSystemError()
        {
            List<SystemError> items = new List<SystemError>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetBaseError", cmd))
            {
                while (sdr.Read())
                {
                    Account account = new Account(Convert.ToInt32(sdr[_DBAccount]), "", "");
                    string DoorCardNo = sdr[_DBDoorCardNo].ToString();
                    string PlanDutyTableID = sdr[_DBPlanDutyTableID].ToString();
                    string LeaveRequestDiyID = sdr[_DBLeaveRequestDiyID].ToString();
                    string OutDiyID = sdr[_DBOutDiyID].ToString();
                    string OverWorkDiyID = sdr[_DBOverWorkDiyID].ToString();
                    string AssessDiyID = sdr[_DBAssessDiyID].ToString();
                    string HRPrincipalDiyID = sdr[_DBHRPrincipalDiyID].ToString();
                    string ReimburseDiyID = sdr[_DBReimburseDiyID].ToString();
                    string TraineeDiyID = sdr[_DBTraineeDiyID].ToString();
                    if (string.IsNullOrEmpty(DoorCardNo))
                    {
                        items.Add(
                            new SystemError(SysErrorUtility.DoorCardNoError(DoorCardNo), ErrorType.DoorCardNoError,
                                            account.Id));
                    }
                    if (string.IsNullOrEmpty(PlanDutyTableID))
                    {
                        items.Add(
                            new SystemError(SysErrorUtility.DutyCalssError(PlanDutyTableID),
                                            ErrorType.DutyCalssError,
                                            account.Id));
                    }
                    if (string.IsNullOrEmpty(LeaveRequestDiyID))
                    {
                        items.Add(
                            new SystemError(SysErrorUtility.DiyLeaveRequestError(LeaveRequestDiyID),
                                            ErrorType.DiyLeaveRequestError, account.Id));
                    }
                    if (string.IsNullOrEmpty(OutDiyID))
                    {
                        items.Add(
                            new SystemError(SysErrorUtility.DiyOutError(OutDiyID),
                                            ErrorType.DiyOutError, account.Id));
                    }
                    if (string.IsNullOrEmpty(OverWorkDiyID))
                    {
                        items.Add(
                            new SystemError(SysErrorUtility.DiyOverWorkError(OverWorkDiyID),
                                            ErrorType.DiyOverWorkError, account.Id));
                    }
                    if (string.IsNullOrEmpty(AssessDiyID))
                    {
                        items.Add(
                            new SystemError(SysErrorUtility.DiyAssessError(AssessDiyID),
                                            ErrorType.DiyAssessError, account.Id));
                    }
                    if (string.IsNullOrEmpty(HRPrincipalDiyID))
                    {
                        items.Add(
                            new SystemError(SysErrorUtility.DiyHRPrincipalError(HRPrincipalDiyID),
                                            ErrorType.DiyHRPrincipalError, account.Id));
                    }
                    //if (string.IsNullOrEmpty(ReimburseDiyID))
                    //{
                    //    items.Add(
                    //        new SystemError(SysErrorUtility.DiyReimburseError(ReimburseDiyID),
                    //                        ErrorType.DiyReimburseError, account.Id));
                    //}
                    if (string.IsNullOrEmpty(TraineeDiyID))
                    {
                        items.Add(
                            new SystemError(SysErrorUtility.DiyTraineeApplicationError(TraineeDiyID),
                                            ErrorType.DiyTraineeApplicationError, account.Id));
                    }
                }
            }
            return items;
        }
    }
}