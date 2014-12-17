using System;
using System.Collections.Generic;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet
{
    public interface ISetEmployeeSalaryConditionView
    {
        List<Department> CompanySource { set; }

        int CompanyId { get; set;}

        List<Department> DepartmentSource { set; }

        List<Position> PositionSource { set; }

        Dictionary<string, string> EmployeeTypeSource { set; }

        List<Model.PayModule.AccountSet> AccountSetSource { set; }

        string SalaryTimeDisplay { get; set; }

        //string SalaryEndTime { get; set; }

        string SalaryTime { get; set;}

        string SalaryTimeMsg { set; }

        string BackAccountName { get; }

        string Message { set; }

        event DelegateNoParameter btnGoToSetEmployeeSalaryEvent;

        event DelegateNoParameter CompanyIndexChangEvent;

        event EventHandler GoToSetEmployeeSalaryPage;
    }
}
