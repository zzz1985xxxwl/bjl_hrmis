//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: InsertAssessItem.cs
// ������: ����������
// ��������: 2008-05-19
// ����: ��ӿ�����
// ----------------------------------------------------------------
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.AssessActivity
{
    public class InsertAssessItem : Transaction
    {
        private static IAssessTemplateItem _IAssessTemplateItem = DalFactory.DataAccess.CreateAssessTemplateItem();
        private readonly  AssessTemplateItem _Item;

        /// <summary>
        /// ִ�и�����ʱ��������������
        /// �쳣�����
        /// 1.Title����������Item��Title�ظ������������ʾ�������ж�
        /// ҵ�����̣�
        /// 1.��Ч���ж�
        /// 2.���ͨ����Ч���жϣ������IDal�㷽�����п���������
        /// </summary>
        public InsertAssessItem(AssessTemplateItem item)
        {
            _Item = item;
        }

        /// <summary>
        /// ����ִ�еĹ��캯��
        /// </summary>
        /// <param name="iAssessTemplateItem"></param>
        /// <param name="item"></param>
        public InsertAssessItem(IAssessTemplateItem iAssessTemplateItem,AssessTemplateItem item)
        {
            _IAssessTemplateItem = iAssessTemplateItem;
            _Item = item;
           
        }

        protected override void ExcuteSelf()
        {
            try
            {
                int ret = _IAssessTemplateItem.InsertTemplateItem(_Item);
                _Item.AssessTemplateItemID = ret;
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        protected override void Validation()
        {
            //if (_title == "")
            //{
            //    BllUtility.ThrowException(BllExceptionConst._AssessTemplateItem_Title_Null);
            //}

            if (_IAssessTemplateItem.CountTemplateItemByTitle(_Item.Question) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._AssessTemplateItem_Title_Exist);
            }
        }
    }

}

