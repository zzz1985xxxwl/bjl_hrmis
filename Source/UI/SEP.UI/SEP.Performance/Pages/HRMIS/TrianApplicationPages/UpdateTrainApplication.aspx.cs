using System;
using SEP.HRMIS.Presenter.TrainApplication;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.TrianApplicationPages
{
    public partial class UpdateTrainApplication : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TrainApplicationUpdatePresenter presenter =
    new TrainApplicationUpdatePresenter(TrainApplicationView1, LoginUser);
            presenter.InitView(SecurityUtil.DECDecrypt(Request.QueryString["TrainApplicationID"]), Page.IsPostBack);

        }
    }
}
