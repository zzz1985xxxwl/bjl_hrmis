using System;
using SEP.HRMIS.Presenter.OutApplications;

namespace SEP.Performance.Pages.HRMIS.OutApplicationPages
{
    public partial class ConfirmOutApplicationItem : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new ConfrimOutApplicationItemPresenter(CancelOutApplicationItemView1, LoginUser, IsPostBack);
        }
    }
}