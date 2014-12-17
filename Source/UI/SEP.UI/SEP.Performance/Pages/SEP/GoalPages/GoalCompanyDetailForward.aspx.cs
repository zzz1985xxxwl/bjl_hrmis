//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GoalCompanyDetailForward.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-23
// 概述: 增加GoalCompanyDetailForward
// ----------------------------------------------------------------
using System;
using SEP.Presenter.Goals;
using ShiXin.Security;

namespace SEP.Performance.Pages
{
    public partial class GoalCompanyDetailForward : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DetailCompanyGoalPresenter presenter = new DetailCompanyGoalPresenter(ManageGoalView, LoginUser);
            //SendLoginInfo(presenter);
            presenter.InitGoal(SecurityUtil.DECDecrypt(Request.QueryString["GoalID"]), IsPostBack);
            ManageGoalView.btnOKClick += ToGoalCompanyAddPage;
            ManageGoalView.IsEdit = false;
        }
        private void ToGoalCompanyAddPage(object sender, EventArgs e)
        {
            Response.Redirect("../indexpages/Index.aspx",false);
        }
    }
}
