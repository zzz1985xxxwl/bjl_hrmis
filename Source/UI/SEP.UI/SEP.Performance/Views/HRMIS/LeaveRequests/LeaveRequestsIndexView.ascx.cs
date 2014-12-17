using System;
using System.Web.UI;
using SEP.HRMIS.Presenter;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.LeaveRequests
{
    public partial class LeaveRequestsIndexView : UserControl
    {
        private Account LoginUser
        {
            get { return Session[SessionKeys.LOGININFO] as Account; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginUser.Id != Account.AdminPkid)
            {
                int count = new IndexViewSummaryPresenter().GetLeaveRequestConfirmCount(LoginUser);
                lblLeaveRequestConfirmCount.Text = count.ToString();
                if (count == 0)
                {
                    imgLeaveRequest.Src = "../../../Pages/image/menupic05gray.jpg";
                }
                else
                {
                    imgLeaveRequest.Src = "../../../Pages/image/menupic05.jpg";
                }
            }
        }
    }
}