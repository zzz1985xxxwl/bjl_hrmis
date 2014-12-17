//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: TeamGoalAdd.cs
// ������: ���h��
// ��������: 2008-06-23
// ����: ����TeamGoalAdd
// ----------------------------------------------------------------
using System;
using SEP.Performance.Pages;
using SEP.Presenter.Goals;

namespace SEP.Performance.Pages
{
    public partial class TeamGoalAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ManageGoalView.SetTime = DateTime.Now.ToShortDateString();
            }
            AddTeamGoalPresenter presenter = new AddTeamGoalPresenter(ManageGoalView, LoginUser);
            //SendLoginInfo(presenter);
            ManageGoalView.btnOKClick += presenter.ExecuteEvent;
            presenter._CompleteEvent += (HandleCompleteEvent);
        }
        private void HandleCompleteEvent(object sender, EventArgs e)
        {
            Response.Redirect("GoalManage.aspx", false);
        }
    }
}
