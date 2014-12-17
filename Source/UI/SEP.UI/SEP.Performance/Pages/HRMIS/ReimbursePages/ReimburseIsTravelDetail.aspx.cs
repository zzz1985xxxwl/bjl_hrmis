using System;
using SEP.HRMIS.Presenter.EmployeeReimburse;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class ReimburseIsTravelDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DetailEmployeeReimbursePresenter detailEmployeeReimbursePresenter = new DetailEmployeeReimbursePresenter(
                Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["ReimburseID"])), EmployeeReimburseView1);
            detailEmployeeReimbursePresenter.ToMyReimbursePage += ToMyReimbursePage;
            detailEmployeeReimbursePresenter.InitView(IsPostBack);

        }
        private void ToMyReimbursePage(object sender, EventArgs e)
        {
            Response.Redirect("SearchTravelReimburse.aspx", false);
        }
    }
}
