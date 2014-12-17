//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ApplyAssessConditionUpdatePresenter.cs
// 创建者:wangshali
// 创建日期: 2008-08-11
// 概述: 工资系数详细
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class ApplyAssessConditionUpdatePresenter : ApplyAssessConditionBasePresenter
    {
        private readonly IApplyAssessConditionView _View;

        public ApplyAssessConditionUpdatePresenter(IApplyAssessConditionView view)
        {
            _View = view;
        }
        public void InitView(ApplyAssessCondition applyAssessCondition, bool isPageValid)
        {
            InitBaseView(_View, isPageValid);
            _View.Title = "添加系统自动发起绩效考核条件";
            _View.FormReadonly = false;
            if (!isPageValid)
            {
                _View.ApplyAssessCondition = applyAssessCondition;
                _View.ApplyAssessConditionID = applyAssessCondition.ConditionID.ToString();
            }
        }

        public delegate void GVUpdateApplyAssessCondition(ApplyAssessCondition applyAssessCondition);
        public GVUpdateApplyAssessCondition _GVUpdateApplyAssessCondition;
        public void btnOKClick(object sender, EventArgs e)
        {
            if (Validation(_View))
            {
                try
                {
                    ApplyAssessCondition applyAssessCondition = _View.ApplyAssessCondition;
                    applyAssessCondition.ConditionID = Convert.ToInt32(_View.ApplyAssessConditionID);
                    _GVUpdateApplyAssessCondition(applyAssessCondition);
                }
                catch (ApplicationException ex)
                {
                    _View.Message = ex.Message;
                }
            }
        }

    }
}
