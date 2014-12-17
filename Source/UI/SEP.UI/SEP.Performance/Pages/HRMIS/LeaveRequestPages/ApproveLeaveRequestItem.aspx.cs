using System;
using SEP.HRMIS.Presenter.LeaveRequests;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.LeaveRequestPages
{
    public partial class ApproveLeaveRequestItem : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApproveLeaveRequestItemPresenter presenter =
                            new ApproveLeaveRequestItemPresenter(CancelLeaveRequestItemView1, LoginUser);
            presenter.LeaveRequestID = SecurityUtil.DECDecrypt(Request.QueryString["LeaveRequestID"]);
            presenter.OperatorID = LoginUser.Id;
            presenter.Initialize(IsPostBack);
            presenter.GoToListPage += ToListPage;
        }
        private void ToListPage()
        {
            Response.Redirect("../LeaveRequestPages/MyLeaveRequest.aspx", false);
        }
    }
}
