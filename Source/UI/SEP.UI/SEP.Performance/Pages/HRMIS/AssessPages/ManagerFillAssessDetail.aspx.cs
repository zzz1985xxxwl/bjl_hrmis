using System;
using SEP.HRMIS.Presenter.AssessActivity;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class ManagerFillAssessDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AssessBasicInfoPresenter assessBasicInfoPresenter =
                new AssessBasicInfoPresenter(SecurityUtil.DECDecrypt(Request.QueryString["assessActivityID"]),
                                             AssessBasicInfoView1, false, LoginUser);
            assessBasicInfoPresenter.Initialize(IsPostBack);
            ManagerFillAssessDetailPresenter managerFillAssessDetailPresenter =
                new ManagerFillAssessDetailPresenter(SecurityUtil.DECDecrypt(Request.QueryString["assessActivityID"]),
                                                     SecurityUtil.DECDecrypt(Request.QueryString["submitID"]),
                                                     AssessAnswerView1, LoginUser);
            managerFillAssessDetailPresenter.InitViewDetail(IsPostBack);
        }
    }
}
