//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: CEOFillAssessPresenter.cs
// ������:wang.shali
// ��������: 2008-06-16
// ����: CEO��д������
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class CEOFillAssessPresenter : FillAssessPresenter
    {
        public CEOFillAssessPresenter(string strAssessActivityId, string submitID, IAssessAnswerView view, Account loginUser)
            : base(strAssessActivityId, submitID, view, loginUser)
        {
        }

        public void InitView(bool isPageValid)
        {
            Initialize(isPageValid);
            if (_AssessActivity != null)
            {
                if (!isPageValid)
                {
                    _View.Title = "CEO��׼";
                    _View.Comment = _SubmitInfo.Comment;
                    _View.SalaryNow = _SalaryNow.ToString();
                    _View.SalaryChange = _SubmitInfo.SalaryChange.ToString();
                    if (!string.IsNullOrEmpty(_ManageSalary))
                    {
                        _View.ManagerSalalry = _ManageSalary;
                    }
                    if (String.IsNullOrEmpty(_View.Comment))
                    {
                        _View.Comment = "����";
                    }
                    _View.ShowPersonalGoal = false;
                    _View.ShowResponsibility = false;
                    _View.ShowAttendanceStatistics = false;
                    _View.ShowIntention = false;
                    _View.ShowAssessItem = false;
                    _View.ShowbtnSave = false;
                    _View.ShowStar = true;
                    _View.ReadOnlySalaryNow = true;
                }
            }
        }

        public void btnSubmitClick(object sender, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    InstanceFactory.AssessActivityFacade.FillCEOCommentExcute(_AssessActivity.AssessActivityID,
                                                                              _View.Comment, LoginUser.Name, ConvertToDecaiml(_View.SalaryChange));
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
