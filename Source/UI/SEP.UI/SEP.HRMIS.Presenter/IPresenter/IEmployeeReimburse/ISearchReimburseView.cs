using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Framework.Common.DataAccess;
using SEP.HRMIS.Model;
using SEP.Model.Departments;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse
{
    public interface ISearchReimburseView
    {
        List<ReimburseCategoriesEnum> ReimburseCategoriesEnumDataSrc { set;}
        string ReimburseCategoriesEnumID { set; get;}
        string Message { get; set; }
        Dictionary<string, string> ReimburseStatus { get; set; }

        string ApplyDateMsg { get; set; }


        string ApplyDateFrom { get; set; }

        string ApplyDateTo { get;set; }

        string TotalCostFrom { get; set;}

        string TotalCostTo { get; set;}

        string TotalCostMsg { get; set; }

        List<Department> DepartmentSource { get; set; }

        List<Reimburse> ReimburseListSource { get; set;}

        string EmployeeName { get; set;}

        string DepartmentID { get; }

        string SelectedReimburseStatus { get; }
        int CompanyID { get;}
        List<Department> CompanySource { set;}
        string BillingTimeFrom { get; }
        string BillingTimeTo { get; }
        string BillingTimeMsg { set;}
        List<string> SelectedReimburses { get; }

        event CommandEventHandler btnViewClick;
        event EventHandler btnSearchClick;
        event EventHandler btnReimbursedClick;
        event EventHandler btnReturnClick;
        event EventHandler btnWaitAuditClick;

        event DelegateID BtnReimbursedEvent;

        bool SelectAllReimburses { set;}

        int SelectedFinishStatus { get; }

        PagerEntity PagerEntity { get;}

    }
}
