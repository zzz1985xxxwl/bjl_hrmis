//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateAssessPaper.cs
// ������: ����������
// ��������: 2008-05-19
// ����: �޸Ŀ�����
// ----------------------------------------------------------------
using System.Collections.Generic;
using System.Transactions;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Positions;
using SEP.Model.Positions;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAssessPaper : Transaction
    {
        private static IAssessTemplatePaper _IAssessTemplatePaper = new AssessTemplatePaperDal();

        private static IAssessTemplatePaperBindPosition _IAssessTemplatePaperBindPosition =
            new AssessTemplatePaperBindPositionDal();

        private static IPositionBll _IPostionBll = BllInstance.PositionBllInstance;
        private readonly AssessTemplatePaper _Paper;

        /// <summary>
        /// ������ִ�к󣬻��޸Ŀ�����Ļ�����Ϣ
        /// �쳣���:
        /// 1.��ǰҪ�޸ĵĿ������Ƿ���ڣ���������������ʾ�������ж�
        /// 2.PaperName����������Paper��PaperName�ظ������������ʾ�������ж�
        /// ҵ�����̣�
        /// 1.��Ч���ж�
        /// 2.���ͨ����Ч���жϣ������IDal�㷽�����п������޸�
        /// </summary>
        public UpdateAssessPaper(AssessTemplatePaper paper)
        {
            _Paper = paper;
        }

        /// <summary>
        /// test
        /// </summary>
        public UpdateAssessPaper(IAssessTemplatePaper iAssessTemplatePaper,
                                 IAssessTemplatePaperBindPosition iAssessTemplatePaperBindPosition,
                                 IPositionBll ipositionbll, AssessTemplatePaper paper):this(paper)
        {
            _IAssessTemplatePaper = iAssessTemplatePaper;
            _IAssessTemplatePaperBindPosition = iAssessTemplatePaperBindPosition;
            _IPostionBll = ipositionbll;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    _IAssessTemplatePaper.UpdateTemplatePaper(_Paper);
                    _IAssessTemplatePaper.DeleteAllItemsInPaper(_Paper.AssessTemplatePaperID);
                    foreach (AssessTemplateItem item in _Paper.ItsAssessTemplateItems)
                    {
                        if (item.AssessTemplateItemID != -1)
                            _IAssessTemplatePaper.ManagePaperItems(_Paper.AssessTemplatePaperID,
                                                                   item.AssessTemplateItemID, item.Weight);
                    }
                    UpdateBindPosition();
                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        private void UpdateBindPosition()
        {
            _IAssessTemplatePaperBindPosition.DeleteByPaperID(_Paper.AssessTemplatePaperID);
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
            if (_IAssessTemplatePaper.GetAssessTempletPaperById(_Paper.AssessTemplatePaperID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._AssessTemplatePaper_Not_Exist);
            }
            if (
                _IAssessTemplatePaper.CountTemplatePaperByPaperNameDiffPKID(_Paper.AssessTemplatePaperID,
                                                                            _Paper.PaperName) > 0)
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
                        _IAssessTemplatePaperBindPosition.GetAssessTemplatePaperBindPostionByPositionIDDiffPaperID(
                            _Paper.AssessTemplatePaperID, position.Id).Count > 0)
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