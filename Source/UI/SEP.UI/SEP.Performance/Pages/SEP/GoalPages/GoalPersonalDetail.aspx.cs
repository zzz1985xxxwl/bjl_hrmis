//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: PersonalGoalDetail.cs
// ������: ���h��
// ��������: 2008-06-23
// ����: ����PersonalGoalDetail
// ----------------------------------------------------------------
using System;
using SEP.Presenter.Goals;
using ShiXin.Security;

namespace SEP.Performance.Pages
{
    public partial class PersonalGoalDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DetailPersonalGoalPresenter presenter = new DetailPersonalGoalPresenter(ManageGoalView, LoginUser);
            //SendLoginInfo(presenter);
            presenter.InitGoal(SecurityUtil.DECDecrypt(Request.QueryString["GoalID"]), IsPostBack);
            ManageGoalView.btnOKClick += ToPersonalGoalListPage;
            ManageGoalView.IsEdit = false;
        }
        private void ToPersonalGoalListPage(object sender, EventArgs e)
        {
            Response.Redirect("GoalManage.aspx", false);
        }
    }
}
