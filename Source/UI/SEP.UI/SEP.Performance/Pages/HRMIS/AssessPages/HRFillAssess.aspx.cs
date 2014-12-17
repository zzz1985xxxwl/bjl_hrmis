using System;
using SEP.HRMIS.Presenter.AssessActivity;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class HRFillAssess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AssessBasicInfoPresenter assessBasicInfoPresenter =
                new AssessBasicInfoPresenter(SecurityUtil.DECDecrypt(Request.QueryString["assessActivityID"]),
                                             AssessBasicInfoView1, false, LoginUser);
            assessBasicInfoPresenter.Initialize(IsPostBack);

            HRFillAssessPresenter hrFillAssessPresenter =
                new HRFillAssessPresenter(SecurityUtil.DECDecrypt(Request.QueryString["assessActivityID"]),
                                          SecurityUtil.DECDecrypt(Request.QueryString["submitID"]),
                                          AssessAnswerView1, LoginUser);
            AssessAnswerView1.btnSubmitClick += hrFillAssessPresenter.btnSubmitClick;
            hrFillAssessPresenter.ToHRFillingAssessPage += ToHRFillingAssessPage;
            hrFillAssessPresenter.InitView(IsPostBack);
        }

        private void ToHRFillingAssessPage(object sender, EventArgs e)
        {
            Response.Redirect("GetCurrentAssess.aspx", false);
        }
    }
}
