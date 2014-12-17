using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics
{
    public interface ICommonStatisticsView
    {
        ITimeSpanStatisticsGroupByParaLineChartView ITimeSpanStatisticsGroupByParaLineChartView { get; set;}
        ITimeSpanStatisticsGroupByParaTableView ITimeSpanStatisticsGroupByParaTableView { get; set;}
        IPositionStatisticsBarChartView IPositionStatisticsBarChartView { get; set;}
        IDepartmentStatisticsBarChartView IDepartmentStatisticsBarChartView{ get; set;}
        IPositionStatisticsTableView IPositionStatisticsTableView { get; set;}
        IDepartmentStatisticsTableView IDepartmentStatisticsTableView { get; set;}
        IStatisticsConditionView IStatisticsConditionView { get; set;}
        event EventHandler StatisticsButtonEvent;

    }
}
