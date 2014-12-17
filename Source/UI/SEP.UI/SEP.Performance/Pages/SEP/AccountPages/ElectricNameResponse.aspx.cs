using System;

namespace SEP.Performance.Pages.SEP.AccountPages
{
    public partial class ElectricNameResponse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite((Byte[])Session[Request.QueryString["PhotoSessionName"]]);
                Response.End();
            } 
        }
    }
}
