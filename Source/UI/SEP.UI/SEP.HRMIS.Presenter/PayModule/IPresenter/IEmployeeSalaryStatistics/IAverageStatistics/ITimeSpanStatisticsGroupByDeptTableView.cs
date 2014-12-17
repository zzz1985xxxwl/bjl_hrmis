using System.Data;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics
{
    public interface ITimeSpanStatisticsGroupByDeptTableView
    {
        DataTable gvTimeSpanStatisticsGroupByDeptSource { get; set;}
    }
}
