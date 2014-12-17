using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;
using SEP.Model.Departments;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics
{
    public interface IStatisticsConditionView
    {
        string FromDate { get; set; }

        string ToDate { get; set; }

        string StatisticsTimeMsg { set; }

        List<AccountSetPara> SelectedAccountSetPara { get; }

        string AccountSetParaMsg { set; }

        List<Department> DepartmentList { set; }

        List<Department> CompanyList { set; }

        int DepartmentID { get; }
        int CompanyID { get; }

        List<AccountSetPara> AccountSetParaList { set; }

        event EventHandler StatisticsButtonEvent;
        event EventHandler ddlCompanySelectedIndexChanged;

        bool IsAccumulated { get;}       
        bool btnExportVisible { set;}
    }
}
