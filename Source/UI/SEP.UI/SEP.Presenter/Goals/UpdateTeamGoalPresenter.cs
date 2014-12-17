//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateTeamGoalPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-05
// 概述: 更新团队目标
// ----------------------------------------------------------------

using System;
using SEP.Model.Goals;
using SEP.Presenter.IPresenter.IGoals;
using SEP.Model.Accounts;
using SEP.IBll;

namespace SEP.Presenter.Goals
{
    public class UpdateTeamGoalPresenter : ShowTeamGoalPresenter
    {
        public EventHandler _CompleteEvent;

        public UpdateTeamGoalPresenter(IGoalBaseView view, Account loginUser)
            : base(view, loginUser)
        {
        }

        public void ExecuteEvent(object sender, EventArgs e)
        {
            if (Validation())
            {
                TeamGoal teamGoal =
                    new TeamGoal(Convert.ToInt32(_IGoalBaseView.GoalID),
                                 _IGoalBaseView.Title, _IGoalBaseView.Content,
                                 Convert.ToDateTime(_IGoalBaseView.SetTime), LoginUser.Dept);
                try
                {
                    BllInstance.GoalBllInstance.UpdateTeamGoal(teamGoal, LoginUser);
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