//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InsertFeedBackPaper.cs
// 创建者: 刘丹
// 创建日期: 2008-07-08
// 概述: 修改反馈表
// ----------------------------------------------------------------

using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;


namespace SEP.HRMIS.Bll.Train
{
    ///<summary>
    ///</summary>
    public class InsertFeedBackPaper : Transaction
    {
        private static IFeedBackPaper _IFeedBackPaper = DalFactory.DataAccess.CreateFeedBackPaper();
        private readonly FeedBackPaper _Paper;
        /// <summary>
        /// 该事务执行后，会增加一张没有考评项的考评表
        /// 异常情况:
        /// 1.Title不可与已有Paper的Title重复，否则给出提示，事务中断
        /// 业务流程：
        /// 1.有效性判断
        /// 2.如果通过有效性判断，则调用IDal层方法进行考评表新增
        /// </summary>
        public InsertFeedBackPaper(FeedBackPaper paper)
        {
            _Paper = paper;
        }

        ///<summary>
        ///</summary>
        public InsertFeedBackPaper(IFeedBackPaper iPaper, FeedBackPaper paper)
        {
            _IFeedBackPaper = iPaper;
            _Paper = paper;
        }
        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    _Paper.FeedBackPaperId = _IFeedBackPaper.InsertFeedBackPaper(_Paper);
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
            if (_IFeedBackPaper.CountFeedBackPaperByPaperName(_Paper.FeedBackPaperName) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._FeedBackPaper_Name_Repeat);
            }
        }
    }
}