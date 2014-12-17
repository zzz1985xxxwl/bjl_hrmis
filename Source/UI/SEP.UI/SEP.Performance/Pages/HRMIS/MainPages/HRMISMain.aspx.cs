using System;

namespace SEP.Performance.Pages.HRMIS.MainPages
{
    public partial class HRMISMain : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session[SessionKeys.SELECTEDAUTHTREEINDEX] = null;
            Session[SessionKeys.SELECTEDNODENAME] = null;
        }
    }
}
