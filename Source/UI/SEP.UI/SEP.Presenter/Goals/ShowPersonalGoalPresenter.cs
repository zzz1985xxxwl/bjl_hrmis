//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ShowPersonalGoalPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-16
// 概述: 个人目标显示
// ----------------------------------------------------------------

using SEP.IBll.Goals;
using SEP.Model.Goals;
using SEP.Presenter.IPresenter.IGoals;
using SEP.Model.Accounts;
using SEP.IBll;

namespace SEP.Presenter.Goals
{
    public class ShowPersonalGoalPresenter : AddUpdateGoalPresenter
    {
        public ShowPersonalGoalPresenter(IGoalBaseView view, Account loginUser)
            : base(view, loginUser)
        {
        }

        public void InitGoal(string goalID, bool isPostBack)
        {
            int GoalID;
            if (!int.TryParse(goalID, out GoalID))
            {
                _IGoalBaseView.ResultMessage = "目标ID必须为整数！";
                return;
            }

            if (!isPostBack)
            {
                PersonalGoal goal = BllInstance.GoalBllInstance.GetGoalByPKID(GoalID, LoginUser) as PersonalGoal;
                if (goal != null)
                {
                    _IGoalBaseView.GoalID = goal.Id.ToString();
                    _IGoalBaseView.Title = goal.Title;
                    _IGoalBaseView.Content = goal.Content;
                    _IGoalBaseView.SetTime = goal.SetTime.ToShortDateString();

                }
            }
        }
    }
}