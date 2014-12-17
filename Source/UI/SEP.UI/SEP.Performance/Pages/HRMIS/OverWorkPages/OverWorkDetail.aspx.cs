using System;
using SEP.HRMIS.Presenter.OverWorks;

namespace SEP.Performance.Pages.HRMIS.OverWorkPages
{
    public partial class OverWorkDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new DetailOverWorkPresenter(OverWorkEditView1, OverWorkFlowListView1, IsPostBack);
            OverWorkEditView1.btnSubmitClick += CompleteEvent;
            OverWorkEditView1.btnOKClick += CompleteEvent;
        }

        private void CompleteEvent(object source, EventArgs e)
        {
            Response.Redirect("../OverWorkPages/OverWorkList.aspx", false);
        }
    }
}