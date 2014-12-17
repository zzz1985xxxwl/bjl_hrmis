using System;
using System.Web.UI;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.Performance.Views.EmployeeStatistics.IndexView
{
    public partial class WorkTypePieChartIndexView : UserControl, IWorkTypePieChartIndexView
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            WorkTypePieChartIndexPresenter workTypePieChartIndexPresenter =
                new WorkTypePieChartIndexPresenter(this, LoginUser);
            workTypePieChartIndexPresenter.InitPresent(false);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            WorkTypePieChartIndexPresenter workTypePieChartIndexPresenter =
                new WorkTypePieChartIndexPresenter(this, LoginUser);
            workTypePieChartIndexPresenter.InitPresent(IsPostBack);
            workTypePieChartIndexPresenter.StatisticsEmployee(null, null);
        }

        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

        public IWorkTypePieChartView IWorkTypePieChartView
        {
            get { return WorkTypePieChartView1; }
            set { throw new NotImplementedException(); }
        }
    }
}