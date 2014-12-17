using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.Performance.Views.EmployeeStatistics.IndexView
{
    public partial class OtherStatisticsDataIndexView : System.Web.UI.UserControl, IOtherStatisticsDataIndexView
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            OtherStatisticsDataIndexPresenter otherStatisticsDataIndexPresenter =
                new OtherStatisticsDataIndexPresenter(this, LoginUser);
            otherStatisticsDataIndexPresenter.InitPresent(false);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            OtherStatisticsDataIndexPresenter otherStatisticsDataIndexPresenter =
                new OtherStatisticsDataIndexPresenter(this, LoginUser);
            otherStatisticsDataIndexPresenter.InitPresent(IsPostBack);
            otherStatisticsDataIndexPresenter.StatisticsEmployee(null, null);
        }

        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

        public IOtherStatisticsDataView IOtherStatisticsDataView
        {
            get { return OtherStatisticsDataView1; }
            set { throw new NotImplementedException(); }
        }

    }
}