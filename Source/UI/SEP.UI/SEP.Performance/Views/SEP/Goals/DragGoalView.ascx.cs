using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Presenter.Goals;
using ShiXin.Security;

namespace SEP.Performance.Views.SEP.Goals
{
    public partial class DragGoalView : UserControl
    {
        private Account LoginUser
        {
            get { return Session[SessionKeys.LOGININFO] as Account; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AllLastGoalPresenter presenter = new AllLastGoalPresenter(GoalAllLastView1, LoginUser);
            GoalAllLastView1.IsEditGoal = presenter.IsEditGoal();
            presenter.InitGoal(IsPostBack);
            GoalAllLastView1.CompanyGoal_Command += presenter.CompanyGoal_Command;
            GoalAllLastView1.TeamGoal_Command += presenter.TeamGoal_Command;
            GoalAllLastView1.PersonalGoal_Command += presenter.PersonalGoal_Command;

            GoalAllLastView1.AddTeamGoal_Command += AddTeamGoal_Command;
            GoalAllLastView1.AddPersonalGoal_Command += AddPersonalGoal_Command;
            GoalAllLastView1.UpdateTeamGoal_Command += UpdateTeamGoal_Command;
            GoalAllLastView1.UpdatePersonalGoal_Command += UpdatePersonalGoal_Command;

            presenter._ToCompanyGoalDetailPage = (ToCompanyGoalDetailPage);
            presenter._ToTeamGoalDetailPage = (ToTeamGoalDetailPage);
            presenter._ToPersonalGoalDetailPage = (ToPersonalGoalDetailPage);
        }

        public void ToCompanyGoalDetailPage(int goalID)
        {
            WindowOpen("../GoalPages/GoalCompanyDetailForward.aspx?" + ConstParameters.GoalID + "=" + SecurityUtil.DECEncrypt(goalID.ToString()));
        }

        public void ToPersonalGoalDetailPage(int goalID)
        {
            WindowOpen("../GoalPages/GoalPersonalDetail.aspx?" + ConstParameters.GoalID + "=" + SecurityUtil.DECEncrypt(goalID.ToString()));
        }

        public void ToTeamGoalDetailPage(int goalID)
        {
            WindowOpen("../GoalPages/GoalTeamDetailView.aspx?" + ConstParameters.GoalID + "=" + SecurityUtil.DECEncrypt(goalID.ToString()));
        }

        private void AddTeamGoal_Command(object sender, CommandEventArgs e)
        {
            WindowOpen("../GoalPages/GoalTeamAdd.aspx");
        }

        private void AddPersonalGoal_Command(object sender, CommandEventArgs e)
        {
            WindowOpen("../GoalPages/GoalPersonalAdd.aspx");
        }

        private void UpdateTeamGoal_Command(object sender, CommandEventArgs e)
        {
            WindowOpen("../GoalPages/GoalTeamUpdate.aspx?" + ConstParameters.GoalID + "=" + e.CommandArgument);
        }

        private void UpdatePersonalGoal_Command(object sender, CommandEventArgs e)
        {
            WindowOpen("../GoalPages/GoalPersonalUpdate.aspx?" + ConstParameters.GoalID + "=" + e.CommandArgument);
        }

        private void WindowOpen(string url)
        {
            Response.Write("<script>window.open(\"" + url + "\")</script>");
        }
    }
}