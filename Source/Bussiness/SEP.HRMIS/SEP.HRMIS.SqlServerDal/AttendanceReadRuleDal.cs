//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AttendanceReadRuleDal.cs
// 创建者:刘丹
// 创建日期: 2008-10-15
// 概述: IAttendanceReadRule接口实现
// ----------------------------------------------------------------

using System;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;

namespace SEP.HRMIS.SqlServerDal
{
    public class AttendanceReadRuleDal:IAttendanceReadRule
    {
        private const string _ParmPKID = "@PKID";
        private const string _ParmReadDateTime = "@ReadDateTime";
        private const string _ParmIsSendEmail = "@IsSendEmail";
        private const string _ParmSendEmailRull = "@SendEmailRull";

        private const string _DbPKID = "PKID";
        private const string _DbReadDateTime = "ReadDateTime";
        private const string _DbIsSendEmail = "IsSendEmail";
        private const string _DbSendEmailRull = "SendEmailRull";

        public int InsertAttendanceReadRule(AttendanceReadRule time)
        {
            int pkid;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(_ParmReadDateTime, SqlDbType.DateTime).Value = time.ReadDateTime;
            sqlCommand.Parameters.Add(_ParmIsSendEmail, SqlDbType.Int).Value = time.IsSendMail;
            sqlCommand.Parameters.Add(_ParmSendEmailRull, SqlDbType.Int).Value = time.SendEmailRule;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertAttendanceReadTime", sqlCommand, out pkid);
            return pkid;
        }

        public int UpdateAttendanceReadRule(AttendanceReadRule time)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = time.AttendanceReadTimeId;
            sqlCommand.Parameters.Add(_ParmReadDateTime, SqlDbType.DateTime).Value = time.ReadDateTime;
            sqlCommand.Parameters.Add(_ParmIsSendEmail, SqlDbType.Int).Value = time.IsSendMail;
            sqlCommand.Parameters.Add(_ParmSendEmailRull, SqlDbType.Int).Value = time.SendEmailRule;
            return SqlHelper.ExecuteNonQuery("UpdateAttendanceReadTime", sqlCommand);
        }

        public int DeleteAttendanceReadRule(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
            return SqlHelper.ExecuteNonQuery("DeleteAttendanceReadTime", cmd);
        }

        public AttendanceReadRule GetAttendanceReadRuleByPkid(int pkid)
        {
            AttendanceReadRule read = null;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAttendanceReadTimeByPkid", sqlCommand))
            {
                while (sdr.Read())
                {
                    read = new AttendanceReadRule();
                    read.AttendanceReadTimeId = Convert.ToInt32(sdr[_DbPKID]);
                    read.ReadDateTime = Convert.ToDateTime(sdr[_DbReadDateTime]);
                    read.IsSendMail = Convert.ToBoolean(sdr[_DbIsSendEmail]);
                    read.SendEmailRule = (SendEmailRuleType)(sdr[_DbSendEmailRull]);
                }
                return read;
            }
        }
    }
}
