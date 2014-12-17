using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;

namespace SEP.Performance.Views.HRMIS.Reimburse.ReimburseStatistics
{
    public partial class CommonStatisticsView : UserControl, ICommonStatisticsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IDepartmentStatisticsBarChartView IDepartmentStatisticsBarChartView
        {
            get { return DepartmentStatisticsBarChartView1; }
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