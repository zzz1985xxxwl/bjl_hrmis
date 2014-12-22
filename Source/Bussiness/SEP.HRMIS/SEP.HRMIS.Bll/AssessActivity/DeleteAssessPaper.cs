//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteAssessPaper.cs
// 创建者: 刘丹、张珍
// 创建日期: 2008-05-19
// 概述: 删除考评表
// ----------------------------------------------------------------
using System.Transactions;

using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAssessPaper : Transaction
    {
        private static IAssessTemplatePaper _IAssessTemplatePaper = new AssessTemplatePaperDal();

        private static IAssessTemplatePaperBindPosition _IAssessTemplatePaperBindPosition =
            new AssessTemplatePaperBindPositionDal();

        private readonly int _AssessPaperID;

        /// <summary>
        /// 该事务执行后，会删除考评表的所有信息
        /// 异常情况:
        /// 1.当前要删除的考评表是否存在，如果不在则给出提示，事务中断
        /// 业务流程：
        /// 1.有效性判断
        /// 2.如果通过有效性判断，则调用IDal层方法进行考评表的删除（其中包括考评表中与考评项关系的删除）
        /// </summary>
        public DeleteAssessPaper(int assessPaperID)
        {
            _AssessPaperID = assessPaperID;
        }

        /// <summary>
        /// test
        /// </summary>
        public DeleteAssessPaper(IAssessTemplatePaper iAssessTemplatePaper,
                                 IAssessTemplatePaperBindPosition paperbindposition, int assessPaperID)
            : this(assessPaperID)
        {
            _IAssessTemplatePaper = iAssessTemplatePaper;
            _IAssessTemplatePaperBindPosition = paperbindposition;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _IAssessTemplatePaper.DeleteAssessPaperByAssessPaperID(_AssessPaperID);
                    _IAssessTemplatePaper.DeleteAllItemsInPaper(_AssessPaperID);
                    _IAssessTemplatePaperBindPosition.DeleteByPaperID(_AssessPaperID);
                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        protected override void Validation()
        {
            if (_IAssessTemplatePaper.GetAssessTempletPaperById(_AssessPaperID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._AssessTemplatePaper_Not_Exist);
            }
        }
    }
}