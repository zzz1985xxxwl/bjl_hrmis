//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PersonalGoalListPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-16
// 概述: 个人目标列表
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.IBll;
using SEP.IBll.Goals;
using SEP.Model.Goals;
using SEP.Presenter.IPresenter.IGoals;
using SEP.Model.Accounts;

namespace SEP.Presenter.Goals
{
    public class PersonalGoalListPresenter : BaseDeleteGoalPresenter
    {
        private IGoalBll _GetGoal = BllInstance.GoalBllInstance;

        public PersonalGoalListPresenter(IGoalBaseListView view, Account loginUser)
            : base(view, loginUser)
        {
        }

        #region 测试用

        public IGoalBll MockGetGoal
        {
            set { _GetGoal = value; }
        }

        #endregion

        public void InitPersonalGoalList()
        {
            BindGoalList();
        }

        private void BindGoalList()
        {
            _IGoalBaseListView.DetailRoot = "GoalPersonalDetail.aspx?GoalID={0}";
            _IGoalBaseListView.UpdateRoot = "../../../Pages/SEP/GoalPages/GoalPersonalUpdate.aspx?GoalID={0}";
            List<PersonalGoal> personalGoalList = _GetGoal.GetPersonalGoalBySetHostID(LoginUser.Id, LoginUser);
            List<Goal> goalList = new List<Goal>();
            for (int i = 0; i < personalGoalList.Count; i++)
            {
                Goal goal = personalGoalList[i];
                goalList.Add(goal);
            }
            _IGoalBaseListView.GoalList = goalList;
        }

        public void ExecuteSearchEvent(object sender, EventArgs e)
        {
            BindGoalList();
        }
    }
}