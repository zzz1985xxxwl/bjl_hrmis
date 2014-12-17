using System;
using EmployeeSalaryStatisticsAverage = SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.AverageStatistics;
using EmployeeSalaryStatisticsSummaryStatistics = SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.SummaryStatistics;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class EmployeeSalaryStatistics : BasePage
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            EmployeeSalaryStatisticsSummaryStatistics.CommonStatisticsPresenter commonStatisticsBackPresenter1 =
                new EmployeeSalaryStatisticsSummaryStatistics.CommonStatisticsPresenter(
                    CommonEmployeeSalaryStatisticsView1.ISummaryStatistics_ICommonStatisticsView, LoginUser);
            commonStatisticsBackPresenter1.InitPresent(IsPostBack);
            EmployeeSalaryStatisticsAverage.CommonStatisticsPresenter commonStatisticsBackPresenter2 =
                new EmployeeSalaryStatisticsAverage.CommonStatisticsPresenter(
                    CommonEmployeeSalaryStatisticsView1.IAverageStatistics_ICommonStatisticsView, LoginUser);
            commonStatisticsBackPresenter2.InitPresent(IsPostBack);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}