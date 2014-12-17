using System;
using System.Web.UI;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Presenter.OutApplications;

namespace SEP.Performance.Pages.HRMIS.OutApplicationPages
{
    public partial class CalculateOutApplication : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OutType outType;
            if(Request.QueryString["OutType"]=="1")
            {
                outType = OutType.OutCity;
            }
            else
            {
                outType = OutType.InCity;
            }
            string ans =
                new CalculateOutHourPresenter(Request.QueryString["FromDate"], Request.QueryString["FromHour"],
                                              Request.QueryString["FromMinute"], Request.QueryString["ToDate"],
                                              Request.QueryString["ToHour"], Request.QueryString["ToMinute"],
                                              Convert.ToInt32(Request.QueryString["AccountID"]), outType).GetHour();
            Response.Write(ans);
            Response.End();
        }
    }
}