using System;
using System.Web.UI;
using SEP.HRMIS.Model;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class CheckFormula : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string formula = Request.QueryString["formula"];
            string ans=string.Empty;
            try
            {
                AssessUtility.CheckFormula(formula);
            }
            catch
            {
                ans = "error";
            }
            Response.Write(ans);
            Response.End();
        }
    }
}