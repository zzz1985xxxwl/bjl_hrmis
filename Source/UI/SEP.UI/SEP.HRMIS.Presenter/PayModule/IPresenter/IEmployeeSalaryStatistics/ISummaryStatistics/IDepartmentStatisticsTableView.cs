using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics
{
    public interface IDepartmentStatisticsTableView
    {
        DataTable gvDepartmentStatisticsTableSource { get;set; }
    }
}
