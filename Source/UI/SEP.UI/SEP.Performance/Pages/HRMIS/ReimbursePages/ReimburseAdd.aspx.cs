using System;
using SEP.HRMIS.Presenter.EmployeeReimburse;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class ReimburseAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddEmployeeReimbursePresenter addEmployeeReimbursePresenter = new AddEmployeeReimbursePresenter(LoginUser, EmployeeReimburseView1);
            addEmployeeReimbursePresenter.ToMyReimbursePage += ToMyReimbursePage;
            addEmployeeReimbursePresenter.InitView(IsPostBack);
        }

        private void ToMyReimbursePage(object sender, EventArgs e)
        {
            Response.Redirect("MyReimburse.aspx", false);
        }
    }
}
