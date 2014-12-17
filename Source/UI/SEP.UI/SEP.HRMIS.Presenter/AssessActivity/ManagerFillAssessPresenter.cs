//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ManagerFillAssessPresenter.cs
// 创建者:wang.shali
// 创建日期: 2008-06-16
// 概述: 主管填写考评项
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    using System.Collections.Generic;
    using Model;

    public class ManagerFillAssessPresenter : FillAssessPresenter
    {
        public ManagerFillAssessPresenter(string strAssessActivityId, string submitID, IAssessAnswerView view, Account loginUser)
            : base(strAssessActivityId, submitID, view, loginUser)
        {
        }

        public void InitView(bool isPageValid)
        {
            Initialize(isPageValid);

            if (_AssessActivity != null)
            {
                //add by liudan 2009-09-04 去除开放项
                List<AssessActivityItem> items = _SubmitInfo.ItsAssessActivityItems;
                List<AssessActivityItem> managerItems=new List<AssessActivityItem>();
                foreach(AssessActivityItem item in items)
                {
                    if (item.AssessTemplateItemType != AssessTemplateItemType.Open
                        && item.Classfication != ItemClassficationEmnu._360)
                    {
                        managerItems.Add(item);
                    }
                }
                _View.AssessActivityItems = managerItems;
                //_View.AssessActivityItems = _SubmitInfo.ItsAssessActivityItems; //GetItemsForUI(false);
                //由于界面上的label值取不到，因此Question信息需要在此初始化，且与绑定分开
                if (!isPageValid)
                {
                    _View.Title = "主管考核意见";
                    _View.PersonalGoal = _AssessActivity.PersonalGoal;
                    _View.Responsibility = _AssessActivity.ItsEmployee.Account.Position.MainDuties;
                    _View.AssessFromTime = _AssessActivity.ScopeFrom.ToShortDateString();
                    _View.AssessToTime = _AssessActivity.ScopeTo.ToShortDateString();
                    _View.EmployeeID = _AssessActivity.ItsEmployee.Account.Id.ToString();
                    _View.ShowStar = true;
                    _View.ReadOnlySalaryNow = true;
                    _View.ShowAttendanceStatistics = true;
                    _View.IntentionSource = GetIntentionsForUI();
                    if (String.IsNullOrEmpty(_AssessActivity.Intention))
                    {
                        _View.ShowIntention = false;
                    }
                    if (_SubmitInfo != null)
                    {
                        _View.Comment = _SubmitInfo.Comment;
                        _View.SelectIntention = _SubmitInfo.Choose;
                        //_View.QuesItemsSource = _SubmitInfo.ItsAssessActivityItems;
                        _View.QuesItemsSource = managerItems;
                        _View.SalaryNow = _SalaryNow.ToString();
                        _View.SalaryChange = _SubmitInfo.SalaryChange.ToString();
                    }
                }
            }
        }

        public void btnSubmitClick(object sender, EventArgs e)
        {
            if (Validation())
            {
                DoExcute(true);
            }

        }
        public void btnSaveClick(object sender, EventArgs e)
        {
            if (Validation())
            {
                DoExcute(false);
            }
        }

        private void DoExcute(bool ifSubmit)
        {
            try
            {
                InstanceFactory.AssessActivityFacade.FillManagerItemsExcute(_AssessActivity.AssessActivityID,
                                                                            _View.AssessActivityItems, _View.Comment,
                                                                            _View.SelectIntention, ifSubmit,
                                                                            LoginUser.Name, ConvertToDecaiml(_View.SalaryChange));
                ToGetCurrentAssessPage(this, null);
            }
            catch (ApplicationException ex)
            {
                _View.Message = ex.Message;
            }
        }
        public EventHandler ToGetCurrentAssessPage;
    }
}