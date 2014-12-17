using System;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics
{
    public interface ICommonStatisticsView
    {
        ITimeSpanStatisticsGroupByDeptLineChartView ITimeSpanStatisticsGroupByDeptLineChartView { get; set;}
        ITimeSpanStatisticsGroupByDeptTableView ITimeSpanStatisticsGroupByDeptTableView { get; set;}
        IAverageStatisticsBarChartView IAverageStatisticsBarChartView { get; set;}
        IAverageStatisticsTableView IAverageStatisticsTableView { get; set;}
        IStatisticsConditionView IStatisticsConditionView { get; set;}
        event EventHandler StatisticsButtonEvent;

    }
}
