//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteAssessItem.cs
// 创建者: 张珍
// 创建日期: 2008-07-31
// 概述: 删除考评项
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
        /// 该事务执行后，会删除考评项的所有信息
        /// 异常情况:
        /// 1.当前要删除的考评项是否存在，如果不在则给出提示，事务中断
        /// 2.当前要删除的考评项与考评表有关系，如果是某考评表中的考评项，给出提示，事务中断
        /// 业务流程：
        /// 1.有效性判断
        /// 2.如果通过有效性判断，则调用IDal层方法进行考评项的删除（其中包括考评项中与考评项关系的删除）
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
