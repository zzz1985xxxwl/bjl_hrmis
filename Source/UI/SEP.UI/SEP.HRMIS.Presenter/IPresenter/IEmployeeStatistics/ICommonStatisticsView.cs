using System;

namespace SEP.HRMIS.Presenter
{
    public interface ICommonStatisticsView
    {
        IAgePieChartView IAgePieChartView{ get; set;}
        IStatisticsConditionView IStatisticsConditionView { get; set;}
        IEduBgPieChartView IEduBgPieChartView { get; set;}
        IGenderPieChartView IGenderPieChartView{ get; set;}
        IWorkAgePieChartView IWorkAgePieChartView{ get; set;}
        IWorkTypePieChartView IWorkTypePieChartView{ get; set;}
        IComeAndLeaveTableView IComeAndLeaveTableView { get; set;}
        IComeAndLeaveBarChartView IComeAndLeaveBarChartView{ get; set;}
        ILeaveRateLineChartView ILeaveRateLineChartView { get; set;}
        IOtherStatisticsDataView IOtherStatisticsDataView { get; set;}
        IPositionGradeTowerTableView IPositionGradeTowerTableView{ get; set;}
        event EventHandler StatisticsButtonEvent;
    }
}
