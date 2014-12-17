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
    public partial class DepartmentStatisticsIndexView : System.Web.UI.UserControl, IDepartmentStatisticsIndexView
    {
        private string IsFirstLoad;
        protected void Page_Load(object sender, EventArgs e)
        {
            IsFirstLoad = ClientID + "IsFirstLoad";
            Session[IsFirstLoad] = Session[IsFirstLoad] == null ? true : false;
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            DepartmentStatisticsIndexPresenter departmentStatisticsIndexPresenter =
                new DepartmentStatisticsIndexPresenter(this, LoginUser);
            if (!Convert.ToBoolean(Session[IsFirstLoad]))
            {
                departmentStatisticsIndexPresenter.InitPresent(IsPostBack);
                if (IsPostBack)
                {
                    departmentStatisticsIndexPresenter.StatisticsEmployeeSalary(null, null);
                }
            }
            else
            {
                departmentStatisticsIndexPresenter.InitPresent(false);
            }
        }

        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

        public IDepartmentStatisticsTableView IDepartmentStatisticsTableView
        {
            get { return DepartmentStatisticsTableView1; }
            set { throw new NotImplementedException(); }
        }

        public IDepartmentStatisticsBarChartView IDepartmentStatisticsBarChartView
        {
            get { return DepartmentStatisticsBarChartView1; }
            set { throw new NotImplementedException(); }
        }

        public event EventHandler StatisticsButtonEvent;
    }
}