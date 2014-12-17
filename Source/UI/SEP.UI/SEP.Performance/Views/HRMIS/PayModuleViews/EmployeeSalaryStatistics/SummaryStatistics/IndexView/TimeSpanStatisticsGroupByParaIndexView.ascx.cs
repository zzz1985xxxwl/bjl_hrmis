using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.SummaryStatistics.IndexView;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics.IndexView;
using SEP.Model.Accounts;
using SEP.Model;
using SEP.Model.Utility;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.SummaryStatistics.IndexView
{
    public partial class TimeSpanStatisticsGroupByParaIndexView : System.Web.UI.UserControl, ITimeSpanStatisticsGroupByParaIndexView
    {
        private string IsFirstLoad;
        protected void Page_Load(object sender, EventArgs e)
        {
            IsFirstLoad = ClientID + "IsFirstLoad";
            Session[IsFirstLoad] = Session[IsFirstLoad] == null ? true : false;
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            TimeSpanStatisticsGroupByParaIndexPresenter timeSpanStatisticsGroupByParaIndexPresenter =
                new TimeSpanStatisticsGroupByParaIndexPresenter(this, LoginUser);
            if (!Convert.ToBoolean(Session[IsFirstLoad]))
            {
                timeSpanStatisticsGroupByParaIndexPresenter.InitPresent(IsPostBack);
                if (IsPostBack)
                {
                    timeSpanStatisticsGroupByParaIndexPresenter.StatisticsEmployeeSalary(null, null);
                }
            }
            else
            {
                timeSpanStatisticsGroupByParaIndexPresenter.InitPresent(false);
            }
        }


        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

        public ITimeSpanStatisticsGroupByParaLineChartView ITimeSpanStatisticsGroupByParaLineChartView
        {
            get { return TimeSpanStatisticsGroupByParaLineChartView1; }
            set { throw new NotImplementedException(); }
        }

        public ITimeSpanStatisticsGroupByParaTableView ITimeSpanStatisticsGroupByParaTableView
        {
            get { return TimeSpanStatisticsGroupByParaTableView1; }
            set { throw new NotImplementedException(); }
        }

        public event EventHandler StatisticsButtonEvent;
    }
}