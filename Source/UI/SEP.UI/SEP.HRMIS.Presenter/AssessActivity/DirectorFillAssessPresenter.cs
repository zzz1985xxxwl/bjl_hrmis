//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: DirectorFillAssessPresenter.cs
// ������:wang.shali
// ��������: 2008-06-16
// ����: �ܼ���д������
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
                    _View.Title = "�ܼ�����";
                    _View.Comment = _AssessActivity.ItsAssessActivityPaper.DirectSubmitInfo.Comment; //defer
                    if(String.IsNullOrEmpty(_View.Comment))
                    {
                        _View.Comment = "����";
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