//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ShowTeamGoalPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-16
// 概述: 团队目标显示
// ----------------------------------------------------------------


using SEP.IBll;
using SEP.IBll.Goals;
using SEP.Model.Goals;
using SEP.Presenter.IPresenter.IGoals;
using SEP.Model.Accounts;

namespace SEP.Presenter.Goals
{
    public class ShowTeamGoalPresenter : AddUpdateGoalPresenter
    {
        private IGoalBll _GetGoal=BllInstance.GoalBllInstance;

        public ShowTeamGoalPresenter(IGoalBaseView view, Account loginUser)
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
                TeamGoal goal = _GetGoal.GetGoalByPKID(GoalID, LoginUser) as TeamGoal;
                if (goal != null)
                {
                    _IGoalBaseView.GoalID = goal.Id.ToString();
                    _IGoalBaseView.Title = goal.Title;
                    _IGoalBaseView.Content = goal.Content;
                    _IGoalBaseView.SetTime = goal.SetTime.ToShortDateString();
                    //_IGoalBaseView.HostID = goal.Dept.Id.ToString();
                    //_IGoalBaseView.HostName = goal.Dept.Name;
                }
            }
        }
        #region 测试用
        public IGoalBll MockGetGoal
        {
            set { _GetGoal = value; }
        }
        #endregion
    }
}
