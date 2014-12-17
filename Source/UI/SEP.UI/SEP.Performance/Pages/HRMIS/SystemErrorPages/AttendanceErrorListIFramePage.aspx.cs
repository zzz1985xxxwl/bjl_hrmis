using System;
using System.Web.UI;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.SystemErrors;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.SystemErrors.AttendanceErrorListAjax
{
    public partial class AttendanceErrorListIFramePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Account account = Session[SessionKeys.LOGININFO] as Account;
            ddlDepartment.DataSource =
                AttendanceErrorListPresenter.GetDepartment(account);
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataBind();
            dtpScopeFrom.Text = new HrmisUtility().CurrenMonthStartTime().ToShortDateString(); //ÔÂÍ·
            dtpScopeTo.Text = new HrmisUtility().CurrenMonthEndTime().ToShortDateString(); //ÔÂÄ©
        }
    }
}