using System;
using SEP.HRMIS.Presenter.OutApplications;

namespace SEP.Performance.Pages.HRMIS.OutApplicationPages
{
    public partial class UpdateOutApplication : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateOutApplicationPresenter presenter =
                new UpdateOutApplicationPresenter(OutApplicationEditView1, IsPostBack);
            presenter._CompleteEvent += CompleteEvent;
        }

        private void CompleteEvent()
        {
            Response.Redirect("../OutApplicationPages/OutApplicationList.aspx", false);
        }
    }
}