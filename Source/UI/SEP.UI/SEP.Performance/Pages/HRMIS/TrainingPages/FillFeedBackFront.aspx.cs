using System;
using SEP.HRMIS.Presenter.Train.TrainCourse;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.TrainingPages
{
    public partial class FillFeedBackFront : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillFeedBackPresenter presenter = new FillFeedBackPresenter(FeedBackDetailView1,
            SecurityUtil.DECDecrypt(Request.QueryString["courseID"]), SecurityUtil.DECDecrypt(Request.QueryString["employeeID"]),LoginUser);
            presenter.InitView(IsPostBack);
        }
    }
}
