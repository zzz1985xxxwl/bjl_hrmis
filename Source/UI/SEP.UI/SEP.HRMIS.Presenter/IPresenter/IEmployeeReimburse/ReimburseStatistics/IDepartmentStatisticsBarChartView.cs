using System.Data;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics
{
    public interface IDepartmentStatisticsBarChartView
    {
        DataTable gvDepartmentStatisticsSource { get; set; }
    }
}
