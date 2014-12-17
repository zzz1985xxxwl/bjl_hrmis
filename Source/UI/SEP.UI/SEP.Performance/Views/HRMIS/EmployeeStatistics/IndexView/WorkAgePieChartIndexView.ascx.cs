using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.Performance.Views.EmployeeStatistics.IndexView
{
    public partial class WorkAgePieChartIndexView : System.Web.UI.UserControl, IWorkAgePieChartIndexView
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            WorkAgePieChartIndexPresenter workAgePieChartIndexPresenter =
                new WorkAgePieChartIndexPresenter(this, LoginUser);
            workAgePieChartIndexPresenter.InitPresent(false);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            WorkAgePieChartIndexPresenter workAgePieChartIndexPresenter =
                new WorkAgePieChartIndexPresenter(this, LoginUser);
            workAgePieChartIndexPresenter.InitPresent(IsPostBack);
            workAgePieChartIndexPresenter.StatisticsEmployee(null, null);
        }

        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

        public IWorkAgePieChartView IWorkAgePieChartView
        {
            get { return WorkAgePieChartView1; }
            set { throw new NotImplementedException(); }
        }
    }
}