using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet
{
    public interface IEmployeeSalaryHistoryListPresenter
    {
        string ResultMessage{ set;}

        string EmployeeName{ set;}

        List<EmployeeSalaryHistory> EmployeeSalaryHistoryList{ set;}
    }
}
