using System;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics
{
    public interface IEmployeeCommonStatisticsView
    {
        IEmployeeStatisticsBarChartView IEmployeeStatisticsBarChartView { get; set;}
        IEmployeeStatisticsTableView IEmployeeStatisticsTableView { get; set;}
        IEmployeeStatisticsConditionView IEmployeeStatisticsConditionView { get; set;}
        event EventHandler StatisticsButtonEvent;

    }
}
