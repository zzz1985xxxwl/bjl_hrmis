//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: InsertAssessPaper.cs
// ������: ����������
// ��������: 2008-05-19
// ����: ��ӿ�����
// ----------------------------------------------------------------

using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Positions;
using SEP.Model.Positions;

namespace SEP.HRMIS.Bll.AssessActivity
{
    ///<summary>
    ///</summary>
    public class InsertAssessPaper : Transaction
    {
        private static IAssessTemplatePaper _IAssessTemplatePaper = DalFactory.DataAccess.CreateAssessTemplatePaper();

        private static IAssessTemplatePaperBindPosition _IAssessTemplatePaperBindPosition =
            DalFactory.DataAccess.CreateAssessTemplatePaperBindPosition();

        private static IPositionBll _IPostionBll = BllInstance.PositionBllInstance;
        private readonly AssessTemplatePaper _Paper;

        /// <summary>
        /// ������ִ�к󣬻�����һ��û�п�����Ŀ�����
        /// �쳣���:
        /// 1.Title����������Paper��Title�ظ������������ʾ�������ж�
        /// ҵ�����̣�
        /// 1.��Ч���ж�
        /// 2.���ͨ����Ч���жϣ������IDal�㷽�����п���������
        /// </summary>
        public InsertAssessPaper(AssessTemplatePaper paper)
        {
            _Paper = paper;
        }

        ///<summary>
        ///</summary>
        public InsertAssessPaper(IAssessTemplatePaper iAssessTemplatePaper,
                                 IAssessTemplatePaperBindPosition iAssessTemplatePaperBindPosition,
                                 IPositionBll iPositionBll, AssessTemplatePaper paper):this(paper)
        {
            _IAssessTemplatePaper = iAssessTemplatePaper;
            _IAssessTemplatePaperBindPosition = iAssessTemplatePaperBindPosition;
            _IPostionBll = iPositionBll;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    _Paper.AssessTemplatePaperID = _IAssessTemplatePaper.InsertAssessTemplatePaper(_Paper);
                    foreach (AssessTemplateItem item in _Paper.ItsAssessTemplateItems)
                    {
                        if (item.AssessTemplateItemID != -1)
                            _IAssessTemplatePaper.ManagePaperItems(_Paper.AssessTemplatePaperID,
                                                                   item.AssessTemplateItemID, item.Weight);
                    }
                    InsertBindPosition();
                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        private void InsertBindPosition()
        {
            if (_Paper.PositionList != null)
            {
                foreach (Position position in _Paper.PositionList)
                {
                    _IAssessTemplatePaperBindPosition.Insert(_Paper.AssessTemplatePaperID, position.Id);
                }
            }
        }

        protected override void Validation()
        {
            if (_IAssessTemplatePaper.CountTemplatePaperByPaperName(_Paper.PaperName) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._AssessTemplatePaper_PaperName_Exist);
            }
            ValideBindPosition();
        }

        private void ValideBindPosition()
        {
            if (_Paper.PositionList != null)
            {
                List<string> errorpositionList = new List<string>();
                foreach (Position position in _Paper.PositionList)
                {
                    if (
                        _IAssessTemplatePaperBindPosition.GetAssessTemplatePaperBindPostionByPositionIDDiffPaperID(0,
                                                                                                                   position
                                                                                                                       .
                                                                                                                       Id)
                            .Count > 0)
                    {
                        errorpositionList.Add(_IPostionBll.GetPositionById(position.Id, null).Name);
                    }
                }
                if (errorpositionList.Count > 0)
                {
                    HrmisUtility.ThrowException(
                        string.Format("ְλ��{0}�ѱ�����������ʹ��", RequestUtility.GetNameListString(errorpositionList)));
                }
            }
        }
    }
}