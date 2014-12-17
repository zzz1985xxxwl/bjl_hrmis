using System;
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.Presenter.IPresenter.IEmployees
{
    public interface IEmployeeDetailPresenter
    {
        int EmployeeID { get; set; }
        string Operation { get; set; }
        string LoginNameMsg { get; set; }
        string NameMsg { get; set; }
        string EmailMsg { get; set; }
        string EmailMsg2 { get; set; }
        string ResultMessage { get; set; }
        string PositionMsg { get; set; }
        string DepartmentMsg { get; set; }

        string LoginName { get; set; }
        string EmployeeName { get; set; }
        string PhoneNum { get; set; }
        string DepartmentID { get; set; }
        string PositionName { get; set; }
        int? Grades { get; set; }
        string Email { get; set; }
        string Email2 { get; set; }
        int IfValidate { get; set; }
        List<Department> DepartmentSource { set; }
        List<GradesType> GradesTypeSource { set; }
        bool IfMyCMMI { get; set; }
        bool IfCRM { get; set; }
        bool IfHRMIS { get; set; }
        bool IfEShopping { get; set; }

        event EventHandler BtnOKEvent;
        event DelegateNoParameter BtnCancelEvent;
    }
}