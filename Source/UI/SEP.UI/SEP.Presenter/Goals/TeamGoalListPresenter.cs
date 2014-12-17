//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TeamGoalListPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-16
// 概述: 团队目标列表
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.IBll;
using SEP.IBll.Goals;
using SEP.Model.Accounts;
using SEP.Model.Goals;
using SEP.Presenter.IPresenter.IGoals;

namespace SEP.Presenter.Goals
{
    public class TeamGoalListPresenter : BaseDeleteGoalPresenter
    {
        private IGoalBll _GetGoal = BllInstance.GoalBllInstance;

        public TeamGoalListPresenter(IGoalBaseListView view, Account loginUser)
            : base(view, loginUser)
        {
        }

        #region 测试用

        public IGoalBll MockGetGoal
        {
            set { _GetGoal = value; }
        }

        #endregion

        public void InitTeamGoalList()
        {
            BindGoalList();
        }

        public bool IsEditGoal()
        {
            if (LoginUser.Dept != null)
            {
                //如果该部门是叶子部门，且员工是部门的领导，则可以新增，编辑团队目标
                return LoginUser.Dept.Leader.Id == LoginUser.Id && LoginUser.Dept.CountChildDept == 0;
            }
            return false;
        }

        private void BindGoalList()
        {
            _IGoalBaseListView.DetailRoot = "GoalTeamDetail.aspx?GoalID={0}";
            _IGoalBaseListView.UpdateRoot = "../../../Pages/SEP/GoalPages/GoalTeamUpdate.aspx?GoalID={0}";
            List<Goal> goalList = new List<Goal>();
            if (LoginUser.Dept != null)
            {
                int _HostID = LoginUser.Dept.Id;
                List<TeamGoal> teamGoalList = _GetGoal.GetTeamGoalBySetHostID(_HostID, LoginUser);
                for (int i = 0; i < teamGoalList.Count; i++)
                {
                    Goal goal = teamGoalList[i];
                    goalList.Add(goal);
                }
            }
            _IGoalBaseListView.GoalList = goalList;
        }

        public void ExecuteSearchEvent(object sender, EventArgs e)
        {
            BindGoalList();
        }
    }
}