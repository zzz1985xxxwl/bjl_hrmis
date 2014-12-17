using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
    public interface IWorkTypePieChartIndexView
    {
        IStatisticsConditionView IStatisticsConditionView { get; set;}
        IWorkTypePieChartView IWorkTypePieChartView { get; set;}

    }
}
