//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InsertAssessItem.cs
// 创建者: 刘丹、张珍
// 创建日期: 2008-05-19
// 概述: 添加考评项
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
        /// 执行该事务时，会新增考评项
        /// 异常情况：
        /// 1.Title不可与已有Item的Title重复，否则给出提示，事务中断
        /// 业务流程：
        /// 1.有效性判断
        /// 2.如果通过有效性判断，则调用IDal层方法进行考评项新增
        /// </summary>
        public InsertAssessItem(AssessTemplateItem item)
        {
            _Item = item;
        }

        /// <summary>
        /// 测试执行的构造函数
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

