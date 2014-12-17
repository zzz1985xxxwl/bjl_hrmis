using System;
using SEP.HRMIS.Presenter.LeaveRequests;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.LeaveRequestPages
{
    public partial class CancelLeaveRequest : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CancelLeaveRequestItemPresenter presenter =
                new CancelLeaveRequestItemPresenter(CancelLeaveRequestItemView1, LoginUser);
            presenter.LeaveRequestID = SecurityUtil.DECDecrypt(Request.QueryString["LeaveRequestID"]);
            presenter.Initialize(IsPostBack);
            presenter.GoToListPage += ToListPage;
        }
        private void ToListPage()
        {
            Response.Redirect("../LeaveRequestPages/MyLeaveRequest.aspx", false);
        }
    }
}
