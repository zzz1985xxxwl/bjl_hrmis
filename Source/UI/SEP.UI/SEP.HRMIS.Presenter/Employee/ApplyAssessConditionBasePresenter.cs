//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: SalaryWeightDeletePresenter.cs
// 创建者:wangshali
// 创建日期: 2008-08-10
// 概述: 删除工资系数
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class ApplyAssessConditionBasePresenter
    {
        public void InitBaseView(IApplyAssessConditionView view, bool isPageValid)
        {
            view.Message = string.Empty;
            view.ApplyDateMsg = string.Empty;
            view.ScopeMsg = string.Empty;
            if (!isPageValid)
            {
                view.AssessCharacterTypes = AssessActivityUtility.GetCharacterTypeEnum();
            }
        }
        public bool Validation(IApplyAssessConditionView view)
        {
            view.ScopeMsg = string.Empty;
            view.Message = string.Empty;
            view.ApplyDateMsg = string.Empty;
            bool ret = true;
            if (String.IsNullOrEmpty(view.ApplyDate.Trim()))
            {
                view.ApplyDateMsg = "发起时间不可为空";
                ret = false;
            }
            else
            {
                DateTime dtApplyDate;
                if (!(DateTime.TryParse(view.ApplyDate, out dtApplyDate)))
                {
                    view.ApplyDateMsg = "发起时间格式不正确";
                    ret = false;
                }
            }
            if (String.IsNullOrEmpty(view.ScopeFrom.Trim()) || String.IsNullOrEmpty(view.ScopeTo.Trim()))
            {
                view.ScopeMsg = "绩效考核时间不可为空";
                ret = false;
            }
            else
            {
                DateTime dtScopeFrom;
                DateTime dtScopeTo;
                if (!(DateTime.TryParse(view.ScopeFrom, out dtScopeFrom) && DateTime.TryParse(view.ScopeTo, out dtScopeTo)))
                {
                    view.ScopeMsg = "绩效考核时间格式不正确";
                    ret = false;
                }
                else
                {
                    if (DateTime.Compare(dtScopeFrom, dtScopeTo) > 0)
                    {
                        view.ScopeMsg = "开始时间不可晚于结束时间";
                        ret = false;
                    }
                }
            }
            return ret;
        }

    }
}
