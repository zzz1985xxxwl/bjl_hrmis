//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteFeedBackPaper.cs
// 创建者: 刘丹
// 创建日期: 2009-07-08
// 概述: 删除反馈表
// ----------------------------------------------------------------
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.Train
{
    ///<summary>
    ///</summary>
    public class DeleteFeedBackPaper : Transaction
    {
        private static IFeedBackPaper _IFeedBackPaper = new FeedBackPaperDal();
        private readonly int _PaperID;

        /// <summary>
        /// 该事务执行后，会删除考评表的所有信息
        /// 异常情况:
        /// 1.当前要删除的考评表是否存在，如果不在则给出提示，事务中断
        /// 业务流程：
        /// 1.有效性判断
        /// 2.如果通过有效性判断，则调用IDal层方法进行考评表的删除（其中包括考评表中与考评项关系的删除）
        /// </summary>
       
        public DeleteFeedBackPaper(int paperID)
        {
            _PaperID = paperID;
        }

        ///<summary>
        ///</summary>
        ///<param name="iPaper"></param>
        ///<param name="paperID"></param>
        public DeleteFeedBackPaper(IFeedBackPaper iPaper, int paperID)
        {
            _IFeedBackPaper = iPaper;
            _PaperID = paperID;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _IFeedBackPaper.DeleteFeedBackPaperByID(_PaperID);
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
            if (_IFeedBackPaper.GetFeedBackPaperById(_PaperID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._FeedBackPaper_Not_Exist); 
            }
        }
    }
}