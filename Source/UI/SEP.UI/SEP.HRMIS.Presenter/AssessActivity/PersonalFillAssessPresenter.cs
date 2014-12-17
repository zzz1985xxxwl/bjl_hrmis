//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: PersonalFillAssessPresenter.cs
// ������:wang.shali
// ��������: 2008-06-16
// ����: ������д������
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class PersonalFillAssessPresenter : FillAssessPresenter
    {
        private bool _360Visible = false;
        public PersonalFillAssessPresenter(string strAssessActivityId, string submitID, IAssessAnswerView view, Account loginUser)
            : base(strAssessActivityId, submitID, view, loginUser)
        {
        }

        public void InitView(bool isPageValid)
        {
            Initialize(isPageValid);
            if (_AssessActivity != null)
            {
                _View.AssessActivityItems = _SubmitInfo.ItsAssessActivityItems; //GetItemsForUI(false);
                //���ڽ����ϵ�labelֵȡ���������Question��Ϣ��Ҫ�ڴ˳�ʼ��������󶨷ֿ�
                if (!isPageValid)
                {
                    //ֻ���Լ����Կ���
                    if (LoginUser.Id == _AssessActivity.ItsEmployee.Account.Id)
                    {
                        _360Visible = true;
                    }

                    _View.Title = "��������";
                    _View.PersonalGoal = _AssessActivity.PersonalGoal;
                    _View.Responsibility = _AssessActivity.ItsEmployee.Account.Position.MainDuties;
                    _View.IntentionSource = GetIntentionsForUI();
                    _View.AssessFromTime = _AssessActivity.ScopeFrom.ToShortDateString();
                    _View.AssessToTime = _AssessActivity.ScopeTo.ToShortDateString();
                    _View.EmployeeID = _AssessActivity.ItsEmployee.Account.Id.ToString();
                    _View.ShowStar = false;
                    _View.ShowSalary = false;
                    _View.ShowAttendanceStatistics = true;
                    if (String.IsNullOrEmpty(_AssessActivity.Intention))
                    {
                        _View.ShowIntention = false;
                    }
                    if (_SubmitInfo!= null)
                    {
                        _View.Comment = _SubmitInfo.Comment;
                        List<AssessActivityItem> itemshow = new List<AssessActivityItem>();
                        for (int i = 0; i < _SubmitInfo.ItsAssessActivityItems.Count; i++)
                        {
                            if (_360Visible)
                            {
                                itemshow.Add(_SubmitInfo.ItsAssessActivityItems[i]);
                            }
                            else 
                            {
                                if (_SubmitInfo.ItsAssessActivityItems[i].Classfication != ItemClassficationEmnu._360)
                                {
                                    itemshow.Add(_SubmitInfo.ItsAssessActivityItems[i]);
                                }
                            }
                        }
                        _View.QuesItemsSource = itemshow;
                        _View.Comment = _SubmitInfo.Comment;
                        _View.SelectIntention = _SubmitInfo.Choose;
                    }
                }
            }
        }

        private void DoExcute(bool ifSubmit)
        {
            try
            {
                InstanceFactory.AssessActivityFacade.FillEmployeeItemsExcute(_AssessActivity.AssessActivityID,
                                                                             _View.AssessActivityItems, _View.Comment,
                                                                             _View.SelectIntention, ifSubmit,
                                                                             LoginUser.Name);
                ToGetCurrentAssessPage(this, null);
            }
            catch (Exception ex)
            {
                _View.Message = ex.Message;
            }
        }

        public EventHandler ToGetCurrentAssessPage;

        public void btnSubmitClick(object sender, EventArgs e)
        {
            if (PersonalValidation())
            {
                DoExcute(true);
            }
        }

        public void btnSaveClick(object sender, EventArgs e)
        {
            if (PersonalValidation())
            {
                DoExcute(false);
            }
        }
    }
}
