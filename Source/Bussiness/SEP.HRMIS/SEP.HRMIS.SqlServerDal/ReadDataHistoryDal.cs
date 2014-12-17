//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ReadDataHistoryDal.cs
// 创建者:刘丹
// 创建日期: 2008-10-15
// 概述: IReadDataHistory接口实现
// ----------------------------------------------------------------

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;

namespace SEP.HRMIS.SqlServerDal
{
    public class ReadDataHistoryDal:IReadDataHistory
    {
        private const string _ParmPKID = "@PKID";
        private const string _ParmReadTime = "@ReadTime";
        private const string _ParmReadResult = "@ReadResult";
        private const string _ParmFailReason = "@FailReason";
        private const string _DbPKID = "PKID";
        private const string _DbReadTime = "ReadTime";
        private const string _DbReadResult = "ReadResult";
        private const string _DbFailReason = "FailReason";
        public int InsertReadDataHistory(ReadDataHistory history)
        {
            int pkid;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(_ParmReadTime, SqlDbType.DateTime).Value = history.ReadTime;
            sqlCommand.Parameters.Add(_ParmReadResult, SqlDbType.Int).Value = history.ReadResult;
            sqlCommand.Parameters.Add(_ParmFailReason, SqlDbType.Text).Value = history.FailReason;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertReadDataHistory", sqlCommand, out pkid);
            return pkid;
        }

        public int UpdateReadDataHistory(ReadDataHistory history)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = history.ReadDataId;
            sqlCommand.Parameters.Add(_ParmReadTime, SqlDbType.DateTime).Value = history.ReadTime;
            sqlCommand.Parameters.Add(_ParmReadResult, SqlDbType.Int).Value = history.ReadResult;
            sqlCommand.Parameters.Add(_ParmFailReason, SqlDbType.Text).Value = history.FailReason;
            return SqlHelper.ExecuteNonQuery("UpdateReadDataHistory", sqlCommand);
        }

        public int DeleteReadDataHistory(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
            return SqlHelper.ExecuteNonQuery("DeleteReadDataHistory", cmd);
        }

        public List<ReadDataHistory> GetAllReadDataHistory()
        {
            List<ReadDataHistory> historys = new List<ReadDataHistory>();
            SqlCommand sqlCommand = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllReadDataHistory", sqlCommand))
            {
                while (sdr.Read())
                {
                    ReadDataHistory history = new ReadDataHistory();
                    history.ReadDataId = Convert.ToInt32(sdr[_DbPKID]);
                    history.ReadTime = Convert.ToDateTime(sdr[_DbReadTime]);
                    history.ReadResult = (ReadDataResultType)(sdr[_DbReadResult]);
                    history.FailReason = sdr[_DbFailReason].ToString();
                    historys.Add(history);
                }
                return historys;
            }
        }

        public ReadDataHistory GetReadDataHistoryByPkid(int pkid)
        {
            ReadDataHistory history = null;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetReadDataHistoryByPkid", sqlCommand))
            {
                while (sdr.Read())
                {
                    history = new ReadDataHistory();
                    history.ReadDataId = Convert.ToInt32(sdr[_DbPKID]);
                    history.ReadTime = Convert.ToDateTime(sdr[_DbReadTime]);
                    history.ReadResult = (ReadDataResultType)(sdr[_DbReadResult]);
                    history.FailReason = sdr[_DbFailReason].ToString();
                }
                return history;
            }
        }

        public ReadDataHistory GetLastSuccessReadDataHistory()
        {
            ReadDataHistory history = null;
            SqlCommand sqlCommand = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLastSuccessReadDataHistory", sqlCommand))
            {
                while (sdr.Read())
                {
                    history = new ReadDataHistory();
                    history.ReadDataId = Convert.ToInt32(sdr[_DbPKID]);
                    history.ReadTime = Convert.ToDateTime(sdr[_DbReadTime]);
                    history.ReadResult = (ReadDataResultType)(sdr[_DbReadResult]);
                    history.FailReason = sdr[_DbFailReason].ToString();
                }
                return history;
            }
        }
        public ReadDataHistory GetLastReadDataHistory()
        {
            ReadDataHistory history = null;
            SqlCommand sqlCommand = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLastReadDataHistory", sqlCommand))
            {
                while (sdr.Read())
                {
                    history = new ReadDataHistory();
                    history.ReadDataId = Convert.ToInt32(sdr[_DbPKID]);
                    history.ReadTime = Convert.ToDateTime(sdr[_DbReadTime]);
                    history.ReadResult = (ReadDataResultType)(sdr[_DbReadResult]);
                    history.FailReason = sdr[_DbFailReason].ToString();
                }
                return history;
            }
        }
        
    }
}
