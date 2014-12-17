using System;
using System.Collections.Generic;
using SEP.Model.Departments;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics
{
    public interface IStatisticsConditionView
    {
        string FromDate { get; set; }

        string ToDate { get; set; }

        string StatisticsTimeMsg { set; }

        List<Department> DepartmentList { set; }

        List<Department> CompanyList { set; }

        int DepartmentID { get; }
        int CompanyID { get; }

        event EventHandler StatisticsButtonEvent;
        event EventHandler ddlCompanySelectedIndexChanged;

        bool IsAccumulated { get;}
    }
}
