using System;
using SEP.HRMIS.Presenter.AssessActivity;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class PersonalFillAssessDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AssessBasicInfoPresenter assessBasicInfoPresenter =
                new AssessBasicInfoPresenter(
                    SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.AssessActivityID]), AssessBasicInfoView1,
                    false, LoginUser);
            assessBasicInfoPresenter.Initialize(IsPostBack);

            PersonalFillAssessDetailPresenter personalFillAssessDetailPresenter =
                new PersonalFillAssessDetailPresenter(
                    SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.AssessActivityID]),
                    SecurityUtil.DECDecrypt(Request.QueryString["submitID"]), AssessAnswerView1,
                    LoginUser);
            personalFillAssessDetailPresenter.InitViewDetail(IsPostBack);
        }
    }
}
