//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateFeedBackPaper.cs
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
    public class UpdateFeedBackPaper : Transaction
    {
        private static IFeedBackPaper _IFeedBackPaper = DalFactory.DataAccess.CreateFeedBackPaper();
        private readonly FeedBackPaper _Paper;
       
        /// <summary>
        /// ������ִ�к󣬻��޸Ŀ�����Ļ�����Ϣ
        /// �쳣���:
        /// 1.��ǰҪ�޸ĵĿ������Ƿ���ڣ���������������ʾ�������ж�
        /// 2.PaperName����������Paper��PaperName�ظ������������ʾ�������ж�
        /// ҵ�����̣�
        /// 1.��Ч���ж�
        /// 2.���ͨ����Ч���жϣ������IDal�㷽�����п������޸�
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