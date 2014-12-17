using System;
using SEP.HRMIS.Presenter.AssessActivity;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class CEOFillAssessBackDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AssessBasicInfoPresenter assessBasicInfoPresenter =
                new AssessBasicInfoPresenter(SecurityUtil.DECDecrypt(Request.QueryString["assessActivityID"]),
                                             AssessBasicInfoView1, true, LoginUser);
            assessBasicInfoPresenter.Initialize(IsPostBack);

            CEOFillAssessDetailPresenter ceoFillAssessDetailPresenter =
                new CEOFillAssessDetailPresenter(SecurityUtil.DECDecrypt(Request.QueryString["assessActivityID"]),
                                                 SecurityUtil.DECDecrypt(Request.QueryString["submitID"]),
                                                 AssessAnswerView1, LoginUser);
            ceoFillAssessDetailPresenter.InitViewDetail(IsPostBack);
        }
    }
}
