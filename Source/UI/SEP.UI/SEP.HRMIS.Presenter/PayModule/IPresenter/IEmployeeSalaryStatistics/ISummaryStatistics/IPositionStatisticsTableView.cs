using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics
{
    public interface IPositionStatisticsTableView
    {
        DataTable gvPositionStatisticsTableSource { get;set; }
    }
}
