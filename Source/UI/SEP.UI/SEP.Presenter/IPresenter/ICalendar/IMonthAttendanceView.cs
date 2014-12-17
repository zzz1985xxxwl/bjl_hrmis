using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Departments;


namespace SEP.Presenter.IPresenter.ICalendar
{
    public interface IMonthAttendanceView
    {
        List<Employee> EmployeeMonthAttendanceList { get; set;}
        string EmployeeName { get; set;}
        List<Department> DepartmentList { set;}
        int SelectedDepartment { get;}
        string FromDate { get; set;}
        string ToDate { get; set;}
        string ScopeDateFrom { set;}
        string ScopeDateTo { set;}
        string ScopeMsg { set;}
        event EventHandler StatisticsAttendance;
        string Message { set;}
        bool EmployeeNameReadOnly { set;}
        event EventHandler ddlParameterTypeSelectedIndexChanged;
        bool AdjustRestRemainedDaysVisible { set;}
        bool btnExportClientVisible { set;}
        bool IsHours { set;}
    }
}
