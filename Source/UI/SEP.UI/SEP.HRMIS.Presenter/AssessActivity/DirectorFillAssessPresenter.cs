//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: DirectorFillAssessPresenter.cs
// 创建者:wang.shali
// 创建日期: 2008-06-16
// 概述: 总监填写考评项
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class DirectorFillAssessPresenter : FillAssessPresenter
    {
        public DirectorFillAssessPresenter(string strAssessActivityID, IAssessAnswerView view, Account loginUser)
            : base(strAssessActivityID, view, loginUser)
        {
        }
        public void InitView(bool isPageValid)
        {
            Initialize(isPageValid);
            if (_AssessActivity != null)
            {
                if (!isPageValid)
                {
                    _View.Title = "总监审批";
                    _View.Comment = _AssessActivity.ItsAssessActivityPaper.DirectSubmitInfo.Comment; //defer
                    if(String.IsNullOrEmpty(_View.Comment))
                    {
                        _View.Comment = "已阅";
                    }
                    _View.ShowPersonalGoal = false;
                    _View.ShowResponsibility = false;
                    _View.ShowIntention = false;
                    _View.ShowAssessItem = false;
                    _View.ShowbtnSave = false;
                }
            }
        }
        public void btnSubmitClick(object sender, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    InstanceFactory.AssessActivityFacade.FillDirectorCommentExcute(_AssessActivity.AssessActivityID,
                                                                                   _View.Comment, LoginUser.Name);
                    ToGetCurrentAssessPage(this, null);
                }
                catch (Exception ex)
                {
                    _View.Message = ex.Message;
                }
            }
        }
        public EventHandler ToGetCurrentAssessPage;

    }
}