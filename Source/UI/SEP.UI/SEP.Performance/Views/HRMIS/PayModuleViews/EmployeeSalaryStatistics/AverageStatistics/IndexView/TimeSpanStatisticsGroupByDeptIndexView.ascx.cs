using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.AverageStatistics.IndexView;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics.IndexView;
using SEP.Model.Accounts;
using SEP.Model;
using SEP.Model.Utility;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.AverageStatistics.IndexView
{
    public partial class TimeSpanStatisticsGroupByDeptIndexView : System.Web.UI.UserControl, ITimeSpanStatisticsGroupByDeptIndexView
    {
        private string IsFirstLoad;
        protected void Page_Load(object sender, EventArgs e)
        {
            IsFirstLoad = ClientID + "IsFirstLoad";
            Session[IsFirstLoad] = Session[IsFirstLoad] == null ? true : false;
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            TimeSpanStatisticsGroupByDeptIndexPresenter timeSpanStatisticsGroupByDeptIndexPresenter =
                new TimeSpanStatisticsGroupByDeptIndexPresenter(this, LoginUser);
            if (!Convert.ToBoolean(Session[IsFirstLoad]))
            {
                timeSpanStatisticsGroupByDeptIndexPresenter.InitPresent(IsPostBack);
                if (IsPostBack)
                {
                    timeSpanStatisticsGroupByDeptIndexPresenter.StatisticsEmployeeSalary(null, null);
                }
            }
            else
            {
                timeSpanStatisticsGroupByDeptIndexPresenter.InitPresent(false);
            }
        }

        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

        public ITimeSpanStatisticsGroupByDeptLineChartView ITimeSpanStatisticsGroupByDeptLineChartView
        {
            get { return TimeSpanStatisticsGroupByDeptLineChartView1; }
            set { throw new NotImplementedException(); }
        }

        public ITimeSpanStatisticsGroupByDeptTableView ITimeSpanStatisticsGroupByDeptTableView
        {
            get { return TimeSpanStatisticsGroupByDeptTableView1; }
            set { throw new NotImplementedException(); }
        }

        public event EventHandler StatisticsButtonEvent;
    }
}