using System;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics.IndexView
{
    public interface IPositionStatisticsIndexView
    {
        IStatisticsConditionView IStatisticsConditionView { get; set;}
        IPositionStatisticsBarChartView IPositionStatisticsBarChartView { get; set;}
        IPositionStatisticsTableView IPositionStatisticsTableView { get; set;}
        event EventHandler StatisticsButtonEvent;
    }
}
