using System;
using SEP.HRMIS.Presenter.LeaveRequests;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.LeaveRequestPages
{
    public partial class DeleteLeaveRequest : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteLeaveRequestPresenter presenter = new DeleteLeaveRequestPresenter(LeaveRequestView1);
            presenter.LeaveRequestID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["LeaveRequestID"]));
            presenter.InitView(IsPostBack);
            presenter.GoToListPage += ToListPage;
        }
        private void ToListPage()
        {
            Response.Redirect("../LeaveRequestPages/MyLeaveRequest.aspx", false);
        }
    }
}
