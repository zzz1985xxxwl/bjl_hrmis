using System;

namespace SEP.Performance.Pages.SEP.IndexPages
{
    public partial class Index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session[SessionKeys.SELECTEDAUTHTREEINDEX] = null;
            Session[SessionKeys.SELECTEDNODENAME] = null;
            ((MasterPage)this.Master).DisplayAuthTree = false;
        }
    }
}