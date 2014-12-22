//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteAssessItem.cs
// ������: ����
// ��������: 2008-07-31
// ����: ɾ��������
// ----------------------------------------------------------------
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.AssessActivity
{
    public class DeleteAssessItem : Transaction
    {
        private static IAssessTemplateItem _IAssessTemplateItem = new AssessTemplateItemDal();
        private readonly int _AssessItemID;

        /// <summary>
        /// ������ִ�к󣬻�ɾ���������������Ϣ
        /// �쳣���:
        /// 1.��ǰҪɾ���Ŀ������Ƿ���ڣ���������������ʾ�������ж�
        /// 2.��ǰҪɾ���Ŀ������뿼�����й�ϵ�������ĳ�������еĿ����������ʾ�������ж�
        /// ҵ�����̣�
        /// 1.��Ч���ж�
        /// 2.���ͨ����Ч���жϣ������IDal�㷽�����п������ɾ�������а������������뿼�����ϵ��ɾ����
        /// </summary>

        public DeleteAssessItem(int assessItemID)
        {
            _AssessItemID = assessItemID;
        }

        public DeleteAssessItem(IAssessTemplateItem iAssessTemplateItem, int assessItemID)
        {
            _IAssessTemplateItem = iAssessTemplateItem;
            _AssessItemID = assessItemID;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _IAssessTemplateItem.DeleteAssessItemByAssessItemID(_AssessItemID);
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
            if (_IAssessTemplateItem.GetTemplateItemById(_AssessItemID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._AssessTemplateItem_Not_Exist);
            }
            if (_IAssessTemplateItem.GetPIShipByItemId(_AssessItemID) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._AssessTemplateItem_In_AssessTemplatePaper);
            }
        }
    }
}
