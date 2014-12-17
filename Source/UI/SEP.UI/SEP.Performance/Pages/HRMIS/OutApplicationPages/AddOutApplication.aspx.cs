using System;
using SEP.HRMIS.Presenter.OutApplications;

namespace SEP.Performance.Pages.HRMIS.OutApplicationPages
{
    public partial class AddOutApplication : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddOutApplicationPresenter presenter =
                new AddOutApplicationPresenter(OutApplicationEditView1, LoginUser, IsPostBack);
            presenter._CompleteEvent += CompleteEvent;
        }
        private void CompleteEvent()
        {
            Response.Redirect("../OutApplicationPages/OutApplicationList.aspx", false);
        }
    }
}