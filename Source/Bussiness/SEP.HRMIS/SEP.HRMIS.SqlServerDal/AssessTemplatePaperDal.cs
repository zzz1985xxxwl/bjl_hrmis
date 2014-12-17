//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AssessTemplatePaperDal.cs
// 创建者: 刘丹
// 创建日期: 2008-05-21
// 概述: 实现IAssessTemplatePaper接口中的方法
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;


namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 
    /// </summary>
    public class AssessTemplatePaperDal : IAssessTemplatePaper
    {
        private const string _ParmPaperName = "@PaperName";
        private const string _ParmPKID = "@PKID";
        private const string _ParmCount = "@count";
        private const string _DbPaperName = "PaperName";
        private const string _DbPKID = "PKID";
        private const string _ParmPaperID = "@PaperID";
        private const string _ParmItemID = "@ItemID";
        private const string _ParmWeight = "@Weight";
        private const string _DbItemID = "ItemID";
        private const string _DbQuestion = "Question";
        private const string _DbOperateType = "OperateType";
        private const string _DbItemClassfication = "ItemClassfication";
        private const string _DbItemOption = "ItemOption";
        private const string _DbItemDescription = "ItemDescription";
        private const string _DbAssessTemplateItemType = "AssessTemplateItemType";
        private const string _DbWeight = "Weight";
        /// <summary>
        /// 更新考评表
        /// </summary>
        /// <param name="assessTemplatePaper"></param>
        /// <returns></returns>
        public int UpdateTemplatePaper(AssessTemplatePaper assessTemplatePaper)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmCount, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = assessTemplatePaper.AssessTemplatePaperID;
            cmd.Parameters.Add(_ParmPaperName, SqlDbType.NVarChar, 50).Value = assessTemplatePaper.PaperName;
            return SqlHelper.ExecuteNonQuery("AssessTemplatePaperUpdate", cmd);
        }

        /// <summary>
        /// 插入考评表
        /// </summary>
        /// <param name="assessTemplatePaper"></param>
        /// <returns></returns>
        public int InsertAssessTemplatePaper(AssessTemplatePaper assessTemplatePaper)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPaperName, SqlDbType.NVarChar, 50).Value = assessTemplatePaper.PaperName;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQueryReturnPKID("AssessTemplatePaperInsert", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 通过Id取考评表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AssessTemplatePaper GetAssessTempletPaperById(int id)
        {
            AssessTemplatePaper templatePaper=null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = id;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAssessTemplatePaperByPKID", cmd))
            {
                while (sdr.Read())
                {
                    templatePaper =
                        new AssessTemplatePaper(Convert.ToInt32(sdr[_DbPKID]), sdr[_DbPaperName].ToString(),
                                                new List<AssessTemplateItem>());
                }
                return templatePaper;
            }
        }

        /// <summary>
        /// 通过Id取考评表以及考评项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AssessTemplatePaper GetTempletPaperAndItemById(int id)
        {
            List<AssessTemplateItem> items = new List<AssessTemplateItem>();
            AssessTemplatePaper templatePaper = GetAssessTempletPaperById(id);
            if (templatePaper != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = id;
                using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetTemplateItemIdInPaperByPaperId", cmd))
                {
                    while (sdr.Read())
                    {
                        AssessTemplateItem item =
                            new AssessTemplateItem(Convert.ToInt32(sdr[_DbItemID]), sdr[_DbQuestion].ToString(),
                                                   (OperateType) Convert.ToInt32(sdr[_DbOperateType]));
                        item.Classfication = (ItemClassficationEmnu)sdr[_DbItemClassfication];
                        item.Option = sdr[_DbItemOption].ToString();
                        item.Description = sdr[_DbItemDescription].ToString();
                        item.AssessTemplateItemType = (AssessTemplateItemType) sdr[_DbAssessTemplateItemType];
                        item.Weight = Convert.ToDecimal(sdr[_DbWeight]);
                        items.Add(item);
                    }
                    templatePaper.ItsAssessTemplateItems = items;
                }
            }
            return templatePaper;
        }

        /// <summary>
        /// 计算有没有重名的考评表
        /// </summary>
        /// <param name="paperName"></param>
        /// <returns></returns>
        public int CountTemplatePaperByPaperName(string paperName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPaperName, SqlDbType.NVarChar, 50).Value = paperName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountTemplatePaperByPaperName", cmd))
            {
                sdr.Read();
                return sdr.GetInt32(0);
            }
        }

        /// <summary>
        /// 计算有没有重名的考评表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paperName"></param>
        /// <returns></returns>
        public int CountTemplatePaperByPaperNameDiffPKID(int id, string paperName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPaperName, SqlDbType.NVarChar, 50).Value = paperName;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = id;

            using(SqlDataReader sdr = SqlHelper.ExecuteReader("CountTemplatePaperByPaperNameDiffPKID", cmd))
            {
                sdr.Read();
                return sdr.GetInt32(0);
            }
        }

        /// <summary>
        /// 删除考评表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteAssessPaperByAssessPaperID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = id;
            cmd.Parameters.Add(_ParmCount, SqlDbType.Int).Direction = ParameterDirection.Output;
            return SqlHelper.ExecuteNonQuery("AssessTemplatePaperDelete", cmd);
        }

        /// <summary>
        /// 在考评表与考评项的关系表中添加关系
        /// </summary>
        public int ManagePaperItems(int paperId, int itemId,decimal weight)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_ParmPaperID, SqlDbType.Int).Value = paperId;
            cmd.Parameters.Add(_ParmItemID, SqlDbType.Int).Value = itemId;
            cmd.Parameters.Add(_ParmWeight, SqlDbType.Decimal).Value = weight;
            SqlHelper.ExecuteNonQueryReturnPKID("AssessTemplatePIShipInsert", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 删除考评表与考评项的关系
        /// </summary>
        /// <param name="paperId"></param>
        /// <returns></returns>
        public int DeleteAllItemsInPaper(int paperId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPaperID, SqlDbType.Int).Value = paperId;
            return SqlHelper.ExecuteNonQuery("DeletePaperAndItemRelation", cmd);
        }

        /// <summary>
        /// 得到所有的考评表
        /// </summary>
        /// <returns></returns>
        public List<AssessTemplatePaper> GetAllTemplatePaper()
        {
            List<AssessTemplatePaper> papers = new List<AssessTemplatePaper>();
            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllAssessTemplatePaper", cmd))
            {
                while (sdr.Read())
                {
                    AssessTemplatePaper paper =
                        new AssessTemplatePaper(Convert.ToInt32(sdr[_DbPKID]), sdr[_DbPaperName].ToString(),
                                                new List<AssessTemplateItem>());
                    papers.Add(paper);
                }
                return papers;
            }
        }

        /// <summary>
        /// 根据名称查找考评表
        /// </summary>
        /// <param name="paperName"></param>
        /// <returns></returns>
        public List<AssessTemplatePaper> GetTemplatePapersByPaperName(string paperName)
        {
            List<AssessTemplatePaper> papers = new List<AssessTemplatePaper>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPaperName, SqlDbType.NVarChar, 50).Value = paperName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAssessTemplatePaperByPaperName", cmd))
            {
                while (sdr.Read())
                {
                    AssessTemplatePaper paper =
                        new AssessTemplatePaper(Convert.ToInt32(sdr[_DbPKID]), sdr[_DbPaperName].ToString(),
                                                new List<AssessTemplateItem>());
                    papers.Add(paper);
                }
                return papers;
            }
        }

        /// <summary>
        /// 根据名称查找考评表
        /// </summary>
        /// <param name="paperName"></param>
        /// <returns></returns>
        public AssessTemplatePaper GetTemplatePapersExactlyByPaperName(string paperName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPaperName, SqlDbType.NVarChar, 50).Value = paperName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetTemplatePapersExactlyByPaperName", cmd))
            {
                while (sdr.Read())
                {
                    AssessTemplatePaper paper =
                        new AssessTemplatePaper(Convert.ToInt32(sdr[_DbPKID]), sdr[_DbPaperName].ToString(),
                                                new List<AssessTemplateItem>());
                    return paper;
                }
                return null;
            }
        }
    }

}
