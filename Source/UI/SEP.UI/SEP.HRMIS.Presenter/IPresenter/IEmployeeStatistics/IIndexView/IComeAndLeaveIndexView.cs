using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
    public interface IComeAndLeaveIndexView
    {
        IStatisticsConditionView IStatisticsConditionView { get; set;}
        IComeAndLeaveTableView IComeAndLeaveTableView { get; set;}
        IComeAndLeaveBarChartView IComeAndLeaveBarChartView { get; set;}
        ILeaveRateLineChartView ILeaveRateLineChartView { get; set;}

    }
}
