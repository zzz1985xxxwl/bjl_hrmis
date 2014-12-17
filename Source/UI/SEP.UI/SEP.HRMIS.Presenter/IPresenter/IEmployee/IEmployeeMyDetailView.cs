using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.Presenter
{
    public interface IEmployeeMyDetailView
    {
        string EmployeeName { get; set;}
        string Email1 { get; set;}
        string ComeDate { get; set;}
        string BirthDay { get; set;}
        string ResidencePermit { get; set;}
        string EmployeeType { get; set;}
        string AccountName { get; set;}
        string Email2 { get; set;}
        string PositionId { get; set;}
        string DepartmentId { get; set;}
        string Responsibility { get; set;}

        ///界面绑定的显示源
        Dictionary<string, string> EmployeeTypeSource { get;set;}
        List<Position> PositionSource { get;set;}
        List<Department> DepartmentSource { get;set;}
        bool Enabled { set;}
    }
}
