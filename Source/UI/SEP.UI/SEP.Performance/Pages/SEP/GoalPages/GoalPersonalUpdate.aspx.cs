//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: PersonalGoalUpdate.cs
// ������: ���h��
// ��������: 2008-06-23
// ����: ����PersonalGoalUpdate
// ----------------------------------------------------------------
using System;
using SEP.Presenter.Goals;

namespace SEP.Performance.Pages
{
    public partial class PersonalGoalUpdate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdatePersonalGoalPresenter presenter = new UpdatePersonalGoalPresenter(ManageGoalView, LoginUser);
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
