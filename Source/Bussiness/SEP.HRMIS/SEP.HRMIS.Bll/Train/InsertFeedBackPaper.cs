//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: InsertFeedBackPaper.cs
// ������: ����
// ��������: 2008-07-08
// ����: �޸ķ�����
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
        /// ������ִ�к󣬻�����һ��û�п�����Ŀ�����
        /// �쳣���:
        /// 1.Title����������Paper��Title�ظ������������ʾ�������ж�
        /// ҵ�����̣�
        /// 1.��Ч���ж�
        /// 2.���ͨ����Ч���жϣ������IDal�㷽�����п���������
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