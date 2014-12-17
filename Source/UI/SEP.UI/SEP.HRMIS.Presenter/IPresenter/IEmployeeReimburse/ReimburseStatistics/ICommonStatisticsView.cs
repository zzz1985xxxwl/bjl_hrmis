using System;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics
{
    public interface ICommonStatisticsView
    {
        IDepartmentStatisticsBarChartView IDepartmentStatisticsBarChartView{ get; set;}
        IDepartmentStatisticsTableView IDepartmentStatisticsTableView { get; set;}
        IStatisticsConditionView IStatisticsConditionView { get; set;}
        event EventHandler StatisticsButtonEvent;

    }
}
