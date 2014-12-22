//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: HRFillAssessPresenter.cs
// ������:wang.shali
// ��������: 2008-06-16
// ����: hr��д������
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class HRFillAssessPresenter : FillAssessPresenter
    {
        public HRFillAssessPresenter(string strAssessActivityID, string submitID, IAssessAnswerView view, Account loginUser)
            : base(strAssessActivityID, submitID, view, loginUser)
        {
        }

        public void InitView(bool isPageValid)
        {
            Initialize(isPageValid);
            if (_AssessActivity != null)
            {
                _View.AssessActivityItems = _SubmitInfo.ItsAssessActivityItems; //���ڽ����ϵ�labelֵȡ���������Question��Ϣ��Ҫ�ڴ˳�ʼ��
                if (_AssessActivity.AssessCharacterType == AssessCharacterType.ProbationII)
                {
                    _View.ShowNowSalaryStar=true;
                }
                if (!isPageValid)
                {
                    _View.Title = "������Դ�������";
                    _View.Comment = _SubmitInfo.Comment;
                    _View.QuesItemsSource = _SubmitInfo.ItsAssessActivityItems;
                    _View.SalaryNow = _SubmitInfo.SalaryNow.ToString();
                    _View.ShowPersonalGoal = false;
                    _View.ShowResponsibility = false;
                    _View.ShowAttendanceStatistics = false;
                    _View.ShowIntention = false;
                    _View.ShowbtnSave = false;
                    _View.ShowSalaryChange = false;
                    _View.ShowStar = false;
                    
                }
            }
        }

        public void btnSubmitClick(object sender, EventArgs e)
        {
            try
            {
                if (HrValidation())
                {
                    InstanceFactory.AssessActivityFacade().FillHRItemsExcute(_AssessActivity.AssessActivityID,
                                                                           _View.AssessActivityItems,_View.Comment,true, LoginUser.Name, ConvertToDecaiml(_View.SalaryNow));
                    ToHRFillingAssessPage(this, null);
                }
            }
            catch (Exception ex)
            {
                _View.Message = ex.Message;
            }
        }

        public EventHandler ToHRFillingAssessPage;
    }
}