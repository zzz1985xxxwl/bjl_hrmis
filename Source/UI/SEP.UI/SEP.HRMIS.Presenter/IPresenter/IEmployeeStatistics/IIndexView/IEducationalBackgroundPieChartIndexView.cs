using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
    public interface IEducationalBackgroundPieChartIndexView
    {
        IEducationalBackgroundPieChartView IEducationalBackgroundPieChartView { get; set;}
        IStatisticsConditionView IStatisticsConditionView { get; set;}
        event EventHandler StatisticsButtonEvent;

    }
}
