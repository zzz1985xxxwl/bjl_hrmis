//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateAssessItem.cs
// ������: ����
// ��������: 2008-07-31
// ����: �޸Ŀ�����
// ----------------------------------------------------------------
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;


namespace SEP.HRMIS.Bll.AssessActivity
{
    public class UpdateAssessItem : Transaction
    {
        private static IAssessTemplateItem _IAssessTemplateItem = DalFactory.DataAccess.CreateAssessTemplateItem();
        private readonly AssessTemplateItem _Item;

        /// <summary>
        /// ������ִ�к󣬻��޸Ŀ�����Ļ�����Ϣ
        /// �쳣���:
        /// 1.��ǰҪ�޸ĵĿ������Ƿ���ڣ���������������ʾ�������ж�
        /// 2.Question����������Item��Question�ظ������������ʾ�������ж�
        /// ҵ�����̣�
        /// 1.��Ч���ж�
        /// 2.���ͨ����Ч���жϣ������IDal�㷽�����п������޸�
        /// </summary>

        public UpdateAssessItem(AssessTemplateItem item)
        {
            _Item = item;
        }

        public UpdateAssessItem(IAssessTemplateItem iAssessTemplateItem, AssessTemplateItem item)
        {
            _IAssessTemplateItem = iAssessTemplateItem;
            _Item = item;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _IAssessTemplateItem.UpdateTemplateItem(_Item);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        protected override void Validation()
        {
            if (_IAssessTemplateItem.GetTemplateItemById(_Item.AssessTemplateItemID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._AssessTemplateItem_Not_Exist);
            }
            if (_IAssessTemplateItem.CountTemplateItemByQuestionDiffPKID(_Item.AssessTemplateItemID, _Item.Question) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._AssessTemplateItem_Title_Exist);
            }
        }
    }
}
