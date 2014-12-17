using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.Presenter.IPresenter.IEmployees
{
    public interface IEmployeeDatagridListPresenter
    {
        string ResultMessage { get; set;}

        string EmployeeName { get; set;}
        string DepartmentID { get; set;}
        string PositionID { get; set;}
        string GradesID { get; set; }
        string IfValidate { get; set;}
        List<Department> DepartmentSource { set;}
        List<Position> PositionSource { set;}
        List<Account> AccountList { set;}
        List<GradesType> GradesTypeSource { set; }
        event DelegateID BtnUpdateEvent;
        event DelegateID BtnResetPasswordEvent;
        event DelegateNoParameter BtnAddEvent;
        event DelegateNoParameter BtnSearchEvent;

        //是否包括只部门
        bool RecursionDepartment { get; }
    }
}
