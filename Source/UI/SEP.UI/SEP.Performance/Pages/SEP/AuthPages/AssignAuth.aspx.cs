using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Presenter.Auths;

namespace SEP.Performance.Pages
{
    public partial class AssignAuth : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AssignAuthInfoPresenter assignAuthInfoPresenter = new AssignAuthInfoPresenter(AssignSEPAuthInfoView1, LoginUser);
            assignAuthInfoPresenter.InitView(IsPostBack);
        }
    }
}
