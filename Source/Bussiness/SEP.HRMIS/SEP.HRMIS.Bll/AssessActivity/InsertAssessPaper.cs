//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InsertAssessPaper.cs
// 创建者: 刘丹、张珍
// 创建日期: 2008-05-19
// 概述: 添加考评表
// ----------------------------------------------------------------

using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Positions;
using SEP.Model.Positions;

namespace SEP.HRMIS.Bll.AssessActivity
{
    ///<summary>
    ///</summary>
    public class InsertAssessPaper : Transaction
    {
        private static IAssessTemplatePaper _IAssessTemplatePaper = DalFactory.DataAccess.CreateAssessTemplatePaper();

        private static IAssessTemplatePaperBindPosition _IAssessTemplatePaperBindPosition =
            DalFactory.DataAccess.CreateAssessTemplatePaperBindPosition();

        private static IPositionBll _IPostionBll = BllInstance.PositionBllInstance;
        private readonly AssessTemplatePaper _Paper;

        /// <summary>
        /// 该事务执行后，会增加一张没有考评项的考评表
        /// 异常情况:
        /// 1.Title不可与已有Paper的Title重复，否则给出提示，事务中断
        /// 业务流程：
        /// 1.有效性判断
        /// 2.如果通过有效性判断，则调用IDal层方法进行考评表新增
        /// </summary>
        public InsertAssessPaper(AssessTemplatePaper paper)
        {
            _Paper = paper;
        }

        ///<summary>
        ///</summary>
        public InsertAssessPaper(IAssessTemplatePaper iAssessTemplatePaper,
                                 IAssessTemplatePaperBindPosition iAssessTemplatePaperBindPosition,
                                 IPositionBll iPositionBll, AssessTemplatePaper paper):this(paper)
        {
            _IAssessTemplatePaper = iAssessTemplatePaper;
            _IAssessTemplatePaperBindPosition = iAssessTemplatePaperBindPosition;
            _IPostionBll = iPositionBll;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    _Paper.AssessTemplatePaperID = _IAssessTemplatePaper.InsertAssessTemplatePaper(_Paper);
                    foreach (AssessTemplateItem item in _Paper.ItsAssessTemplateItems)
                    {
                        if (item.AssessTemplateItemID != -1)
                            _IAssessTemplatePaper.ManagePaperItems(_Paper.AssessTemplatePaperID,
                                                                   item.AssessTemplateItemID, item.Weight);
                    }
                    InsertBindPosition();
                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        private void InsertBindPosition()
        {
            if (_Paper.PositionList != null)
            {
                foreach (Position position in _Paper.PositionList)
                {
                    _IAssessTemplatePaperBindPosition.Insert(_Paper.AssessTemplatePaperID, position.Id);
                }
            }
        }

        protected override void Validation()
        {
            if (_IAssessTemplatePaper.CountTemplatePaperByPaperName(_Paper.PaperName) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._AssessTemplatePaper_PaperName_Exist);
            }
            ValideBindPosition();
        }

        private void ValideBindPosition()
        {
            if (_Paper.PositionList != null)
            {
                List<string> errorpositionList = new List<string>();
                foreach (Position position in _Paper.PositionList)
                {
                    if (
                        _IAssessTemplatePaperBindPosition.GetAssessTemplatePaperBindPostionByPositionIDDiffPaperID(0,
                                                                                                                   position
                                                                                                                       .
                                                                                                                       Id)
                            .Count > 0)
                    {
                        errorpositionList.Add(_IPostionBll.GetPositionById(position.Id, null).Name);
                    }
                }
                if (errorpositionList.Count > 0)
                {
                    HrmisUtility.ThrowException(
                        string.Format("职位：{0}已被其它考评表使用", RequestUtility.GetNameListString(errorpositionList)));
                }
            }
        }
    }
}