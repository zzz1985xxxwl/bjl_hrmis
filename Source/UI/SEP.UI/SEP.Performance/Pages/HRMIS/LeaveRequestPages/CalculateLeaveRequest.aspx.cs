using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.LeaveRequests;

namespace SEP.Performance.Pages.HRMIS.LeaveRequestPages
{
    /// <summary>
    /// ajax异步计算小时数 by xwl
    /// </summary>
    public partial class CalculateLeaveRequest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                string ans =
                    new CalculateLeaveRequestPresenter(Request.QueryString["FromDate"], Request.QueryString["FromHour"],
                                                       Request.QueryString["FromMinute"], Request.QueryString["ToDate"],
                                                       Request.QueryString["ToHour"], Request.QueryString["ToMinute"],
                                                       Convert.ToInt32(Request.QueryString["AccountID"]),
                                                       Convert.ToInt32(Request.QueryString["LeaveRequestTypeID"])).GetHour();
                Response.Write(ans);
                Response.End();
        }
    }
}