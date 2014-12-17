using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.AssessActivity;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class HRApplyEmployeeAssess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A703))
            {
                throw new ApplicationException("没有权限访问");
            }

            HRApplyEmployeeAssessPresenter hrApplyEmployeeAssessPresenter = new HRApplyEmployeeAssessPresenter(GetEmployeeForApplyView1, LoginUser);
            hrApplyEmployeeAssessPresenter.Initialize(IsPostBack);
        }
    }
}
