//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: GoalPersonalList.cs
// ������: ���h��
// ��������: 2008-06-23
// ����: ����GoalPersonalList
// ----------------------------------------------------------------
using System;
using System.Web;
using SEP.Performance.Views;
using SEP.Presenter.Goals;

namespace SEP.Performance.Pages
{
    public partial class GoalPersonalList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonalGoalListPresenter presenter = new PersonalGoalListPresenter(GoalListView1, LoginUser);
            GoalListView1.Goal_Delete = presenter.ExecuteEvent;
            //SendLoginInfo(presenter);
            presenter.InitPersonalGoalList();
            presenter._CompleteEvent = ToPersonalGoalListPage;
            GoalListView1.Goal_Search = presenter.ExecuteSearchEvent;
            GoalListView1.Goal_Add = ToPersonalGoalAddPage;
        }
        private static void ToPersonalGoalListPage(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("GoalPersonalList.aspx",false);
        }
        private void ToPersonalGoalAddPage(object sender, EventArgs e)
        {
            Response.Redirect("GoalPersonalAdd.aspx",false);
        }

    }
}
