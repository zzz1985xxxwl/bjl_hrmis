using System.Data;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics
{
    public interface IEmployeeStatisticsBarChartView
    {
        DataTable gvEmployeeStatisticsSource { get; set; }
    }
}
