using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.AccountAuth;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;

namespace SEP.Performance.Pages.HRMIS.SystemErrorPages
{
    public partial class EmployeeContractErrorListIFramePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Account account = Session[SessionKeys.LOGININFO] as Account;
            ddlDepartment.DataSource = GetDepartment(account);
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataBind();

        }
        private static List<Department> GetDepartment(Account loginUser)
        {
            return
                Tools.RemoteUnAuthDeparetment(BllInstance.DepartmentBllInstance.GetAllDepartment(), AuthType.HRMIS,
                                              loginUser, HrmisPowers.A402);
        }

    }
}
