//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateAssessItem.cs
// 创建者: 张珍
// 创建日期: 2008-07-31
// 概述: 修改考评项
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
        /// 该事务执行后，会修改考评表的基本信息
        /// 异常情况:
        /// 1.当前要修改的考评项是否存在，如果不在则给出提示，事务中断
        /// 2.Question不可与已有Item的Question重复，否则给出提示，事务中断
        /// 业务流程：
        /// 1.有效性判断
        /// 2.如果通过有效性判断，则调用IDal层方法进行考评表修改
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
