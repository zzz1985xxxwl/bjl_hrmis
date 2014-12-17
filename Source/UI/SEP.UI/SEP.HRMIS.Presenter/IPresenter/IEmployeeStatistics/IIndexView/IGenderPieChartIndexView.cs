using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
    public interface IGenderPieChartIndexView
    {
        IGenderPieChartView IGenderPieChartView { get; set;}
        IStatisticsConditionView IStatisticsConditionView { get; set;}
    }
}
