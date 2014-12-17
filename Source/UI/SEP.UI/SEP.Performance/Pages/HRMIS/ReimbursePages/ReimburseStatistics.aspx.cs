using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseStatistics;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class ReimburseStatistics : BasePage
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            CommonStatisticsBackPresenter commonStatisticsBackPresenter1 =
                new CommonStatisticsBackPresenter(
                    CommonReimburseStatisticsView1.ICommonStatisticsView, LoginUser);
            commonStatisticsBackPresenter1.InitPresent(IsPostBack);

            EmployeeCommonStatisticsBackPresenter employeeCommonStatisticsBackPresenter =
                new EmployeeCommonStatisticsBackPresenter(
                    CommonReimburseStatisticsView1.IEmployeeCommonStatisticsView, LoginUser);
            employeeCommonStatisticsBackPresenter.InitPresent(IsPostBack);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A903))
            {
                throw new ApplicationException("没有权限访问");
            }

        }
    }
}
