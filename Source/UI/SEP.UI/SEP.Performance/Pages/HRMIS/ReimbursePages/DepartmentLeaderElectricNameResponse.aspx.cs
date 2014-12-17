using System;
using System.Web.UI;


namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class DepartmentLeaderElectricNameResponse : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite((Byte[])Session[Request.QueryString["DepartmentLeaderElectricNameSessionName"]]);
                Response.End();
            } 
        }
    }
}
