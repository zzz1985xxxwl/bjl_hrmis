using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet
{
    public interface ISetEmployeeAccountSetListPresenter
    {
        event DelegateNoParameter BtnSearchEvent;
        string ResultMessage { set;}
        string EmployeeName { get;}
        string EmployeeType { get; set;}
        Dictionary<string, string> EmployeeTypeSource { set;}
        int PositionId { get;}
        List<Position> PositionSource { set;}
        int DepartmentId { get;}
        List<Department> DepartmentSource { set;}
        List<EmployeeSalary> EmployeeAccountSetList { set;}
        bool RecursionDepartment{ get;}
        event DelegateID ImportEvent;
        string EmployeeStatusId { get;}
    }
}