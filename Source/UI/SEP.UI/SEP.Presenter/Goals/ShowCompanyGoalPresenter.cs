//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ShowCompanyGoalPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-16
// 概述: 公司目标显示
// ----------------------------------------------------------------


using SEP.IBll;
using SEP.IBll.Goals;
using SEP.Model.Goals;
using SEP.Presenter.IPresenter.IGoals;
using SEP.Model.Accounts;

namespace SEP.Presenter.Goals
{
    public class ShowCompanyGoalPresenter : AddUpdateGoalPresenter
    {
        protected readonly IGoalBll _GetGoal = BllInstance.GoalBllInstance;

        public ShowCompanyGoalPresenter(IGoalBaseView view, Account loginUser)
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
                CompanyGoal goal = _GetGoal.GetGoalByPKID(GoalID, LoginUser) as CompanyGoal;
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