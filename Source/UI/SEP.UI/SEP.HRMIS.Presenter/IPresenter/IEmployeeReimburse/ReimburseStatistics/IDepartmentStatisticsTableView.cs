using System.Data;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics
{
    public interface IDepartmentStatisticsTableView
    {
        DataTable gvDepartmentStatisticsTableSource { get;set; }
    }
}
