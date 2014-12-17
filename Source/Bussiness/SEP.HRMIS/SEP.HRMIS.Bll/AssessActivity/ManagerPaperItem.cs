//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ManagerPaperItem.cs
// ������: ����������
// ��������: 2008-05-19
// ����: ��������
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
        /// ������ִ�к󣬻ᱣ�濼������Ӧ�еĿ�����
        /// �쳣���:
        /// 1.��ǰ�������Ƿ�Ϊ20���������������ʾ�������ж�
        /// 2.��ǰҪά���Ŀ������Ƿ���ڣ���������������ʾ�������ж�
        /// 3.��ǰҪά����Items�Ƿ���ڣ�����������������ʾ�������ж�
        /// ҵ�����̣�
        /// 1.��Ч���ж�
        /// 2.���ͨ����Ч���жϣ������IDal�㷽�����濼�����еĿ�����
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
                        //Ӧ�ø÷����Ľ����Է�����ֱ��ע��������� by xwl 2009-7-16
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
