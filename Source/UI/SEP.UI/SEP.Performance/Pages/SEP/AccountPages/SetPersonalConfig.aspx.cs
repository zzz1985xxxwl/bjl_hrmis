using System;
using SEP.Presenter.Accounts;

namespace SEP.Performance.Pages.SEP.AccountPages
{
    public partial class SetPersonalConfig : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new PersonalConfigPresenter(PersonalConfigView1, LoginUser).Initialize(IsPostBack);
        }
    }
}
