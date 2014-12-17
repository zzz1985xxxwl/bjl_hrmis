using System;

namespace SEP.Performance.Pages.Config
{
    public partial class ConfigEnd : System.Web.UI.Page
    {
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SetOtherCompanyInfoConfig.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx");
        }
    }
}
