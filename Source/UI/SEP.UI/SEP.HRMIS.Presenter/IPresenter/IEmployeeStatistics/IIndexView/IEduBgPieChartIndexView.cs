using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
    public interface IEduBgPieChartIndexView
    {
        IEduBgPieChartView IEduBgPieChartView { get; set;}
        IStatisticsConditionView IStatisticsConditionView { get; set;}

    }
}
