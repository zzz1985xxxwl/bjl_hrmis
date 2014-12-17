//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: GoalCompanyList.cs
// ������: ���h��
// ��������: 2008-06-23
// ����: ����GoalCompanyList
// ----------------------------------------------------------------
using System;
using SEP.Presenter.Goals;

namespace SEP.Performance.Pages
{
    public partial class GoalCompanyList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoalListView1.BindPageTemplate("Company");
            CompanyGoalListPresenter presenter = new CompanyGoalListPresenter(GoalListView1, LoginUser);
            GoalListView1.Goal_Delete = presenter.ExecuteEvent;
            //SendLoginInfo(presenter);
            GoalListView1.IsEditGoal = true;
            GoalListView1.Title = "��˾Ŀ��";
            presenter.InitCompanyGoalList();
            presenter._CompleteEvent = ToCompanyGoalListPage;
            GoalListView1.Goal_Search = presenter.ExecuteSearchEvent;
            GoalListView1.Goal_Add = ToCompanyGoalAddPage;
        }
        private void ToCompanyGoalListPage(object sender, EventArgs e)
        {
            Response.Redirect("GoalCompanyList.aspx",false);
        }
        private void ToCompanyGoalAddPage(object sender, EventArgs e)
        {
            Response.Redirect("GoalCompanyAdd.aspx",false);
        }
    }
}
