using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.LeaveRequests;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.LeaveRequestPages
{
    public partial class MyLeaveRequest : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyLeaveRequestInfoPresenter presenter = new MyLeaveRequestInfoPresenter(MyLeaveRequestInfoView1, LoginUser);
            presenter.Initialize(IsPostBack);
            MyLeaveRequestInfoView1.MyLeaveRequestListView.btnAddClick += ToAddPage;
            MyLeaveRequestInfoView1.MyLeaveRequestListView.btnUpdateClick += ToUpdatePage;
            MyLeaveRequestInfoView1.MyLeaveRequestListView.btnDeleteClick += ToDeletePage;
            MyLeaveRequestInfoView1.MyLeaveRequestListView.btnViewClick += ToDetailPage;
            MyLeaveRequestInfoView1.MyLeaveRequestListView.btnCancelItemClick += ToCancelItemPage;
            MyLeaveRequestInfoView1.MyLeaveRequestConfirmHistoryListView.btnViewClick += View_Command;
            MyLeaveRequestInfoView1.MyLeaveRequestConfirmListView.btnApproveClick += Approve_Command;
            MyLeaveRequestInfoView1.MyLeaveRequestConfirmListView.btnViewClick += View_Command;
        }

        #region MyLeaveRequestConfirmListView

        private void Approve_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ApproveLeaveRequestItem.aspx?LeaveRequestID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }

        #endregion

        #region MyLeaveRequestConfirmHistoryListView

        private void View_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("LeaveRequestDetail.aspx?LeaveRequestID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }

        #endregion

        #region MyLeaveRequestListView

        private void ToAddPage()
        {
            Response.Redirect("../LeaveRequestPages/AddLeaveRequest.aspx", false);
        }

        private void ToUpdatePage(string id)
        {
            Response.Redirect("../LeaveRequestPages/UpdateLeaveRequest.aspx?LeaveRequestID=" + SecurityUtil.DECEncrypt(id), false);
        }

        private void ToDeletePage(string id)
        {
            Response.Redirect("../LeaveRequestPages/DeleteLeaveRequest.aspx?LeaveRequestID=" + SecurityUtil.DECEncrypt(id), false);
        }

        private void ToDetailPage(string id)
        {
            Response.Redirect("../LeaveRequestPages/LeaveRequestDetail.aspx?LeaveRequestID=" + SecurityUtil.DECEncrypt(id), false);
        }

        private void ToCancelItemPage(string id)
        {
            Response.Redirect("../LeaveRequestPages/CancelLeaveRequest.aspx?LeaveRequestID=" + SecurityUtil.DECEncrypt(id), false);
        }

        #endregion
    }
}
