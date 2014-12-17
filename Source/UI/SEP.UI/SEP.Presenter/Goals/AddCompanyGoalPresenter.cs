//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddCompanyGoalPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-05
// 概述: 增加公司目标
// ----------------------------------------------------------------
using System;
using SEP.Model.Goals;
using SEP.Presenter.IPresenter.IGoals;
using SEP.Model.Accounts;
using SEP.IBll;

namespace SEP.Presenter.Goals
{
    public class AddCompanyGoalPresenter : AddUpdateGoalPresenter
    {
        public EventHandler _CompleteEvent;

        public AddCompanyGoalPresenter(IGoalBaseView view, Account loginUser)
            : base(view, loginUser)
        {
        }

        public void ExecuteEvent(object sender, EventArgs e)
        {
            if (Validation())
            {
                CompanyGoal companyGoal =
                    new CompanyGoal(0,
                                    _IGoalBaseView.Title, _IGoalBaseView.Content,
                                    Convert.ToDateTime(_IGoalBaseView.SetTime));
                try
                {
                    BllInstance.GoalBllInstance.CreateCompanyGoal(companyGoal, LoginUser);
                    _CompleteEvent(this, EventArgs.Empty);
                }
                catch (ApplicationException ex)
                {
                    _IGoalBaseView.ResultMessage = ex.Message;
                }
            }
        }
    }
}