//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: LeaveRequestTypeDal.cs
// Creater:  Xue.wenlong
// Date:  2009-03-24
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 请假类型
    /// </summary>
    public class LeaveRequestTypeDal : ILeaveRequestType
    {
        private const string _PKID = "@PKID";
        private const string _Name = "@Name";
        private const string _Description = "@Description";
        private const string _IncludeNationalHolidays = "@IncludeNationalHolidays";
        private const string _IncludeRestDay = "@IncludeRestDay";

        private const string _LeastHour = "@LeastHour";

        private const string _DBPKID = "PKID";
        private const string _DBName = "Name";
        private const string _DBDescription = "Description";
        private const string _DBIncludeNationalHolidays = "IncludeNationalHolidays";
        private const string _DBIncludeRestDay = "IncludeRestDay";

        private const string _DBLeastHour = "LeastHour";

        /// <summary>
        /// 添加请假类型
        /// </summary>
        public int InsertLeaveRequestType(LeaveRequestType leaveRequestType)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 50).Value = leaveRequestType.Name;
            if (String.IsNullOrEmpty(leaveRequestType.Description))
            {
                cmd.Parameters.Add(_Description, SqlDbType.Text).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add(_Description, SqlDbType.Text).Value = leaveRequestType.Description;
            }
            cmd.Parameters.Add(_IncludeNationalHolidays, SqlDbType.Int).Value = leaveRequestType.IncludeLegalHoliday;
            cmd.Parameters.Add(_IncludeRestDay, SqlDbType.Int).Value = leaveRequestType.IncludeRestDay;

            cmd.Parameters.Add(_LeastHour, SqlDbType.Decimal).Value = leaveRequestType.LeastHour;
            SqlHelper.ExecuteNonQueryReturnPKID("LeaveRequestTypeInsert", cmd, out pkid);
            return leaveRequestType.LeaveRequestTypeID = pkid;
        }


        /// <summary>
        /// 修改请假类型
        /// </summary>
        /// <param name="leaveRequestType"></param>
        public void UpdateLeaveRequestType(LeaveRequestType leaveRequestType)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = leaveRequestType.LeaveRequestTypeID;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 50).Value = leaveRequestType.Name;
            if (String.IsNullOrEmpty(leaveRequestType.Description))
            {
                cmd.Parameters.Add(_Description, SqlDbType.Text).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add(_Description, SqlDbType.Text).Value = leaveRequestType.Description;
            }
            cmd.Parameters.Add(_IncludeNationalHolidays, SqlDbType.Int).Value = leaveRequestType.IncludeLegalHoliday;
            cmd.Parameters.Add(_IncludeRestDay, SqlDbType.Int).Value = leaveRequestType.IncludeRestDay;
            cmd.Parameters.Add(_LeastHour, SqlDbType.Decimal).Value = leaveRequestType.LeastHour;
            SqlHelper.ExecuteNonQuery("LeaveRequestTypeUpdate", cmd);
        }

        /// <summary>
        /// 删除请假类型
        /// </summary>
        /// <param name="leaveRequestTypeID"></param>
        public void DeleteLeaveRequestType(int leaveRequestTypeID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = leaveRequestTypeID;
            SqlHelper.ExecuteNonQuery("LeaveRequestTypeDelete", cmd);
        }

        /// <summary>
        /// 得到所有请假类型
        /// </summary>
        /// <returns></returns>
        public List<LeaveRequestType> GetAllLeaveRequestType()
        {
            return GetLeaveRequestTypeByNameLike("");
        }

        /// <summary>
        /// 通过ID取得请假类型
        /// </summary>
        /// <param name="leaveTypeID"></param>
        /// <returns></returns>
        public LeaveRequestType GetLeaveRequestTypeByPkid(int leaveTypeID)
        {
            LeaveRequestType leave = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = leaveTypeID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestTypeByPkid", cmd))
            {
                while (sdr.Read())
                {
                    leave = new LeaveRequestType(Convert.ToInt32(sdr[_DBPKID]),
                                                 sdr[_DBName].ToString(),
                                                 sdr[_DBDescription] == DBNull.Value
                                                     ? null
                                                     : sdr[_DBDescription].ToString(),
                                                 (LegalHoliday) sdr[_DBIncludeNationalHolidays],
                                                 (RestDay)sdr[_DBIncludeRestDay],
                                                 Convert.ToDecimal(sdr[_DBLeastHour]));
                    break;
                }
            }

            return leave;
        }

        /// <summary>
        /// 通过名字找请假
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public LeaveRequestType GetLeaveRequestTypeByName(string name)
        {
            LeaveRequestType leave = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 50).Value = name;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestTypeByName", cmd))
            {
                while (sdr.Read())
                {
                    leave = new LeaveRequestType(Convert.ToInt32(sdr[_DBPKID]),
                                                 sdr[_DBName].ToString(),
                                                 sdr[_DBDescription] == DBNull.Value
                                                     ? null
                                                     : sdr[_DBDescription].ToString(),
                                                 (LegalHoliday)sdr[_DBIncludeNationalHolidays],
                                                 (RestDay)sdr[_DBIncludeRestDay],
                                                 Convert.ToDecimal(sdr[_DBLeastHour]));
                    break;
                }
            }

            return leave;
        }

        public List<LeaveRequestType> GetLeaveRequestTypeByNameLike(string namelike)
        {
            List<LeaveRequestType> leaveTypeList = new List<LeaveRequestType>();

            SqlCommand cmd = new SqlCommand();
            if (!String.IsNullOrEmpty(namelike))
            {
                cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 50).Value = namelike;
            }
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestTypeByNameLike", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequestType leave = new LeaveRequestType(Convert.ToInt32(sdr[_DBPKID]),
                                                                  sdr[_DBName].ToString(),
                                                                  sdr[_DBDescription] == DBNull.Value
                                                                      ? null
                                                                      : sdr[_DBDescription].ToString(),
                                                 (LegalHoliday)sdr[_DBIncludeNationalHolidays],
                                                 (RestDay)sdr[_DBIncludeRestDay],
                                                                  Convert.ToDecimal(sdr[_DBLeastHour]));
                    leaveTypeList.Add(leave);
                }
            }
            return leaveTypeList;
        }
    }
}