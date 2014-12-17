using System;
using System.Web.UI;
using SEP.HRMIS.IFacede;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.LeaveRequestPages
{
    public partial class LeaveRequestConfirmByMail : Page
    {
        private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            int accountID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["accountId"]));
            int leaveRequestID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["Id"]));
            try
            {
                lblMessage.Text = _ILeaveRequestFacade.FastApproveWholeLeaveRequest(leaveRequestID, accountID, "邮件通过");
            }
            catch
            {
                lblMessage.Text = "无法审核";
            }
        }
    }
}