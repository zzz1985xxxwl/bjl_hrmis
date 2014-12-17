using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeWelfares
{
    public interface IEmployeeWelfareListView
    {
        List<EmployeeWelfare> EmployeeWelfareList{ get; set;}
        event DelegateNoParameter SearchEvent;
        event DelegateNoParameter SaveEvent;
        List<Position> PositionSource { set;}
        List<Department> DepartmentSource { set;}
        int PositionId { get;}
        int DepartmentId { get;}
        bool RecursionDepartment { get; }
        string EmployeeName { get;}
        EmployeeTypeEnum EmployeeType { get;set;}
        Dictionary<string, string> EmployeeTypeSource { set;}
        string Message{ set;}
        event DelegateID ImportEvent;
        string EmployeeStatusId { get;}
        List<Department> CompanySource { set;}
        int CompanyId{ get; set;}
    }
}