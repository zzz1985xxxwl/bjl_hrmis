using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;

namespace SEP.Performance.Views.HRMIS.Reimburse.ReimburseStatistics
{
    public partial class EmployeeCommonStatisticsView : UserControl, IEmployeeCommonStatisticsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEmployeeStatisticsBarChartView IEmployeeStatisticsBarChartView
        {
            get { return EmployeeStatisticsBarChartView1; }
            set { throw new NotImplementedException(); }
        }

        public IEmployeeStatisticsTableView IEmployeeStatisticsTableView
        {
            get { return EmployeeStatisticsTableView1; }
            set { throw new NotImplementedException(); }
        }

        public IEmployeeStatisticsConditionView IEmployeeStatisticsConditionView
        {
            get { return EmployeeStatisticsConditionView1; }
            set { throw new NotImplementedException(); }
        }

        public event EventHandler StatisticsButtonEvent;
    }
}