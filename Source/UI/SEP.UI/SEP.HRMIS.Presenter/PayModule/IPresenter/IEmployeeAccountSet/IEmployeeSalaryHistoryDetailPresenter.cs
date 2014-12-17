using System;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet
{
    public interface IEmployeeSalaryHistoryDetailPresenter
    {
        string ResultMessage { set;}
        event EventHandler GoToListPage;
        string EmployeeID { get; set;}
        Model.PayModule.AccountSet AccountSet { set;}
        Model.PayModule.EmployeeSalary EmployeeSalary { set;}
    }
}
