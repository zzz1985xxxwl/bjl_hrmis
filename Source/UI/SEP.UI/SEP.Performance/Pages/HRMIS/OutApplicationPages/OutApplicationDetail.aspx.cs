using System;
using SEP.HRMIS.Presenter.OutApplications;

namespace SEP.Performance.Pages.HRMIS.OutApplicationPages
{
    public partial class OutApplicationDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new DetailOutApplicationPresenter(OutApplicationEditView1,OutApplicationFlowListView1, IsPostBack);
            OutApplicationEditView1.btnSubmitClick += CompleteEvent;
            OutApplicationEditView1.btnOKClick += CompleteEvent;
        }
        private void CompleteEvent(object source, EventArgs e)
        {
            Response.Redirect("../OutApplicationPages/OutApplicationList.aspx", false);
        }
    }
}