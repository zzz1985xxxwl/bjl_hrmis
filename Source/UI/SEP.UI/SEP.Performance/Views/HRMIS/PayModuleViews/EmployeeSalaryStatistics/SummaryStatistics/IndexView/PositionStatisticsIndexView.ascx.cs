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
    public partial class PositionStatisticsIndexView : System.Web.UI.UserControl, IPositionStatisticsIndexView
    {
        private string IsFirstLoad;
        protected void Page_Load(object sender, EventArgs e)
        {
            IsFirstLoad = ClientID + "IsFirstLoad";
            Session[IsFirstLoad] = Session[IsFirstLoad] == null ? true : false;
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            PositionStatisticsIndexPresenter positionStatisticsIndexPresenter =
                new PositionStatisticsIndexPresenter(this, LoginUser);
            if (!Convert.ToBoolean(Session[IsFirstLoad]))
            {
                positionStatisticsIndexPresenter.InitPresent(IsPostBack);
                if (IsPostBack)
                {
                    positionStatisticsIndexPresenter.StatisticsEmployeeSalary(null, null);
                }
            }
            else
            {
                positionStatisticsIndexPresenter.InitPresent(false);
            }
        }

        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

        public IPositionStatisticsBarChartView IPositionStatisticsBarChartView
        {
            get { return PositionStatisticsBarChartView1; }
            set { throw new NotImplementedException(); }
        }

        public IPositionStatisticsTableView IPositionStatisticsTableView
        {
            get { return PositionStatisticsTableView1; }
            set { throw new NotImplementedException(); }
        }

        public event EventHandler StatisticsButtonEvent;
    }
}