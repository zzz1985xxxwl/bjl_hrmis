using System;
using SEP.HRMIS.Presenter.AssessActivity;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class ManagerFillAssess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AssessBasicInfoPresenter assessBasicInfoPresenter =
                new AssessBasicInfoPresenter(SecurityUtil.DECDecrypt(Request.QueryString["assessActivityID"]),
                                             AssessBasicInfoView1, false, LoginUser);
            assessBasicInfoPresenter.Initialize(IsPostBack);

            ManagerFillAssessPresenter managerFillAssessPresenter =
                new ManagerFillAssessPresenter(SecurityUtil.DECDecrypt(Request.QueryString["assessActivityID"]),
                                               SecurityUtil.DECDecrypt(Request.QueryString["submitID"]),
                                               AssessAnswerView1, LoginUser);
            AssessAnswerView1.btnSubmitClick += managerFillAssessPresenter.btnSubmitClick;
            AssessAnswerView1.btnSaveClick += managerFillAssessPresenter.btnSaveClick;
            managerFillAssessPresenter.ToGetCurrentAssessPage += ToGetCurrentAssessPage;
            managerFillAssessPresenter.InitView(IsPostBack);
        }

        private void ToGetCurrentAssessPage(object sender, EventArgs e)
        {
            Response.Redirect("GetCurrentAssess.aspx", false);
        }
    }
}
