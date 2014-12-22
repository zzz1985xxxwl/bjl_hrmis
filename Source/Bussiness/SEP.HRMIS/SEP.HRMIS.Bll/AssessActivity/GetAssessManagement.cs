//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetAssessTemplateContainer.cs
// 创建者: 刘丹、张珍
// 创建日期: 2008-05-22
// 概述: 查询考评项、考评表
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Positions;
using SEP.Model.Positions;

namespace SEP.HRMIS.Bll.AssessActivity
{
    public class GetAssessManagement
    {
        private static readonly IAssessTemplateItem _IAssessTemplateItem = new AssessTemplateItemDal();
        private static readonly IAssessTemplatePaper _IAssessTemplatePaper = new AssessTemplatePaperDal();
        private static readonly IAssessTemplatePaperBindPosition _IAssessTemplatePaperBindPosition = new AssessTemplatePaperBindPositionDal();
        private static readonly IPositionBll _IPostionBll = BllInstance.PositionBllInstance;
        //Get考评项的3个方法
        public AssessTemplateItem GetTemplateItemById(int id)
        {
            return _IAssessTemplateItem.GetTemplateItemById(id);

        }

        public List<AssessTemplateItem> GetAllTemplateItems()
        {
            return _IAssessTemplateItem.GetAllTemplateItems();
        }

        public List<AssessTemplateItem> GetTemplateItemsByConditon(string question, OperateType type, ItemClassficationEmnu classfication, AssessTemplateItemType itemtype)
        {
            return _IAssessTemplateItem.GetTemplateItemsByConditon(question, type, classfication, itemtype);
        }

        /// <summary>
        /// Get考评表的3个方法
        /// </summary>
        public AssessTemplatePaper GetAssessTempletPaperById(int id)
        {

            return GetTempletPaperAndItemById(id);
            //return _IAssessTemplatePaper.GetAssessTempletPaperById(id);
        }

        //public List<AssessTemplateItem> GetTemplateItemsByConditon(string question, OperateType type)
        //{
        //    throw new System.NotImplementedException();
        //}

        public List<AssessTemplatePaper> GetAllTemplatePaper()
        {
            return _IAssessTemplatePaper.GetAllTemplatePaper();
        }

        public List<AssessTemplatePaper> GetTemplatePapersByPaperName(string paperName)
        {
            return _IAssessTemplatePaper.GetTemplatePapersByPaperName(paperName);
        }
        public List<AssessTemplatePaper> GetTemplatePapersAllInfoByPaperName(string paperName)
        {
            List<AssessTemplatePaper> returnlist = _IAssessTemplatePaper.GetTemplatePapersByPaperName(paperName);
            if (returnlist != null)
            {
                for (int i = 0; i < returnlist.Count; i++)
                {
                    returnlist[i] = GetTempletPaperAndItemById(returnlist[i].AssessTemplatePaperID);
                }
            }
            return returnlist;
        }

        /// <summary>
        /// 
        /// </summary>
        public AssessTemplatePaper GetTempletPaperAndItemById(int paperId)
        {
            AssessTemplatePaper paper = _IAssessTemplatePaper.GetTempletPaperAndItemById(paperId);
            paper.PositionList = _IAssessTemplatePaperBindPosition.GetBindPostionByPaperID(paperId);
            for (int i = 0; i < paper.PositionList.Count;i++ )
            {
                Position p = _IPostionBll.GetPositionById(paper.PositionList[i].Id, null);
                if (p == null)
                {
                    paper.PositionList.RemoveAt(i);
                    i--;
                    continue;
                }
                paper.PositionList[i] = p;
            }
            return paper;
        }

        /// <summary>
        /// 
        /// </summary>
        public int GetTempletPaperIDByEmployeePositionID(int positionID)
        {
            return _IAssessTemplatePaperBindPosition.GetAssessTemplatePaperIDByPositionID(positionID);
        }

        public AssessTemplatePaper GetAssessTempletPaperByName(string name)
        {
            List<AssessTemplatePaper> papers = _IAssessTemplatePaper.GetTemplatePapersByPaperName(name);
            foreach (AssessTemplatePaper paper in papers)
            {
                if (paper.PaperName == name)
                {
                    return GetAssessTempletPaperById(paper.AssessTemplatePaperID);
                }
            }
            return null;
        }

        public AssessTemplateItem GetTemplateItemByName(string question)
        {
            List<AssessTemplateItem> list = GetTemplateItemsByConditon(question,
                                              OperateType.ALL, ItemClassficationEmnu.All,
                                              AssessTemplateItemType.ALL);
            foreach (AssessTemplateItem item in list)
            {
                if (item.Question == question)
                {
                    return GetTemplateItemById(item.AssessTemplateItemID);
                }
            }
            return null;
        }
    }
}
