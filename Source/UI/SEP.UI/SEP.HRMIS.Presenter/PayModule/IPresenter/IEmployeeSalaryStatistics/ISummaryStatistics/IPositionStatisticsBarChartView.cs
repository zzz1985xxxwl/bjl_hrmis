using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics
{
    public interface IPositionStatisticsBarChartView
    {
        DataTable gvPositionStatisticsSource { get; set; }
    }
}
