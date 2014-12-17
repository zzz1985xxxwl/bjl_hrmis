//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: MakeAssessPaper.cs
// 创建者: 倪豪
// 创建日期: 2008-05-20
// 概述: 用于处理考评表模板到考评表的转换
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 用于处理考评表模板到考评表的转换
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
        ///// 将考评表模板转换成考评表并返回
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
        /// AssessActivityPaper中的人事项
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
        /// AssessActivityPaper中的主管项
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