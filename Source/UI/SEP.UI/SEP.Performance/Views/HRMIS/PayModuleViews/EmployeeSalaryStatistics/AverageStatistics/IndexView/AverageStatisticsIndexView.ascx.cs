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
    public partial class AverageStatisticsIndexView : System.Web.UI.UserControl, IAverageStatisticsIndexView
    {
        private string IsFirstLoad;
        protected void Page_Load(object sender, EventArgs e)
        {
            IsFirstLoad = ClientID + "IsFirstLoad";
            Session[IsFirstLoad] = Session[IsFirstLoad] == null ? true : false;
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            AverageStatisticsIndexPresenter averageStatisticsIndexPresenter =
                new AverageStatisticsIndexPresenter(this, LoginUser);
            if (!Convert.ToBoolean(Session[IsFirstLoad]))
            {
                averageStatisticsIndexPresenter.InitPresent(IsPostBack);
                if (IsPostBack)
                {
                    averageStatisticsIndexPresenter.StatisticsEmployeeSalary(null, null);
                }
            }
            else
            {
                averageStatisticsIndexPresenter.InitPresent(false);
            }
        }

        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

        public IAverageStatisticsBarChartView IAverageStatisticsBarChartView
        {
            get { return AverageStatisticsBarChartView1; }
            set { throw new NotImplementedException(); }
        }

        public IAverageStatisticsTableView IAverageStatisticsTableView
        {
            get { return AverageStatisticsTableView1; }
            set { throw new NotImplementedException(); }
        }

        public event EventHandler StatisticsButtonEvent;
    }
}