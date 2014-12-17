using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet
{
    public interface IAdjustHistoryDetailPresenter
    {
        string ResultMessage{ set;}

        string AdjustHistoryID{ set;}

        string EmployeeID{ set; get;}

        EmployeeSalary EmployeeSalary{ set;}
    }
}
