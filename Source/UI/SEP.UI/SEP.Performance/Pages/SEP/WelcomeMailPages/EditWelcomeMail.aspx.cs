using System;
using SEP.Presenter.WelcomeMails;

namespace SEP.Performance.Pages.SEP.WelcomeMailPages
{
    public partial class EditWelcomeMail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WelcomeMailPresenter presenter = new WelcomeMailPresenter(EditWelcomeMailView1, LoginUser);
            //SendLoginInfo(presenter);
            presenter.InitView(Page.IsPostBack);
        }
    }
}
