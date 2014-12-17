//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: MakeAssessPaper.cs
// ������: �ߺ�
// ��������: 2008-05-20
// ����: ���ڴ�������ģ�嵽�������ת��
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// ���ڴ�������ģ�嵽�������ת��
    /// </summary>
    public class MakeAssessPaper
    {
        private readonly AssessTemplatePaper _AssessTemplatePaper;
        private readonly Model.AssessActivity _AssessActivity;

        /// <summary>
        /// 
        /// </summary>
        public MakeAssessPaper(AssessTemplatePaper assessTemplatePaper, Model.AssessActivity assessActivity)
        {
            _AssessTemplatePaper = assessTemplatePaper;
            _AssessActivity = assessActivity;
        }

        #region MakePaper
        ///// <summary>
        ///// ��������ģ��ת���ɿ���������
        ///// </summary>
        //public AssessActivityPaper MakePaper()
        //{
        //    _RetValue = new AssessActivityPaper(_AssessTemplatePaper.PaperName);

        //    List<AssessTemplateItem> assessTemplateItems = _AssessTemplatePaper.ItsAssessTemplateItems;

        //    foreach (AssessTemplateItem ati in assessTemplateItems)
        //    {
        //        if (ati.ItsOperateType == OperateType.HR)
        //        {
        //            AddHrItem(ati);
        //        }
        //        else
        //        {
        //            AddNonHrItem(ati);
        //        }
        //    }

        //    return _RetValue;
        //}
        #endregion

        /// <summary>
        /// AssessActivityPaper�е�������
        /// </summary>
        /// <returns></returns>
        public List<AssessActivityItem> HrItems()
        {
            List<AssessActivityItem> iRet = new List<AssessActivityItem>();
            List<AssessTemplateItem> assessTemplateItems = _AssessTemplatePaper.ItsAssessTemplateItems;

            foreach (AssessTemplateItem ati in assessTemplateItems)
            {
                if (ati.ItsOperateType == OperateType.HR)
                {
                    AssessActivityItem hrItem = new AssessActivityItem(ati.Question, ati.Option, ati.Classfication, ati.Description);
                    hrItem.AssessTemplateItemType = ati.AssessTemplateItemType;
                    hrItem.Note = string.Empty;
                    hrItem.Weight = ati.Weight;
                    if (ati.AssessTemplateItemType == AssessTemplateItemType.Formula)
                    {
                        hrItem.Grade =
                            new CalculateFormula().Calculate(_AssessActivity.ItsEmployee.Account.Id, _AssessActivity.ScopeFrom,
                                                             _AssessActivity.ScopeTo, ati.Option);
                    }
                    else
                    {
                        hrItem.Grade = 0;
                    }
                    iRet.Add(hrItem);
                }
            }

            return iRet;
        }

        /// <summary>
        /// AssessActivityPaper�е�������
        /// </summary>
        /// <returns></returns>
        public List<AssessActivityItem> NotHrItems()
        {
            List<AssessActivityItem> iRet = new List<AssessActivityItem>();
            List<AssessTemplateItem> assessTemplateItems = _AssessTemplatePaper.ItsAssessTemplateItems;

            foreach (AssessTemplateItem ati in assessTemplateItems)
            {
                if (ati.ItsOperateType != OperateType.HR)
                {
                    AssessActivityItem manageItem = new AssessActivityItem(ati.Question, ati.Option, ati.Classfication, ati.Description);
                    manageItem.AssessTemplateItemType = ati.AssessTemplateItemType;
                    manageItem.Note = string.Empty;
                    manageItem.Weight = ati.Weight;
                    if (ati.AssessTemplateItemType == AssessTemplateItemType.Formula)
                    {
                        manageItem.Grade =
                            new CalculateFormula().Calculate(_AssessActivity.ItsEmployee.Account.Id, _AssessActivity.ScopeFrom,
                                                             _AssessActivity.ScopeTo, ati.Option);
                    }
                    else
                    {
                        manageItem.Grade = 0;
                    }
                    iRet.Add(manageItem);
                }
            }

            return iRet;
        }
    }
}