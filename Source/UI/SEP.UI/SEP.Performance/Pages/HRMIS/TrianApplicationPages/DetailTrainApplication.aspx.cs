using System;
using SEP.HRMIS.Presenter.TrainApplication;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.TrianApplicationPages
{
    public partial class DetailTrainApplication : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TrainApplicationDetailPresenter presenter =
                new TrainApplicationDetailPresenter(TrainApplicationView1, LoginUser);
            presenter.InitView(SecurityUtil.DECDecrypt(Request.QueryString["TrainApplicationID"]), Page.IsPostBack);
            TrainApplicationFlowListPresenter TrainApplicationFlowListPresenter =
                new TrainApplicationFlowListPresenter(TrainApplicationFlowListView1,
                                                      Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["TrainApplicationID"])));
            TrainApplicationFlowListPresenter.InitView(Page.IsPostBack);

        }
    }
}