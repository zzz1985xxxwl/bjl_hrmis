using System;
using System.Web.UI;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.Performance.Views.EmployeeStatistics.IndexView
{
    public partial class GenderPieChartIndexView : UserControl, IGenderPieChartIndexView
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            GenderPieChartIndexPresenter genderPieChartIndexPresenter =
                new GenderPieChartIndexPresenter(this, LoginUser);
            genderPieChartIndexPresenter.InitPresent(false);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            GenderPieChartIndexPresenter genderPieChartIndexPresenter =
                new GenderPieChartIndexPresenter(this, LoginUser);
            genderPieChartIndexPresenter.InitPresent(IsPostBack);
            genderPieChartIndexPresenter.StatisticsEmployee(null, null);
        }

        public IGenderPieChartView IGenderPieChartView
        {
            get { return GenderPieChartView1; }
            set { throw new NotImplementedException(); }
        }

        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

    }
}