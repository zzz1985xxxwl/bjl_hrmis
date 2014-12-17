using System;
using System.Web.UI;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.Performance.Views.EmployeeStatistics.IndexView
{
    public partial class AgePieChartIndexView : UserControl, IAgePieChartIndexView
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            AgePieChartIndexPresenter agePieChartIndexPresenter =
                new AgePieChartIndexPresenter(this, LoginUser);
            agePieChartIndexPresenter.InitPresent(false);
        }
      
        protected void Page_Load(object sender, EventArgs e)
        {
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            AgePieChartIndexPresenter agePieChartIndexPresenter =
                new AgePieChartIndexPresenter(this, LoginUser);
            agePieChartIndexPresenter.InitPresent(IsPostBack);
            agePieChartIndexPresenter.StatisticsEmployee(null, null);
        }

        public IAgePieChartView IAgePieChartView
        {
            get { return AgePieChartView1; }
            set { throw new NotImplementedException(); }
        }

        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

    }
}