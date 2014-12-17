using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics
{
    public interface ITimeSpanStatisticsGroupByDeptLineChartView
    {
        DataTable gvTimeSpanStatisticsGroupByDeptSource { get; set; }
    }
}
