using System;
using SEP.HRMIS.Presenter.AssessActivity;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class ManagerManualAssess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ManagerManualAssessPresenter presenter =
                new ManagerManualAssessPresenter(
                    SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.EmployeeId]), ManualAssessView1,
                    LoginUser);
            ManualAssessView1.btnApplyClick += presenter.btnApplyClick;
            presenter.ToGetEmployeeForApplyPage += ToManagerApplyEmployeeAssessPage;
            presenter.Initialize(IsPostBack);

        }
        private void ToManagerApplyEmployeeAssessPage(object sender, EventArgs e)
        {
            Response.Redirect("ManagerApplyEmployeeAssess.aspx", false);
        }
    }
}
