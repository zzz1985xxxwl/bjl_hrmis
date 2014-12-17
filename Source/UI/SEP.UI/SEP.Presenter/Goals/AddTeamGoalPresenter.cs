//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddTeamGoalPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-05
// 概述: 增加团队目标
// ----------------------------------------------------------------

using System;
using SEP.Model.Goals;
using SEP.Presenter.IPresenter.IGoals;
using SEP.Model.Accounts;
using SEP.IBll;

namespace SEP.Presenter.Goals
{
    public class AddTeamGoalPresenter : AddUpdateGoalPresenter
    {
        public EventHandler _CompleteEvent;

        public AddTeamGoalPresenter(IGoalBaseView view, Account loginUser)
            : base(view, loginUser)
        {
        }

        public void ExecuteEvent(object sender, EventArgs e)
        {
            if (Validation()) //&& ValidationTeamGoal())
            {
                TeamGoal teamGoal =
                    new TeamGoal(0,
                                 _IGoalBaseView.Title, _IGoalBaseView.Content,
                                 Convert.ToDateTime(_IGoalBaseView.SetTime), LoginUser.Dept);

                try
                {
                    BllInstance.GoalBllInstance.CreateTeamGoal(teamGoal, LoginUser);
                    _CompleteEvent(this, EventArgs.Empty);
                }
                catch (ApplicationException ex)
                {
                    _IGoalBaseView.ResultMessage = ex.Message;
                }
            }
        }

        //public bool ValidationTeamGoal()
        //{
        //    if (!int.TryParse(_IGoalBaseView.HostID, out _DepartmentID)
        //        || String.IsNullOrEmpty(_IGoalBaseView.HostName))
        //    {
        //        _IGoalBaseView.ResultMessage = "部门ID必须为整数！";
        //        return false;
        //    }
        //    return true;
        //}
    }
}