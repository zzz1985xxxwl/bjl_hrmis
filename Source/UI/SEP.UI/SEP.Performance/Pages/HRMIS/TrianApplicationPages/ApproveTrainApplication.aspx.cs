using System;
using SEP.HRMIS.Presenter.TrainApplication;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.TrianApplicationPages
{
    public partial class ApproveTrainApplication : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TrainApplicationApprovePresenter presenter =
                new TrainApplicationApprovePresenter(TrainApplicationView1, LoginUser);
            presenter.InitView(SecurityUtil.DECDecrypt(Request.QueryString["TrainApplicationID"]), Page.IsPostBack);
            presenter._CompleteEvent += GoToList;
        }
        private void GoToList()
        {
            Response.Redirect("MyTrainApplication.aspx");
        }
    }
}