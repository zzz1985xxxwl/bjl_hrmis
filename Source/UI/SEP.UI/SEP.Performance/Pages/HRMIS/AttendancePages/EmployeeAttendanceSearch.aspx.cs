using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.EmployeeAttendances;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class EmployeeAttendanceSearch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //PowerUser.UserHasPower(PowerUser._AttendanceManage);

            EmployeeAttendancePresenter thePresenter = new EmployeeAttendancePresenter(AttendanceInfoView1, LoginUser);
            thePresenter.InitView(Page.IsPostBack);

        }
    }
}
