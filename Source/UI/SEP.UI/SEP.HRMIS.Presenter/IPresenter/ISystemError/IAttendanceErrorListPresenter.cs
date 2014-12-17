using System.Collections.Generic;
using SEP.HRMIS.Model.SystemError;
using SEP.Model.Departments;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ISystemError
{
    public interface IAttendanceErrorListPresenter
    {
        string EmployeeName { get; set;}
        List<Department> DepartmentSource { set;}
        int DepartmentID { get;}
        string FromDate { get; set;}
        string ToDate { get; set;}
        string ScopeMsg { set;}
        List<SystemError> SystemErrors { set;}
        event DelegateNoParameter SearchEvent;
    }
}