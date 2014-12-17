using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.HRMIS.Presenter;

namespace SEP.Performance.Pages.HRMIS.CompanyTeleBooksPages
{
    public partial class CompanyTeleBook : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A106))
            {
                throw new ApplicationException("没有权限访问");
            }
            CompanyLinkManInfoPresenter presenter =
                new CompanyLinkManInfoPresenter(CompanyLinkManInfo1, LoginUser);
            presenter.InitView(IsPostBack);
        }
    }
}
