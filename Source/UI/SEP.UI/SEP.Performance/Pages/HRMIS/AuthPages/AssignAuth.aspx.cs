using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.Auths;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.AuthPages
{
    public partial class AssignAuth : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A201))
            {
                throw new ApplicationException("没有权限访问");
            }

            AssignAuthInfoPresenter assignAuthInfoPresenter = new AssignAuthInfoPresenter(AssignHrmisAuthInfoView1,LoginUser);
            assignAuthInfoPresenter.InitView(IsPostBack);
        }
    }
}
