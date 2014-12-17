using System;
using SEP.HRMIS.Presenter.OverWorks;

namespace SEP.Performance.Pages.HRMIS.OverWorkPages
{
    public partial class UpdateOverWork : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateOverWorkPresenter presenter =
                new UpdateOverWorkPresenter(OverWorkEditView1, IsPostBack);
            presenter._CompleteEvent += CompleteEvent;
        }

        private void CompleteEvent()
        {
            Response.Redirect("../OverWorkPages/OverWorkList.aspx", false);
        }
    }
}