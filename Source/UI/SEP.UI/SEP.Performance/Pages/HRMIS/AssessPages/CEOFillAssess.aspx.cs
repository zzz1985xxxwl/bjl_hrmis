using System;
using SEP.HRMIS.Presenter.AssessActivity;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class CEOFillAssess : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AssessBasicInfoPresenter assessBasicInfoPresenter =
                new AssessBasicInfoPresenter(SecurityUtil.DECDecrypt(Request.QueryString["assessActivityID"]),
                                             AssessBasicInfoView1, false, LoginUser);
            assessBasicInfoPresenter.Initialize(IsPostBack);

            CEOFillAssessPresenter ceoFillAssessPresenter =
                new CEOFillAssessPresenter(SecurityUtil.DECDecrypt(Request.QueryString["assessActivityID"]),
                                           SecurityUtil.DECDecrypt(Request.QueryString["submitID"]),
                                           AssessAnswerView1, LoginUser);
            AssessAnswerView1.btnSubmitClick += ceoFillAssessPresenter.btnSubmitClick;
            ceoFillAssessPresenter.ToGetCurrentAssessPage += ToGetCurrentAssessPage;
            ceoFillAssessPresenter.InitView(IsPostBack);
        }

        private void ToGetCurrentAssessPage(object sender, EventArgs e)
        {
            Response.Redirect("GetCurrentAssess.aspx", false);
        }
    }
}
