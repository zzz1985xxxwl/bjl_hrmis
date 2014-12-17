using System;
using System.Web;
using SEP.Model.Utility;

namespace SEP.Performance
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            CompanyConfig.FileName = Server.MapPath("~/");//HttpContext.Current.Request.PhysicalApplicationPath;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}