using System;
using System.Web;
using SEP.Presenter.Goals;
using ShiXin.Security;

namespace SEP.Performance.Pages
{
    public partial class GoalManage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoalListPerson.BindPageTemplate("Person");
            LastCompanyGoalPresenter lastCompanyGoalPresenter = new LastCompanyGoalPresenter(GoalLastCompany1, LoginUser);
            //SendLoginInfo(lastCompanyGoalPresenter);
            lastCompanyGoalPresenter.InitGoal(IsPostBack);
            GoalLastCompany1.CompanyGoal_Command += lastCompanyGoalPresenter.CompanyGoal_Command;
            lastCompanyGoalPresenter._ToCompanyGoalDetailPage = (ToCompanyGoalDetailPage);
            PersonalGoalListPresenter presenter1 = new PersonalGoalListPresenter(GoalListPerson, LoginUser);
            GoalListPerson.Goal_Delete = presenter1.ExecuteEvent;
            GoalListPerson.Title = "个人目标";
            GoalListPerson.IsEditGoal = true;
            presenter1.InitPersonalGoalList();
            presenter1._CompleteEvent = ToGoalManagePage;
            GoalListPerson.Goal_Search = presenter1.ExecuteSearchEvent;
            GoalListPerson.Goal_Add = ToPersonalGoalAddPage;

            if(LoginUser.Dept!=null)
            {
                GoalListTeam.BindPageTemplate("Team");
                TeamGoalListPresenter presenter = new TeamGoalListPresenter(GoalListTeam, LoginUser);
                GoalListTeam.Goal_Delete = presenter.ExecuteEvent;
                GoalListTeam.Title = "团队目标";
                GoalListTeam.IsEditGoal = presenter.IsEditGoal();
                presenter.InitTeamGoalList();
                presenter._CompleteEvent = ToGoalManagePage;
                GoalListTeam.Goal_Search = presenter.ExecuteSearchEvent;
                GoalListTeam.Goal_Add = ToTeamGoalAddPage;
            }
            else
            {
                GoalListTeam.Visible = false;
            }
        }
        public void ToCompanyGoalDetailPage(int goalID)
        {
            Response.Redirect("GoalCompanyDetailForward.aspx?" + ConstParameters.GoalID + "=" + SecurityUtil.DECEncrypt(goalID.ToString()), false);
        }
        private static void ToGoalManagePage(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("GoalManage.aspx", false);
        }
        private void ToTeamGoalAddPage(object sender, EventArgs e)
        {
            Response.Redirect("GoalTeamAdd.aspx", false);
        }
        private void ToPersonalGoalAddPage(object sender, EventArgs e)
        {
            Response.Redirect("GoalPersonalAdd.aspx", false);
        }
    }
}
