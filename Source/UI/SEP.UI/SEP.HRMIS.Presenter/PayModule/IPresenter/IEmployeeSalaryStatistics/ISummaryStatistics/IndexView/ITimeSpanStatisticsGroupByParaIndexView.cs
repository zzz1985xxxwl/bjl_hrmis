using System;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics.IndexView
{
    public interface ITimeSpanStatisticsGroupByParaIndexView
    {
        IStatisticsConditionView IStatisticsConditionView { get; set;}
        ITimeSpanStatisticsGroupByParaLineChartView ITimeSpanStatisticsGroupByParaLineChartView { get; set;}
        ITimeSpanStatisticsGroupByParaTableView ITimeSpanStatisticsGroupByParaTableView { get; set;}
        event EventHandler StatisticsButtonEvent;

    }
}
