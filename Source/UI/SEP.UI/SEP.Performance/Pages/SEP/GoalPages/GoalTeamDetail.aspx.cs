//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: TeamGoalDetail.cs
// ������: ���h��
// ��������: 2008-06-23
// ����: ����TeamGoalDetail
// ----------------------------------------------------------------
using System;
using SEP.Presenter.Goals;
using ShiXin.Security;

namespace SEP.Performance.Pages
{
    public partial class TeamGoalDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DetailTeamGoalPresenter presenter = new DetailTeamGoalPresenter(ManageGoalView, LoginUser);
            //SendLoginInfo(presenter);
            presenter.InitGoal(SecurityUtil.DECDecrypt(Request.QueryString["GoalID"]), IsPostBack);
            ManageGoalView.btnOKClick += ToTeamGoalListPage;
            ManageGoalView.IsEdit = false;
        }
        private void ToTeamGoalListPage(object sender, EventArgs e)
        {
            Response.Redirect("GoalManage.aspx", false);
        }
    }
}
