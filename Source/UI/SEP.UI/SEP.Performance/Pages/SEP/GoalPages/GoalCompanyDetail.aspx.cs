//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: CompanyGoalDetail.cs
// ������: ���h��
// ��������: 2008-06-23
// ����: ����CompanyGoalDetail
// ----------------------------------------------------------------
using System;
using System.Web.UI;
using SEP.Presenter.Goals;
using ShiXin.Security;

namespace SEP.Performance.Pages
{
    public partial class CompanyGoalDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DetailCompanyGoalPresenter presenter = new DetailCompanyGoalPresenter(ManageGoalView, LoginUser);
            //SendLoginInfo(presenter);
            presenter.InitGoal(SecurityUtil.DECDecrypt(Request.QueryString["GoalID"]), IsPostBack);
            ManageGoalView.btnOKClick += ToCompanyGoalListPage;
            ManageGoalView.IsEdit = false;
        }
        private void ToCompanyGoalListPage(object sender, EventArgs e)
        {
            Response.Redirect("GoalCompanyList.aspx",false);
        }
    }
}
