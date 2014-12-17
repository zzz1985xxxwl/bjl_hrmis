﻿//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdatePersonalGoalPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-05
// 概述: 更新个人目标
// ----------------------------------------------------------------

using System;
using SEP.Model.Accounts;
using SEP.Model.Goals;
using SEP.Presenter.IPresenter.IGoals;
using SEP.IBll;

namespace SEP.Presenter.Goals
{
    public class UpdatePersonalGoalPresenter : ShowPersonalGoalPresenter
    {
        public EventHandler _CompleteEvent;

        public UpdatePersonalGoalPresenter(IGoalBaseView view, Account loginUser)
            : base(view, loginUser)
        {
        }

        public void ExecuteEvent(object sender, EventArgs e)
        {
            if (Validation() )//&& ValidationPersonalGoal())
            {

                PersonalGoal personalGoal =
                    new PersonalGoal(Convert.ToInt32(_IGoalBaseView.GoalID),
                                     _IGoalBaseView.Title, _IGoalBaseView.Content,
                                     Convert.ToDateTime(_IGoalBaseView.SetTime),LoginUser);
                try
                {
                    BllInstance.GoalBllInstance.UpdatePersonalGoal(personalGoal, LoginUser);
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