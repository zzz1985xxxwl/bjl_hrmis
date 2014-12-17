//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CompanyGoalUpdate.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-23
// 概述: 增加CompanyGoalUpdate
// ----------------------------------------------------------------
using System;
using SEP.Presenter.Goals;

namespace SEP.Performance.Pages
{
    public partial class CompanyGoalUpdate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateCompanyGoalPresenter presenter = new UpdateCompanyGoalPresenter(ManageGoalView, LoginUser);
            //SendLoginInfo(presenter);
            presenter.InitGoal(Request.QueryString["GoalID"], IsPostBack);
            ManageGoalView.btnOKClick += presenter.ExecuteEvent;
            presenter._CompleteEvent += (HandleCompleteEvent);
        }
        private void HandleCompleteEvent(object sender, EventArgs e)
        {
            Response.Redirect("GoalCompanyList.aspx",false);
        }
    }
}
