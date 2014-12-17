//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TeamGoalUpdate.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-23
// 概述: 增加TeamGoalUpdate
// ----------------------------------------------------------------
using System;
using SEP.Presenter.Goals;

namespace SEP.Performance.Pages
{
    public partial class TeamGoalUpdate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateTeamGoalPresenter presenter = new UpdateTeamGoalPresenter(ManageGoalView, LoginUser);
            //SendLoginInfo(presenter);
            presenter.InitGoal(Request.QueryString["GoalID"], IsPostBack);
            ManageGoalView.btnOKClick += presenter.ExecuteEvent;
            presenter._CompleteEvent += (HandleCompleteEvent);
        }
        private void HandleCompleteEvent(object sender, EventArgs e)
        {
            Response.Redirect("GoalManage.aspx", false);
        }
    }
}
