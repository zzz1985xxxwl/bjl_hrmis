using System;
using System.Web.UI;
using SEP.Model.Utility;

namespace SEP.Performance.Pages
{
    public partial class Login : Page
    {
        protected string companyMailTo;

        protected void Page_Load(object sender, EventArgs e)
        {
            companyMailTo = "mailto:" + CompanyConfig.SYSTEMMAILADDRESS;
        }
    }
}
