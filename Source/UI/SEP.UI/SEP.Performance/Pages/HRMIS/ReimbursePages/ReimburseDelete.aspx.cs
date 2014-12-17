using System;
using SEP.HRMIS.Presenter.EmployeeReimburse;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class ReimburseDelete : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteEmployeeReimbursePresenter deleteEmployeeReimbursePresenter = new DeleteEmployeeReimbursePresenter(
                    Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["ReimburseID"])),
                    LoginUser, EmployeeReimburseView1);
            deleteEmployeeReimbursePresenter.ToMyReimbursePage += ToMyReimbursePage;
            deleteEmployeeReimbursePresenter.InitView(IsPostBack);
        }
        private void ToMyReimbursePage(object sender, EventArgs e)
        {
            Response.Redirect("MyReimburse.aspx", false);
        }
    }
}
