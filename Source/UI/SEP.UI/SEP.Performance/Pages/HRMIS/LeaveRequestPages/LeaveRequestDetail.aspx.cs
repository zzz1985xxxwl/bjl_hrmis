using System;
using SEP.HRMIS.Presenter.LeaveRequests;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.LeaveRequestPages
{
    public partial class LeaveRequestDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeaveRequestDetailPresenter presenter = new LeaveRequestDetailPresenter(LeaveRequestView1);
            presenter.LeaveRequestID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["LeaveRequestID"]));
            presenter.InitView(IsPostBack);
            presenter.GoToListPage += ToListPage;

            LeaveRequestItemHistoryPresenter presenter2 = new LeaveRequestItemHistoryPresenter(LeaveRequestItemHistoryView1);
            presenter2.LeaveRequestID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["LeaveRequestID"]));
            presenter2.InitView(IsPostBack);
        }

        private void ToListPage()
        {
            Response.Redirect("../LeaveRequestPages/MyLeaveRequest.aspx", false);
        }
    }
}
