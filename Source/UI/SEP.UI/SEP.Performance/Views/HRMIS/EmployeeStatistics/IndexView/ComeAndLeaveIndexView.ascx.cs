using System;
using System.Web.UI;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.Performance.Views.EmployeeStatistics.IndexView
{
    public partial class ComeAndLeaveIndexView : UserControl, IComeAndLeaveIndexView
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            ComeAndLeaveIndexPresenter comeAndLeaveIndexPresenter =
                new ComeAndLeaveIndexPresenter(this, LoginUser);
            comeAndLeaveIndexPresenter.InitPresent(false);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            ComeAndLeaveIndexPresenter comeAndLeaveIndexPresenter =
                new ComeAndLeaveIndexPresenter(this, LoginUser);
            comeAndLeaveIndexPresenter.InitPresent(IsPostBack);
            comeAndLeaveIndexPresenter.StatisticsEmployee(null, null);
        }


        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

        public IComeAndLeaveTableView IComeAndLeaveTableView
        {
            get { return ComeAndLeaveTableView1; }
            set { throw new NotImplementedException(); }
        }

        public IComeAndLeaveBarChartView IComeAndLeaveBarChartView
        {
            get { return ComeAndLeaveBarChartView1; }
            set { throw new NotImplementedException(); }
        }

        public ILeaveRateLineChartView ILeaveRateLineChartView
        {
            get { return LeaveRateLineChartView1; }
            set { throw new NotImplementedException(); }
        }
    }
}