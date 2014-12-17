using System;
using SEP.Presenter.Accounts;

namespace SEP.Performance.Pages.SEP.AccountPages
{
    public partial class ChangePassword : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new ChangePasswordPresenter(ChangePasswordView1, LoginUser).Initialize(IsPostBack);
        }
    }
}
