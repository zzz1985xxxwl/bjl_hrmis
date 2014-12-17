using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.AssessActivity;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class HRManualAssess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A703))
            {
                throw new ApplicationException("没有权限访问");
            }

            HRManualAssessPresenter presenter =
                new HRManualAssessPresenter(SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.EmployeeId]),
                                            ManualAssessView1, LoginUser);
            presenter.ToGetEmployeeForApplyPage += ToHRApplyEmployeeAssessPage;
            ManualAssessView1.btnApplyClick += presenter.btnApplyClick;
            presenter.Initialize(IsPostBack);
        }
        private void ToHRApplyEmployeeAssessPage(object sender, EventArgs e)
        {
            Response.Redirect("HRApplyEmployeeAssess.aspx", false);
        }
    }
}