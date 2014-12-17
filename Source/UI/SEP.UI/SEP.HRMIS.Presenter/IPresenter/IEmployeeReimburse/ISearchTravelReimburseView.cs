using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.Model.Departments;

namespace SEP.HRMIS.Presenter
{
    public interface ISearchTravelReimburseView
    {
        DataTable gvSearchReimburseTableSource { get; set;}
        List<ReimburseCategoriesEnum> ReimburseCategoriesEnumDataSrc { set;}

        string ReimburseCategoriesEnumID { set; get;}

        string Message { get; set; }
        string EmployeeName { get; }
        string Destinations { get; }
        string CustomerName { get; }
        string ProjectName { get; }
        string ApplyDateMsg { get; set; }
        string ApplyDateFrom { get; }
        string ApplyDateTo { get; }

        string MealTotal { set;}
        string CityTrafficTotalTotal { set;}
        string LongTripTotal { set;}
        string ShortTripTotal { set;}
        string LodgingTotal { set;}
        string EntertainmentTotal { set;}
        string OtherTotal { set;}
        string Total { set;}
        string OutCityAllowanceTotal { set;}
        string Remark{ get;}
        int DepartMentID { get;}
        List<Department> DepartmentSource{ set;}
        int CompanyID { get;}
        List<Department> CompanySource { set;}
        string BillingTimeFrom { get; set; }
        string BillingTimeTo { get; set; }
        string BillingTimeMsg{ set;}
        List<ReimburseTotal> ReimburseTotalListSource { get; set;}

        event EventHandler btnSearchClick;

        event CommandEventHandler btnViewClick;
    }
}
