using System;
using System.Web.UI;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Presenter.OverWorks;
using OverWorkUtility=SEP.HRMIS.Model.OverWork.OverWorkUtility;

namespace SEP.Performance.Pages.HRMIS.OverWorkPages
{
    public partial class CalculateOverWork : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OverWorkType type;
            string ans =
                new CalculateOverWorkHourPresenter(Request.QueryString["FromDate"], Request.QueryString["FromHour"],
                                                   Request.QueryString["FromMinute"], Request.QueryString["ToDate"],
                                                   Request.QueryString["ToHour"], Request.QueryString["ToMinute"],
                                                   Convert.ToInt32(Request.QueryString["AccountID"])).GetHour(out type);
            ans = string.Format("{0}#{1}", ans, OverWorkUtility.GetOverWorkTypeName(type));
            Response.Write(ans);
            Response.End();
        }
    }
}