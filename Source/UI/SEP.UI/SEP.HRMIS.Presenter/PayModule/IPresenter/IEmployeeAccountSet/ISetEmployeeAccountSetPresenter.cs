using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet
{
    public interface ISetEmployeeAccountSetPresenter
    {
        string ResultMessage { set;}
        event EventHandler BtnOKEvent;
        event EventHandler BtnCancelEvent; 
        string EmployeeID { get; set;}
        string Description{ get; set;}
        int AccountSetID { get; set;}
        Model.PayModule.AccountSet AccountSet { get; set;}
        List<Model.PayModule.AccountSet> AccountSetSource { set;}
        Model.PayModule.EmployeeSalary EmployeeSalary { get;set;}
        bool IsPostBack { get;set;}
    }
}