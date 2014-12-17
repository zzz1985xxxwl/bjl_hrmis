using System;
using SEP.Model.Utility;

namespace SEP.Performance.Pages
{
    public partial class Error : System.Web.UI.Page
    {
        protected string companyMailTo;
        protected void Page_Load(object sender, EventArgs e)
        {
            companyMailTo = "mailto:" + CompanyConfig.SYSTEMMAILADDRESS;
        }
    }
}
