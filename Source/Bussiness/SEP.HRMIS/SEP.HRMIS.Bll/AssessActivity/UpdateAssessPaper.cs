//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateAssessPaper.cs
// 创建者: 刘丹、张珍
// 创建日期: 2008-05-19
// 概述: 修改考评表
// ----------------------------------------------------------------
using System.Collections.Generic;
using System.Transactions;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Positions;
using SEP.Model.Positions;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAssessPaper : Transaction
    {
        private static IAssessTemplatePaper _IAssessTemplatePaper = new AssessTemplatePaperDal();

        private static IAssessTemplatePaperBindPosition _IAssessTemplatePaperBindPosition =
            new AssessTemplatePaperBindPositionDal();

        private static IPositionBll _IPostionBll = BllInstance.PositionBllInstance;
        private readonly AssessTemplatePaper _Paper;

        /// <summary>
        /// 该事务执行后，会修改考评表的基本信息
        /// 异常情况:
        /// 1.当前要修改的考评表是否存在，如果不在则给出提示，事务中断
        /// 2.PaperName不可与已有Paper的PaperName重复，否则给出提示，事务中断
        /// 业务流程：
        /// 1.有效性判断
        /// 2.如果通过有效性判断，则调用IDal层方法进行考评表修改
        /// </summary>
        public UpdateAssessPaper(AssessTemplatePaper paper)
        {
            _Paper = paper;
        }

        /// <summary>
        /// test
        /// </summary>
        public UpdateAssessPaper(IAssessTemplatePaper iAssessTemplatePaper,
                                 IAssessTemplatePaperBindPosition iAssessTemplatePaperBindPosition,
                                 IPositionBll ipositionbll, AssessTemplatePaper paper):this(paper)
        {
            _IAssessTemplatePaper = iAssessTemplatePaper;
            _IAssessTemplatePaperBindPosition = iAssessTemplatePaperBindPosition;
            _IPostionBll = ipositionbll;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    _IAssessTemplatePaper.UpdateTemplatePaper(_Paper);
                    _IAssessTemplatePaper.DeleteAllItemsInPaper(_Paper.AssessTemplatePaperID);
                    foreach (AssessTemplateItem item in _Paper.ItsAssessTemplateItems)
                    {
                        if (item.AssessTemplateItemID != -1)
                            _IAssessTemplatePaper.ManagePaperItems(_Paper.AssessTemplatePaperID,
                                                                   item.AssessTemplateItemID, item.Weight);
                    }
                    UpdateBindPosition();
                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        private void UpdateBindPosition()
        {
            _IAssessTemplatePaperBindPosition.DeleteByPaperID(_Paper.AssessTemplatePaperID);
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
            if (_IAssessTemplatePaper.GetAssessTempletPaperById(_Paper.AssessTemplatePaperID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._AssessTemplatePaper_Not_Exist);
            }
            if (
                _IAssessTemplatePaper.CountTemplatePaperByPaperNameDiffPKID(_Paper.AssessTemplatePaperID,
                                                                            _Paper.PaperName) > 0)
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
                        _IAssessTemplatePaperBindPosition.GetAssessTemplatePaperBindPostionByPositionIDDiffPaperID(
                            _Paper.AssessTemplatePaperID, position.Id).Count > 0)
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