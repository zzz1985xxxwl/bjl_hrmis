using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEP.Performance.Pages.HRMIS.EmployeePages
{
    public partial class EmployeePhoto : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int accountId = Convert.ToInt32(Request.QueryString["id"]);
            Image image = new Image();
            image.Attributes["style"] = "border:1px solid gray;";
            image.ImageUrl = "GetEmployeePhoto.aspx?id=" + accountId;
            image.Width = 61;
            image.Height = 85;
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            image.RenderControl(writer);
            Response.Write(sb.ToString());
            Response.End();
        }
    }
}