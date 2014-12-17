using System;
using SEP.HRMIS.Presenter.LeaveRequests;

namespace SEP.Performance.Pages.HRMIS.LeaveRequestPages
{
    public partial class AddLeaveRequest : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddLeaveRequestPresenter presenter = new AddLeaveRequestPresenter(LeaveRequestView1);
            LeaveRequestView1.EmployeeID = LoginUser.Id.ToString();
            presenter.EmployeeName = LoginUser.Name;
            presenter.InitView(IsPostBack);
            presenter.GoToListPage += ToListPage;
        }
        private void ToListPage()
        {
            Response.Redirect("../LeaveRequestPages/MyLeaveRequest.aspx", false);
        }
    }
}
