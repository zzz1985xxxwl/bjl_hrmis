using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.AverageStatistics
{
    public partial class CommonStatisticsView : UserControl, ICommonStatisticsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        public IStatisticsConditionView IStatisticsConditionView
        {
            get { return StatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

        public event EventHandler StatisticsButtonEvent;
    }
}