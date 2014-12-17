//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TeamGoalList.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-23
// 概述: 增加TeamGoalList
// ----------------------------------------------------------------
using System;
using System.Web;
using SEP.Performance.Views;
using SEP.Presenter.Goals;

namespace SEP.Performance.Pages
{
    public partial class TeamGoalList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TeamGoalListPresenter presenter = new TeamGoalListPresenter(GoalListView1, LoginUser);
            GoalListView1.Goal_Delete = presenter.ExecuteEvent;
            //SendLoginInfo(presenter);
            presenter.InitTeamGoalList();
            presenter._CompleteEvent = ToTeamGoalListPage;
            GoalListView1.Goal_Search = presenter.ExecuteSearchEvent;
            GoalListView1.Goal_Add = ToTeamGoalAddPage;
        }
        private static void ToTeamGoalListPage(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("GoalTeamList.aspx",false);
        }
        private void ToTeamGoalAddPage(object sender, EventArgs e)
        {
            Response.Redirect("GoalTeamAdd.aspx",false);
        }
    }
}
