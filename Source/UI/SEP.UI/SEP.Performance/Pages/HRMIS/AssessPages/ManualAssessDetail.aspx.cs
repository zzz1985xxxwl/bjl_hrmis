using System;
using SEP.HRMIS.Presenter.AssessActivity;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class ManualAssessDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ManualAssessDetailPresenter presenter =
                new ManualAssessDetailPresenter(
                    SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.AssessActivityID]), ManualAssessView1,
                    LoginUser);
            presenter.Initialize(IsPostBack);

        }
    }
}
