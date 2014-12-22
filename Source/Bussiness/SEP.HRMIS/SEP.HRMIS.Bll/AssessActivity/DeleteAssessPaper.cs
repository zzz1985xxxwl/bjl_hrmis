//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteAssessPaper.cs
// ������: ����������
// ��������: 2008-05-19
// ����: ɾ��������
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
        /// ������ִ�к󣬻�ɾ���������������Ϣ
        /// �쳣���:
        /// 1.��ǰҪɾ���Ŀ������Ƿ���ڣ���������������ʾ�������ж�
        /// ҵ�����̣�
        /// 1.��Ч���ж�
        /// 2.���ͨ����Ч���жϣ������IDal�㷽�����п������ɾ�������а������������뿼�����ϵ��ɾ����
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