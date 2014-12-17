//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CompanyGoalAdd.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-23
// 概述: 增加CompanyGoalAdd
// ----------------------------------------------------------------
using System;
using SEP.Presenter.Goals;

namespace SEP.Performance.Pages
{
    public partial class CompanyGoalAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddCompanyGoalPresenter presenter = new AddCompanyGoalPresenter(ManageGoalView, LoginUser);
            //SendLoginInfo(presenter);
            ManageGoalView.btnOKClick += presenter.ExecuteEvent;
            if(!IsPostBack)
            {
                ManageGoalView.SetTime = DateTime.Now.ToShortDateString();
            }
           
            presenter._CompleteEvent += (HandleCompleteEvent);
        }
        private void HandleCompleteEvent(object sender, EventArgs e)
        {
            Response.Redirect("GoalCompanyList.aspx",false);
        }
    }
}
