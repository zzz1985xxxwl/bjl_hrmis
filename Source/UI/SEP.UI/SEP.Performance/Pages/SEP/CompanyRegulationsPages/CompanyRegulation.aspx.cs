using System;
using SEP.Model;

namespace SEP.Performance.Pages.SEP.CompanyRegulationsPages
{
    public partial class CompanyRegulation : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session[SessionKeys.SELECTEDAUTHTREEINDEX] = null;
        }

    }
}
