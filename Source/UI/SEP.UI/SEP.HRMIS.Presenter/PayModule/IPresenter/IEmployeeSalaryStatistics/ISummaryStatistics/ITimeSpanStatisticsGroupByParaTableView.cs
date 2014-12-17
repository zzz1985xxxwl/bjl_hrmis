using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics
{
    public interface ITimeSpanStatisticsGroupByParaTableView
    {
        DataTable gvTimeSpanStatisticsGroupByParaSource { get; set;}
    }
}
