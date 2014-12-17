//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: BulletinDal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 公告持久层实现
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SEP.IDal.Bulletins;
using SEP.Model.Bulletins;
using SEP.Model.Departments;

namespace SEP.SqlServerDal
{
    public class BulletinDal : IBulletinDal
    {
        private int _retVal;
        private const string _DbCount = "Counts";

        private const string _BulletinID = "@PKID";
        private const string _BTitle = "@Title";
        private const string _PublishTime = "@PublishTime";
        private const string _PublishStartTime = "@PublishStartTime";
        private const string _PublishEndTime = "@PublishEndTime";
        private const string _Content = "@Content";
        private const string _DepartmentID = "@DepartmentID";
        private const string _DbBulletinID = "PKID";
        private const string _DbBTitle = "Title";
        private const string _DbPublishTime = "PublishTime";
        private const string _DbContent = "Content";

        private const string _AppendixID = "@PKID";
        private const string _ABulletinID = "@BulletinID";
        private const string _ATitle = "@Title";
        private const string _Directory = "@Directory";
        private const string _DbAppendixID = "PKID";
        private const string _DbABulletinID = "BulletinID";
        private const string _DbATitle = "Title";
        private const string _DbDirectory = "Directory";

        private const string _DbDepartmentID = "DepartmentID";


        /// <summary>
        /// 插入附件
        /// </summary>
        public int InsertAppendix(Appendix appendix)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AppendixID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_ABulletinID, SqlDbType.Int).Value = appendix.BulletinID;
            cmd.Parameters.Add(_ATitle, SqlDbType.NVarChar, 50).Value = appendix.Title;
            cmd.Parameters.Add(_Directory, SqlDbType.Text).Value = appendix.Directory;

            SqlHelper.ExecuteNonQueryReturnPKID("AppendixInsert", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 插入公告
        /// </summary>
        public int InsertBulletin(Bulletin bulletin)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_BulletinID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_BTitle, SqlDbType.NVarChar, 50).Value = bulletin.Title;
            cmd.Parameters.Add(_PublishTime, SqlDbType.DateTime).Value = bulletin.PublishTime;
            cmd.Parameters.Add(_Content, SqlDbType.Text).Value = bulletin.Content;
            cmd.Parameters.Add(_DepartmentID, SqlDbType.Int).Value = bulletin.Dept.Id;
            SqlHelper.ExecuteNonQueryReturnPKID("BulletinInsert", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 更新公告
        /// </summary>
        public int UpdateBulletin(Bulletin bulletin)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_BulletinID, SqlDbType.Int).Value = bulletin.BulletinID;
            cmd.Parameters.Add(_BTitle, SqlDbType.NVarChar, 50).Value = bulletin.Title;
            cmd.Parameters.Add(_PublishTime, SqlDbType.DateTime).Value = bulletin.PublishTime;
            cmd.Parameters.Add(_Content, SqlDbType.Text).Value = bulletin.Content;
            cmd.Parameters.Add(_DepartmentID, SqlDbType.Int).Value = bulletin.Dept.Id;
            return SqlHelper.ExecuteNonQuery("BulletinUpdate", cmd);
        }

        /// <summary>
        /// 通过公告ID，标题来查找附近数量
        /// </summary>
        /// <param name="bulletinID">公告ID</param>
        /// <param name="title">标题</param>
        /// <returns>附件数量</returns>
        public int GetAppendixCountByBulletinIDAndTitle(int bulletinID, string title)
        {
            _retVal = -1;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ABulletinID, SqlDbType.Int).Value = bulletinID;
            cmd.Parameters.Add(_ATitle, SqlDbType.NVarChar, 50).Value = title;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountAppendixByBulletinIDAndTitle", cmd))
            {
                while (sdr.Read())
                {
                    _retVal = Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        /// <summary>
        /// 通过标题查找公告数量
        /// </summary>
        public int GetBulletinCountByTitle(string title)
        {
            _retVal = -1;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_BTitle, SqlDbType.NVarChar, 50).Value = title;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountBulletinByTitle", cmd))
            {
                while (sdr.Read())
                {
                    _retVal = Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        public int GetBulletinCountByTitleDiffPKID(int bulletinID, string title)
        {
            _retVal = -1;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_BulletinID, SqlDbType.Int).Value = bulletinID;
            cmd.Parameters.Add(_BTitle, SqlDbType.NVarChar, 50).Value = title;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountBulletinByTitleDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    _retVal = Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        /// <summary>
        /// 查找所有公告
        /// </summary>
        public List<Bulletin> GetAllBulletin()
        {
            List<Bulletin> bulletinList = new List<Bulletin>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdrItem = SqlHelper.ExecuteReader("GetAllBulletin", cmd))
            {
                while (sdrItem.Read())
                {
                    Bulletin bulletin =
                        new Bulletin(Convert.ToInt32(sdrItem[_DbBulletinID]), sdrItem[_DbBTitle].ToString(),
                                     "", Convert.ToDateTime(sdrItem[_DbPublishTime]));
                    bulletin.Dept = new Department(Convert.ToInt32(sdrItem[_DbDepartmentID]), "");
                    bulletinList.Add(bulletin);
                }
            }
            return bulletinList;
        }

        /// <summary>
        /// 查找前5个公告
        /// </summary>
        public List<Bulletin> GetLastBulletin()
        {
            List<Bulletin> bulletinList = new List<Bulletin>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdrItem = SqlHelper.ExecuteReader("GetLastBulletin", cmd))
            {
                while (sdrItem.Read())
                {
                    Bulletin bulletin =
                        new Bulletin(Convert.ToInt32(sdrItem[_DbBulletinID]), sdrItem[_DbBTitle].ToString(),
                                     "", Convert.ToDateTime(sdrItem[_DbPublishTime]));
                    bulletin.Dept = new Department(Convert.ToInt32(sdrItem[_DbDepartmentID]), "");
                    bulletinList.Add(bulletin);
                }
            }
            return bulletinList;
        }

        /// <summary>
        /// 通过条件查找公告
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="publishStartTime">公告开始时间</param>
        /// <param name="publishEndTime">公告结束时间</param>
        public List<Bulletin> GetBulletinByCondition(string title, DateTime publishStartTime, DateTime publishEndTime)
        {
            List<Bulletin> bulletinList = new List<Bulletin>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_BTitle, SqlDbType.NVarChar, 50).Value = title;
            cmd.Parameters.Add(_PublishStartTime, SqlDbType.DateTime).Value = publishStartTime;
            cmd.Parameters.Add(_PublishEndTime, SqlDbType.DateTime).Value = publishEndTime;

            using (SqlDataReader sdrItem = SqlHelper.ExecuteReader("GetBulletinByCondition", cmd))
            {
                while (sdrItem.Read())
                {
                    Bulletin bulletin =
                        new Bulletin(Convert.ToInt32(sdrItem[_DbBulletinID]), sdrItem[_DbBTitle].ToString(),
                                     "", Convert.ToDateTime(sdrItem[_DbPublishTime]));
                    bulletin.Dept = new Department(Convert.ToInt32(sdrItem[_DbDepartmentID]), "");
                    bulletinList.Add(bulletin);
                }
            }
            return bulletinList;
        }

        /// <summary>
        /// 通过公告ID查找公告
        /// </summary>
        /// <param name="bulletinID">公告ID</param>
        public Bulletin GetBulletinByBulletinID(int bulletinID)
        {
            Bulletin bulletin = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_BulletinID, SqlDbType.Int).Value = bulletinID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetBulletinByBulletinID", cmd))
            {
                while (sdr.Read())
                {
                    bulletin = new Bulletin(Convert.ToInt32(sdr[_DbBulletinID]), sdr[_DbBTitle].ToString(),
                                            sdr[_DbContent].ToString(), Convert.ToDateTime(sdr[_DbPublishTime]));
                    bulletin.Dept = new Department(Convert.ToInt32(sdr[_DbDepartmentID]), "");
                    BulletinDal bulletinDal = new BulletinDal();
                    bulletin.AppendixList = bulletinDal.GetAppendixByBulletinID(Convert.ToInt32(sdr[_DbBulletinID]));
                }
            }
            return bulletin;
        }

        /// <summary>
        /// 通过时间查找公告
        /// </summary>
        /// <param name="publishStartTime">公告开始时间</param>
        /// <param name="publishEndTime">公告结束时间</param>
        public List<Bulletin> GetBulletinByTime(DateTime publishStartTime, DateTime publishEndTime)
        {
            List<Bulletin> bulletinList = new List<Bulletin>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PublishStartTime, SqlDbType.DateTime).Value = publishStartTime;
            cmd.Parameters.Add(_PublishEndTime, SqlDbType.DateTime).Value = publishEndTime;


            using (SqlDataReader sdrItem = SqlHelper.ExecuteReader("GetBulletinByTime", cmd))
            {
                while (sdrItem.Read())
                {
                    Bulletin bulletin =
                        new Bulletin(Convert.ToInt32(sdrItem[_DbBulletinID]), sdrItem[_DbBTitle].ToString(),
                                     "", Convert.ToDateTime(sdrItem[_DbPublishTime]));
                    bulletinList.Add(bulletin);
                }
            }
            return bulletinList;
        }

        /// <summary>
        /// 通过附件ID删除附件
        /// </summary>
        public int DeleteAppendixByPKID(int appendixID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AppendixID, SqlDbType.Int).Value = appendixID;
            return SqlHelper.ExecuteNonQuery("DeleteAppendixByPKID", cmd);
        }

        /// <summary>
        /// 通过公告ID删除附件
        /// </summary>
        public int DeleteAppendixByBulletinID(int bulletinID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ABulletinID, SqlDbType.Int).Value = bulletinID;
            return SqlHelper.ExecuteNonQuery("DeleteAppendixByBulletinID", cmd);
        }

        /// <summary>
        /// 通过公告ID删除公告
        /// </summary>
        public int DeleteBulletinByPKID(int bulletinID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_BulletinID, SqlDbType.Int).Value = bulletinID;
            return SqlHelper.ExecuteNonQuery("DeleteBulletinByPKID", cmd);
        }

        /// <summary>
        /// 通过附件ID查找附件
        /// </summary>
        public Appendix GetAppendixByPKID(int appendixID)
        {
            Appendix appendix = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AppendixID, SqlDbType.Int).Value = appendixID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAppendixByPKID", cmd))
            {
                while (sdr.Read())
                {
                    appendix = new Appendix(Convert.ToInt32(sdr[_DbAppendixID]), Convert.ToInt32(sdr[_DbABulletinID]),
                                            sdr[_DbATitle].ToString(), sdr[_DbDirectory].ToString());
                }
            }
            return appendix;
        }

        /// <summary>
        /// 通过公告ID查找附件
        /// </summary>
        public List<Appendix> GetAppendixByBulletinID(int bulletinID)
        {
            List<Appendix> appendixList = new List<Appendix>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_ABulletinID, SqlDbType.Int).Value = bulletinID;

            using (SqlDataReader sdrItem = SqlHelper.ExecuteReader("GetAppendixByBulletinID", cmd))
            {
                while (sdrItem.Read())
                {
                    Appendix appendix =
                        new Appendix(Convert.ToInt32(sdrItem[_DbAppendixID]), Convert.ToInt32(sdrItem[_DbABulletinID]),
                                     sdrItem[_DbATitle].ToString(), sdrItem[_DbDirectory].ToString());
                    appendixList.Add(appendix);
                }
            }
            return appendixList;
        }
    }
}