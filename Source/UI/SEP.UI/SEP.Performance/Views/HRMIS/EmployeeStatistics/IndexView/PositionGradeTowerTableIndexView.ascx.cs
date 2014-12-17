using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.Performance.Views.EmployeeStatistics.IndexView
{
    public partial class PositionGradeTowerTableIndexView : System.Web.UI.UserControl, IPositionGradeTowerTableIndexView
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            PositionGradeTowerTableIndexPresenter positionGradeTowerTableIndexPresenter =
                new PositionGradeTowerTableIndexPresenter(this, LoginUser);
            positionGradeTowerTableIndexPresenter.InitPresent(false);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            PositionGradeTowerTableIndexPresenter positionGradeTowerTableIndexPresenter =
                new PositionGradeTowerTableIndexPresenter(this, LoginUser);
            positionGradeTowerTableIndexPresenter.InitPresent(IsPostBack);
            positionGradeTowerTableIndexPresenter.StatisticsEmployee(null, null);
        }

        
        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

        public IPositionGradeTowerTableView IPositionGradeTowerTableView
        {
            get { return PositionGradeTowerTableView1; }
            set { throw new NotImplementedException(); }
        }
    }
}