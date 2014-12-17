using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
    public interface IOtherStatisticsDataIndexView
    {
        IStatisticsConditionView IStatisticsConditionView { get; set;}
        IOtherStatisticsDataView IOtherStatisticsDataView { get; set;}

    }
}
