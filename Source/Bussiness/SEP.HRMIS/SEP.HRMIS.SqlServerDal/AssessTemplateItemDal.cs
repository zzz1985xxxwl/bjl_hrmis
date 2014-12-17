//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AssessTemplateItemDal.cs
// 创建者: 刘丹
// 创建日期: 2008-05-21
// 概述: 实现IAssessTemplateItem接口中的方法
// 修改：添加更新、删除、计算有无重复的考评项3个方法 
// 修改者：张珍
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;


namespace SEP.HRMIS.SqlServerDal
{
    public class AssessTemplateItemDal : IAssessTemplateItem
    {
        private const string _ParmPKID = "@PKID";
        private const string _ParmQuestion = "@Question";
        private const string _ParmItsOperateType = "@OperateType";
        private const string _ParmItemClassfication = "@ItemClassfication";
        private const string _ParmItemOption = "@ItemOption";
        private const string _ParmItemDescription = "@ItemDescription";
        private const string _DbPKID = "PKID";
        private const string _DbQuestion = "Question";
        private const string _DbOperateType = "OperateType";
        private const string _DbItemClassfication = "ItemClassfication";
        private const string _DbItemOption = "ItemOption";
        private const string _DbItemDescription = "ItemDescription";
        private const string _ParmCount = "@count";
        private const string _DbCount = "Counts";
        private readonly int _retVal = -1;

        private const string _ParmAssessTemplateItemType = "@AssessTemplateItemType";
        private const string _DbAssessTemplateItemType = "AssessTemplateItemType";

        /// <summary>
        /// 计算是否有重名的考评项
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public int CountTemplateItemByTitle(string title)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmQuestion, SqlDbType.NVarChar, 100).Value = title;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountTemplateItemByTitle", cmd))
            {
                sdr.Read();
                return sdr.GetInt32(0);
            }
        }

        /// <summary>
        /// 插入考评项
        /// </summary>
        /// <param name="assessTemplateItem"></param>
        /// <returns></returns>
        public int InsertTemplateItem(AssessTemplateItem assessTemplateItem)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmQuestion, SqlDbType.NVarChar, 100).Value = assessTemplateItem.Question;
            cmd.Parameters.Add(_ParmAssessTemplateItemType, SqlDbType.Int).Value = assessTemplateItem.AssessTemplateItemType;
            cmd.Parameters.Add(_ParmItsOperateType, SqlDbType.Int).Value = assessTemplateItem.ItsOperateType;
            cmd.Parameters.Add(_ParmItemClassfication, SqlDbType.Int).Value = assessTemplateItem.Classfication;
            cmd.Parameters.Add(_ParmItemOption, SqlDbType.NVarChar, 1000).Value = assessTemplateItem.Option;
            cmd.Parameters.Add(_ParmItemDescription, SqlDbType.Text).Value = assessTemplateItem.Description;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQueryReturnPKID("AssessTemplateItemInsert", cmd, out pkid);
            return pkid;
        }

        public AssessTemplateItem GetTemplateItemById(int id)
        {
            AssessTemplateItem assessTemplateItem = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = id;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAssessTemplateItemByPKID", cmd))
            {
                while (sdr.Read())
                {
                    assessTemplateItem =
                        new AssessTemplateItem(Convert.ToInt32(sdr[_DbPKID]), sdr[_DbQuestion].ToString(),
                                               (OperateType) sdr[_DbOperateType]);
                    assessTemplateItem.AssessTemplateItemType = (AssessTemplateItemType)sdr[_DbAssessTemplateItemType];
                    assessTemplateItem.Classfication = (ItemClassficationEmnu)sdr[_DbItemClassfication];
                    assessTemplateItem.Option = sdr[_DbItemOption].ToString();
                    assessTemplateItem.Description = sdr[_DbItemDescription].ToString();
                   
                   
                }
                return assessTemplateItem;
            }
        }

        public List<AssessTemplateItem> GetAllTemplateItems()
        {
            List<AssessTemplateItem> assesstemplateItems = new List<AssessTemplateItem>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllTemplateItems", cmd))
            {
                while (sdr.Read())
                {
                    AssessTemplateItem assesstemplateItem =
                        new AssessTemplateItem(Convert.ToInt32(sdr[_DbPKID]), sdr[_DbQuestion].ToString(),
                                               (OperateType)sdr[_DbOperateType]);
                    assesstemplateItem.AssessTemplateItemType = (AssessTemplateItemType)sdr[_DbAssessTemplateItemType];
                    assesstemplateItem.Classfication = (ItemClassficationEmnu)sdr[_DbItemClassfication];
                    assesstemplateItem.Option = sdr[_DbItemOption].ToString();
                    assesstemplateItem.Description = sdr[_DbItemDescription].ToString();
                    assesstemplateItems.Add(assesstemplateItem);
                }
                return assesstemplateItems;
            }
        }


        public List<AssessTemplateItem> GetTemplateItemsByConditon(string question, OperateType type, ItemClassficationEmnu classfication,AssessTemplateItemType itemtype)
        {
            List<AssessTemplateItem> assesstemplateItems = new List<AssessTemplateItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmQuestion, SqlDbType.NVarChar, 100).Value = question;
            cmd.Parameters.Add(_ParmItsOperateType, SqlDbType.Int, 4).Value = (int)type;
            cmd.Parameters.Add(_ParmItemClassfication, SqlDbType.Int, 4).Value = classfication;
            cmd.Parameters.Add(_ParmAssessTemplateItemType, SqlDbType.Int).Value = itemtype;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetTemplateItemsByConditon", cmd))
            {
                while (sdr.Read())
                {
                    AssessTemplateItem assesstemplateItem =
                        new AssessTemplateItem(Convert.ToInt32(sdr[_DbPKID]), sdr[_DbQuestion].ToString(),
                                               (OperateType)sdr[_DbOperateType]);
                    assesstemplateItem.AssessTemplateItemType = (AssessTemplateItemType)sdr[_DbAssessTemplateItemType];
                    assesstemplateItem.Classfication = (ItemClassficationEmnu)sdr[_DbItemClassfication];
                    assesstemplateItem.Option = sdr[_DbItemOption].ToString();
                    assesstemplateItem.Description = sdr[_DbItemDescription].ToString();
                    assesstemplateItems.Add(assesstemplateItem);
                }
                return assesstemplateItems;
            }
        }
        /// <summary>
        /// 补充更新考评项
        /// </summary>
        /// <param name="assessTemplateItem"></param>
        /// <returns></returns>
        public int UpdateTemplateItem(AssessTemplateItem assessTemplateItem)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmCount, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = assessTemplateItem.AssessTemplateItemID;
            cmd.Parameters.Add(_ParmQuestion, SqlDbType.NVarChar, 100).Value = assessTemplateItem.Question;
            cmd.Parameters.Add(_ParmItsOperateType, SqlDbType.Int).Value = assessTemplateItem.ItsOperateType;
            cmd.Parameters.Add(_ParmAssessTemplateItemType, SqlDbType.Int).Value =
               assessTemplateItem.AssessTemplateItemType;
            cmd.Parameters.Add(_ParmItemClassfication, SqlDbType.Int).Value = assessTemplateItem.Classfication;
            cmd.Parameters.Add(_ParmItemOption, SqlDbType.NVarChar, 1000).Value = assessTemplateItem.Option;
            cmd.Parameters.Add(_ParmItemDescription, SqlDbType.Text).Value = assessTemplateItem.Description;
            return SqlHelper.ExecuteNonQuery("AssessTemplateItemUpdate", cmd);

        }
        /// <summary>
        /// 补充删除考评项
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public int DeleteAssessItemByAssessItemID(int itemID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = itemID;
            cmd.Parameters.Add(_ParmCount, SqlDbType.Int).Direction = ParameterDirection.Output;
            return SqlHelper.ExecuteNonQuery("AssessTemplateItemDelete", cmd);
        }
        /// <summary>
        /// 补充计算有没有重名的考评项
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="question"></param>
        /// <returns></returns>
        public int CountTemplateItemByQuestionDiffPKID(int itemID, string question)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmQuestion, SqlDbType.NVarChar, 50).Value = question;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = itemID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountTemplateItemByQuestionDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }
        /// <summary>
        /// 补充查询考评项在考评表中的关系
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public int GetPIShipByItemId(int itemID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.NVarChar, 50).Value = itemID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPIShipByItemId", cmd))
            {
                sdr.Read();
                return sdr.GetInt32(0);
            }
        }
    }
}
