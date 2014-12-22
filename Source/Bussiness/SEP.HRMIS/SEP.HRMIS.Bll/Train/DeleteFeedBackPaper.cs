//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteFeedBackPaper.cs
// ������: ����
// ��������: 2009-07-08
// ����: ɾ��������
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
        /// ������ִ�к󣬻�ɾ���������������Ϣ
        /// �쳣���:
        /// 1.��ǰҪɾ���Ŀ������Ƿ���ڣ���������������ʾ�������ж�
        /// ҵ�����̣�
        /// 1.��Ч���ж�
        /// 2.���ͨ����Ч���жϣ������IDal�㷽�����п������ɾ�������а������������뿼�����ϵ��ɾ����
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