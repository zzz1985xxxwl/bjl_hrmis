using System;
using System.Web.UI;
using SEP.HRMIS.Model;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class ChangeSalaryTime : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string result = string.Empty;

            if (Request.QueryString["salaryTime"] != null)
            {
                string salaryTime = Request.QueryString["salaryTime"];
                DateTime temp;
                if (DateTime.TryParse(salaryTime, out temp))
                {
                    DateTime _SalaryTime = new HrmisUtility().StartMonthByYearMonth(temp);
                    result = _SalaryTime.ToShortDateString() + "---" +
                             new HrmisUtility().EndMonthByYearMonth(_SalaryTime).
                                 ToShortDateString();
                }
            }
            Response.Write(result);
            Response.End();
        }
    }
}
   

