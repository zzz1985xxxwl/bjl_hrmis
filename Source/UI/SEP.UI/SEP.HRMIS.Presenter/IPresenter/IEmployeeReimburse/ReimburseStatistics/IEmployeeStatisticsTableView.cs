using System.Data;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics
{
    public interface IEmployeeStatisticsTableView
    {
        DataTable gvEmployeeStatisticsTableSource { get;set; }
    }
}
