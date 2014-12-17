using System;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics.IndexView
{
    public interface IAverageStatisticsIndexView
    {
        IStatisticsConditionView IStatisticsConditionView{ get; set;}
        IAverageStatisticsBarChartView IAverageStatisticsBarChartView { get; set;}
        IAverageStatisticsTableView IAverageStatisticsTableView{ get; set;}
        event EventHandler StatisticsButtonEvent;
    }
}
