using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.IDal.SpecialDates;
using SEP.Model.SpecialDates;

namespace SEP.SqlServerDal
{
    public class SpecialDateDal : ISpecialDateDal
    {
        #region const string

        private const string _SpecialDateID = "@PKID";
        private const string _SpecialDate = "@SpecialDate";
        private const string _SpecialFromDate = "@SpecialFromDate";
        private const string _SpecialToDate = "@SpecialToDate";
        private const string _IsWork = "@IsWork";
        private const string _SpecialHeader = "@SpecialHeader";
        private const string _SpecialDescription = "@SpecialDescription";
        private const string _SpecialForeColor = "@SpecialForeColor";
        private const string _SpecialBackColor = "@SpecialBackColor";

        private const string _DbSpecialDateID = "PKID";
        private const string _DbSpecialDate = "SpecialDate";
        private const string _DbIsWork = "IsWork";
        private const string _DbSpecialHeader = "SpecialHeader";
        private const string _DbSpecialDescription = "SpecialDescription";
        private const string _DbSpecialForeColor = "SpecialForeColor";
        private const string _DbSpecialBackColor = "SpecialBackColor";

        #endregion

        /// <summary>
        /// 新增特殊日期
        /// </summary>
        public int InsertSpecialDate(SpecialDate specialDate)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_SpecialDateID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_SpecialDate, SqlDbType.DateTime).Value = specialDate.SpecialDateTime;
            cmd.Parameters.Add(_IsWork, SqlDbType.Int, 32).Value = specialDate.IsWork;
            cmd.Parameters.Add(_SpecialHeader, SqlDbType.NVarChar, 50).Value = specialDate.SpecialHeader;
            cmd.Parameters.Add(_SpecialDescription, SqlDbType.NVarChar, 255).Value = specialDate.SpecialDescription;
            cmd.Parameters.Add(_SpecialForeColor, SqlDbType.NVarChar, 50).Value = specialDate.SpecialForeColor;
            cmd.Parameters.Add(_SpecialBackColor, SqlDbType.NVarChar, 50).Value = specialDate.SpecialBackColor;

            SqlHelper.ExecuteNonQueryReturnPKID("SpecialDateInsert", cmd, out pkid);
            return pkid;
        }

        ///// <summary>
        ///// 根据PKID删除特殊日期
        ///// </summary>
        ///// <param name="specialDateID"></param>
        ///// <returns></returns>
        //public int DeleteSpecialDateByPKID(int specialDateID)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Parameters.Add(_SpecialDateID, SqlDbType.Int).Value = specialDateID;
        //    return SqlHelper.ExecuteNonQuery("DeleteSpecialDateByPKID", cmd);
        //}

        ///// <summary>
        ///// 根据PKID找到特殊日期
        ///// </summary>
        //public List<SpecialDate> GetSpecialDateByPKID(int pkid)
        //{
        //    List<SpecialDate> specialDates = new List<SpecialDate>();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Parameters.Add(_SpecialDateID, SqlDbType.Int).Value = pkid;
        //    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetSpecialDateByPKID", cmd))
        //    {
        //        while (sdr.Read())
        //        {
        //            SpecialDate specialDate = new SpecialDate();
        //            specialDate.SpecialDateID = Convert.ToInt32(sdr[_DbSpecialDateID]);
        //            specialDate.SpecialBackColor = sdr[_DbSpecialBackColor].ToString();
        //            specialDate.SpecialDateTime = Convert.ToDateTime(sdr[_DbSpecialDate]);
        //            specialDate.SpecialDescription = (sdr[_DbSpecialDescription]).ToString();
        //            specialDate.SpecialForeColor = sdr[_DbSpecialForeColor].ToString();
        //            specialDate.SpecialHeader = (sdr[_DbSpecialHeader]).ToString();
        //            specialDate.IsWork = Convert.ToInt32(sdr[_DbIsWork]);
        //            specialDates.Add(specialDate);
        //        }
        //    }
        //    return specialDates;
        //}

        ///// <summary>
        ///// 得到一段时间内的所有特殊日期
        ///// </summary>
        //public List<SpecialDate> GetSpecialDateByFromToDate(DateTime From, DateTime To)
        //{
        //    List<SpecialDate> specialDates = new List<SpecialDate>();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Parameters.Add(_SpecialFromDate, SqlDbType.DateTime).Value = From;
        //    cmd.Parameters.Add(_SpecialToDate, SqlDbType.DateTime).Value = To;

        //    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetSpecialDateByFromToDate", cmd))
        //    {
        //        while (sdr.Read())
        //        {
        //            SpecialDate specialDate = new SpecialDate();
        //            specialDate.SpecialDateID = Convert.ToInt32(sdr[_DbSpecialDateID]);
        //            specialDate.SpecialBackColor = sdr[_DbSpecialBackColor].ToString();
        //            specialDate.SpecialDateTime = Convert.ToDateTime(sdr[_DbSpecialDate]);
        //            specialDate.SpecialDescription = (sdr[_DbSpecialDescription]).ToString();
        //            specialDate.SpecialForeColor = sdr[_DbSpecialForeColor].ToString();
        //            specialDate.SpecialHeader = (sdr[_DbSpecialHeader]).ToString();
        //            specialDate.IsWork = Convert.ToInt32(sdr[_DbIsWork]);
        //            specialDates.Add(specialDate);
        //        }
        //    }
        //    return specialDates;
        //}

        /// <summary>
        /// 根据SpecialDateTime删除特殊日期
        /// </summary>
        public int DeleteSpecialDateByDate(DateTime specialDateTime)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SpecialDate, SqlDbType.DateTime).Value = specialDateTime;
            return SqlHelper.ExecuteNonQuery("DeleteSpecialDateByDate", cmd);
        }

        public List<SpecialDate> GetAllSpecialDate()
        {
            List<SpecialDate> specialDates = new List<SpecialDate>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetSpecialDateByPKID", cmd))
            {
                while (sdr.Read())
                {
                    SpecialDate specialDate = new SpecialDate();
                    specialDate.SpecialDateID = Convert.ToInt32(sdr[_DbSpecialDateID]);
                    specialDate.SpecialBackColor = sdr[_DbSpecialBackColor].ToString();
                    specialDate.SpecialDateTime = Convert.ToDateTime(sdr[_DbSpecialDate]);
                    specialDate.SpecialDescription = (sdr[_DbSpecialDescription]).ToString();
                    specialDate.SpecialForeColor = sdr[_DbSpecialForeColor].ToString();
                    specialDate.SpecialHeader = (sdr[_DbSpecialHeader]).ToString();
                    specialDate.IsWork = Convert.ToInt32(sdr[_DbIsWork]);
                    specialDates.Add(specialDate);
                }
            }
            return specialDates;
        }
    }
}
