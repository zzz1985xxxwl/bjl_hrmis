using System;
using SEP.HRMIS.Presenter.OverWorks;

namespace SEP.Performance.Pages.HRMIS.OverWorkPages
{
    public partial class AddOverWork : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddOverWorkPresenter presenter =
                new AddOverWorkPresenter(OverWorkEditView1, LoginUser, IsPostBack);
            presenter._CompleteEvent += CompleteEvent;
        }

        private void CompleteEvent()
        {
            Response.Redirect("../OverWorkPages/OverWorkList.aspx", false);
        }
    }
}