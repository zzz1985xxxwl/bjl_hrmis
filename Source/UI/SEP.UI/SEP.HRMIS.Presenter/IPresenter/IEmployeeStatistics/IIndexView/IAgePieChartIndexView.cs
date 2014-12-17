using System;

namespace SEP.HRMIS.Presenter
{
    public interface IAgePieChartIndexView
    {
        IAgePieChartView IAgePieChartView { get; set;}
        IStatisticsConditionView IStatisticsConditionView { get; set;}
    }
}
