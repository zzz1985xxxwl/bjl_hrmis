using System;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics.IndexView
{
    public interface IDepartmentStatisticsIndexView
    {
        IStatisticsConditionView IStatisticsConditionView { get; set;}
        IDepartmentStatisticsTableView IDepartmentStatisticsTableView { get; set;}
        IDepartmentStatisticsBarChartView IDepartmentStatisticsBarChartView { get; set;}
        event EventHandler StatisticsButtonEvent;

    }
}
