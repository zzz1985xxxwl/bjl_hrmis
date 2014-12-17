using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.SummaryStatistics
{
    public partial class CommonStatisticsView : UserControl, ICommonStatisticsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        public IPositionStatisticsBarChartView IPositionStatisticsBarChartView
        {
            get { return PositionStatisticsBarChartView1; }
            set { throw new NotImplementedException(); }
        }

        public IDepartmentStatisticsBarChartView IDepartmentStatisticsBarChartView
        {
            get { return DepartmentStatisticsBarChartView1; }
            set { throw new NotImplementedException(); }
        }

        public IPositionStatisticsTableView IPositionStatisticsTableView
        {
            get { return PositionStatisticsTableView1; }
            set { throw new NotImplementedException(); }
        }

        public IDepartmentStatisticsTableView IDepartmentStatisticsTableView
        {
            get { return DepartmentStatisticsTableView1; }
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