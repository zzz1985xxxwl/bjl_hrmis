using System;
using SEP.HRMIS.Presenter.AssessActivity;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class SummaryAssessDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AssessBasicInfoPresenter assessBasicInfoPresenter =
                new AssessBasicInfoPresenter(SecurityUtil.DECDecrypt(Request.QueryString["assessActivityID"]),
                                             AssessBasicInfoView1, false, LoginUser);
            assessBasicInfoPresenter.Initialize(IsPostBack);

            SummarizeCommmentAssessDetailPresenter summarizeCommmentAssessDetailPresenter =
                new SummarizeCommmentAssessDetailPresenter(
                    SecurityUtil.DECDecrypt(Request.QueryString["assessActivityID"]),
                    SecurityUtil.DECDecrypt(Request.QueryString["submitID"]),
                    AssessAnswerView1, LoginUser);
            summarizeCommmentAssessDetailPresenter.InitViewDetail(IsPostBack);
        }
    }
}