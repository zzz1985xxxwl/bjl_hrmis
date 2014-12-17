//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CompanyGoalListPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-16
// 概述: 公司目标列表
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.IBll;
using SEP.IBll.Goals;
using SEP.Model.Goals;
using SEP.Presenter.Goals;
using SEP.Presenter.IPresenter.IGoals;
using SEP.Model.Accounts;


namespace SEP.Presenter.Goals
{
    public class CompanyGoalListPresenter : BaseDeleteGoalPresenter
    {
        readonly IGoalBll _GetGoal = BllInstance.GoalBllInstance;
        public CompanyGoalListPresenter(IGoalBaseListView view, Account loginUser)
            : base(view, loginUser)
        {
        }
        public void InitCompanyGoalList()
        {
            BindGoalList();
        }
        private void BindGoalList()
        {
            _IGoalBaseListView.DetailRoot = "GoalCompanyDetail.aspx?GoalID={0}";
            _IGoalBaseListView.UpdateRoot = "../../../Pages/SEP/GoalPages/GoalCompanyUpdate.aspx?GoalID={0}";

            List<CompanyGoal> companyGoalList = _GetGoal.GetCompanyGoal(LoginUser);
            List<Goal> goalList = new List<Goal>();
            for (int i = 0; i < companyGoalList.Count; i++)
            {
                Goal goal = companyGoalList[i] ;
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
