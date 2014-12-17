using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
    public interface IWorkAgePieChartIndexView
    {
        IStatisticsConditionView IStatisticsConditionView { get; set;}
        IWorkAgePieChartView IWorkAgePieChartView { get; set;}
    }
}
