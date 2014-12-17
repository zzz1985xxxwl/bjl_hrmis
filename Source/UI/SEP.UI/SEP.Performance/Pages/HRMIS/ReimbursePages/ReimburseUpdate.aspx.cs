using System;
using SEP.HRMIS.Presenter.EmployeeReimburse;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class ReimburseUpdate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateEmployeeReimbursePresenter updateEmployeeReimbursePresenter = new UpdateEmployeeReimbursePresenter(
                    Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["ReimburseID"])),
                    LoginUser, EmployeeReimburseView1);
            updateEmployeeReimbursePresenter.ToMyReimbursePage += ToMyReimbursePage;
            updateEmployeeReimbursePresenter.InitView(IsPostBack);

        }

        private void ToMyReimbursePage(object sender, EventArgs e)
        {
            Response.Redirect("MyReimburse.aspx", false);
        }
    }
}
