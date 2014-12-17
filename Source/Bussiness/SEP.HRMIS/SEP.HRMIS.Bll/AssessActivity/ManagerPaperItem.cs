//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ManagerPaperItem.cs
// 创建者: 刘丹、张珍
// 创建日期: 2008-05-19
// 概述: 管理考评项
// ----------------------------------------------------------------
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.IDal;

namespace SEP.HRMIS.Bll.AssessActivity
{
    public class ManagerPaperItem : Transaction
    {
        private static IAssessTemplatePaper _IAssessTemplatePaper = DalFactory.DataAccess.CreateAssessTemplatePaper();
        private static IAssessTemplateItem _IItem = DalFactory.DataAccess.CreateAssessTemplateItem();
        private readonly int _AssessPaperID;
        private readonly List<int> _AssessTemplateItemsId;

        /// <summary>
        /// 该事务执行后，会保存考评表中应有的考评项
        /// 异常情况:
        /// 1.当前考评项是否为20项，如果不是则给出提示，事务中断
        /// 2.当前要维护的考评表是否存在，如果不在则给出提示，事务中断
        /// 3.当前要维护的Items是否存在，如果不存在则给出提示，事务中断
        /// 业务流程：
        /// 1.有效性判断
        /// 2.如果通过有效性判断，则调用IDal层方法保存考评表中的考评项
        /// </summary>      
        public ManagerPaperItem(int paperId, List<int> items)
        {
            _AssessTemplateItemsId = items;
            _AssessPaperID = paperId;
        }

        public ManagerPaperItem(int paperId, IAssessTemplatePaper iPaper, IAssessTemplateItem iItem, List<int> itemsId)
        {
            _IAssessTemplatePaper = iPaper;
            _AssessPaperID = paperId;
            _AssessTemplateItemsId = itemsId;
            _IItem = iItem;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _IAssessTemplatePaper.DeleteAllItemsInPaper(_AssessPaperID);

                    foreach (int i in _AssessTemplateItemsId)
                    {
                        //应用该方法的界面以废弃，直接注释下面代码 by xwl 2009-7-16
                        //_IAssessTemplatePaper.ManagePaperItems(_AssessPaperID, i);
                    }
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
            //if (_AssessTemplateItemsId.Count != AAUtility._RightItemCount)
            //{
            //    BllUtility.ThrowException(BllExceptionConst._AssessTemplatePaper_Not_20);
            //}

            if (_IAssessTemplatePaper.GetAssessTempletPaperById(_AssessPaperID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._AssessTemplatePaper_Not_Exist);
            }

            foreach (int id in _AssessTemplateItemsId)
            {
                if (_IItem.GetTemplateItemById(id) == null)
                {
                    BllUtility.ThrowException(BllExceptionConst._AssessTemplateItem_Not_Exist);
                }
            }
        }
    }
}
