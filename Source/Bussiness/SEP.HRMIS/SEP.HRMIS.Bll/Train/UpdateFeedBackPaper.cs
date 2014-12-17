//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateFeedBackPaper.cs
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
    public class UpdateFeedBackPaper : Transaction
    {
        private static IFeedBackPaper _IFeedBackPaper = DalFactory.DataAccess.CreateFeedBackPaper();
        private readonly FeedBackPaper _Paper;
       
        /// <summary>
        /// 该事务执行后，会修改考评表的基本信息
        /// 异常情况:
        /// 1.当前要修改的考评表是否存在，如果不在则给出提示，事务中断
        /// 2.PaperName不可与已有Paper的PaperName重复，否则给出提示，事务中断
        /// 业务流程：
        /// 1.有效性判断
        /// 2.如果通过有效性判断，则调用IDal层方法进行考评表修改
        /// </summary>

        public UpdateFeedBackPaper(FeedBackPaper paper)
        {
            _Paper = paper;
        }

        ///<summary>
        ///</summary>
        ///<param name="iPaper"></param>
        ///<param name="paper"></param>
        public UpdateFeedBackPaper(IFeedBackPaper iPaper, FeedBackPaper paper)
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
                    _IFeedBackPaper.UpdateFeedBackPaper(_Paper);
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
            if (_IFeedBackPaper.GetFeedBackPaperById(_Paper.FeedBackPaperId) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._FeedBackPaper_Not_Exist);
            }
            if (_IFeedBackPaper.CountFeedBackPaperByPaperNameDiffPKID(_Paper.FeedBackPaperId, _Paper.FeedBackPaperName) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._FeedBackPaper_Name_Repeat);
            }
        }
    }
}