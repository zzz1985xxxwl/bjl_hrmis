using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.Performance.Views.EmployeeStatistics.IndexView
{
    public partial class EduBgPieChartIndexView : System.Web.UI.UserControl, IEduBgPieChartIndexView
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            EduBgPieChartIndexPresenter eduBgPieChartIndexPresenter =
                new EduBgPieChartIndexPresenter(this, LoginUser);
            eduBgPieChartIndexPresenter.InitPresent(false);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            EduBgPieChartIndexPresenter eduBgPieChartIndexPresenter =
                new EduBgPieChartIndexPresenter(this, LoginUser);
            eduBgPieChartIndexPresenter.InitPresent(IsPostBack);
            eduBgPieChartIndexPresenter.StatisticsEmployee(null, null);
        }


        public IEduBgPieChartView IEduBgPieChartView
        {
            get { return EduBgPieChartView1; }
            set { throw new NotImplementedException(); }
        }

        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }
    }
}