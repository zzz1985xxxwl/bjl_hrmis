using System;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics.IndexView
{
    public interface ITimeSpanStatisticsGroupByDeptIndexView
    {
        IStatisticsConditionView IStatisticsConditionView { get; set;}
        ITimeSpanStatisticsGroupByDeptLineChartView ITimeSpanStatisticsGroupByDeptLineChartView { get; set;}
        ITimeSpanStatisticsGroupByDeptTableView ITimeSpanStatisticsGroupByDeptTableView { get; set;}
        event EventHandler StatisticsButtonEvent;

    }
}
